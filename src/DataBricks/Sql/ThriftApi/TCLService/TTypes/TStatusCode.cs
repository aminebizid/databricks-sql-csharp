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
  public enum TStatusCode
  {
    SUCCESS_STATUS = 0,
    SUCCESS_WITH_INFO_STATUS = 1,
    STILL_EXECUTING_STATUS = 2,
    ERROR_STATUS = 3,
    INVALID_HANDLE_STATUS = 4,
  }
}
