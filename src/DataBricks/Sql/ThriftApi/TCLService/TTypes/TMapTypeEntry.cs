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

  public partial class TMapTypeEntry : TBase
  {
    private int _keyTypePtr;
    private int _valueTypePtr;

    public int KeyTypePtr
    {
      get
      {
        return _keyTypePtr;
      }
      set
      {
        __isset.keyTypePtr = true;
        this._keyTypePtr = value;
      }
    }

    public int ValueTypePtr
    {
      get
      {
        return _valueTypePtr;
      }
      set
      {
        __isset.valueTypePtr = true;
        this._valueTypePtr = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool keyTypePtr;
      public bool valueTypePtr;
    }

    public TMapTypeEntry()
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
              if (field.Type == TType.I32)
              {
                KeyTypePtr = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I32)
              {
                ValueTypePtr = await iprot.ReadI32Async(cancellationToken);
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
        var tmp21 = new TStruct("TMapTypeEntry");
        await oprot.WriteStructBeginAsync(tmp21, cancellationToken);
        var tmp22 = new TField();
        if(__isset.keyTypePtr)
        {
          tmp22.Name = "keyTypePtr";
          tmp22.Type = TType.I32;
          tmp22.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp22, cancellationToken);
          await oprot.WriteI32Async(KeyTypePtr, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.valueTypePtr)
        {
          tmp22.Name = "valueTypePtr";
          tmp22.Type = TType.I32;
          tmp22.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp22, cancellationToken);
          await oprot.WriteI32Async(ValueTypePtr, cancellationToken);
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
      if (that is not TMapTypeEntry other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.keyTypePtr == other.__isset.keyTypePtr) && ((!__isset.keyTypePtr) || (global::System.Object.Equals(KeyTypePtr, other.KeyTypePtr))))
        && ((__isset.valueTypePtr == other.__isset.valueTypePtr) && ((!__isset.valueTypePtr) || (global::System.Object.Equals(ValueTypePtr, other.ValueTypePtr))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.keyTypePtr)
        {
          hashcode = (hashcode * 397) + KeyTypePtr.GetHashCode();
        }
        if(__isset.valueTypePtr)
        {
          hashcode = (hashcode * 397) + ValueTypePtr.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp23 = new StringBuilder("TMapTypeEntry(");
      int tmp24 = 0;
      if(__isset.keyTypePtr)
      {
        if(0 < tmp24++) { tmp23.Append(", "); }
        tmp23.Append("KeyTypePtr: ");
        KeyTypePtr.ToString(tmp23);
      }
      if(__isset.valueTypePtr)
      {
        if(0 < tmp24++) { tmp23.Append(", "); }
        tmp23.Append("ValueTypePtr: ");
        ValueTypePtr.ToString(tmp23);
      }
      tmp23.Append(')');
      return tmp23.ToString();
    }
  }

}