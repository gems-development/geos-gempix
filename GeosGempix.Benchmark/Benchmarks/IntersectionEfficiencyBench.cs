using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Benchmark.Benchmarks
{
    public class IntersectionEfficiencyBench
    {
        [Benchmark]
        public bool ContourIntersects()
        {
            var points1 = new List<Point>
            {
                new Point(2, 1),
                new Point(4, 2),
                new Point(6, 1),
                new Point(8, 6),
                new Point(7, 6),
                new Point(6, 8),
                new Point(4, 7),
                new Point(2, 8),
                new Point(1, 6),
                new Point(1, 3),
                new Point(2, 1)
            };
            var contour1 = new Contour(points1);
            var points2 = new List<Point>
            {
                new Point(4, 5),
                new Point(6, 6),
                new Point(4, 8),
                new Point(5, 9),
                new Point(3, 9),
                new Point(4, 10),
                new Point(5, 11),
                new Point(4, 12),
                new Point(3, 13),
                new Point(0, 9),
                new Point(4, 5)
            };
            var contour2 = new Contour(points2);

            return contour1.Intersects(contour2);
        }

        [Benchmark]
        public bool ContourDontIntersects()
        {
            var points1 = new List<Point>
            {
                new Point(2, 1),
                new Point(4, 2),
                new Point(6, 1),
                new Point(8, 6),
                new Point(7, 6),
                new Point(6, 8),
                new Point(4, 7),
                new Point(2, 8),
                new Point(1, 6),
                new Point(1, 3),
                new Point(2, 1)
            };
            var contour1 = new Contour(points1);
            var points2 = new List<Point>
            {
                new Point(13, 1),
                new Point(16, 1),
                new Point(17, 2),
                new Point(16, 4),
                new Point(17, 7),
                new Point(14, 7),
                new Point(12, 9),
                new Point(11, 5),
                new Point(13, 3),
                new Point(12, 2),
                new Point(13, 1)
            };
            var contour2 = new Contour(points2);

            return contour1.Intersects(contour2);
        }

        [Benchmark]
        public bool ContoursRectenglesIntersects()
        {
            var points1 = new List<Point>
            {
                new Point(2, 1),
                new Point(4, 2),
                new Point(6, 1),
                new Point(8, 6),
                new Point(7, 6),
                new Point(6, 8),
                new Point(4, 7),
                new Point(2, 8),
                new Point(1, 6),
                new Point(1, 3),
                new Point(2, 1)
            };
            var contour1 = new Contour(points1);
            var points2 = new List<Point>
            {
                new Point(9, 7),
                new Point(10, 9),
                new Point(11, 10),
                new Point(10, 12),
                new Point(9, 13),
                new Point(8, 12),
                new Point(8, 11),
                new Point(7, 10),
                new Point(8, 9),
                new Point(9, 7)
            };
            var contour2 = new Contour(points2);

            return contour1.Intersects(contour2);
        }
    }
}