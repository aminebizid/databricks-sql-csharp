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

  public partial class TOpenSessionResp : TBase
  {
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? _status;
    private int _serverProtocolVersion;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? _sessionHandle;
    private Dictionary<string, string>? _configuration;
    private global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TNamespace? _initialNamespace;
    private bool _canUseMultipleCatalogs;
    private List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetInfoValue>? _getInfos;

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus? Status
    {
      get
      {
        return _status;
      }
      set
      {
        __isset.status = true;
        this._status = value;
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

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle? SessionHandle
    {
      get
      {
        return _sessionHandle;
      }
      set
      {
        __isset.sessionHandle = true;
        this._sessionHandle = value;
      }
    }

    public Dictionary<string, string>? Configuration
    {
      get
      {
        return _configuration;
      }
      set
      {
        __isset.configuration = true;
        this._configuration = value;
      }
    }

    public global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TNamespace? InitialNamespace
    {
      get
      {
        return _initialNamespace;
      }
      set
      {
        __isset.initialNamespace = true;
        this._initialNamespace = value;
      }
    }

    public bool CanUseMultipleCatalogs
    {
      get
      {
        return _canUseMultipleCatalogs;
      }
      set
      {
        __isset.canUseMultipleCatalogs = true;
        this._canUseMultipleCatalogs = value;
      }
    }

    public List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetInfoValue>? GetInfos
    {
      get
      {
        return _getInfos;
      }
      set
      {
        __isset.getInfos = true;
        this._getInfos = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool status;
      public bool serverProtocolVersion;
      public bool sessionHandle;
      public bool configuration;
      public bool initialNamespace;
      public bool canUseMultipleCatalogs;
      public bool getInfos;
    }

    public TOpenSessionResp()
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
                Status = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TStatus();
                await Status.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I32)
              {
                ServerProtocolVersion = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                SessionHandle = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TSessionHandle();
                await SessionHandle.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.Map)
              {
                {
                  var _map275 = await iprot.ReadMapBeginAsync(cancellationToken);
                  Configuration = new Dictionary<string, string>(_map275.Count);
                  for(int _i276 = 0; _i276 < _map275.Count; ++_i276)
                  {
                    string _key277;
                    string _val278;
                    _key277 = await iprot.ReadStringAsync(cancellationToken);
                    _val278 = await iprot.ReadStringAsync(cancellationToken);
                    Configuration[_key277] = _val278;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1284:
              if (field.Type == TType.Struct)
              {
                InitialNamespace = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TNamespace();
                await InitialNamespace.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1285:
              if (field.Type == TType.Bool)
              {
                CanUseMultipleCatalogs = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1281:
              if (field.Type == TType.List)
              {
                {
                  var _list279 = await iprot.ReadListBeginAsync(cancellationToken);
                  GetInfos = new List<global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetInfoValue>(_list279.Count);
                  for(int _i280 = 0; _i280 < _list279.Count; ++_i280)
                  {
                    global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetInfoValue _elem281;
                    _elem281 = new global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetInfoValue();
                    await _elem281.ReadAsync(iprot, cancellationToken);
                    GetInfos.Add(_elem281);
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
        var tmp282 = new TStruct("TOpenSessionResp");
        await oprot.WriteStructBeginAsync(tmp282, cancellationToken);
        var tmp283 = new TField();
        if((Status != null) && __isset.status)
        {
          tmp283.Name = "status";
          tmp283.Type = TType.Struct;
          tmp283.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await Status.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.serverProtocolVersion)
        {
          tmp283.Name = "serverProtocolVersion";
          tmp283.Type = TType.I32;
          tmp283.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await oprot.WriteI32Async(ServerProtocolVersion, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          tmp283.Name = "sessionHandle";
          tmp283.Type = TType.Struct;
          tmp283.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Configuration != null) && __isset.configuration)
        {
          tmp283.Name = "configuration";
          tmp283.Type = TType.Map;
          tmp283.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, Configuration.Count), cancellationToken);
          foreach (string _iter284 in Configuration.Keys)
          {
            await oprot.WriteStringAsync(_iter284, cancellationToken);
            await oprot.WriteStringAsync(Configuration[_iter284], cancellationToken);
          }
          await oprot.WriteMapEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((GetInfos != null) && __isset.getInfos)
        {
          tmp283.Name = "getInfos";
          tmp283.Type = TType.List;
          tmp283.ID = 1281;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, GetInfos.Count), cancellationToken);
          foreach (global::DataBricks.Sql.ThriftApi.TCLService.TTypes.TGetInfoValue _iter285 in GetInfos)
          {
            await _iter285.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((InitialNamespace != null) && __isset.initialNamespace)
        {
          tmp283.Name = "initialNamespace";
          tmp283.Type = TType.Struct;
          tmp283.ID = 1284;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await InitialNamespace.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.canUseMultipleCatalogs)
        {
          tmp283.Name = "canUseMultipleCatalogs";
          tmp283.Type = TType.Bool;
          tmp283.ID = 1285;
          await oprot.WriteFieldBeginAsync(tmp283, cancellationToken);
          await oprot.WriteBoolAsync(CanUseMultipleCatalogs, cancellationToken);
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
      if (that is not TOpenSessionResp other) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.status == other.__isset.status) && ((!__isset.status) || (global::System.Object.Equals(Status, other.Status))))
        && ((__isset.serverProtocolVersion == other.__isset.serverProtocolVersion) && ((!__isset.serverProtocolVersion) || (global::System.Object.Equals(ServerProtocolVersion, other.ServerProtocolVersion))))
        && ((__isset.sessionHandle == other.__isset.sessionHandle) && ((!__isset.sessionHandle) || (global::System.Object.Equals(SessionHandle, other.SessionHandle))))
        && ((__isset.configuration == other.__isset.configuration) && ((!__isset.configuration) || (TCollections.Equals(Configuration, other.Configuration))))
        && ((__isset.initialNamespace == other.__isset.initialNamespace) && ((!__isset.initialNamespace) || (global::System.Object.Equals(InitialNamespace, other.InitialNamespace))))
        && ((__isset.canUseMultipleCatalogs == other.__isset.canUseMultipleCatalogs) && ((!__isset.canUseMultipleCatalogs) || (global::System.Object.Equals(CanUseMultipleCatalogs, other.CanUseMultipleCatalogs))))
        && ((__isset.getInfos == other.__isset.getInfos) && ((!__isset.getInfos) || (TCollections.Equals(GetInfos, other.GetInfos))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Status != null) && __isset.status)
        {
          hashcode = (hashcode * 397) + Status.GetHashCode();
        }
        if(__isset.serverProtocolVersion)
        {
          hashcode = (hashcode * 397) + ServerProtocolVersion.GetHashCode();
        }
        if((SessionHandle != null) && __isset.sessionHandle)
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        if((Configuration != null) && __isset.configuration)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Configuration);
        }
        if((InitialNamespace != null) && __isset.initialNamespace)
        {
          hashcode = (hashcode * 397) + InitialNamespace.GetHashCode();
        }
        if(__isset.canUseMultipleCatalogs)
        {
          hashcode = (hashcode * 397) + CanUseMultipleCatalogs.GetHashCode();
        }
        if((GetInfos != null) && __isset.getInfos)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(GetInfos);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp286 = new StringBuilder("TOpenSessionResp(");
      int tmp287 = 0;
      if((Status != null) && __isset.status)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("Status: ");
        Status.ToString(tmp286);
      }
      if(__isset.serverProtocolVersion)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("ServerProtocolVersion: ");
        ServerProtocolVersion.ToString(tmp286);
      }
      if((SessionHandle != null) && __isset.sessionHandle)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("SessionHandle: ");
        SessionHandle.ToString(tmp286);
      }
      if((Configuration != null) && __isset.configuration)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("Configuration: ");
        Configuration.ToString(tmp286);
      }
      if((InitialNamespace != null) && __isset.initialNamespace)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("InitialNamespace: ");
        InitialNamespace.ToString(tmp286);
      }
      if(__isset.canUseMultipleCatalogs)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("CanUseMultipleCatalogs: ");
        CanUseMultipleCatalogs.ToString(tmp286);
      }
      if((GetInfos != null) && __isset.getInfos)
      {
        if(0 < tmp287++) { tmp286.Append(", "); }
        tmp286.Append("GetInfos: ");
        GetInfos.ToString(tmp286);
      }
      tmp286.Append(')');
      return tmp286.ToString();
    }
  }

}
