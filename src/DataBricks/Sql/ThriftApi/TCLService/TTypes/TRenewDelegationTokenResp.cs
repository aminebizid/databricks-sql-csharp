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

  public partial class TRenewDelegationTokenResp : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? _status;

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


    public Isset __isset;
    public struct Isset
    {
      public bool status;
    }

    public TRenewDelegationTokenResp()
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
        var tmp469 = new TStruct("TRenewDelegationTokenResp");
        await oprot.WriteStructBeginAsync(tmp469, cancellationToken);
        var tmp470 = new TField();
        if((Status != null) && __isset.status)
        {
          tmp470.Name = "status";
          tmp470.Type = TType.Struct;
          tmp470.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp470, cancellationToken);
          await Status.WriteAsync(oprot, cancellationToken);
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
      if (that is not TRenewDelegationTokenResp other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.status == other.__isset.status) && ((!__isset.status) || (global::System.Object.Equals(Status, other.Status))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Status != null) && __isset.status)
        {
          hashcode = (hashcode * 397) + Status.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp471 = new StringBuilder("TRenewDelegationTokenResp(");
      int tmp472 = 0;
      if((Status != null) && __isset.status)
      {
        if(0 < tmp472++) { tmp471.Append(", "); }
        tmp471.Append("Status: ");
        Status.ToString(tmp471);
      }
      tmp471.Append(')');
      return tmp471.ToString();
    }
  }

}
