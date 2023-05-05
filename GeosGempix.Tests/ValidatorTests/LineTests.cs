using GeosGempix.Visitors.Validators;
using GeosGempix.Models;


namespace GeosGempix.Tests.ValidatorTests
{
    public class LineTests
    {
        [Fact]
        public static void LineTest_Success() 
        {
            //Arrange. + Act.
            Line line = new Line(new Point(0, 0), new Point(1, 1));
            var validator = new Validator(line);
            //Assert.
            Assert.True(validator.Validate());
        }

        [Fact]
        public static void LineTest_Failed()
        {
            //Arrange. + Act.
            Line line = new Line(new Point(0, 0), new Point(0, 0));
            var validator = new Validator(line);
            //Assert.
            Assert.False(validator.Validate());
        }
    }
}
