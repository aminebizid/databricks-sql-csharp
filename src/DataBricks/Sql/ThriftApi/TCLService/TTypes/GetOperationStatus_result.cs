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

  public partial class GetOperationStatus_result : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetOperationStatusResp? _success;

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetOperationStatusResp? Success
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
    public struct Isset
    {
      public bool success;
    }

    public GetOperationStatus_result()
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
                Success = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetOperationStatusResp();
                await Success.ReadAsync(iprot, cancellationToken);
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
        var tmp485 = new TStruct("GetOperationStatus_result");
        await oprot.WriteStructBeginAsync(tmp485, cancellationToken);
        var tmp486 = new TField();
        if((Success != null) && __isset.success)
        {
          tmp486.Name = "success";
          tmp486.Type = TType.Struct;
          tmp486.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp486, cancellationToken);
          await Success.WriteAsync(oprot, cancellationToken);
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
      if (that is not GetOperationStatus_result other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.success == other.__isset.success) && ((!__isset.success) || (global::System.Object.Equals(Success, other.Success))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Success != null) && __isset.success)
        {
          hashcode = (hashcode * 397) + Success.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp487 = new StringBuilder("GetOperationStatus_result(");
      int tmp488 = 0;
      if((Success != null) && __isset.success)
      {
        if(0 < tmp488++) { tmp487.Append(", "); }
        tmp487.Append("Success: ");
        Success.ToString(tmp487);
      }
      tmp487.Append(')');
      return tmp487.ToString();
    }
  }

}