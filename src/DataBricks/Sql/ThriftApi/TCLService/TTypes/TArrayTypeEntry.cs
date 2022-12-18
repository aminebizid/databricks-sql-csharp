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

  public partial class TArrayTypeEntry : TBase
  {
    private int _objectTypePtr;

    public int ObjectTypePtr
    {
      get
      {
        return _objectTypePtr;
      }
      set
      {
        __isset.objectTypePtr = true;
        this._objectTypePtr = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool objectTypePtr;
    }

    public TArrayTypeEntry()
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
                ObjectTypePtr = await iprot.ReadI32Async(cancellationToken);
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
        var tmp17 = new TStruct("TArrayTypeEntry");
        await oprot.WriteStructBeginAsync(tmp17, cancellationToken);
        var tmp18 = new TField();
        if(__isset.objectTypePtr)
        {
          tmp18.Name = "objectTypePtr";
          tmp18.Type = TType.I32;
          tmp18.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp18, cancellationToken);
          await oprot.WriteI32Async(ObjectTypePtr, cancellationToken);
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
      if (that is not TArrayTypeEntry other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.objectTypePtr == other.__isset.objectTypePtr) && ((!__isset.objectTypePtr) || (global::System.Object.Equals(ObjectTypePtr, other.ObjectTypePtr))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.objectTypePtr)
        {
          hashcode = (hashcode * 397) + ObjectTypePtr.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp19 = new StringBuilder("TArrayTypeEntry(");
      int tmp20 = 0;
      if(__isset.objectTypePtr)
      {
        if(0 < tmp20++) { tmp19.Append(", "); }
        tmp19.Append("ObjectTypePtr: ");
        ObjectTypePtr.ToString(tmp19);
      }
      tmp19.Append(')');
      return tmp19.ToString();
    }
  }

}
