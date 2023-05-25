using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest
{
    public class CountourDistanceCalculatorTriangleTests
    {
        [Theory]
        [MemberData(nameof(CountourDistanceCalculatorTriangleTestData.ContourAndContourTriangle1), MemberType = typeof(CountourDistanceCalculatorTriangleTestData))]
        public void GetDistanceBetweenContourAndContourTriangle(Contour contour1, Contour contour2)
        {
            //Act + Assert.
            Assert.Equal(246.23392637306685, contour2.GetDistance(contour1));
        }
        
        [Theory]
        [MemberData(nameof(CountourDistanceCalculatorTriangleTestData.ContourAndContourTriangle2), MemberType = typeof(CountourDistanceCalculatorTriangleTestData))]
        public void GetDistanceBetweenContourAndContourTriangle2(Contour contour1, Contour contour2)
        {
            //Act + Assert.
            Assert.Equal(2.1213203435596424, contour2.GetDistance(contour1));
        }
    }
}
