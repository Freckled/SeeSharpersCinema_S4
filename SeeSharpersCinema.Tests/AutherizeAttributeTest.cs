using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SeeSharpersCinema.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SeeSharpersCinema.Tests
{
    public class AutherizeAttributeTest
    {
        private Mock<UserManager<IdentityUser>> userManagerMock;
        private Mock<RoleManager<IdentityRole>> roleManagerMock;
        private Mock<SignInManager<IdentityUser>> signInManagerMock;

        public AutherizeAttributeTest()
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

        private Mock<SignInManager<IdentityUser>> GetMockSignInManager()
        {
            var userManager = GetMockUserManager();
            var signInManagerMock = new Mock<SignInManager<IdentityUser>>(
            userManager.Object,
            /* IHttpContextAccessor contextAccessor */Mock.Of<IHttpContextAccessor>(),
            /* IUserClaimsPrincipalFactory<TUser> claimsFactory */Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),
            /* IOptions<IdentityOptions> optionsAccessor */null,
            /* ILogger<SignInManager<TUser>> logger */null,
            /* IAuthenticationSchemeProvider schemes */null,
            /* IUserConfirmation<TUser> confirmation */null);
            return signInManagerMock;
        }



        public void AccountControllerAutherizeTests() { }
        public void DashboardControllerAutherizeTests() { }
        public void HomeControllerAutherizeTests() { }
        public void ReviewControllerAutherizeTests() { }
        public void SeatControllerAutherizeTests() { }

        [Fact]
        public void UsersControllerAutherizeTests()
        {
            //Arrange
            //var userManagerMock = GetMockUserManager();
/*            userManagerMock.Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
                    .ReturnsAsync(new IdentityUser { UserName = "Noel" });
            userManagerMock.Setup(userManager => userManager.IsInRoleAsync(It.IsAny<IdentityUser>(), "Noel"))
                    .ReturnsAsync(true);*/
            
            //var roleManagerMock = GetMockRoleManager();
            //var signInManagerMock = GetMockSignInManager();
            //var signInManager = GetMockSignInManager();

            //var signInManager = new Mock<SignInManager<IdentityUser>>(userManager.Object,
            //    contextAccessor.Object, userPrincipalFactory.Object, null, null, null);

            UsersController controller = new UsersController(userManagerMock.Object, signInManagerMock.Object, roleManagerMock.Object);


            //Act
            
            var actualAttribute = controller.GetType().GetMethod("Manage").GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Console.WriteLine(actualAttribute);

            //Assert




        }
        //public void NoticesControllerAutherizeTests() { }
        //public void PaymentControllerAutherizeTests() { }

    }
}
