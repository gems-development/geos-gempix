using BenchmarkDotNet.Running;
using GeosGempix.Benchmark.Benchmarks;

namespace GeosGempix.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<IntersectionEfficiencyBench>();
        }
    }
}
