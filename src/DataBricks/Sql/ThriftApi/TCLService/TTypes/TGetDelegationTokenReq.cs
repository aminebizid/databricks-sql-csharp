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

namespace DataBricks.Sql.ThriftApi.TCLService.TTypes
{

  public partial class TGetDelegationTokenReq : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? _sessionHandle;
    private string? _owner;
    private string? _renewer;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf? _sessionConf;

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? SessionHandle
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

    public string? Owner
    {
      get
      {
        return _owner;
      }
      set
      {
        __isset.owner = true;
        this._owner = value;
      }
    }

    public string? Renewer
    {
      get
      {
        return _renewer;
      }
      set
      {
        __isset.renewer = true;
        this._renewer = value;
      }
    }

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf? SessionConf
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
      public bool owner;
      public bool renewer;
      public bool sessionConf;
    }

    public TGetDelegationTokenReq()
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
                SessionHandle = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle();
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
                Owner = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                Renewer = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.Struct)
              {
                SessionConf = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf();
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
        var tmp449 = new TStruct("TGetDelegationTokenReq");
        await oprot.WriteStructBeginAsync(tmp449, cancellationToken);
        var tmp450 = new TField();
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          tmp450.Name = "sessionHandle";
          tmp450.Type = TType.Struct;
          tmp450.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp450, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Owner != null) && __isset.owner)
        {
          tmp450.Name = "owner";
          tmp450.Type = TType.String;
          tmp450.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp450, cancellationToken);
          await oprot.WriteStringAsync(Owner, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Renewer != null) && __isset.renewer)
        {
          tmp450.Name = "renewer";
          tmp450.Type = TType.String;
          tmp450.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp450, cancellationToken);
          await oprot.WriteStringAsync(Renewer, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SessionConf != null) && __isset.sessionConf)
        {
          tmp450.Name = "sessionConf";
          tmp450.Type = TType.Struct;
          tmp450.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp450, cancellationToken);
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
      if (that is not TGetDelegationTokenReq other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.sessionHandle == other.__isset.sessionHandle) && ((!__isset.sessionHandle) || (global::System.Object.Equals(SessionHandle, other.SessionHandle))))
        && ((__isset.owner == other.__isset.owner) && ((!__isset.owner) || (global::System.Object.Equals(Owner, other.Owner))))
        && ((__isset.renewer == other.__isset.renewer) && ((!__isset.renewer) || (global::System.Object.Equals(Renewer, other.Renewer))))
        && ((__isset.sessionConf == other.__isset.sessionConf) && ((!__isset.sessionConf) || (global::System.Object.Equals(SessionConf, other.SessionConf))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        if((Owner != null) && __isset.owner)
        {
          hashcode = (hashcode * 397) + Owner.GetHashCode();
        }
        if((Renewer != null) && __isset.renewer)
        {
          hashcode = (hashcode * 397) + Renewer.GetHashCode();
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
      var tmp451 = new StringBuilder("TGetDelegationTokenReq(");
      int tmp452 = 0;
      if((SessionHandle != null) && __isset.sessionHandle)
      {
        if(0 < tmp452++) { tmp451.Append(", "); }
        tmp451.Append("SessionHandle: ");
        SessionHandle.ToString(tmp451);
      }
      if((Owner != null) && __isset.owner)
      {
        if(0 < tmp452++) { tmp451.Append(", "); }
        tmp451.Append("Owner: ");
        Owner.ToString(tmp451);
      }
      if((Renewer != null) && __isset.renewer)
      {
        if(0 < tmp452++) { tmp451.Append(", "); }
        tmp451.Append("Renewer: ");
        Renewer.ToString(tmp451);
      }
      if((SessionConf != null) && __isset.sessionConf)
      {
        if(0 < tmp452++) { tmp451.Append(", "); }
        tmp451.Append("SessionConf: ");
        SessionConf.ToString(tmp451);
      }
      tmp451.Append(')');
      return tmp451.ToString();
    }
  }

}
