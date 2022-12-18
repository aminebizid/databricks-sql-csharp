namespace netstd DataBricks.Sql.ThriftApi.TCLService.TTypes

typedef i32 int // We can use typedef to get pretty names for the types we are using

enum TProtocolVersion{
     __HIVE_JDBC_WORKAROUND = -7,
    __TEST_PROTOCOL_VERSION = 65281,
    HIVE_CLI_SERVICE_PROTOCOL_V1 = 0,
    HIVE_CLI_SERVICE_PROTOCOL_V2 = 1,
    HIVE_CLI_SERVICE_PROTOCOL_V3 = 2,
    HIVE_CLI_SERVICE_PROTOCOL_V4 = 3,
    HIVE_CLI_SERVICE_PROTOCOL_V5 = 4,
    HIVE_CLI_SERVICE_PROTOCOL_V6 = 5,
    HIVE_CLI_SERVICE_PROTOCOL_V7 = 6,
    HIVE_CLI_SERVICE_PROTOCOL_V8 = 7,
    HIVE_CLI_SERVICE_PROTOCOL_V9 = 8,
    HIVE_CLI_SERVICE_PROTOCOL_V10 = 9,
    SPARK_CLI_SERVICE_PROTOCOL_V1 = 42241,
    SPARK_CLI_SERVICE_PROTOCOL_V2 = 42242,
    SPARK_CLI_SERVICE_PROTOCOL_V3 = 42243,
    SPARK_CLI_SERVICE_PROTOCOL_V4 = 42244,
    SPARK_CLI_SERVICE_PROTOCOL_V5 = 42245,
    SPARK_CLI_SERVICE_PROTOCOL_V6 = 42246,
}

enum TTypeId {
    BOOLEAN_TYPE = 0,
    TINYINT_TYPE = 1,
    SMALLINT_TYPE = 2,
    INT_TYPE = 3,
    BIGINT_TYPE = 4,
    FLOAT_TYPE = 5,
    DOUBLE_TYPE = 6,
    STRING_TYPE = 7,
    TIMESTAMP_TYPE = 8,
    BINARY_TYPE = 9,
    ARRAY_TYPE = 10,
    MAP_TYPE = 11,
    STRUCT_TYPE = 12,
    UNION_TYPE = 13,
    USER_DEFINED_TYPE = 14,
    DECIMAL_TYPE = 15,
    NULL_TYPE = 16,
    DATE_TYPE = 17,
    VARCHAR_TYPE = 18,
    CHAR_TYPE = 19,
    INTERVAL_YEAR_MONTH_TYPE = 20,
    INTERVAL_DAY_TIME_TYPE = 21,
}

enum TSparkRowSetType {
    ARROW_BASED_SET = 0,
    COLUMN_BASED_SET = 1,
    ROW_BASED_SET = 2,
    URL_BASED_SET = 3,
}

enum TStatusCode {
    SUCCESS_STATUS = 0,
    SUCCESS_WITH_INFO_STATUS = 1,
    STILL_EXECUTING_STATUS = 2,
    ERROR_STATUS = 3,
    INVALID_HANDLE_STATUS = 4,
}

enum TOperationState {
    INITIALIZED_STATE = 0,
    RUNNING_STATE = 1,
    FINISHED_STATE = 2,
    CANCELED_STATE = 3,
    CLOSED_STATE = 4,
    ERROR_STATE = 5,
    UKNOWN_STATE = 6,
    PENDING_STATE = 7,
    TIMEDOUT_STATE = 8,
}

enum TOperationType {
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

enum TGetInfoType {
    CLI_MAX_DRIVER_CONNECTIONS = 0,
    CLI_MAX_CONCURRENT_ACTIVITIES = 1,
    CLI_DATA_SOURCE_NAME = 2,
    CLI_FETCH_DIRECTION = 8,
    CLI_SERVER_NAME = 13,
    CLI_SEARCH_PATTERN_ESCAPE = 14,
    CLI_DBMS_NAME = 17,
    CLI_DBMS_VER = 18,
    CLI_ACCESSIBLE_TABLES = 19,
    CLI_ACCESSIBLE_PROCEDURES = 20,
    CLI_CURSOR_COMMIT_BEHAVIOR = 23,
    CLI_DATA_SOURCE_READ_ONLY = 25,
    CLI_DEFAULT_TXN_ISOLATION = 26,
    CLI_IDENTIFIER_CASE = 28,
    CLI_IDENTIFIER_QUOTE_CHAR = 29,
    CLI_MAX_COLUMN_NAME_LEN = 30,
    CLI_MAX_CURSOR_NAME_LEN = 31,
    CLI_MAX_SCHEMA_NAME_LEN = 32,
    CLI_MAX_CATALOG_NAME_LEN = 34,
    CLI_MAX_TABLE_NAME_LEN = 35,
    CLI_SCROLL_CONCURRENCY = 43,
    CLI_TXN_CAPABLE = 46,
    CLI_USER_NAME = 47,
    CLI_TXN_ISOLATION_OPTION = 72,
    CLI_INTEGRITY = 73,
    CLI_GETDATA_EXTENSIONS = 81,
    CLI_NULL_COLLATION = 85,
    CLI_ALTER_TABLE = 86,
    CLI_ORDER_BY_COLUMNS_IN_SELECT = 90,
    CLI_SPECIAL_CHARACTERS = 94,
    CLI_MAX_COLUMNS_IN_GROUP_BY = 97,
    CLI_MAX_COLUMNS_IN_INDEX = 98,
    CLI_MAX_COLUMNS_IN_ORDER_BY = 99,
    CLI_MAX_COLUMNS_IN_SELECT = 100,
    CLI_MAX_COLUMNS_IN_TABLE = 101,
    CLI_MAX_INDEX_SIZE = 102,
    CLI_MAX_ROW_SIZE = 104,
    CLI_MAX_STATEMENT_LEN = 105,
    CLI_MAX_TABLES_IN_SELECT = 106,
    CLI_MAX_USER_NAME_LEN = 107,
    CLI_OJ_CAPABILITIES = 115,
    CLI_XOPEN_CLI_YEAR = 10000,
    CLI_CURSOR_SENSITIVITY = 10001,
    CLI_DESCRIBE_PARAMETER = 10002,
    CLI_CATALOG_NAME = 10003,
    CLI_COLLATION_SEQ = 10004,
    CLI_MAX_IDENTIFIER_LEN = 10005
}

enum TFetchOrientation {
    FETCH_NEXT = 0,
    FETCH_PRIOR = 1,
    FETCH_RELATIVE = 2,
    FETCH_ABSOLUTE = 3,
    FETCH_FIRST = 4,
    FETCH_LAST = 5
}

enum TJobExecutionStatus {
    IN_PROGRESS = 0,
    COMPLETE = 1,
    NOT_AVAILABLE = 2
}

struct TTypeQualifierValue {
    1: i32 i32Value,
    2: string stringValue
}

struct TTypeQualifiers {
    1: map<string, TTypeQualifierValue> qualifiers
}

struct TPrimitiveTypeEntry {
    1: TTypeId type,
    2: TTypeQualifiers typeQualifiers
}

struct TArrayTypeEntry {
    1: i32 objectTypePtr,
}

struct TMapTypeEntry {
    1: i32 keyTypePtr,
    2: i32 valueTypePtr
}

struct TStructTypeEntry {
    1: map<string, i32> nameToTypePtr
}

struct TUnionTypeEntry {
    1: map<string, i32> nameToTypePtr
}

struct TUserDefinedTypeEntry {
    1: string typeClassName
}

struct TTypeEntry {
    1: TPrimitiveTypeEntry primitiveEntry,
    2: TArrayTypeEntry arrayEntry,
    3: TMapTypeEntry mapEntry,
    4: TStructTypeEntry structEntry,
    5: TUnionTypeEntry unionEntry,
    6: TUserDefinedTypeEntry userDefinedTypeEntry
}

struct TTypeDesc {
    1: list<TTypeEntry> types
}

struct TColumnDesc {
    1: string columnName,
    2: TTypeDesc typeDesc,
    3: i32 position,
    4: string comment
}

struct TTableSchema {
    1: list<TColumnDesc> columns
}

struct TBoolValue {
    1: bool value
}

struct TByteValue {
    1: i8 value
}

struct TI16Value {
    1: i16 value
}

struct TI32Value {
    1: i32 value
}

struct TI64Value {
    1: i64 value
}

struct TDoubleValue {
    1: double value
}

struct TStringValue {
    1: string value
}

struct TColumnValue {
    1: TBoolValue boolVal,
    2: TByteValue byteVal,
    3: TI16Value i16Val,
    4: TI32Value i32Val,
    5: TI64Value i64Val,
    6: TDoubleValue doubleVal,
    7: TStringValue stringVal
}

struct TRow {
    1: list<TColumnValue> colVals
}

struct TBoolColumn {
    1: list<bool> values,
    2: binary nulls
}

struct TByteColumn {
    1: list<i8> values,
    2: binary nulls
}

struct TI16Column {
    1: list<i16> values,
    2: binary nulls
}

struct TI32Column {
    1: list<i32> values,
    2: binary nulls
}

struct TI64Column {
    1: list<i64> values,
    2: binary nulls
}

struct TDoubleColumn {
    1: list<double> values,
    2: binary nulls
}

struct TStringColumn {
    1: list<string> values,
    2: binary nulls
}

struct TBinaryColumn {
    1: list<binary> values,
    2: binary nulls
}

struct TColumn {
    1: TBoolColumn boolVal,
    2: TByteColumn byteVal,
    3: TI16Column i16Val,
    4: TI32Column i32Val,
    5: TI64Column i64Val,
    6: TDoubleColumn doubleVal,
    7: TStringColumn stringVal,
    8: TBinaryColumn binaryVal
}

struct TSparkArrowBatch {
    1: binary batch,
    2: i64 rowCount
}

struct TSparkArrowResultLink {
    1: string fileLink,
    2: i64 expiryTime,
    3: i64 startRowOffset;
    4: i64 rowCount,
    5: i64 bytesNum
}

struct TRowSet {
    1: i64 startRowOffset,
    2: list<TRow> rows,
    3: list<TColumn> columns,
    4: binary binaryColumns,
    5: i32 columnCount,
    1281: list<TSparkArrowBatch> arrowBatches,
    1282: list<TSparkArrowResultLink> resultLinks
}

struct TDBSqlTempView {
    1: string name,
    2: string sqlStatement,
    3: map<string, string> properties,
    4: string viewSchema
}

struct TDBSqlSessionCapabilities {
    1: bool supportsMultipleCatalogs
}

struct TDBSqlSessionConf {
    1: map<string, string> confs,
    2: list<TDBSqlTempView> tempViews,
    3: string currentDatabase,
    4: string currentCatalog,
    5: TDBSqlSessionCapabilities sessionCapabilities
}

struct TStatus {
    1: i32 statusCode,
    2: list<string> infoMessages,
    3: string sqlState,
    4: i32 errorCode,
    5: string errorMessage
}

struct TNamespace {
    1: string catalogName,
    2: string schemaName
}

struct THandleIdentifier {
    1: binary guid,
    2: binary secret
}

struct TSessionHandle {
    1: THandleIdentifier sessionId,
    3329: i32 serverProtocolVersion
}

struct TOperationHandle {
    1: THandleIdentifier operationId,
    2: i32 operationType,
    3: bool hasResultSet,
    4: double modifiedRowCount
}

struct TOpenSessionReq {
    1: i32 client_protocol,
    2: string username,
    3: string password,
    4: map<string, string> configuration,
    1281: list<i32> getInfos
    1282: i64 client_protocol_i64,
    1283: map<string, string> connectionProperties,
    1284: TNamespace initialNamespace,
    1285: bool canUseMultipleCatalogs,
    3329: THandleIdentifier sessionId
}

struct TOpenSessionResp {
    1: TStatus status,
    2: i32 serverProtocolVersion,
    3: TSessionHandle sessionHandle,
    4: map<string, string> configuration,
    1284: TNamespace initialNamespace,
    1285: bool canUseMultipleCatalogs,
    1281: list<TGetInfoValue> getInfos
}

struct TCloseSessionReq {
    1: TSessionHandle sessionHandle
}

struct TCloseSessionResp {
    1: TStatus status
}

struct TGetInfoValue {
    1: string stringValue,
    2: i16 smallIntValue,
    3: i32 integerBitmask,
    4: i32 integerFlag,
    5: i32 binaryValue,
    6: i64 lenValue
}

struct TGetInfoReq {
    1: TSessionHandle sessionHandle,
    2: i32 infoType,
    3329: TDBSqlSessionConf sessionConf
}

struct TGetInfoResp {
    1: TStatus status,
    2: TGetInfoValue infoValue
}

struct TSparkGetDirectResults {
    1: i64 maxRows,
    2: i64 maxBytes
}

struct TSparkDirectResults {
    1: TGetOperationStatusResp operationStatus,
    2: TGetResultSetMetadataResp resultSetMetadata,
    3: TFetchResultsResp resultSet,
    4: TCloseOperationResp closeOperation
}

struct TSparkArrowTypes {
    1: bool timestampAsArrow,
    2: bool decimalAsArrow,
    3: bool complexTypesAsArrow,
    4: bool intervalTypesAsArrow
}

struct TExecuteStatementReq {
    1: TSessionHandle sessionHandle,
    2: string statement,
    3: map<string, string> confOverlay,
    4: bool runAsync,
    1281: TSparkGetDirectResults getDirectResults,
    5: i64 queryTimeout,
    1282: bool canReadArrowResult,
    1283: bool canDownloadResult,
    1284: bool canDecompressLZ4Result,
    1285: i64 maxBytesPerFile,
    1286: TSparkArrowTypes useArrowNativeTypes,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf,
    3331: bool rejectHighCostQueries,
    3332: double estimatedCost
}

struct TExecuteStatementResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults,
    3329: bool executionRejected,
    3330: double maxClusterCapacity,
    3331: double queryCost,
    3332: TDBSqlSessionConf sessionConf,
    3333: double currentClusterLoad
}

struct TGetTypeInfoReq {
    1: TSessionHandle sessionHandle,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetTypeInfoResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetCatalogsReq {
    1: TSessionHandle sessionHandle;
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf 
}

struct TGetCatalogsResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetSchemasReq {
    1: TSessionHandle sessionHandle,
    2: string catalogName,
    3: string schemaName,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetSchemasResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults 
}

struct TGetTablesReq {
    1: TSessionHandle sessionHandle,
    2: string catalogName,
    3: string schemaName,
    4: string tableName,
    5: list<string> tableTypes,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetTablesRsp {
     1: TStatus status,
     2: TOperationHandle operationHandle,
     1281: TSparkDirectResults directResults
}

struct TGetTableTypesReq {
    1: TSessionHandle sessionHandle,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetTableTypesResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetColumnsReq {
    1: TSessionHandle sessionHandle,
    2: string catalogName,
    3: string schemaName,
    4: string tableName,
    5: string columnName,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetColumnsResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetFunctionsReq {
    1: TSessionHandle sessionHandle,
    2: string catalogName,
    3: string schemaName,
    4: string functionName,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetFunctionsResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetPrimaryKeysReq {
    1: TSessionHandle sessionHandle,
    2: string catalogName,
    3: string schemaName,
    4: string tableName,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetPrimaryKeysResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetCrossReferenceReq {
    1: TSessionHandle sessionHandle,
    2: string parentCatalogName,
    3: string parentSchemaName,
    4: string parentTableName,
    5: string foreignCatalogName,
    6: string foreignSchemaName,
    7: string foreignTableName,
    1281: TSparkGetDirectResults getDirectResults,
    1282: bool runAsync,
    3329: THandleIdentifier operationId,
    3330: TDBSqlSessionConf sessionConf
}

struct TGetCrossReferenceResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

struct TGetOperationStatusReq {
    1: TOperationHandle operationHandle,
    2: bool getProgressUpdate
}

struct TGetOperationStatusResp {
    1: TStatus status,
    2: TOperationState operationState,
    3: string sqlState,
    4: i32 errorCode,
    5: string errorMessage,
    6: string taskStatus,
    7: i64 operationStarted,
    8: i64 operationCompleted,
    9: bool hasResultSet,
    10: TProgressUpdateResp progressUpdateResponse,
    11: i64 numModifiedRows,
    1281: string displayMessage,
    1282: string diagnosticInfo;
}

struct TCancelOperationReq {
    1: TOperationHandle operationHandle
}

struct TCancelOperationResp {
    1: TStatus status
}

struct TCloseOperationReq {
    1: TOperationHandle operationHandle
}

struct TCloseOperationResp {
    1: TStatus status
}

struct TGetResultSetMetadataReq {
    1: TOperationHandle operationHandle
}

struct TGetResultSetMetadataResp {
    1: TStatus status,
    2: TTableSchema schema,
    1281: i32 resultFormat,
    1282: bool lz4Compressed,
    1283: binary arrowSchema
}

struct TFetchResultsReq {
    1: TOperationHandle operationHandle,
    2: i32 orientation,
    3: i64 maxRows,
    4: i16 fetchType,
    1281: i64 maxBytes,
    1282: i64 startRowOffset,
    1283: bool includeResultSetMetadata
}

struct TFetchResultsResp {
    1: TStatus status,
    2: bool hasMoreRows,
    3: TRowSet results,
    1281: TGetResultSetMetadataResp resultSetMetadata
}

struct TGetDelegationTokenReq {
    1: TSessionHandle sessionHandle,
    2: string owner,
    3: string renewer,
    3329: TDBSqlSessionConf sessionConf
}

struct TGetDelegationTokenResp {
    1: TStatus status,
    2: string delegationToken
}

struct TCancelDelegationTokenReq {
    1: TSessionHandle sessionHandle,
    2: string delegationToken,
    3329: TDBSqlSessionConf sessionConf
}

struct TCancelDelegationTokenResp {
    1: TStatus status
}

struct TRenewDelegationTokenReq {
    1: TSessionHandle sessionHandle,
    2: string delegationToken,
    3329: TDBSqlSessionConf sessionConf
}

struct TRenewDelegationTokenResp {
    1: TStatus status
}

struct TProgressUpdateResp {
    1: list<string> headerNames,
    2: list<string> rows,
    3: double progressedPercentage,
    4: i32 status,
    5: string footerSummary,
    6: i64 startTime
}

struct TGetTablesResp {
    1: TStatus status,
    2: TOperationHandle operationHandle,
    1281: TSparkDirectResults directResults
}

service TCLIService {
    TOpenSessionResp OpenSession(1: TOpenSessionReq req),
    TCloseSessionResp CloseSession(1: TCloseSessionReq req),
    TGetInfoResp GetInfo(1: TGetInfoReq req),
    TExecuteStatementResp ExecuteStatement(1: TExecuteStatementReq req),
    TGetTypeInfoResp GetTypeInfo(1: TGetTypeInfoReq req),
    TGetCatalogsResp GetCatalogs(1: TGetCatalogsReq req),
    TGetSchemasResp GetSchemas(1: TGetSchemasReq req),
    TGetTablesResp GetTables(1: TGetTablesReq req),
    TGetTableTypesResp GetTableTypes(1: TGetTableTypesReq req),
    TGetColumnsResp GetColumns(1: TGetColumnsReq req),
    TGetFunctionsResp GetFunctions(1: TGetFunctionsReq req),
    TGetPrimaryKeysResp GetPrimaryKeys(1: TGetPrimaryKeysReq req),
    TGetCrossReferenceResp GetCrossReference(1: TGetCrossReferenceReq req),
    TGetOperationStatusResp GetOperationStatus(1: TGetOperationStatusReq req),
    TCancelOperationResp CancelOperation(1: TCancelOperationReq req),
    TCloseOperationResp CloseOperation(1: TCloseOperationReq req),
    TGetResultSetMetadataResp GetResultSetMetadata(1: TGetResultSetMetadataReq req),
    TFetchResultsResp FetchResults(1: TFetchResultsReq req),
    TGetDelegationTokenResp GetDelegationToken(1: TGetDelegationTokenReq req),
    TCancelDelegationTokenResp CancelDelegationToken(1: TCancelDelegationTokenReq req),
    TRenewDelegationTokenResp RenewDelegationToken(1: TRenewDelegationTokenReq req)
}