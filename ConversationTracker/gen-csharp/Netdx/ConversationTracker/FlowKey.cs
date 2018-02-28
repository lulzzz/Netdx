/**
 * Autogenerated by Thrift Compiler (0.11.0)
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
  public partial class FlowKey : TBase
  {
    private int _Protocol;
    private byte[] _SourcePoint;
    private byte[] _DestinationPoint;

    public int Protocol
    {
      get
      {
        return _Protocol;
      }
      set
      {
        __isset.Protocol = true;
        this._Protocol = value;
      }
    }

    public byte[] SourcePoint
    {
      get
      {
        return _SourcePoint;
      }
      set
      {
        __isset.SourcePoint = true;
        this._SourcePoint = value;
      }
    }

    public byte[] DestinationPoint
    {
      get
      {
        return _DestinationPoint;
      }
      set
      {
        __isset.DestinationPoint = true;
        this._DestinationPoint = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Protocol;
      public bool SourcePoint;
      public bool DestinationPoint;
    }

    public FlowKey() {
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
              if (field.Type == TType.I32) {
                Protocol = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                SourcePoint = iprot.ReadBinary();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                DestinationPoint = iprot.ReadBinary();
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
        TStruct struc = new TStruct("FlowKey");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.Protocol) {
          field.Name = "Protocol";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Protocol);
          oprot.WriteFieldEnd();
        }
        if (SourcePoint != null && __isset.SourcePoint) {
          field.Name = "SourcePoint";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteBinary(SourcePoint);
          oprot.WriteFieldEnd();
        }
        if (DestinationPoint != null && __isset.DestinationPoint) {
          field.Name = "DestinationPoint";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteBinary(DestinationPoint);
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
      StringBuilder __sb = new StringBuilder("FlowKey(");
      bool __first = true;
      if (__isset.Protocol) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Protocol: ");
        __sb.Append(Protocol);
      }
      if (SourcePoint != null && __isset.SourcePoint) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SourcePoint: ");
        __sb.Append(SourcePoint);
      }
      if (DestinationPoint != null && __isset.DestinationPoint) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DestinationPoint: ");
        __sb.Append(DestinationPoint);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
