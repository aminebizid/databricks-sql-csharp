using System;
using System.Threading;
using System.Threading.Tasks;
using DataBricks.Sql;

namespace Examples.SimpleQuery
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage SimpleQuery hostname httpPath accessToken");
                return;
            }
            
            var hostname = args[0];
            var httpPath =  args[1];
            var accessToken =  args[2];

            var connection = new Connection(
                hostname,
                httpPath,
                accessToken);
            
            var cancellationToken = new CancellationToken();

            await connection.OpenAsync(cancellationToken);
            var cursor = connection.GetCursor(arraySize: 100000, canReadArrowResult: true, canReadCompressed: true);
            const string sql = "SELECT * FROM RANGE(100000)";
            try
            {
                await cursor.ExecuteAsync(sql, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await cursor.CloseAsync(cancellationToken);
                await connection.CloseSessionAsync(cancellationToken);
                throw;
            }

            var count = 0;
            await foreach (var row in cursor.GetRowAsync(cancellationToken:cancellationToken))
            {
                Console.WriteLine($"{row[0]}");
                count++;
            }
            
            Console.WriteLine($"Received {count} rows");
          
            await cursor.CloseAsync(cancellationToken);
            await connection.CloseSessionAsync(cancellationToken);


        }
    }
}