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

  public partial class TGetInfoValue : TBase
  {
    private string? _stringValue;
    private short _smallIntValue;
    private int _integerBitmask;
    private int _integerFlag;
    private int _binaryValue;
    private long _lenValue;

    public string? StringValue
    {
      get
      {
        return _stringValue;
      }
      set
      {
        __isset.stringValue = true;
        this._stringValue = value;
      }
    }

    public short SmallIntValue
    {
      get
      {
        return _smallIntValue;
      }
      set
      {
        __isset.smallIntValue = true;
        this._smallIntValue = value;
      }
    }

    public int IntegerBitmask
    {
      get
      {
        return _integerBitmask;
      }
      set
      {
        __isset.integerBitmask = true;
        this._integerBitmask = value;
      }
    }

    public int IntegerFlag
    {
      get
      {
        return _integerFlag;
      }
      set
      {
        __isset.integerFlag = true;
        this._integerFlag = value;
      }
    }

    public int BinaryValue
    {
      get
      {
        return _binaryValue;
      }
      set
      {
        __isset.binaryValue = true;
        this._binaryValue = value;
      }
    }

    public long LenValue
    {
      get
      {
        return _lenValue;
      }
      set
      {
        __isset.lenValue = true;
        this._lenValue = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool stringValue;
      public bool smallIntValue;
      public bool integerBitmask;
      public bool integerFlag;
      public bool binaryValue;
      public bool lenValue;
    }

    public TGetInfoValue()
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
                StringValue = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I16)
              {
                SmallIntValue = await iprot.ReadI16Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.I32)
              {
                IntegerBitmask = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.I32)
              {
                IntegerFlag = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.I32)
              {
                BinaryValue = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.I64)
              {
                LenValue = await iprot.ReadI64Async(cancellationToken);
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
        var tmp296 = new TStruct("TGetInfoValue");
        await oprot.WriteStructBeginAsync(tmp296, cancellationToken);
        var tmp297 = new TField();
        if((StringValue != null) && __isset.stringValue)
        {
          tmp297.Name = "stringValue";
          tmp297.Type = TType.String;
          tmp297.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp297, cancellationToken);
          await oprot.WriteStringAsync(StringValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.smallIntValue)
        {
          tmp297.Name = "smallIntValue";
          tmp297.Type = TType.I16;
          tmp297.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp297, cancellationToken);
          await oprot.WriteI16Async(SmallIntValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.integerBitmask)
        {
          tmp297.Name = "integerBitmask";
          tmp297.Type = TType.I32;
          tmp297.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp297, cancellationToken);
          await oprot.WriteI32Async(IntegerBitmask, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.integerFlag)
        {
          tmp297.Name = "integerFlag";
          tmp297.Type = TType.I32;
          tmp297.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp297, cancellationToken);
          await oprot.WriteI32Async(IntegerFlag, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.binaryValue)
        {
          tmp297.Name = "binaryValue";
          tmp297.Type = TType.I32;
          tmp297.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp297, cancellationToken);
          await oprot.WriteI32Async(BinaryValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.lenValue)
        {
          tmp297.Name = "lenValue";
          tmp297.Type = TType.I64;
          tmp297.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp297, cancellationToken);
          await oprot.WriteI64Async(LenValue, cancellationToken);
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
      if (that is not TGetInfoValue other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.stringValue == other.__isset.stringValue) && ((!__isset.stringValue) || (global::System.Object.Equals(StringValue, other.StringValue))))
        && ((__isset.smallIntValue == other.__isset.smallIntValue) && ((!__isset.smallIntValue) || (global::System.Object.Equals(SmallIntValue, other.SmallIntValue))))
        && ((__isset.integerBitmask == other.__isset.integerBitmask) && ((!__isset.integerBitmask) || (global::System.Object.Equals(IntegerBitmask, other.IntegerBitmask))))
        && ((__isset.integerFlag == other.__isset.integerFlag) && ((!__isset.integerFlag) || (global::System.Object.Equals(IntegerFlag, other.IntegerFlag))))
        && ((__isset.binaryValue == other.__isset.binaryValue) && ((!__isset.binaryValue) || (global::System.Object.Equals(BinaryValue, other.BinaryValue))))
        && ((__isset.lenValue == other.__isset.lenValue) && ((!__isset.lenValue) || (global::System.Object.Equals(LenValue, other.LenValue))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((StringValue != null) && __isset.stringValue)
        {
          hashcode = (hashcode * 397) + StringValue.GetHashCode();
        }
        if(__isset.smallIntValue)
        {
          hashcode = (hashcode * 397) + SmallIntValue.GetHashCode();
        }
        if(__isset.integerBitmask)
        {
          hashcode = (hashcode * 397) + IntegerBitmask.GetHashCode();
        }
        if(__isset.integerFlag)
        {
          hashcode = (hashcode * 397) + IntegerFlag.GetHashCode();
        }
        if(__isset.binaryValue)
        {
          hashcode = (hashcode * 397) + BinaryValue.GetHashCode();
        }
        if(__isset.lenValue)
        {
          hashcode = (hashcode * 397) + LenValue.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp298 = new StringBuilder("TGetInfoValue(");
      int tmp299 = 0;
      if((StringValue != null) && __isset.stringValue)
      {
        if(0 < tmp299++) { tmp298.Append(", "); }
        tmp298.Append("StringValue: ");
        StringValue.ToString(tmp298);
      }
      if(__isset.smallIntValue)
      {
        if(0 < tmp299++) { tmp298.Append(", "); }
        tmp298.Append("SmallIntValue: ");
        SmallIntValue.ToString(tmp298);
      }
      if(__isset.integerBitmask)
      {
        if(0 < tmp299++) { tmp298.Append(", "); }
        tmp298.Append("IntegerBitmask: ");
        IntegerBitmask.ToString(tmp298);
      }
      if(__isset.integerFlag)
      {
        if(0 < tmp299++) { tmp298.Append(", "); }
        tmp298.Append("IntegerFlag: ");
        IntegerFlag.ToString(tmp298);
      }
      if(__isset.binaryValue)
      {
        if(0 < tmp299++) { tmp298.Append(", "); }
        tmp298.Append("BinaryValue: ");
        BinaryValue.ToString(tmp298);
      }
      if(__isset.lenValue)
      {
        if(0 < tmp299++) { tmp298.Append(", "); }
        tmp298.Append("LenValue: ");
        LenValue.ToString(tmp298);
      }
      tmp298.Append(')');
      return tmp298.ToString();
    }
  }

}
