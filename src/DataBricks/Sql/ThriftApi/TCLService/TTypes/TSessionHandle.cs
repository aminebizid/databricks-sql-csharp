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

  public partial class TSessionHandle : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.THandleIdentifier? _sessionId;
    private int _serverProtocolVersion;

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.THandleIdentifier? SessionId
    {
      get
      {
        return _sessionId;
      }
      set
      {
        __isset.sessionId = true;
        this._sessionId = value;
      }
    }

    public int ServerProtocolVersion
    {
      get
      {
        return _serverProtocolVersion;
      }
      set
      {
        __isset.serverProtocolVersion = true;
        this._serverProtocolVersion = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool sessionId;
      public bool serverProtocolVersion;
    }

    public TSessionHandle()
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
              if (field.Type == TType.Struct)
              {
                SessionId = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.THandleIdentifier();
                await SessionId.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.I32)
              {
                ServerProtocolVersion = await iprot.ReadI32Async(cancellationToken);
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
        var tmp249 = new TStruct("TSessionHandle");
        await oprot.WriteStructBeginAsync(tmp249, cancellationToken);
        var tmp250 = new TField();
        if((SessionId != null) && __isset.sessionId)
        {
          tmp250.Name = "sessionId";
          tmp250.Type = TType.Struct;
          tmp250.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp250, cancellationToken);
          await SessionId.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.serverProtocolVersion)
        {
          tmp250.Name = "serverProtocolVersion";
          tmp250.Type = TType.I32;
          tmp250.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp250, cancellationToken);
          await oprot.WriteI32Async(ServerProtocolVersion, cancellationToken);
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
      if (that is not TSessionHandle other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.sessionId == other.__isset.sessionId) && ((!__isset.sessionId) || (global::System.Object.Equals(SessionId, other.SessionId))))
        && ((__isset.serverProtocolVersion == other.__isset.serverProtocolVersion) && ((!__isset.serverProtocolVersion) || (global::System.Object.Equals(ServerProtocolVersion, other.ServerProtocolVersion))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((SessionId != null) && __isset.sessionId)
        {
          hashcode = (hashcode * 397) + SessionId.GetHashCode();
        }
        if(__isset.serverProtocolVersion)
        {
          hashcode = (hashcode * 397) + ServerProtocolVersion.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp251 = new StringBuilder("TSessionHandle(");
      int tmp252 = 0;
      if((SessionId != null) && __isset.sessionId)
      {
        if(0 < tmp252++) { tmp251.Append(", "); }
        tmp251.Append("SessionId: ");
        SessionId.ToString(tmp251);
      }
      if(__isset.serverProtocolVersion)
      {
        if(0 < tmp252++) { tmp251.Append(", "); }
        tmp251.Append("ServerProtocolVersion: ");
        ServerProtocolVersion.ToString(tmp251);
      }
      tmp251.Append(')');
      return tmp251.ToString();
    }
  }

}
