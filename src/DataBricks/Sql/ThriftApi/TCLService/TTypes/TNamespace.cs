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

  public partial class TNamespace : TBase
  {
    private string? _catalogName;
    private string? _schemaName;

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


    public Isset __isset;
    public struct Isset
    {
      public bool catalogName;
      public bool schemaName;
    }

    public TNamespace()
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
                CatalogName = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                SchemaName = await iprot.ReadStringAsync(cancellationToken);
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
        var tmp241 = new TStruct("TNamespace");
        await oprot.WriteStructBeginAsync(tmp241, cancellationToken);
        var tmp242 = new TField();
        if((CatalogName != null) && __isset.catalogName)
        {
          tmp242.Name = "catalogName";
          tmp242.Type = TType.String;
          tmp242.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp242, cancellationToken);
          await oprot.WriteStringAsync(CatalogName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SchemaName != null) && __isset.schemaName)
        {
          tmp242.Name = "schemaName";
          tmp242.Type = TType.String;
          tmp242.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp242, cancellationToken);
          await oprot.WriteStringAsync(SchemaName, cancellationToken);
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
      if (that is not TNamespace other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.catalogName == other.__isset.catalogName) && ((!__isset.catalogName) || (global::System.Object.Equals(CatalogName, other.CatalogName))))
        && ((__isset.schemaName == other.__isset.schemaName) && ((!__isset.schemaName) || (global::System.Object.Equals(SchemaName, other.SchemaName))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((CatalogName != null) && __isset.catalogName)
        {
          hashcode = (hashcode * 397) + CatalogName.GetHashCode();
        }
        if((SchemaName != null) && __isset.schemaName)
        {
          hashcode = (hashcode * 397) + SchemaName.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp243 = new StringBuilder("TNamespace(");
      int tmp244 = 0;
      if((CatalogName != null) && __isset.catalogName)
      {
        if(0 < tmp244++) { tmp243.Append(", "); }
        tmp243.Append("CatalogName: ");
        CatalogName.ToString(tmp243);
      }
      if((SchemaName != null) && __isset.schemaName)
      {
        if(0 < tmp244++) { tmp243.Append(", "); }
        tmp243.Append("SchemaName: ");
        SchemaName.ToString(tmp243);
      }
      tmp243.Append(')');
      return tmp243.ToString();
    }
  }

}