/**
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#nullable enable                 // requires C# 8.0
#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static

namespace HiveClient.Sql.ThriftApi.TCLService.TTypes
{

  public partial class TRenewDelegationTokenReq : TBase
  {
    private global::HiveClient.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? _sessionHandle;
    private string? _delegationToken;
    private global::HiveClient.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf? _sessionConf;

    public global::HiveClient.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? SessionHandle
    {
      get
      {
        return _sessionHandle;
      }
      set
      {
        __isset.sessionHandle = true;
        this._sessionHandle = value;
      }
    }

    public string? DelegationToken
    {
      get
      {
        return _delegationToken;
      }
      set
      {
        __isset.delegationToken = true;
        this._delegationToken = value;
      }
    }

    public global::HiveClient.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf? SessionConf
    {
      get
      {
        return _sessionConf;
      }
      set
      {
        __isset.sessionConf = true;
        this._sessionConf = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool sessionHandle;
      public bool delegationToken;
      public bool sessionConf;
    }

    public TRenewDelegationTokenReq()
    {
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.Struct)
              {
                SessionHandle = new global::HiveClient.Sql.ThriftApi.TCLService.TTypes.TSessionHandle();
                await SessionHandle.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                DelegationToken = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.Struct)
              {
                SessionConf = new global::HiveClient.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf();
                await SessionConf.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp465 = new TStruct("TRenewDelegationTokenReq");
        await oprot.WriteStructBeginAsync(tmp465, cancellationToken);
        var tmp466 = new TField();
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          tmp466.Name = "sessionHandle";
          tmp466.Type = TType.Struct;
          tmp466.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp466, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((DelegationToken != null) && __isset.delegationToken)
        {
          tmp466.Name = "delegationToken";
          tmp466.Type = TType.String;
          tmp466.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp466, cancellationToken);
          await oprot.WriteStringAsync(DelegationToken, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SessionConf != null) && __isset.sessionConf)
        {
          tmp466.Name = "sessionConf";
          tmp466.Type = TType.Struct;
          tmp466.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp466, cancellationToken);
          await SessionConf.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object? that)
    {
      if (that is not TRenewDelegationTokenReq other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.sessionHandle == other.__isset.sessionHandle) && ((!__isset.sessionHandle) || (global::System.Object.Equals(SessionHandle, other.SessionHandle))))
        && ((__isset.delegationToken == other.__isset.delegationToken) && ((!__isset.delegationToken) || (global::System.Object.Equals(DelegationToken, other.DelegationToken))))
        && ((__isset.sessionConf == other.__isset.sessionConf) && ((!__isset.sessionConf) || (global::System.Object.Equals(SessionConf, other.SessionConf))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        if((DelegationToken != null) && __isset.delegationToken)
        {
          hashcode = (hashcode * 397) + DelegationToken.GetHashCode();
        }
        if((SessionConf != null) && __isset.sessionConf)
        {
          hashcode = (hashcode * 397) + SessionConf.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp467 = new StringBuilder("TRenewDelegationTokenReq(");
      int tmp468 = 0;
      if((SessionHandle != null) && __isset.sessionHandle)
      {
        if(0 < tmp468++) { tmp467.Append(", "); }
        tmp467.Append("SessionHandle: ");
        SessionHandle.ToString(tmp467);
      }
      if((DelegationToken != null) && __isset.delegationToken)
      {
        if(0 < tmp468++) { tmp467.Append(", "); }
        tmp467.Append("DelegationToken: ");
        DelegationToken.ToString(tmp467);
      }
      if((SessionConf != null) && __isset.sessionConf)
      {
        if(0 < tmp468++) { tmp467.Append(", "); }
        tmp467.Append("SessionConf: ");
        SessionConf.ToString(tmp467);
      }
      tmp467.Append(')');
      return tmp467.ToString();
    }
  }

}