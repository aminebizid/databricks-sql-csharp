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

  public partial class TExecuteStatementResp : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? _status;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TOperationHandle? _operationHandle;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSparkDirectResults? _directResults;
    private bool _executionRejected;
    private double _maxClusterCapacity;
    private double _queryCost;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TDBSqlSessionConf? _sessionConf;
    private double _currentClusterLoad;

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

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSparkDirectResults? DirectResults
    {
      get
      {
        return _directResults;
      }
      set
      {
        __isset.directResults = true;
        this._directResults = value;
      }
    }

    public bool ExecutionRejected
    {
      get
      {
        return _executionRejected;
      }
      set
      {
        __isset.executionRejected = true;
        this._executionRejected = value;
      }
    }

    public double MaxClusterCapacity
    {
      get
      {
        return _maxClusterCapacity;
      }
      set
      {
        __isset.maxClusterCapacity = true;
        this._maxClusterCapacity = value;
      }
    }

    public double QueryCost
    {
      get
      {
        return _queryCost;
      }
      set
      {
        __isset.queryCost = true;
        this._queryCost = value;
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

    public double CurrentClusterLoad
    {
      get
      {
        return _currentClusterLoad;
      }
      set
      {
        __isset.currentClusterLoad = true;
        this._currentClusterLoad = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool status;
      public bool operationHandle;
      public bool directResults;
      public bool executionRejected;
      public bool maxClusterCapacity;
      public bool queryCost;
      public bool sessionConf;
      public bool currentClusterLoad;
    }

    public TExecuteStatementResp()
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
            case 1281:
              if (field.Type == TType.Struct)
              {
                DirectResults = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSparkDirectResults();
                await DirectResults.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.Bool)
              {
                ExecutionRejected = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3330:
              if (field.Type == TType.Double)
              {
                MaxClusterCapacity = await iprot.ReadDoubleAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3331:
              if (field.Type == TType.Double)
              {
                QueryCost = await iprot.ReadDoubleAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3332:
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
            case 3333:
              if (field.Type == TType.Double)
              {
                CurrentClusterLoad = await iprot.ReadDoubleAsync(cancellationToken);
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
        var tmp329 = new TStruct("TExecuteStatementResp");
        await oprot.WriteStructBeginAsync(tmp329, cancellationToken);
        var tmp330 = new TField();
        if((Status != null) && __isset.status)
        {
          tmp330.Name = "status";
          tmp330.Type = TType.Struct;
          tmp330.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await Status.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((OperationHandle != null) && __isset.operationHandle)
        {
          tmp330.Name = "operationHandle";
          tmp330.Type = TType.Struct;
          tmp330.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await OperationHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((DirectResults != null) && __isset.directResults)
        {
          tmp330.Name = "directResults";
          tmp330.Type = TType.Struct;
          tmp330.ID = 1281;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await DirectResults.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.executionRejected)
        {
          tmp330.Name = "executionRejected";
          tmp330.Type = TType.Bool;
          tmp330.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await oprot.WriteBoolAsync(ExecutionRejected, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.maxClusterCapacity)
        {
          tmp330.Name = "maxClusterCapacity";
          tmp330.Type = TType.Double;
          tmp330.ID = 3330;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await oprot.WriteDoubleAsync(MaxClusterCapacity, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.queryCost)
        {
          tmp330.Name = "queryCost";
          tmp330.Type = TType.Double;
          tmp330.ID = 3331;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await oprot.WriteDoubleAsync(QueryCost, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SessionConf != null) && __isset.sessionConf)
        {
          tmp330.Name = "sessionConf";
          tmp330.Type = TType.Struct;
          tmp330.ID = 3332;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await SessionConf.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.currentClusterLoad)
        {
          tmp330.Name = "currentClusterLoad";
          tmp330.Type = TType.Double;
          tmp330.ID = 3333;
          await oprot.WriteFieldBeginAsync(tmp330, cancellationToken);
          await oprot.WriteDoubleAsync(CurrentClusterLoad, cancellationToken);
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
      if (that is not TExecuteStatementResp other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.status == other.__isset.status) && ((!__isset.status) || (global::System.Object.Equals(Status, other.Status))))
        && ((__isset.operationHandle == other.__isset.operationHandle) && ((!__isset.operationHandle) || (global::System.Object.Equals(OperationHandle, other.OperationHandle))))
        && ((__isset.directResults == other.__isset.directResults) && ((!__isset.directResults) || (global::System.Object.Equals(DirectResults, other.DirectResults))))
        && ((__isset.executionRejected == other.__isset.executionRejected) && ((!__isset.executionRejected) || (global::System.Object.Equals(ExecutionRejected, other.ExecutionRejected))))
        && ((__isset.maxClusterCapacity == other.__isset.maxClusterCapacity) && ((!__isset.maxClusterCapacity) || (global::System.Object.Equals(MaxClusterCapacity, other.MaxClusterCapacity))))
        && ((__isset.queryCost == other.__isset.queryCost) && ((!__isset.queryCost) || (global::System.Object.Equals(QueryCost, other.QueryCost))))
        && ((__isset.sessionConf == other.__isset.sessionConf) && ((!__isset.sessionConf) || (global::System.Object.Equals(SessionConf, other.SessionConf))))
        && ((__isset.currentClusterLoad == other.__isset.currentClusterLoad) && ((!__isset.currentClusterLoad) || (global::System.Object.Equals(CurrentClusterLoad, other.CurrentClusterLoad))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Status != null) && __isset.status)
        {
          hashcode = (hashcode * 397) + Status.GetHashCode();
        }
        if((OperationHandle != null) && __isset.operationHandle)
        {
          hashcode = (hashcode * 397) + OperationHandle.GetHashCode();
        }
        if((DirectResults != null) && __isset.directResults)
        {
          hashcode = (hashcode * 397) + DirectResults.GetHashCode();
        }
        if(__isset.executionRejected)
        {
          hashcode = (hashcode * 397) + ExecutionRejected.GetHashCode();
        }
        if(__isset.maxClusterCapacity)
        {
          hashcode = (hashcode * 397) + MaxClusterCapacity.GetHashCode();
        }
        if(__isset.queryCost)
        {
          hashcode = (hashcode * 397) + QueryCost.GetHashCode();
        }
        if((SessionConf != null) && __isset.sessionConf)
        {
          hashcode = (hashcode * 397) + SessionConf.GetHashCode();
        }
        if(__isset.currentClusterLoad)
        {
          hashcode = (hashcode * 397) + CurrentClusterLoad.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp331 = new StringBuilder("TExecuteStatementResp(");
      int tmp332 = 0;
      if((Status != null) && __isset.status)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("Status: ");
        Status.ToString(tmp331);
      }
      if((OperationHandle != null) && __isset.operationHandle)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("OperationHandle: ");
        OperationHandle.ToString(tmp331);
      }
      if((DirectResults != null) && __isset.directResults)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("DirectResults: ");
        DirectResults.ToString(tmp331);
      }
      if(__isset.executionRejected)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("ExecutionRejected: ");
        ExecutionRejected.ToString(tmp331);
      }
      if(__isset.maxClusterCapacity)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("MaxClusterCapacity: ");
        MaxClusterCapacity.ToString(tmp331);
      }
      if(__isset.queryCost)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("QueryCost: ");
        QueryCost.ToString(tmp331);
      }
      if((SessionConf != null) && __isset.sessionConf)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("SessionConf: ");
        SessionConf.ToString(tmp331);
      }
      if(__isset.currentClusterLoad)
      {
        if(0 < tmp332++) { tmp331.Append(", "); }
        tmp331.Append("CurrentClusterLoad: ");
        CurrentClusterLoad.ToString(tmp331);
      }
      tmp331.Append(')');
      return tmp331.ToString();
    }
  }

}