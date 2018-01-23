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


#if !SILVERLIGHT
[Serializable]
#endif
public partial class Conversation : TBase
{
  private int _ConversationId;
  private int _ParentId;
  private FlowKey _ConversationKey;
  private FlowAttributes _Upflow;
  private FlowAttributes _Downflow;
  private List<long> _UpflowPackets;
  private List<long> _DownflowPackets;

  public int ConversationId
  {
    get
    {
      return _ConversationId;
    }
    set
    {
      __isset.ConversationId = true;
      this._ConversationId = value;
    }
  }

  public int ParentId
  {
    get
    {
      return _ParentId;
    }
    set
    {
      __isset.ParentId = true;
      this._ParentId = value;
    }
  }

  public FlowKey ConversationKey
  {
    get
    {
      return _ConversationKey;
    }
    set
    {
      __isset.ConversationKey = true;
      this._ConversationKey = value;
    }
  }

  public FlowAttributes Upflow
  {
    get
    {
      return _Upflow;
    }
    set
    {
      __isset.Upflow = true;
      this._Upflow = value;
    }
  }

  public FlowAttributes Downflow
  {
    get
    {
      return _Downflow;
    }
    set
    {
      __isset.Downflow = true;
      this._Downflow = value;
    }
  }

  public List<long> UpflowPackets
  {
    get
    {
      return _UpflowPackets;
    }
    set
    {
      __isset.UpflowPackets = true;
      this._UpflowPackets = value;
    }
  }

  public List<long> DownflowPackets
  {
    get
    {
      return _DownflowPackets;
    }
    set
    {
      __isset.DownflowPackets = true;
      this._DownflowPackets = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool ConversationId;
    public bool ParentId;
    public bool ConversationKey;
    public bool Upflow;
    public bool Downflow;
    public bool UpflowPackets;
    public bool DownflowPackets;
  }

  public Conversation() {
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
              ConversationId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              ParentId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              ConversationKey = new FlowKey();
              ConversationKey.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              Upflow = new FlowAttributes();
              Upflow.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Struct) {
              Downflow = new FlowAttributes();
              Downflow.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.List) {
              {
                UpflowPackets = new List<long>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  long _elem2;
                  _elem2 = iprot.ReadI64();
                  UpflowPackets.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.List) {
              {
                DownflowPackets = new List<long>();
                TList _list3 = iprot.ReadListBegin();
                for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                {
                  long _elem5;
                  _elem5 = iprot.ReadI64();
                  DownflowPackets.Add(_elem5);
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
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public void Write(TProtocol oprot) {
    oprot.IncrementRecursionDepth();
    try
    {
      TStruct struc = new TStruct("Conversation");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.ConversationId) {
        field.Name = "ConversationId";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ConversationId);
        oprot.WriteFieldEnd();
      }
      if (__isset.ParentId) {
        field.Name = "ParentId";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ParentId);
        oprot.WriteFieldEnd();
      }
      if (ConversationKey != null && __isset.ConversationKey) {
        field.Name = "ConversationKey";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        ConversationKey.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Upflow != null && __isset.Upflow) {
        field.Name = "Upflow";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        Upflow.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Downflow != null && __isset.Downflow) {
        field.Name = "Downflow";
        field.Type = TType.Struct;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        Downflow.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (UpflowPackets != null && __isset.UpflowPackets) {
        field.Name = "UpflowPackets";
        field.Type = TType.List;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I64, UpflowPackets.Count));
          foreach (long _iter6 in UpflowPackets)
          {
            oprot.WriteI64(_iter6);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (DownflowPackets != null && __isset.DownflowPackets) {
        field.Name = "DownflowPackets";
        field.Type = TType.List;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I64, DownflowPackets.Count));
          foreach (long _iter7 in DownflowPackets)
          {
            oprot.WriteI64(_iter7);
          }
          oprot.WriteListEnd();
        }
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
    StringBuilder __sb = new StringBuilder("Conversation(");
    bool __first = true;
    if (__isset.ConversationId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ConversationId: ");
      __sb.Append(ConversationId);
    }
    if (__isset.ParentId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ParentId: ");
      __sb.Append(ParentId);
    }
    if (ConversationKey != null && __isset.ConversationKey) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ConversationKey: ");
      __sb.Append(ConversationKey== null ? "<null>" : ConversationKey.ToString());
    }
    if (Upflow != null && __isset.Upflow) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Upflow: ");
      __sb.Append(Upflow== null ? "<null>" : Upflow.ToString());
    }
    if (Downflow != null && __isset.Downflow) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Downflow: ");
      __sb.Append(Downflow== null ? "<null>" : Downflow.ToString());
    }
    if (UpflowPackets != null && __isset.UpflowPackets) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("UpflowPackets: ");
      __sb.Append(UpflowPackets);
    }
    if (DownflowPackets != null && __isset.DownflowPackets) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("DownflowPackets: ");
      __sb.Append(DownflowPackets);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

