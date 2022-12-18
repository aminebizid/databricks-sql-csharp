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

  public partial class TGetDelegationTokenResp : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? _status;
    private string? _delegationToken;

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? Status
    {
      get
      {
        return _status;
      }
      set
      {
        __isset.status = true;
        this._status = value;
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


    public Isset __isset;
    public struct Isset
    {
      public bool status;
      public bool delegationToken;
    }

    public TGetDelegationTokenResp()
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
                Status = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus();
                await Status.ReadAsync(iprot, cancellationToken);
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
        var tmp453 = new TStruct("TGetDelegationTokenResp");
        await oprot.WriteStructBeginAsync(tmp453, cancellationToken);
        var tmp454 = new TField();
        if((Status != null) && __isset.status)
        {
          tmp454.Name = "status";
          tmp454.Type = TType.Struct;
          tmp454.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp454, cancellationToken);
          await Status.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((DelegationToken != null) && __isset.delegationToken)
        {
          tmp454.Name = "delegationToken";
          tmp454.Type = TType.String;
          tmp454.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp454, cancellationToken);
          await oprot.WriteStringAsync(DelegationToken, cancellationToken);
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
      if (that is not TGetDelegationTokenResp other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.status == other.__isset.status) && ((!__isset.status) || (global::System.Object.Equals(Status, other.Status))))
        && ((__isset.delegationToken == other.__isset.delegationToken) && ((!__isset.delegationToken) || (global::System.Object.Equals(DelegationToken, other.DelegationToken))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Status != null) && __isset.status)
        {
          hashcode = (hashcode * 397) + Status.GetHashCode();
        }
        if((DelegationToken != null) && __isset.delegationToken)
        {
          hashcode = (hashcode * 397) + DelegationToken.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp455 = new StringBuilder("TGetDelegationTokenResp(");
      int tmp456 = 0;
      if((Status != null) && __isset.status)
      {
        if(0 < tmp456++) { tmp455.Append(", "); }
        tmp455.Append("Status: ");
        Status.ToString(tmp455);
      }
      if((DelegationToken != null) && __isset.delegationToken)
      {
        if(0 < tmp456++) { tmp455.Append(", "); }
        tmp455.Append("DelegationToken: ");
        DelegationToken.ToString(tmp455);
      }
      tmp455.Append(')');
      return tmp455.ToString();
    }
  }

}
