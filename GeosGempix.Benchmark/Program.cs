using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using GeosGempix;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace MyBenchmarks
{
    public class LineDistanceCalculatorBench
    {
        public LineDistanceCalculatorBench()
        {
        }

        [Benchmark]
        public double LineDistanceBenchmark()
        {
            Line line1 = new Line(new Point(1, 1), new Point(3, -2));
            Line line2 = new Line(new Point(4, 3), new Point(-2, -4));
            //Act. + Assert.
            return LineDistanceCalculator.GetDistance(line1, line2);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LineDistanceCalculatorBench>();
        }
    }
}