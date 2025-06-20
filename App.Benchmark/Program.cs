using System;
using BenchmarkDotNet.Running;
using App.Benchmark.PerformanceTests;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace App.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Run individual benchmark or all benchmarks based on arguments
            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "kebersihan":
                        BenchmarkRunner.Run<PengaduanKebersihanPerformanceTests>();
                        break;
                    case "fasilitas":
                        BenchmarkRunner.Run<PengaduanFasilitasPerformanceTests>();
                        break;
                    case "keamanan":
                        BenchmarkRunner.Run<PengaduanKeamananPerformanceTests>();
                        break;
                    case "guest":
                        BenchmarkRunner.Run<GuestRepositoryPerformanceTests>();
                        break;
                    case "auth":
                        BenchmarkRunner.Run<AuthServicePerformanceTests>();
                        break;
                    case "usercreation":
                        BenchmarkRunner.Run<UserCreationServicePerformanceTests>();
                        break;
                    case "all":
                        RunAllBenchmarks();
                        break;
                    default:
                        Console.WriteLine("Available options: kebersihan, fasilitas, keamanan, guest, auth, usercreation, all");
                        break;
                }
            }
            else
            {
                // Default: run all benchmarks
                RunAllBenchmarks();
            }
        }

        private static void RunAllBenchmarks()
        {
            Console.WriteLine("Running all performance benchmarks...");

            var types = new[]
            {
                typeof(PengaduanKebersihanPerformanceTests),
                typeof(PengaduanFasilitasPerformanceTests),
                typeof(PengaduanKeamananPerformanceTests),
                typeof(GuestRepositoryPerformanceTests),
                typeof(AuthServicePerformanceTests),
                typeof(UserCreationServicePerformanceTests)
            };

            BenchmarkRunner.Run(types);
        }
    }
}
