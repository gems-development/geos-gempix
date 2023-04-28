using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using GeosGempix;
using GeosGempix.Extensions;
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
    public class IntersectionEfficiencyBench
    {
        IntersectionEfficiencyBench()
        { }
        [Benchmark]
        public bool ContourIntersects()
        {
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(2, 1));
            points1.Add(new Point(4, 2));
            points1.Add(new Point(6, 1));
            points1.Add(new Point(8, 6));
            points1.Add(new Point(7, 6));
            points1.Add(new Point(6, 8));
            points1.Add(new Point(4, 7));
            points1.Add(new Point(2, 8));
            points1.Add(new Point(1, 6));
            points1.Add(new Point(1, 3));
            points1.Add(new Point(2, 1));
            Contour contour1 = new Contour(points1);
            List<Point> points2 = new List<Point>();
            points2.Add(new Point(4, 5));
            points2.Add(new Point(6, 6));
            points2.Add(new Point(4, 8));
            points2.Add(new Point(5, 9));
            points2.Add(new Point(3, 9));
            points2.Add(new Point(4, 10));
            points2.Add(new Point(5, 11));
            points2.Add(new Point(4, 12));
            points2.Add(new Point(3, 13));
            points2.Add(new Point(0, 9));
            points2.Add(new Point(4, 5));
            Contour contour2 = new Contour(points2);
            return contour1.Intersects(contour2);
        }
        [Benchmark]
        public bool ContourDontIntersects()
        {
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(2, 1));
            points1.Add(new Point(4, 2));
            points1.Add(new Point(6, 1));
            points1.Add(new Point(8, 6));
            points1.Add(new Point(7, 6));
            points1.Add(new Point(6, 8));
            points1.Add(new Point(4, 7));
            points1.Add(new Point(2, 8));
            points1.Add(new Point(1, 6));
            points1.Add(new Point(1, 3));
            points1.Add(new Point(2, 1));
            Contour contour1 = new Contour(points1);
            List<Point> points2 = new List<Point>();
            points2.Add(new Point(13,1));
            points2.Add(new Point(16,1));
            points2.Add(new Point(17,2));
            points2.Add(new Point(16,4));
            points2.Add(new Point(17,7));
            points2.Add(new Point(14,7));
            points2.Add(new Point(12,9));
            points2.Add(new Point(11,5));
            points2.Add(new Point(13,3));
            points2.Add(new Point(12,2));
            points2.Add(new Point(13,1));
            Contour contour2 = new Contour(points2);
            return contour1.Intersects(contour2);
        }
        [Benchmark]
        public bool ContoursRectenglesIntersects()
        {
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(2, 1));
            points1.Add(new Point(4, 2));
            points1.Add(new Point(6, 1));
            points1.Add(new Point(8, 6));
            points1.Add(new Point(7, 6));
            points1.Add(new Point(6, 8));
            points1.Add(new Point(4, 7));
            points1.Add(new Point(2, 8));
            points1.Add(new Point(1, 6));
            points1.Add(new Point(1, 3));
            points1.Add(new Point(2, 1));
            Contour contour1 = new Contour(points1);
            List<Point> points2 = new List<Point>();
            points2.Add(new Point(9,7));
            points2.Add(new Point(10,9));
            points2.Add(new Point(11,10));
            points2.Add(new Point(10,12));
            points2.Add(new Point(9,13));
            points2.Add(new Point(8,12));
            points2.Add(new Point(8,11));
            points2.Add(new Point(7,10));
            points2.Add(new Point(8,9));
            points2.Add(new Point(9,7));

            Contour contour2 = new Contour(points2);
            return contour1.Intersects(contour2);
        }

        }

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<IntersectionEfficiencyBench>();
           
        }
    }
}