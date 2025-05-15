using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;


namespace APP.TESTING
{
    public class BenchmarkRunnerProgram
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TamuHelperPerformanceTests>();
        }
    }
}
