using System.Threading.Tasks;
using FastCourse.Models.TokenAuth;
using FastCourse.Web.Controllers;
using Shouldly;
using Xunit;

namespace FastCourse.Web.Tests.Controllers
{
    public class HomeController_Tests: FastCourseWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}