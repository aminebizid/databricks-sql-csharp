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

  public partial class TCancelOperationReq : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TOperationHandle? _operationHandle;

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TOperationHandle? OperationHandle
    {
      get
      {
        return _operationHandle;
      }
      set
      {
        __isset.operationHandle = true;
        this._operationHandle = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool operationHandle;
    }

    public TCancelOperationReq()
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
                OperationHandle = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TOperationHandle();
                await OperationHandle.ReadAsync(iprot, cancellationToken);
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
        var tmp417 = new TStruct("TCancelOperationReq");
        await oprot.WriteStructBeginAsync(tmp417, cancellationToken);
        var tmp418 = new TField();
        if((OperationHandle != null) && __isset.operationHandle)
        {
          tmp418.Name = "operationHandle";
          tmp418.Type = TType.Struct;
          tmp418.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp418, cancellationToken);
          await OperationHandle.WriteAsync(oprot, cancellationToken);
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
      if (that is not TCancelOperationReq other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.operationHandle == other.__isset.operationHandle) && ((!__isset.operationHandle) || (global::System.Object.Equals(OperationHandle, other.OperationHandle))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((OperationHandle != null) && __isset.operationHandle)
        {
          hashcode = (hashcode * 397) + OperationHandle.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp419 = new StringBuilder("TCancelOperationReq(");
      int tmp420 = 0;
      if((OperationHandle != null) && __isset.operationHandle)
      {
        if(0 < tmp420++) { tmp419.Append(", "); }
        tmp419.Append("OperationHandle: ");
        OperationHandle.ToString(tmp419);
      }
      tmp419.Append(')');
      return tmp419.ToString();
    }
  }

}
