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

  public partial class TTableSchema : TBase
  {
    private List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TColumnDesc>? _columns;

    public List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TColumnDesc>? Columns
    {
      get
      {
        return _columns;
      }
      set
      {
        __isset.columns = true;
        this._columns = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool columns;
    }

    public TTableSchema()
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
              if (field.Type == TType.List)
              {
                {
                  var _list63 = await iprot.ReadListBeginAsync(cancellationToken);
                  Columns = new List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TColumnDesc>(_list63.Count);
                  for(int _i64 = 0; _i64 < _list63.Count; ++_i64)
                  {
                    global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TColumnDesc _elem65;
                    _elem65 = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TColumnDesc();
                    await _elem65.ReadAsync(iprot, cancellationToken);
                    Columns.Add(_elem65);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
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
        var tmp66 = new TStruct("TTableSchema");
        await oprot.WriteStructBeginAsync(tmp66, cancellationToken);
        var tmp67 = new TField();
        if((Columns != null) && __isset.columns)
        {
          tmp67.Name = "columns";
          tmp67.Type = TType.List;
          tmp67.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp67, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, Columns.Count), cancellationToken);
          foreach (global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TColumnDesc _iter68 in Columns)
          {
            await _iter68.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
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
      if (that is not TTableSchema other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.columns == other.__isset.columns) && ((!__isset.columns) || (TCollections.Equals(Columns, other.Columns))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Columns != null) && __isset.columns)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Columns);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp69 = new StringBuilder("TTableSchema(");
      int tmp70 = 0;
      if((Columns != null) && __isset.columns)
      {
        if(0 < tmp70++) { tmp69.Append(", "); }
        tmp69.Append("Columns: ");
        Columns.ToString(tmp69);
      }
      tmp69.Append(')');
      return tmp69.ToString();
    }
  }

}
