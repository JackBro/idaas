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
  public partial class Database {
    public interface Iface {
      List<ida_enum> listEnums();
      #if SILVERLIGHT
      IAsyncResult Begin_listEnums(AsyncCallback callback, object state, );
      List<ida_enum> End_listEnums(IAsyncResult asyncResult);
      #endif
      void storeEnum(ida_enum _enum);
      #if SILVERLIGHT
      IAsyncResult Begin_storeEnum(AsyncCallback callback, object state, ida_enum _enum);
      void End_storeEnum(IAsyncResult asyncResult);
      #endif
      void deleteEnum(int id);
      #if SILVERLIGHT
      IAsyncResult Begin_deleteEnum(AsyncCallback callback, object state, int id);
      void End_deleteEnum(IAsyncResult asyncResult);
      #endif
    }

    public class Client : Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      
      #if SILVERLIGHT
      public IAsyncResult Begin_listEnums(AsyncCallback callback, object state, )
      {
        return send_listEnums(callback, state);
      }

      public List<ida_enum> End_listEnums(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_listEnums();
      }

      #endif

      public List<ida_enum> listEnums()
      {
        #if !SILVERLIGHT
        send_listEnums();
        return recv_listEnums();

        #else
        var asyncResult = Begin_listEnums(null, null, );
        return End_listEnums(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_listEnums(AsyncCallback callback, object state, )
      #else
      public void send_listEnums()
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("listEnums", TMessageType.Call, seqid_));
        listEnums_args args = new listEnums_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public List<ida_enum> recv_listEnums()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        listEnums_result result = new listEnums_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "listEnums failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_storeEnum(AsyncCallback callback, object state, ida_enum _enum)
      {
        return send_storeEnum(callback, state, _enum);
      }

      public void End_storeEnum(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_storeEnum();
      }

      #endif

      public void storeEnum(ida_enum _enum)
      {
        #if !SILVERLIGHT
        send_storeEnum(_enum);
        recv_storeEnum();

        #else
        var asyncResult = Begin_storeEnum(null, null, _enum);
        End_storeEnum(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_storeEnum(AsyncCallback callback, object state, ida_enum _enum)
      #else
      public void send_storeEnum(ida_enum _enum)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("storeEnum", TMessageType.Call, seqid_));
        storeEnum_args args = new storeEnum_args();
        args._enum = _enum;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public void recv_storeEnum()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        storeEnum_result result = new storeEnum_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_deleteEnum(AsyncCallback callback, object state, int id)
      {
        return send_deleteEnum(callback, state, id);
      }

      public void End_deleteEnum(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_deleteEnum();
      }

      #endif

      public void deleteEnum(int id)
      {
        #if !SILVERLIGHT
        send_deleteEnum(id);
        recv_deleteEnum();

        #else
        var asyncResult = Begin_deleteEnum(null, null, id);
        End_deleteEnum(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_deleteEnum(AsyncCallback callback, object state, int id)
      #else
      public void send_deleteEnum(int id)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("deleteEnum", TMessageType.Call, seqid_));
        deleteEnum_args args = new deleteEnum_args();
        args.Id = id;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public void recv_deleteEnum()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        deleteEnum_result result = new deleteEnum_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

    }
    public class Processor : TProcessor {
      public Processor(Iface iface)
      {
        iface_ = iface;
        processMap_["listEnums"] = listEnums_Process;
        processMap_["storeEnum"] = storeEnum_Process;
        processMap_["deleteEnum"] = deleteEnum_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private Iface iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void listEnums_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        listEnums_args args = new listEnums_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        listEnums_result result = new listEnums_result();
        result.Success = iface_.listEnums();
        oprot.WriteMessageBegin(new TMessage("listEnums", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void storeEnum_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        storeEnum_args args = new storeEnum_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        storeEnum_result result = new storeEnum_result();
        iface_.storeEnum(args._enum);
        oprot.WriteMessageBegin(new TMessage("storeEnum", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void deleteEnum_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        deleteEnum_args args = new deleteEnum_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        deleteEnum_result result = new deleteEnum_result();
        iface_.deleteEnum(args.Id);
        oprot.WriteMessageBegin(new TMessage("deleteEnum", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class listEnums_args : TBase
    {

      public listEnums_args() {
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
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("listEnums_args");
        oprot.WriteStructBegin(struc);
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("listEnums_args(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class listEnums_result : TBase
    {
      private List<ida_enum> _success;

      public List<ida_enum> Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public listEnums_result() {
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
            case 0:
              if (field.Type == TType.List) {
                {
                  Success = new List<ida_enum>();
                  TList _list4 = iprot.ReadListBegin();
                  for( int _i5 = 0; _i5 < _list4.Count; ++_i5)
                  {
                    ida_enum _elem6 = new ida_enum();
                    _elem6 = new ida_enum();
                    _elem6.Read(iprot);
                    Success.Add(_elem6);
                  }
                  iprot.ReadListEnd();
                }
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
        TStruct struc = new TStruct("listEnums_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.List;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteListBegin(new TList(TType.Struct, Success.Count));
              foreach (ida_enum _iter7 in Success)
              {
                _iter7.Write(oprot);
              }
              oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("listEnums_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class storeEnum_args : TBase
    {
      private ida_enum __enum;

      public ida_enum _enum
      {
        get
        {
          return __enum;
        }
        set
        {
          __isset._enum = true;
          this.__enum = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool _enum;
      }

      public storeEnum_args() {
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
              if (field.Type == TType.Struct) {
                _enum = new ida_enum();
                _enum.Read(iprot);
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
        TStruct struc = new TStruct("storeEnum_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (_enum != null && __isset._enum) {
          field.Name = "_enum";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          _enum.Write(oprot);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("storeEnum_args(");
        sb.Append("_enum: ");
        sb.Append(_enum== null ? "<null>" : _enum.ToString());
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class storeEnum_result : TBase
    {

      public storeEnum_result() {
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
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("storeEnum_result");
        oprot.WriteStructBegin(struc);

        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("storeEnum_result(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class deleteEnum_args : TBase
    {
      private int _id;

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


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool id;
      }

      public deleteEnum_args() {
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
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("deleteEnum_args");
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
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("deleteEnum_args(");
        sb.Append("Id: ");
        sb.Append(Id);
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class deleteEnum_result : TBase
    {

      public deleteEnum_result() {
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
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("deleteEnum_result");
        oprot.WriteStructBegin(struc);

        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("deleteEnum_result(");
        sb.Append(")");
        return sb.ToString();
      }

    }

  }
}
