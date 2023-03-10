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

  public partial class TUnionTypeEntry : TBase
  {
    private Dictionary<string, int>? _nameToTypePtr;

    public Dictionary<string, int>? NameToTypePtr
    {
      get
      {
        return _nameToTypePtr;
      }
      set
      {
        __isset.nameToTypePtr = true;
        this._nameToTypePtr = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool nameToTypePtr;
    }

    public TUnionTypeEntry()
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
              if (field.Type == TType.Map)
              {
                {
                  var _map34 = await iprot.ReadMapBeginAsync(cancellationToken);
                  NameToTypePtr = new Dictionary<string, int>(_map34.Count);
                  for(int _i35 = 0; _i35 < _map34.Count; ++_i35)
                  {
                    string _key36;
                    int _val37;
                    _key36 = await iprot.ReadStringAsync(cancellationToken);
                    _val37 = await iprot.ReadI32Async(cancellationToken);
                    NameToTypePtr[_key36] = _val37;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
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
        var tmp38 = new TStruct("TUnionTypeEntry");
        await oprot.WriteStructBeginAsync(tmp38, cancellationToken);
        var tmp39 = new TField();
        if((NameToTypePtr != null) && __isset.nameToTypePtr)
        {
          tmp39.Name = "nameToTypePtr";
          tmp39.Type = TType.Map;
          tmp39.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp39, cancellationToken);
          await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.I32, NameToTypePtr.Count), cancellationToken);
          foreach (string _iter40 in NameToTypePtr.Keys)
          {
            await oprot.WriteStringAsync(_iter40, cancellationToken);
            await oprot.WriteI32Async(NameToTypePtr[_iter40], cancellationToken);
          }
          await oprot.WriteMapEndAsync(cancellationToken);
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
      if (that is not TUnionTypeEntry other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.nameToTypePtr == other.__isset.nameToTypePtr) && ((!__isset.nameToTypePtr) || (TCollections.Equals(NameToTypePtr, other.NameToTypePtr))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((NameToTypePtr != null) && __isset.nameToTypePtr)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(NameToTypePtr);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp41 = new StringBuilder("TUnionTypeEntry(");
      int tmp42 = 0;
      if((NameToTypePtr != null) && __isset.nameToTypePtr)
      {
        if(0 < tmp42++) { tmp41.Append(", "); }
        tmp41.Append("NameToTypePtr: ");
        NameToTypePtr.ToString(tmp41);
      }
      tmp41.Append(')');
      return tmp41.ToString();
    }
  }

}
