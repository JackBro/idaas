/**
 * Autogenerated by Thrift Compiler (0.9.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Idaas
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ida_enum_const : TBase
  {
    private int _id;
    private string _name;
    private int _value;
    private byte _serial;
    private int _mask;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        __isset.name = true;
        this._name = value;
      }
    }

    public int Value
    {
      get
      {
        return _value;
      }
      set
      {
        __isset.value = true;
        this._value = value;
      }
    }

    public byte Serial
    {
      get
      {
        return _serial;
      }
      set
      {
        __isset.serial = true;
        this._serial = value;
      }
    }

    public int Mask
    {
      get
      {
        return _mask;
      }
      set
      {
        __isset.mask = true;
        this._mask = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool name;
      public bool value;
      public bool serial;
      public bool mask;
    }

    public ida_enum_const() {
      this._id = -1;
      this._mask = -1;
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Name = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I32) {
              Value = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Byte) {
              Serial = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.I32) {
              Mask = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("ida_enum_const");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (Name != null && __isset.name) {
        field.Name = "name";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Name);
        oprot.WriteFieldEnd();
      }
      if (__isset.value) {
        field.Name = "value";
        field.Type = TType.I32;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Value);
        oprot.WriteFieldEnd();
      }
      if (__isset.serial) {
        field.Name = "serial";
        field.Type = TType.Byte;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Serial);
        oprot.WriteFieldEnd();
      }
      if (__isset.mask) {
        field.Name = "mask";
        field.Type = TType.I32;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Mask);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ida_enum_const(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",Name: ");
      sb.Append(Name);
      sb.Append(",Value: ");
      sb.Append(Value);
      sb.Append(",Serial: ");
      sb.Append(Serial);
      sb.Append(",Mask: ");
      sb.Append(Mask);
      sb.Append(")");
      return sb.ToString();
    }

  }

}