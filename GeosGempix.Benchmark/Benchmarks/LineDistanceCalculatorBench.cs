using BenchmarkDotNet.Attributes;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace GeosGempix.Benchmark.Benchmarks
{
    public class LineDistanceCalculatorBench
    {
        [Benchmark]
        public double LineDistanceBenchmark()
        {
            var line1 = new Line(new Point(1, 1), new Point(3, -2));
            var line2 = new Line(new Point(4, 3), new Point(-2, -4));
            //Act. + Assert.
            return LineDistanceCalculator.GetDistance(line1, line2);
        }
    }
}