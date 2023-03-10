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

  public partial class TGetFunctionsReq : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? _sessionHandle;
    private string? _catalogName;
    private string? _schemaName;
    private string? _functionName;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSparkGetDirectResults? _getDirectResults;
    private bool _runAsync;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.THandleIdentifier? _operationId;
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

    public string? CatalogName
    {
      get
      {
        return _catalogName;
      }
      set
      {
        __isset.catalogName = true;
        this._catalogName = value;
      }
    }

    public string? SchemaName
    {
      get
      {
        return _schemaName;
      }
      set
      {
        __isset.schemaName = true;
        this._schemaName = value;
      }
    }

    public string? FunctionName
    {
      get
      {
        return _functionName;
      }
      set
      {
        __isset.functionName = true;
        this._functionName = value;
      }
    }

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSparkGetDirectResults? GetDirectResults
    {
      get
      {
        return _getDirectResults;
      }
      set
      {
        __isset.getDirectResults = true;
        this._getDirectResults = value;
      }
    }

    public bool RunAsync
    {
      get
      {
        return _runAsync;
      }
      set
      {
        __isset.runAsync = true;
        this._runAsync = value;
      }
    }

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.THandleIdentifier? OperationId
    {
      get
      {
        return _operationId;
      }
      set
      {
        __isset.operationId = true;
        this._operationId = value;
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
      public bool catalogName;
      public bool schemaName;
      public bool functionName;
      public bool getDirectResults;
      public bool runAsync;
      public bool operationId;
      public bool sessionConf;
    }

    public TGetFunctionsReq()
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
                CatalogName = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                SchemaName = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.String)
              {
                FunctionName = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1281:
              if (field.Type == TType.Struct)
              {
                GetDirectResults = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSparkGetDirectResults();
                await GetDirectResults.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1282:
              if (field.Type == TType.Bool)
              {
                RunAsync = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.Struct)
              {
                OperationId = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.THandleIdentifier();
                await OperationId.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3330:
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
        var tmp385 = new TStruct("TGetFunctionsReq");
        await oprot.WriteStructBeginAsync(tmp385, cancellationToken);
        var tmp386 = new TField();
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          tmp386.Name = "sessionHandle";
          tmp386.Type = TType.Struct;
          tmp386.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((CatalogName != null) && __isset.catalogName)
        {
          tmp386.Name = "catalogName";
          tmp386.Type = TType.String;
          tmp386.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await oprot.WriteStringAsync(CatalogName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SchemaName != null) && __isset.schemaName)
        {
          tmp386.Name = "schemaName";
          tmp386.Type = TType.String;
          tmp386.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await oprot.WriteStringAsync(SchemaName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((FunctionName != null) && __isset.functionName)
        {
          tmp386.Name = "functionName";
          tmp386.Type = TType.String;
          tmp386.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await oprot.WriteStringAsync(FunctionName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((GetDirectResults != null) && __isset.getDirectResults)
        {
          tmp386.Name = "getDirectResults";
          tmp386.Type = TType.Struct;
          tmp386.ID = 1281;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await GetDirectResults.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.runAsync)
        {
          tmp386.Name = "runAsync";
          tmp386.Type = TType.Bool;
          tmp386.ID = 1282;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await oprot.WriteBoolAsync(RunAsync, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((OperationId != null) && __isset.operationId)
        {
          tmp386.Name = "operationId";
          tmp386.Type = TType.Struct;
          tmp386.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
          await OperationId.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SessionConf != null) && __isset.sessionConf)
        {
          tmp386.Name = "sessionConf";
          tmp386.Type = TType.Struct;
          tmp386.ID = 3330;
          await oprot.WriteFieldBeginAsync(tmp386, cancellationToken);
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
      if (that is not TGetFunctionsReq other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.sessionHandle == other.__isset.sessionHandle) && ((!__isset.sessionHandle) || (global::System.Object.Equals(SessionHandle, other.SessionHandle))))
        && ((__isset.catalogName == other.__isset.catalogName) && ((!__isset.catalogName) || (global::System.Object.Equals(CatalogName, other.CatalogName))))
        && ((__isset.schemaName == other.__isset.schemaName) && ((!__isset.schemaName) || (global::System.Object.Equals(SchemaName, other.SchemaName))))
        && ((__isset.functionName == other.__isset.functionName) && ((!__isset.functionName) || (global::System.Object.Equals(FunctionName, other.FunctionName))))
        && ((__isset.getDirectResults == other.__isset.getDirectResults) && ((!__isset.getDirectResults) || (global::System.Object.Equals(GetDirectResults, other.GetDirectResults))))
        && ((__isset.runAsync == other.__isset.runAsync) && ((!__isset.runAsync) || (global::System.Object.Equals(RunAsync, other.RunAsync))))
        && ((__isset.operationId == other.__isset.operationId) && ((!__isset.operationId) || (global::System.Object.Equals(OperationId, other.OperationId))))
        && ((__isset.sessionConf == other.__isset.sessionConf) && ((!__isset.sessionConf) || (global::System.Object.Equals(SessionConf, other.SessionConf))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        if((CatalogName != null) && __isset.catalogName)
        {
          hashcode = (hashcode * 397) + CatalogName.GetHashCode();
        }
        if((SchemaName != null) && __isset.schemaName)
        {
          hashcode = (hashcode * 397) + SchemaName.GetHashCode();
        }
        if((FunctionName != null) && __isset.functionName)
        {
          hashcode = (hashcode * 397) + FunctionName.GetHashCode();
        }
        if((GetDirectResults != null) && __isset.getDirectResults)
        {
          hashcode = (hashcode * 397) + GetDirectResults.GetHashCode();
        }
        if(__isset.runAsync)
        {
          hashcode = (hashcode * 397) + RunAsync.GetHashCode();
        }
        if((OperationId != null) && __isset.operationId)
        {
          hashcode = (hashcode * 397) + OperationId.GetHashCode();
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
      var tmp387 = new StringBuilder("TGetFunctionsReq(");
      int tmp388 = 0;
      if((SessionHandle != null) && __isset.sessionHandle)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("SessionHandle: ");
        SessionHandle.ToString(tmp387);
      }
      if((CatalogName != null) && __isset.catalogName)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("CatalogName: ");
        CatalogName.ToString(tmp387);
      }
      if((SchemaName != null) && __isset.schemaName)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("SchemaName: ");
        SchemaName.ToString(tmp387);
      }
      if((FunctionName != null) && __isset.functionName)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("FunctionName: ");
        FunctionName.ToString(tmp387);
      }
      if((GetDirectResults != null) && __isset.getDirectResults)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("GetDirectResults: ");
        GetDirectResults.ToString(tmp387);
      }
      if(__isset.runAsync)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("RunAsync: ");
        RunAsync.ToString(tmp387);
      }
      if((OperationId != null) && __isset.operationId)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("OperationId: ");
        OperationId.ToString(tmp387);
      }
      if((SessionConf != null) && __isset.sessionConf)
      {
        if(0 < tmp388++) { tmp387.Append(", "); }
        tmp387.Append("SessionConf: ");
        SessionConf.ToString(tmp387);
      }
      tmp387.Append(')');
      return tmp387.ToString();
    }
  }

}
