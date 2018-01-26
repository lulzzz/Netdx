/**
 * Autogenerated by Thrift Compiler (0.9.3)
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

namespace Netdx.ConversationTracker
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class FlowRecord : TBase
  {
    private long _FirstSeen;
    private long _LastSeen;
    private long _Octets;
    private int _Packets;

    public long FirstSeen
    {
      get
      {
        return _FirstSeen;
      }
      set
      {
        __isset.FirstSeen = true;
        this._FirstSeen = value;
      }
    }

    public long LastSeen
    {
      get
      {
        return _LastSeen;
      }
      set
      {
        __isset.LastSeen = true;
        this._LastSeen = value;
      }
    }

    public long Octets
    {
      get
      {
        return _Octets;
      }
      set
      {
        __isset.Octets = true;
        this._Octets = value;
      }
    }

    public int Packets
    {
      get
      {
        return _Packets;
      }
      set
      {
        __isset.Packets = true;
        this._Packets = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool FirstSeen;
      public bool LastSeen;
      public bool Octets;
      public bool Packets;
    }

    public FlowRecord() {
      this._FirstSeen = 1;
      this.__isset.FirstSeen = true;
      this._LastSeen = 2;
      this.__isset.LastSeen = true;
      this._Octets = 3;
      this.__isset.Octets = true;
      this._Packets = 4;
      this.__isset.Packets = true;
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
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
              if (field.Type == TType.I64) {
                FirstSeen = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I64) {
                LastSeen = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I64) {
                Octets = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.I32) {
                Packets = iprot.ReadI32();
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
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("FlowRecord");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.FirstSeen) {
          field.Name = "FirstSeen";
          field.Type = TType.I64;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(FirstSeen);
          oprot.WriteFieldEnd();
        }
        if (__isset.LastSeen) {
          field.Name = "LastSeen";
          field.Type = TType.I64;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(LastSeen);
          oprot.WriteFieldEnd();
        }
        if (__isset.Octets) {
          field.Name = "Octets";
          field.Type = TType.I64;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Octets);
          oprot.WriteFieldEnd();
        }
        if (__isset.Packets) {
          field.Name = "Packets";
          field.Type = TType.I32;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Packets);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("FlowRecord(");
      bool __first = true;
      if (__isset.FirstSeen) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FirstSeen: ");
        __sb.Append(FirstSeen);
      }
      if (__isset.LastSeen) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LastSeen: ");
        __sb.Append(LastSeen);
      }
      if (__isset.Octets) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Octets: ");
        __sb.Append(Octets);
      }
      if (__isset.Packets) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Packets: ");
        __sb.Append(Packets);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}