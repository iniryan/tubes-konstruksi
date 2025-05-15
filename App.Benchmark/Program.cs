using BenchmarkDotNet.Running;
using App.Benchmark.PerformanceTests;

namespace App.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<PengaduanKebersihanPerformanceTests>();
        }
    }
}
