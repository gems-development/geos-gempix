using GeosGempix.Models;
using GeosGempix.Visitors.Validators;

namespace GeosGempix.Tests.ValidatorTests
{
    public class CountourTests
    {
        [Fact]
        public static void ContourTest1_Success()
        {
			//Arrange. + Act.
			Contour contour = TestHelper.CreateContour(new Point(0, 0), new Point(0, 2), new Point(2, 2), 
                                                       new Point(2, 0), new Point(0, 0));
            var validator = new Validator(contour);
            //Assert.
            Assert.True(validator.Validate());
        }

        [Fact]
        public static void ContourTest1_Failed()
        {
			//Arrange. + Act.
			Contour contour = TestHelper.CreateContour(new Point(0, 0), new Point(0 ,2), new Point(2, 0), 
                                                       new Point(2, 2), new Point(0, 0));
            var validator = new Validator(contour);
            //Assert.
            Assert.False(validator.Validate());
        }


        [Fact]
        public static void ContourTest2_Success()
        {
			//Arrange. + Act.
			Contour contour = TestHelper.CreateContour(new Point(0, 0), new Point(0, 2), new Point(2, 2), 
                                                       new Point(2, 1), new Point(1, 0), new Point(0, 0));
            var validator = new Validator(contour);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void ContourTest2_Failed()
        {
			//Arrange. + Act.
			Contour contour = TestHelper.CreateContour(new Point(0, 0), new Point(6, 2), new Point(4, 0), 
                                                       new Point(-6, 3), new Point(6, 3), new Point(0, 0));
            var validator = new Validator(contour);
            //Assert.
            Assert.False(validator.Validate());
        }
    }
}
