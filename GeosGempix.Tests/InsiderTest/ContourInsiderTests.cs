using GeosGempix.Models;
using GeosGempix.Extensions;
using GeosGempix.GeometryPrimitiveInsiders;
using GeosGempix.MultiModels;
using GeosGempix.Tests.InsiderTest.TestData;
using BaseTestData = GeosGempix.Tests.InsiderTest.TestData.BaseTestData;

namespace GeosGempix.Tests.InsiderTest
{
    public class ContourInsiderTests
    {
        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndPoint), MemberType = typeof(ContourInsiderTestData))]
        public static void IsPointInsideContour(bool result, Contour contour, Point point)
        {
            //Act. + Assert.
            Assert.Equal(result, contour.IsInside(point));
        }

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndLine), MemberType = typeof(ContourInsiderTestData))]
        public static void IsLineInsideContour(bool result, Contour contour, Line line)
        {
	        //Act. + Assert.
	        Assert.Equal(result, contour.IsInside(line));
        }

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndLineInternal), MemberType = typeof(ContourInsiderTestData))]
        public static void IsLineInsideContourInternal(bool result, Contour contour, Line line)
        {
	        //Act. + Assert.
	        Assert.Equal(result, contour.IsInside(line));
        }

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndContour), MemberType = typeof(ContourInsiderTestData))]
        public static void IsContourInsideContour(bool result, Contour contour1, Contour contour2)
        {
            //Act + Assert.
            Assert.Equal(result, contour1.IsInside(contour2));
        }

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndMultiPoint), MemberType = typeof(ContourInsiderTestData))]
        public static void IsMultiPointInsideContour(bool result, Contour contour, MultiPoint multiPoint)
        {
            //Act + Assert.
            Assert.Equal(result, contour.IsInside(multiPoint));
        }

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndMultiLine), MemberType = typeof(ContourInsiderTestData))]
        public static void IsMultiLineInsideContour(bool result, Contour contour, MultiLine multiLine)
        {
            //Act + Assert.
            Assert.Equal(result, contour.IsInside(multiLine));
        }

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndPolygon), MemberType = typeof(ContourInsiderTestData))]
        public static void IsPolygonInsideContour(bool result, Contour contour, Polygon polygon)
        {
	        //Act + Assert.
	        Assert.Equal(result, contour.IsInside(polygon));
		}

        [Theory]
        [MemberData(nameof(ContourInsiderTestData.ContourAndMultiPolygon), MemberType = typeof(ContourInsiderTestData))]
        public static void IsMultiPolygonInsideContour(bool result, Contour contour, MultiPolygon multiPolygon)
        {
            //Act + Assert.
            Assert.Equal(result, contour.IsInside(multiPolygon));
        }
    }
}