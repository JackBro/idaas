﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using Idaas;

namespace Ida.Client
{
    public enum ItemState
    {
        New,
        Updated
    };

    public static class IdaEnumExtensions
    {
        public static void AddConstant(this ida_enum @enum, string name, int value, int? mask = null)
        {
            var @const = new ida_enum_const {Name = name, Value = value};
            if (mask != null)
            {
                @const.Mask = mask.Value;
            } else if (@enum.IsBitfield)
            {
                @const.Mask = value;
            }
            @enum.Constants.Add(@const);
        }

        public static ida_enum_const Get(this ida_enum @enum, string constantName)
        {
            return @enum.Constants.First(c => c.Name == constantName);
        }
    }

    public static class EnumerationsDatabaseExtensions
    {
        public static bool Store(this Database database, ida_enum @enum)
        {
            return database.Enumerations.Store(@enum);
        }

        public static ida_enum NewEnumeration(this Database database, string name, bool isBitfield = false,
                                              IEnumerable<KeyValuePair<string, int>> constants = null)
        {
            return database.Enumerations.New(name, isBitfield, constants);
        }
    }

    public class Enumerations : IEnumerable<ida_enum>, IExportable
    {
        private readonly Idaas.Database.Client _client;
        private List<ida_enum> _items;

        internal Enumerations(Idaas.Database.Client client)
        {
            _client = client;
        }

        private List<ida_enum> Items
        {
            get { return _items ?? (_items = Load()); }
        }

        public IEnumerator<ida_enum> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<ida_enum> Load()
        {
            return _client.listEnums();
        }

        public ida_enum New(string name, bool isBitfield = false,
                            IEnumerable<KeyValuePair<string, int>> constants = null)
        {
            ida_enum @enum = this.FirstOrDefault(e => e.Name == name);
            if (@enum == null)
            {
                @enum = new ida_enum {Name = name};
                Items.Add(@enum);
            }
            @enum.Constants = new List<ida_enum_const>();
            @enum.IsBitfield = isBitfield;
            if (constants != null)
            {
                foreach (var pair in constants)
                {
                    @enum.Constants.Add(new ida_enum_const {Name = pair.Key, Value = pair.Value});
                }
            }
            return @enum;
        }

        public bool Store(ida_enum @enum)
        {
            return _client.storeEnum(@enum);
        }

        public void Delete(ida_enum @enum)
        {
            if (_items != null)
            {
                _items.Remove(@enum);
            }
            _client.deleteEnum(@enum.Name);
        }

        public bool Store(IEnumerable<ida_enum> enums)
        {
            return _client.storeEnums(enums.ToList());
        }

        public bool StoreAll()
        {
            return _client.storeEnums(Items);
        }        

        public ida_enum this[string name]
        {
            get { return this.First(e => e.Name == name); }
        }

        public bool Has(string name)
        {
            return this.Any(e => e.Name == name);
        }

        public void SaveTo(Stream output)
        {
            XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings
            {
                Indent = true
            });
            writer.WriteStartElement("Enumerations");
            foreach (ida_enum item in Items)
            {
                writer.WriteStartElement("Enumeration");
                writer.WriteAttributeString("Name", item.Name);
                writer.WriteAttributeString("IsBitfield", item.IsBitfield.ToString());
                foreach (var constant in item.Constants)
                {
                    writer.WriteStartElement("Constant");
                    writer.WriteAttributeString("Name", constant.Name);
                    writer.WriteAttributeString("Value", constant.Value.ToString(NumberFormatInfo.CurrentInfo));
                    writer.WriteAttributeString("Mask", constant.Mask.ToString(NumberFormatInfo.CurrentInfo));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }

        public void LoadFrom(Stream input)
        {
            XmlReader reader = XmlReader.Create(input);
            reader.ReadToFollowing("Enumerations");
            var loadedEnumerations = new List<ida_enum>();
            for (bool hasEnum = reader.ReadToDescendant("Enumeration");
                 hasEnum;
                 hasEnum = reader.ReadToNextSibling("Enumeration"))
            {
                var isBitfield = bool.TrueString.Equals(reader.GetAttribute("IsBitfield"), StringComparison.CurrentCultureIgnoreCase);
                var @enum = New(reader.GetAttribute("Name"), isBitfield);
                for (bool hasConstant = reader.ReadToDescendant("Constant");
                     hasConstant;
                     hasConstant = reader.ReadToNextSibling("Constant"))
                {
                    var value = reader.GetAttribute("Value");
                    if (value == null)
                    {
                        throw new NullReferenceException("Value is not provided");
                    }
                    var mask = reader.GetAttribute("Mask");                    
                    if (mask == null)
                    {
                        throw new NullReferenceException("Mask is not provided");
                    }
                    @enum.Constants.Add(new ida_enum_const
                    {
                        Name = reader.GetAttribute("Name"),
                        Value = int.Parse(value),
                        Mask = int.Parse(mask)
                    });
                }
                loadedEnumerations.Add(@enum);
            }
            reader.Close();
            Store(loadedEnumerations);
        }
    };
}