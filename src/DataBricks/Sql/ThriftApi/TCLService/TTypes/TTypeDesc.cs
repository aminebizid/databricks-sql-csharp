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

  public partial class TTypeDesc : TBase
  {
    private List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TTypeEntry>? _types;

    public List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TTypeEntry>? Types
    {
      get
      {
        return _types;
      }
      set
      {
        __isset.types = true;
        this._types = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool types;
    }

    public TTypeDesc()
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
                  var _list51 = await iprot.ReadListBeginAsync(cancellationToken);
                  Types = new List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TTypeEntry>(_list51.Count);
                  for(int _i52 = 0; _i52 < _list51.Count; ++_i52)
                  {
                    global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TTypeEntry _elem53;
                    _elem53 = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TTypeEntry();
                    await _elem53.ReadAsync(iprot, cancellationToken);
                    Types.Add(_elem53);
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
        var tmp54 = new TStruct("TTypeDesc");
        await oprot.WriteStructBeginAsync(tmp54, cancellationToken);
        var tmp55 = new TField();
        if((Types != null) && __isset.types)
        {
          tmp55.Name = "types";
          tmp55.Type = TType.List;
          tmp55.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp55, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, Types.Count), cancellationToken);
          foreach (global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TTypeEntry _iter56 in Types)
          {
            await _iter56.WriteAsync(oprot, cancellationToken);
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
      if (that is not TTypeDesc other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.types == other.__isset.types) && ((!__isset.types) || (TCollections.Equals(Types, other.Types))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Types != null) && __isset.types)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Types);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp57 = new StringBuilder("TTypeDesc(");
      int tmp58 = 0;
      if((Types != null) && __isset.types)
      {
        if(0 < tmp58++) { tmp57.Append(", "); }
        tmp57.Append("Types: ");
        Types.ToString(tmp57);
      }
      tmp57.Append(')');
      return tmp57.ToString();
    }
  }

}
