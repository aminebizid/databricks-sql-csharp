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

  public partial class TSparkArrowBatch : TBase
  {
    private byte[]? _batch;
    private long _rowCount;

    public byte[]? Batch
    {
      get
      {
        return _batch;
      }
      set
      {
        __isset.batch = true;
        this._batch = value;
      }
    }

    public long RowCount
    {
      get
      {
        return _rowCount;
      }
      set
      {
        __isset.rowCount = true;
        this._rowCount = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool batch;
      public bool rowCount;
    }

    public TSparkArrowBatch()
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
              if (field.Type == TType.String)
              {
                Batch = await iprot.ReadBinaryAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I64)
              {
                RowCount = await iprot.ReadI64Async(cancellationToken);
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
        var tmp179 = new TStruct("TSparkArrowBatch");
        await oprot.WriteStructBeginAsync(tmp179, cancellationToken);
        var tmp180 = new TField();
        if((Batch != null) && __isset.batch)
        {
          tmp180.Name = "batch";
          tmp180.Type = TType.String;
          tmp180.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp180, cancellationToken);
          await oprot.WriteBinaryAsync(Batch, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.rowCount)
        {
          tmp180.Name = "rowCount";
          tmp180.Type = TType.I64;
          tmp180.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp180, cancellationToken);
          await oprot.WriteI64Async(RowCount, cancellationToken);
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
      if (that is not TSparkArrowBatch other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.batch == other.__isset.batch) && ((!__isset.batch) || (TCollections.Equals(Batch, other.Batch))))
        && ((__isset.rowCount == other.__isset.rowCount) && ((!__isset.rowCount) || (global::System.Object.Equals(RowCount, other.RowCount))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Batch != null) && __isset.batch)
        {
          hashcode = (hashcode * 397) + Batch.GetHashCode();
        }
        if(__isset.rowCount)
        {
          hashcode = (hashcode * 397) + RowCount.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp181 = new StringBuilder("TSparkArrowBatch(");
      int tmp182 = 0;
      if((Batch != null) && __isset.batch)
      {
        if(0 < tmp182++) { tmp181.Append(", "); }
        tmp181.Append("Batch: ");
        Batch.ToString(tmp181);
      }
      if(__isset.rowCount)
      {
        if(0 < tmp182++) { tmp181.Append(", "); }
        tmp181.Append("RowCount: ");
        RowCount.ToString(tmp181);
      }
      tmp181.Append(')');
      return tmp181.ToString();
    }
  }

}
