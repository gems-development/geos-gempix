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
            LineValidator lineValidator = new LineValidator(new Line(new Point(0, 0), new Point(1, 1)));
            //Assert.
            Assert.True(lineValidator.Validate());
        }
    }
}
