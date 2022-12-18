/**
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */

#nullable enable                 // requires C# 8.0
#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static

namespace DataBricks.Sql.ThriftApi.TCLService.TTypes
{
  public enum TOperationType
  {
    EXECUTE_STATEMENT = 0,
    GET_TYPE_INFO = 1,
    GET_CATALOGS = 2,
    GET_SCHEMAS = 3,
    GET_TABLES = 4,
    GET_TABLE_TYPES = 5,
    GET_COLUMNS = 6,
    GET_FUNCTIONS = 7,
    UNKNOWN = 8,
  }
}
