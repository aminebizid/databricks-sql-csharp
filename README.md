# Databricks SQL Connector for C#

This is a port of [databricks-sql-python](https://github.com/databricks/databricks-sql-python)

## Simple Usage

```csharp
var hostname = args[0];
var httpPath =  args[1];
var accessToken =  args[2];

var connection = new Connection(
    hostname,
    httpPath,
    accessToken);

var cancellationToken = new CancellationToken();

await connection.OpenAsync(cancellationToken);

const string sql = "select * from db.table where year_month='202212' limit 200000";

using (var cursor =
    connection.GetCursor(maxRows: 100000, canReadArrowResult: true, canReadCompressed: true))
{
   
    await cursor.ExecuteAsync(sql, cancellationToken);

    await foreach (var row in cursor.GetRowAsync(cancellationToken:cancellationToken))
    {
        Console.WriteLine($"{row[0]}");
    }
    
}

await connection.CloseSessionAsync(cancellationToken);

```


# Contrib
```
 thrift --gen netstd:no_deepcopy,net6 -out . dbxsql.thrift
```

## ToDo
- Implement retry policy
