using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;

namespace DataBricks.Sql.ThriftApi.TCLService
{
    public interface IProtocolGateway
    {
        Task ReadAsync(TProtocol protocol, CancellationToken cancellationToken);
        Task WriteAsync(TProtocol protocol, CancellationToken cancellationToken);
    }
    
    
    /// <summary>
    /// Skip Method is not implemented in .Net Thrift library
    /// </summary>
    public static class ProtocolExtensions
    {
       
        public static async Task SkipAsync(this TProtocol protocol, TField field,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await TProtocolUtil.SkipAsync(protocol, field.Type, cancellationToken);
        }

        public static async Task WriteFieldAsync(this TProtocol protocol,
            string name,
            TType type,
            IProtocolGateway gateway,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (gateway == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, type, id), cancellationToken);
            await gateway.WriteAsync(protocol, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        
        public static async Task WriteStructFieldAsync(this TProtocol protocol,
            string name,
            IProtocolGateway gateway,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (gateway == null) return;
            await protocol.WriteFieldAsync(name, TType.Struct, gateway, id, cancellationToken);
        }
        
        public static async Task WriteBoolFieldAsync(this TProtocol protocol,
            string name,
            bool? value,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (value == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, TType.Bool, id), cancellationToken);
            await protocol.WriteBoolAsync(value.Value, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        
        public static async Task WriteDoubleFieldAsync(this TProtocol protocol,
            string name,
            double? value,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (value == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, TType.Double, id), cancellationToken);
            await protocol.WriteDoubleAsync(value.Value, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        
        public static async Task WriteI64FieldAsync(this TProtocol protocol,
            string name,
            long? value,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (value == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, TType.I64, id), cancellationToken);
            await protocol.WriteI64Async(value.Value, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        
        public static async Task WriteI32FieldAsync(this TProtocol protocol,
            string name,
            int? value,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (value == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, TType.I32, id), cancellationToken);
            await protocol.WriteI32Async(value.Value, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        
        public static async Task WriteI16FieldAsync(this TProtocol protocol,
            string name,
            short? value,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (value == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, TType.I16, id), cancellationToken);
            await protocol.WriteI16Async(value.Value, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        

        
        public static async Task WriteStringFieldAsync(this TProtocol protocol,
            string name,
            object value,
            short id,
            CancellationToken cancellationToken = default)
        {
            if (value == null) return;
            await protocol.WriteFieldBeginAsync(new TField(name, TType.String, id), cancellationToken);
            if (value.GetType() == typeof(string))
                await protocol.WriteStringAsync((string)value, cancellationToken);
            else 
                await protocol.WriteBinaryAsync((byte[])value, cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }
        
        public static async Task ReadStructAsync(this TProtocol protocol, Func<TField, Task> functionAsync, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await protocol.ReadStructBeginAsync(cancellationToken);

            while (true)
            {
                var field = await protocol.ReadFieldBeginAsync(cancellationToken);
                if (field.Type == TType.Stop) break;
                await functionAsync(field);
                await protocol.ReadFieldEndAsync(cancellationToken);
            }

            await protocol.ReadStructEndAsync(cancellationToken);
        }
        

        public static async Task WriteStructAsync(this TProtocol protocol,
            TGroup structGroup,
            CancellationToken cancellationToken = default)
        {
            await protocol.WriteStructBeginAsync(new TStruct(structGroup.Name), cancellationToken);

            foreach (var elt in structGroup.Group)
            {
                if (elt.Value == null)
                    continue;
                
                switch (elt.Type)
                {
                    case TType.Struct:
                        await protocol.WriteStructFieldAsync(elt.Name, (IProtocolGateway)elt.Value, elt.Id,
                            cancellationToken);
                        break;
                    
                    case TType.Map:
                        await protocol.WriteStringMapFieldAsync(elt.Name, (Dictionary<string, string>)(elt.Value), elt.Id,  cancellationToken);
                        break;

                    case TType.Bool:
                        await protocol.WriteBoolFieldAsync(elt.Name, (bool)(elt.Value),
                            elt.Id, cancellationToken);
                        break;
                    case TType.Double:
                        await protocol.WriteDoubleFieldAsync(elt.Name, (double)(elt.Value),
                            elt.Id, cancellationToken);;
                        break;
                    case TType.I16:
                        await protocol.WriteI16FieldAsync(elt.Name, (short)(elt.Value),
                            elt.Id, cancellationToken);;
                        break;
                    case TType.I32:
                        await protocol.WriteI32FieldAsync(elt.Name, (int)(elt.Value),
                            elt.Id, cancellationToken);;
                        break;
                    case TType.I64:
                        await protocol.WriteI64FieldAsync(elt.Name, (long)(elt.Value),
                            elt.Id, cancellationToken);;
                        break;
                    case TType.String:
                        await protocol.WriteStringFieldAsync(elt.Name, (string)(elt.Value),
                            elt.Id, cancellationToken);;
                        break;
                    
                    case TType.List:
                        if (elt.Value is ICollection<TProtocolGateway>)
                        {
                            var l = (List<object>)(elt.Value);
                            await protocol.WriteListBeginAsync(new TList(TType.Struct, l.Count), cancellationToken);
                            foreach (var e in l)
                            {
                                if (e is TProtocolGateway)
                                    await ((TProtocolGateway)e).WriteAsync(protocol, cancellationToken);
                            }

                            await protocol.WriteListEndAsync(cancellationToken);
                            break;
                        }
                        
                        
                        if (elt.IsNested)
                            await protocol.WriteNestedStringListFiledAsync(elt.Name, (List<List<string>>)elt.Value, elt.Id, cancellationToken);
                        else 
                            await protocol.WriteStringListFiledAsync(elt.Name, (List<string>)(elt.Value), elt.Id, cancellationToken);
                        break;
                    default:
                        throw new Exception($"Unable to write type {elt.Type}");
                }
            }
            

            await protocol.WriteFieldStopAsync(cancellationToken);
            await protocol.WriteStructEndAsync(cancellationToken);
            
        }

        public static async Task WriteStringMapFieldAsync(this TProtocol protocol, string name,  Dictionary<string, string> map,
            short id, CancellationToken cancellationToken)
        {
            await protocol.WriteFieldBeginAsync(new TField(name, TType.Map, id), cancellationToken);
            await protocol.WriteMapBeginAsync(new TMap(TType.String, TType.String, map.Keys.Count), cancellationToken);

            foreach (var (key, value) in map)
            {
                await protocol.WriteStringAsync(key, cancellationToken);
                await protocol.WriteStringAsync(value, cancellationToken);
            }

            await protocol.WriteMapEndAsync(cancellationToken);
            await protocol.WriteFieldEndAsync(cancellationToken);
        }

        public static async Task WriteStringListFiledAsync(this TProtocol protocol, string name,  List<string> list, short id, CancellationToken cancellationToken = default)
        {
            await protocol.WriteFieldBeginAsync(new TField(name, TType.List, id), cancellationToken);
            await protocol.WriteListBeginAsync(new TList(TType.String, list.Count), cancellationToken);

            foreach (var e in list)
            {
                await protocol.WriteStringAsync(e, cancellationToken);
            }
            
            await protocol.WriteListEndAsync(cancellationToken);
            await protocol.WriteFieldStopAsync(cancellationToken);
        }
        
        public static async Task WriteNestedStringListFiledAsync(this TProtocol protocol, string name,  List<List<string>> list, short id, CancellationToken cancellationToken = default)
        {
            await protocol.WriteFieldBeginAsync(new TField(name, TType.List, id), cancellationToken);
            await protocol.WriteListBeginAsync(new TList(TType.String, list.Count), cancellationToken);

            foreach (var e in list)
            {
                await protocol.WriteListBeginAsync(new TList(TType.String, e.Count), cancellationToken);
                foreach (var ne in e)
                {
                    await protocol.WriteStringAsync(ne, cancellationToken);
                }

               
                await protocol.WriteListEndAsync(cancellationToken);
            }
            
            await protocol.WriteListEndAsync(cancellationToken);
            await protocol.WriteFieldStopAsync(cancellationToken);
        }
        
        public static async Task<List<string>> ReadStringListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<string>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
               result.Add(await protocol.ReadStringAsync(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<bool>> ReadBoolListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<bool>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadBoolAsync(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<sbyte>> ReadByteListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<sbyte>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadByteAsync(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<short>> ReadI16ListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<short>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadI16Async(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<int>> ReadI32ListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<int>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadI32Async(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<long>> ReadI64ListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<long>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadI64Async(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<double>> ReadDoubleListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<double>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadDoubleAsync(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<byte[]>> ReadBinaryListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<byte[]>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
                result.Add(await protocol.ReadBinaryAsync(cancellationToken));

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        
        public static async Task<List<List<string>>> ReadNestedStringListAsync(this TProtocol protocol, CancellationToken cancellationToken = default)
        {
            var result = new List<List<string>>();
            var l = await protocol.ReadListBeginAsync(cancellationToken);

            for (var i = 0; i < l.Count; i++)
            {
                var nl = await protocol.ReadListBeginAsync(cancellationToken);
                var nResult = new List<string>();
                for (var j = 0; i < nl.Count; j++)
                {
                    nResult.Add(await protocol.ReadStringAsync(cancellationToken));
                }
                result.Add(nResult);
                await protocol.ReadListEndAsync(cancellationToken);
            }
                

            await protocol.ReadListEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<Dictionary<string, string>> ReadMapAsync(this TProtocol protocol, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, string>();
            var map = await protocol.ReadMapBeginAsync(cancellationToken);

            for (var i = 0; i < map.Count; i++)
            {
                var key = await protocol.ReadStringAsync(cancellationToken);
                result[key] = await protocol.ReadStringAsync(cancellationToken);
            }

            await protocol.ReadMapEndAsync(cancellationToken);

            return result;
        }
        
        public static async Task<List<T>> ReadListAsync<T>(this TProtocol protocol, CancellationToken cancellationToken) where T : TProtocolGateway, new()
        {
            var result = new List<T>();
            var list = await protocol.ReadListBeginAsync(cancellationToken);
            for (var i = 0; i < list.Count; i++)
            {
                var e = new T();
                await e.ReadAsync(protocol, cancellationToken);
                result.Add(e);
            }

            await protocol.ReadListEndAsync(cancellationToken);
            return result;

        }
        
      
        
    }

    public class TGroup
    {
        public TGroup(string name, TElement[] group)
        {
            Name = name;
            Group = group;
        }

        public string Name { get; set; }
        public TElement[] Group;
    }

    public class TElement
    {
        public TElement(string name, TType type, object value, short id, bool isNested = false)
        {
            Name = name;
            Type = type;
            Id = id;
            Value = value;
            IsNested = isNested;
        }

        public bool IsNested { get; set; }

        public object Value;

        public short Id { get; set; }
        

        public TType Type { get; set; }

        public string Name { get; set; }
    }
}