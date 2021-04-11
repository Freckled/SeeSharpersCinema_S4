using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using SeeSharpersCinema.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeeSharpersCinema.Tests
{
    public class UserControllerTests
    {
        /*private Mock<UserManager<IdentityUser>> userManagerMock;
        private Mock<RoleManager<IdentityRole>> roleManagerMock;
        private Mock<SignInManager<IdentityUser>> signInManagerMock;

        public UserControllerTests()
        {
            this.userManagerMock = GetMockUserManager();
            this.roleManagerMock = GetMockRoleManager();
            this.signInManagerMock = GetMockSignInManager();
        }

        private Mock<UserManager<IdentityUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            return new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        public static Mock<RoleManager<IdentityRole>> GetMockRoleManager()
        {
            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            return new Mock<RoleManager<IdentityRole>>(
                         roleStore.Object, null, null, null, null);

        }

        private Mock<SignInManager<IdentityUser>> GetMockSignInManager(Mock<UserManager<IdentityUser>> userManager = null)
        {
            if (userManager == null)
            {
                userManager = GetMockUserManager();
            }

            var signInManagerMock = new Mock<SignInManager<IdentityUser>>(
            userManager.Object,
             IHttpContextAccessor contextAccessor Mock.Of<IHttpContextAccessor>(),
             IUserClaimsPrincipalFactory < TUser > claimsFactory Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),
             IOptions < IdentityOptions > optionsAccessor null,
             ILogger < SignInManager < TUser >> logger null,
             IAuthenticationSchemeProvider schemes null,
             IUserConfirmation < TUser > confirmation null);
            return signInManagerMock;
        }

        [Fact]
        public async Task AddRoleTestAsync()
        {
            //Arrange
            var user = new IdentityUser() { UserName = "JohnDoe", Id = "1" };
            user.Id = "02dfeb89-9b80-4884-b694-862adf38f09d";

            userManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            //userManagerMock.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Admin", "Member", "Moderator" });
            //userManagerMock.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Admin", "Member", "Moderator" });

            UsersController controller = new UsersController(userManagerMock.Object, signInManagerMock.Object, roleManagerMock.Object);

            //Act
            await controller.RemoveRole(user.UserName, "Admin");
            var roles = await userManagerMock.Object.GetRolesAsync(user);


            //Assert


        }

        //RemoveRole
        //Edit
        //DeleteUser
*/





    }
}
