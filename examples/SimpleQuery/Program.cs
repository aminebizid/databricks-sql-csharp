using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using HiveClient.Sql;
using HiveClient.Sql.Auth;

namespace SimpleQuery
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Usage SimpleQuery hostname port login password");
                return;
            }
            
            var hostname = args[0];
            var port = args[1];
            var login  = args[2];
            var password  = args[3];
            var scheme = "binary"; 
            
            
            var httpPath = "cliservice";

            var connection = new Connection(
                hostname,
                new BasicAuthProvider(login, password),
                port: port,
                scheme:scheme,
                httpPath:  httpPath,
                login: login,
                password: password);
            
            var cancellationToken = new CancellationToken();

            await connection.OpenAsync(cancellationToken);
            
            string sql = @"select metering_point_code, to_date(timestamp_utc) d, sum(value) 
                    from gemdownstreamwattsonvolumesfranpd.fr_series_power_metering_offtake_10t 
                    where year_month='202303' and metering_point_code='57020003' and expiration_datetime > '9999-01-01' 
                    group by metering_point_code, d 
                    order by d
         ";
            
            sql = @"select metering_point_code, timestamp_utc, value 
                    from gemdownstreamwattsonvolumesfranpd.fr_series_power_metering_offtake_10t 
                    where year_month in ('202303', '202304', '202305') and metering_point_code='57020003' and expiration_datetime > '9999-01-01' 
         ";

            var sw = new Stopwatch();
            sw.Start();
            var count = 0;

            
            Console.WriteLine("Query started");
            using (var cursor =
                   connection.GetCursor(maxRows: 100000, canReadArrowResult: true, canReadCompressed: true))
            {
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

                await foreach (var row in cursor.GetRowAsync(cancellationToken: cancellationToken))
                {
                    // Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
                    count++;
                }

                sw.Stop();
                Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");

                Console.WriteLine($"Received {count} rows");



                sw.Restart();
                count = 0;
                
                Console.WriteLine("Query started");

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

                await foreach (var row in cursor.GetRowAsync(cancellationToken: cancellationToken))
                {
                    // Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
                    count++;
                }



                sw.Stop();
                Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");

                Console.WriteLine($"Received {count} rows");
            }


            await connection.CloseSessionAsync(cancellationToken);


        }
    }
}