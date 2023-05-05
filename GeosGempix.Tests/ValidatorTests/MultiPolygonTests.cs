using GeosGempix.Visitors.Validators;

namespace GeosGempix.Tests.ValidatorTests
{
    public class MultiPolygonTests
	{

		[Fact]
		public static void IsNotPolygonIntersectsInMultiPolygon_Success()
		{ // Проверка на непересечение полигонов в мультиполигоне (успех)
			//Arrange. + Act. 
			MultiPolygon multiPolygon = TestHelper.CreateMultiPolygon(
				TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0)),
				TestHelper.CreatePolygon(new Point(4, 4), new Point(4, 5), new Point(5, 5), new Point(5, 4), new Point(4, 4)));
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.True(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonIntersectsInMultiPolygon_Failed()
		{ // Проверка на непересечение полигонов в мультиполигоне (провал)
			//Arrange. + Act. 
			MultiPolygon multiPolygon = TestHelper.CreateMultiPolygon(
				TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0)),
				TestHelper.CreatePolygon(new Point(2, 2), new Point(2, 4), new Point(4, 4), new Point(4, 2), new Point(2, 2)));
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonInsideInMultiPolygon_Failed()
		{ // Проверка на ненахождение одного полигона внутри другого в мультиполигоне (провал)
			//Arrange. + Act. 
			MultiPolygon multiPolygon = TestHelper.CreateMultiPolygon(
				TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0)),
				TestHelper.CreatePolygon(new Point(1, 1), new Point(1, 2), new Point(2, 2), new Point(2, 1), new Point(1, 1)));
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonTouchingInMultiPolygon_Failed()
		{   // Проверка на касание полигонов друг друга в мультиполигоне (провал)
			//Arrange. + Act. 
			MultiPolygon multiPolygon = TestHelper.CreateMultiPolygon(
				TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0)),
				TestHelper.CreatePolygon(new Point(3, 0), new Point(3, 3), new Point(6, 3), new Point(6, 0), new Point(3, 0)));
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonsConnectingInMultiPolygon_Failed()
		{   // Проверка на соединение полигонов в двух точках в мультиполигоне (успех)
			//Arrange. + Act. 
			MultiPolygon multiPolygon = TestHelper.CreateMultiPolygon(
				TestHelper.CreatePolygon(new Point(0, 0), new Point(0, 3), new Point(2, 2), new Point(3, 3), new Point(3, 0), new Point(0, 0)),
				TestHelper.CreatePolygon(new Point(0, 3), new Point(0, 5), new Point(3, 5), new Point(2, 4), new Point(0, 3)));
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}
	}
}
