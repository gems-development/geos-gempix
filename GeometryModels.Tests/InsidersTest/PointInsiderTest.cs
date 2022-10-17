using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryModels;
using GeometryModels.GeometryPrimitiveInsiders;

namespace GeometryModels.Tests.InsidersTest
{
    public class PointInsiderTest
    {
        [Fact]
        public void IsPointsInsidrs_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 0);
            //Act. + Assert.
            Assert.True(PointInsider.IsInside(point1, point2));
        }

        [Fact]
        public void IsPointsInsidrs_Failed()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 1);
            //Act. + Assert.
            Assert.False(PointInsider.IsInside(point1, point2));
        }
    }
}
