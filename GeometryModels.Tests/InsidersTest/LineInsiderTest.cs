using GeometryModels.GeometryPrimitiveInsiders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Tests.InsidersTest
{
    public class LineInsiderTest
    {
        [Fact]
        public void IsInsideLinePoint_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 3);
            Point point3 = new Point(1, 1);
            Line line = new Line(point1, point2);
            //Act. + Assert.
            Assert.True(LineInsider.IsInside(line, point3));
        }

        [Fact]
        public void IsInsideLinePoint_Failed()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 3);
            Point point3 = new Point(1, 2);
            Line line = new Line(point1, point2);
            //Act. + Assert.
            Assert.False(LineInsider.IsInside(line, point3));
        }

        [Fact]
        public void IsInsideLine1Line2_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 3);
            Point point3 = new Point(1, 1);
            Point point4 = new Point(2, 2);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point3, point4);
            //Act. + Assert.
            Assert.True(LineInsider.IsInside(line1, line2));
        }

        [Fact]
        public void IsInsideLine1Line2_Failed()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 3);
            Point point3 = new Point(1, 1);
            Point point4 = new Point(3, 4);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point3, point4);
            //Act. + Assert.
            Assert.False(LineInsider.IsInside(line1, line2));
        }
    }
}
