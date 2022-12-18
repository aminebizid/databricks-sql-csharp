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

  public partial class TI16Column : TBase
  {
    private List<short>? _values;
    private byte[]? _nulls;

    public List<short>? Values
    {
      get
      {
        return _values;
      }
      set
      {
        __isset.values = true;
        this._values = value;
      }
    }

    public byte[]? Nulls
    {
      get
      {
        return _nulls;
      }
      set
      {
        __isset.nulls = true;
        this._nulls = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool values;
      public bool nulls;
    }

    public TI16Column()
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
                  var _list127 = await iprot.ReadListBeginAsync(cancellationToken);
                  Values = new List<short>(_list127.Count);
                  for(int _i128 = 0; _i128 < _list127.Count; ++_i128)
                  {
                    short _elem129;
                    _elem129 = await iprot.ReadI16Async(cancellationToken);
                    Values.Add(_elem129);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                Nulls = await iprot.ReadBinaryAsync(cancellationToken);
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
        var tmp130 = new TStruct("TI16Column");
        await oprot.WriteStructBeginAsync(tmp130, cancellationToken);
        var tmp131 = new TField();
        if((Values != null) && __isset.values)
        {
          tmp131.Name = "values";
          tmp131.Type = TType.List;
          tmp131.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp131, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.I16, Values.Count), cancellationToken);
          foreach (short _iter132 in Values)
          {
            await oprot.WriteI16Async(_iter132, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Nulls != null) && __isset.nulls)
        {
          tmp131.Name = "nulls";
          tmp131.Type = TType.String;
          tmp131.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp131, cancellationToken);
          await oprot.WriteBinaryAsync(Nulls, cancellationToken);
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
      if (that is not TI16Column other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.values == other.__isset.values) && ((!__isset.values) || (TCollections.Equals(Values, other.Values))))
        && ((__isset.nulls == other.__isset.nulls) && ((!__isset.nulls) || (TCollections.Equals(Nulls, other.Nulls))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Values != null) && __isset.values)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Values);
        }
        if((Nulls != null) && __isset.nulls)
        {
          hashcode = (hashcode * 397) + Nulls.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp133 = new StringBuilder("TI16Column(");
      int tmp134 = 0;
      if((Values != null) && __isset.values)
      {
        if(0 < tmp134++) { tmp133.Append(", "); }
        tmp133.Append("Values: ");
        Values.ToString(tmp133);
      }
      if((Nulls != null) && __isset.nulls)
      {
        if(0 < tmp134++) { tmp133.Append(", "); }
        tmp133.Append("Nulls: ");
        Nulls.ToString(tmp133);
      }
      tmp133.Append(')');
      return tmp133.ToString();
    }
  }

}