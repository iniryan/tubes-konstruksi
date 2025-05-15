using BenchmarkDotNet.Running;
using App.Benchmark;

class BenchmarkRunnerMain
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<PerformanceTesting>();
    }
}
