using Xunit;
using Wishlist.Controllers;

namespace Wishlist
{
    public class ValuesControllerTests
    {
        [Fact]
        public void Get_Returns_All_Values()
        {
            var controller = new ValuesController();
            
            var result = controller.Get();
            
            Assert.Equal(new[] {"value1", "value2", "value3"}, result);
        }
    }
}