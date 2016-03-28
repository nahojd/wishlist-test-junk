using Xunit;
using Wishlist.Controllers;

namespace Wishlist
{
    public class UsersControllerTests
    {
        [Fact]
        public void Get_Returns_All_Users()
        {
            var controller = new UsersController(null);
            
            /*var result = controller.Get();
            
            Assert.Equal(new[] {"value1", "value2", "value3"}, result);*/
            
            Assert.True(false, "TODO: Fake database connection");
        }
    }
}