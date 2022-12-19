using System;
using System.Diagnostics;
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
            const string sql = "select * from gemdownstreamwattsonvolumesfranpd.fr_series_power_metering_offtake_10t where year_month='202212' limit 100000";

            var sw = new Stopwatch();
            sw.Start();
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
                // Console.WriteLine($"{row[0]}");
                count++;
            }
            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
            
            Console.WriteLine($"Received {count} rows");
          
            await cursor.CloseAsync(cancellationToken);
            await connection.CloseSessionAsync(cancellationToken);


        }
    }
}