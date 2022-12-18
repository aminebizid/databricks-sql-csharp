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

  public partial class TUserDefinedTypeEntry : TBase
  {
    private string? _typeClassName;

    public string? TypeClassName
    {
      get
      {
        return _typeClassName;
      }
      set
      {
        __isset.typeClassName = true;
        this._typeClassName = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool typeClassName;
    }

    public TUserDefinedTypeEntry()
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
                TypeClassName = await iprot.ReadStringAsync(cancellationToken);
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
        var tmp43 = new TStruct("TUserDefinedTypeEntry");
        await oprot.WriteStructBeginAsync(tmp43, cancellationToken);
        var tmp44 = new TField();
        if((TypeClassName != null) && __isset.typeClassName)
        {
          tmp44.Name = "typeClassName";
          tmp44.Type = TType.String;
          tmp44.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp44, cancellationToken);
          await oprot.WriteStringAsync(TypeClassName, cancellationToken);
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
      if (that is not TUserDefinedTypeEntry other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.typeClassName == other.__isset.typeClassName) && ((!__isset.typeClassName) || (global::System.Object.Equals(TypeClassName, other.TypeClassName))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((TypeClassName != null) && __isset.typeClassName)
        {
          hashcode = (hashcode * 397) + TypeClassName.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp45 = new StringBuilder("TUserDefinedTypeEntry(");
      int tmp46 = 0;
      if((TypeClassName != null) && __isset.typeClassName)
      {
        if(0 < tmp46++) { tmp45.Append(", "); }
        tmp45.Append("TypeClassName: ");
        TypeClassName.ToString(tmp45);
      }
      tmp45.Append(')');
      return tmp45.ToString();
    }
  }

}