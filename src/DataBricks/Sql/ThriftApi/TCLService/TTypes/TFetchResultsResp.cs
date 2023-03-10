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

  public partial class TFetchResultsResp : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? _status;
    private bool _hasMoreRows;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TRowSet? _results;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetResultSetMetadataResp? _resultSetMetadata;

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

    public bool HasMoreRows
    {
      get
      {
        return _hasMoreRows;
      }
      set
      {
        __isset.hasMoreRows = true;
        this._hasMoreRows = value;
      }
    }

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TRowSet? Results
    {
      get
      {
        return _results;
      }
      set
      {
        __isset.results = true;
        this._results = value;
      }
    }

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetResultSetMetadataResp? ResultSetMetadata
    {
      get
      {
        return _resultSetMetadata;
      }
      set
      {
        __isset.resultSetMetadata = true;
        this._resultSetMetadata = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool status;
      public bool hasMoreRows;
      public bool results;
      public bool resultSetMetadata;
    }

    public TFetchResultsResp()
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
              if (field.Type == TType.Bool)
              {
                HasMoreRows = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                Results = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TRowSet();
                await Results.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1281:
              if (field.Type == TType.Struct)
              {
                ResultSetMetadata = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetResultSetMetadataResp();
                await ResultSetMetadata.ReadAsync(iprot, cancellationToken);
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
        var tmp445 = new TStruct("TFetchResultsResp");
        await oprot.WriteStructBeginAsync(tmp445, cancellationToken);
        var tmp446 = new TField();
        if((Status != null) && __isset.status)
        {
          tmp446.Name = "status";
          tmp446.Type = TType.Struct;
          tmp446.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp446, cancellationToken);
          await Status.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.hasMoreRows)
        {
          tmp446.Name = "hasMoreRows";
          tmp446.Type = TType.Bool;
          tmp446.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp446, cancellationToken);
          await oprot.WriteBoolAsync(HasMoreRows, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Results != null) && __isset.results)
        {
          tmp446.Name = "results";
          tmp446.Type = TType.Struct;
          tmp446.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp446, cancellationToken);
          await Results.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((ResultSetMetadata != null) && __isset.resultSetMetadata)
        {
          tmp446.Name = "resultSetMetadata";
          tmp446.Type = TType.Struct;
          tmp446.ID = 1281;
          await oprot.WriteFieldBeginAsync(tmp446, cancellationToken);
          await ResultSetMetadata.WriteAsync(oprot, cancellationToken);
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
      if (that is not TFetchResultsResp other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.status == other.__isset.status) && ((!__isset.status) || (global::System.Object.Equals(Status, other.Status))))
        && ((__isset.hasMoreRows == other.__isset.hasMoreRows) && ((!__isset.hasMoreRows) || (global::System.Object.Equals(HasMoreRows, other.HasMoreRows))))
        && ((__isset.results == other.__isset.results) && ((!__isset.results) || (global::System.Object.Equals(Results, other.Results))))
        && ((__isset.resultSetMetadata == other.__isset.resultSetMetadata) && ((!__isset.resultSetMetadata) || (global::System.Object.Equals(ResultSetMetadata, other.ResultSetMetadata))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Status != null) && __isset.status)
        {
          hashcode = (hashcode * 397) + Status.GetHashCode();
        }
        if(__isset.hasMoreRows)
        {
          hashcode = (hashcode * 397) + HasMoreRows.GetHashCode();
        }
        if((Results != null) && __isset.results)
        {
          hashcode = (hashcode * 397) + Results.GetHashCode();
        }
        if((ResultSetMetadata != null) && __isset.resultSetMetadata)
        {
          hashcode = (hashcode * 397) + ResultSetMetadata.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp447 = new StringBuilder("TFetchResultsResp(");
      int tmp448 = 0;
      if((Status != null) && __isset.status)
      {
        if(0 < tmp448++) { tmp447.Append(", "); }
        tmp447.Append("Status: ");
        Status.ToString(tmp447);
      }
      if(__isset.hasMoreRows)
      {
        if(0 < tmp448++) { tmp447.Append(", "); }
        tmp447.Append("HasMoreRows: ");
        HasMoreRows.ToString(tmp447);
      }
      if((Results != null) && __isset.results)
      {
        if(0 < tmp448++) { tmp447.Append(", "); }
        tmp447.Append("Results: ");
        Results.ToString(tmp447);
      }
      if((ResultSetMetadata != null) && __isset.resultSetMetadata)
      {
        if(0 < tmp448++) { tmp447.Append(", "); }
        tmp447.Append("ResultSetMetadata: ");
        ResultSetMetadata.ToString(tmp447);
      }
      tmp447.Append(')');
      return tmp447.ToString();
    }
  }

}
