﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Idaas;
using Thrift.Protocol;
using Thrift.Transport;
using System.Linq;

namespace Ida.Client
{
    public class Database : IDisposable
    {
        private static string _idaExecutablePath;
        private Idaas.Database.Client _client;
        private TTransport _transport;

        public static string IdaHome
        {
            set { _idaExecutablePath = Path.Combine(value, "idag.exe"); }
        }

        public static Database Open(String path)
        {
            string infFilePath = string.Format("{0}.idaas", path);
	        if (!File.Exists(infFilePath))
	        {
	            if (_idaExecutablePath != null)
	            {
	                Process.Start(_idaExecutablePath, path);
	                DateTime start = DateTime.Now;	                
	                while (!File.Exists(infFilePath) && (DateTime.Now - start).Seconds < 10)
	                {
	                    Thread.Sleep(100);
	                }
	            }
                if (!File.Exists(infFilePath))
                {
                    return null;
                }
	        }
            var lines = File.ReadLines(infFilePath).ToArray();
            var port = int.Parse(lines[0]);
            var pid = int.Parse(lines[1]);
            try
            {
                Process.GetProcessById(pid);
            }
            catch (ArgumentException)
            {
                File.Delete(infFilePath);
                return Open(path);
            }
            var database = new Database();
            if (!database.Connect(new IPEndPoint(IPAddress.Loopback, port)))
            {
                return null;
            }
            return database;
        }

        protected bool Connect(IPEndPoint endPoint)
        {
            _transport = new TSocket(endPoint.Address.ToString(), endPoint.Port);
            var proto = new TBinaryProtocol(_transport);
            _client = new Idaas.Database.Client(proto);
            Enumerations = new Enumerations(_client);
            Structures = new Structures(_client);
            Strings = new Strings(_client);
            Functions = new Functions(_client);
            Instructions = new Instructions(_client);
            Names = new Names(_client);
            TypeLibraries = new TypeLibraries(_client);

            _transport.Open();
            return true;
        }

        public void Wait()
        {
            _client.waitBackgroundTasks();
        }

        public Enumerations Enumerations { get; private set; }

        public Structures Structures { get; private set; }

        public Strings Strings { get; private set; }

        public Functions Functions { get; private set; }

        public Instructions Instructions { get; private set; }

        public Names Names { get; private set; }

        public TypeLibraries TypeLibraries { get; private set; }

        public TypeLibrary MainTypeLibrary { get { return TypeLibraries["_main"]; } }

        public List<IdaRef> GetDataRefsTo(int address)
        {
            return _client.xrefsTo(address, IdaRefType.Data);
        }

        public List<IdaRef> GetDataRefsFrom(int address)
        {
            return _client.xrefsFrom(address, IdaRefType.Data);
        }

        public IdaTypeInfo ParseTypeDeclaration(string typeDeclaration)
        {
            return _client.parseTypeDeclaration(typeDeclaration);
        }

        public string FormatTypeInfo(IdaTypeInfo typeInfo)
        {
            return _client.formatTypeInfo(typeInfo);
        }

        public void Dispose()
        {
            _transport.Close();
        }
    }
}
