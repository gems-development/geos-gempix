using GeosGempix.Models;
using GeosGempix.Tests.ValidatorTests.TestData;
using GeosGempix.Visitors.Validators;

namespace GeosGempix.Tests.ValidatorTests
{
    public class PolygonTests
	{
		[Fact]
		public static void PolygonTest_Square_Success()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 2), new Point(2, 2), 
													   new Point(2, 0), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.True(validator.Validate());
		}

		[Fact]
		public static void PolygonTest_HourGlass_Failed()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 2), new Point(2, 0), 
													   new Point(2, 2), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void PolygonTest_FiveAngles_Success()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 2), new Point(2, 2), 
													   new Point(2, 1), new Point(1, 0), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.True(validator.Validate());
		}


		[Fact]
		public static void PolygonTest_StarSelfIntersecting_Failed()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(new Point(0, 0), new Point(6, 2), new Point(4, 0), 
													   new Point(-6, 3), new Point(6, 3), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}

		[Fact]
		public static void PolygonTest_SquareWithHole_Failed()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(
				new List<Contour>
				{
					TestHelper.CreateContour(new Point(0, 0), new Point(0, 1), new Point(1, 1),
											 new Point(1, 0), new Point(0, 0))
				},
				new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void PolygonTest_SquareWithHoleIntersecting_Failed()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(
				new List<Contour>
				{
					TestHelper.CreateContour(new Point(1, 1), new Point(1, 2), new Point(2, 1), new Point(2, 2), new Point(1, 1))
				},
				new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}

		[Theory]
		[ClassData(typeof(SquareWithHoleIntersectingTwoLinesTestData))]
		public static void PolygonTest_SquareWithHoleIntersectingTwoLines_Failed(Polygon polygon)
		{
			//Arrange. + Act.
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void PolygonTest_SquareWithHolePartiallyOutOfBounds_Failed()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(
				new List<Contour>
				{
					TestHelper.CreateContour(new Point(-1, 1), new Point(-1, 2), new Point(2, 1), 
											 new Point(1, 1), new Point(-1, 1))
				});
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}

		[Theory]
		[ClassData(typeof(HoleNotInsidePolygonTestData))]
		public static void PolygonTest_HoleNotInsidePolygon_Failed(Polygon polygon)
		{
			//Arrange. + Act.
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void PolygonTest_LineIintersectPolygon_Failed()
		{
			//Arrange. + Act.
			Polygon polygon = TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 2), new Point(2, 2),
													   new Point(2, 0), new Point(5, 0), new Point(0, 0));
			var validator = new Validator(polygon);
			//Assert.
			Assert.False(validator.Validate());
		}
	}
}
