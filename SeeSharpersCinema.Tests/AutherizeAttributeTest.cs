using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Website.Controllers;
using System;
using System.Linq;
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

        [Fact]
        public void DashboardControllerAutherizeTests()
        {
            //Arrange
            var playListRepositoryMock = new Mock<IPlayListRepository>();
            var movieRepositoryMock = new Mock<IMovieRepository>();


            DashboardController controller = new DashboardController(playListRepositoryMock.Object, movieRepositoryMock.Object);
            var controllerType = controller.GetType();

            //Act
            var attrib = controllerType.GetCustomAttributes(typeof(AuthorizeAttribute), true).FirstOrDefault() as AuthorizeAttribute;
            if (attrib == null)
            {
                throw new Exception();
            }

            //Assert
            Assert.DoesNotContain("Desk", attrib.Roles);
            Assert.DoesNotContain("Member", attrib.Roles);
            Assert.Contains("Admin", attrib.Roles);
            Assert.Contains("Manager", attrib.Roles);

        }


        [Fact]
        public void ReviewControllerAutherizeTests()
        {
            //Arrange
            var playListRepositoryMock = new Mock<IPlayListRepository>();
            var reviewRepositoryMock = new Mock<IReviewRepository>();
            ReviewController controller = new ReviewController(playListRepositoryMock.Object, userManagerMock.Object, reviewRepositoryMock.Object);

            //Act
            var actualAttribute = controller.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), true);

            //Assert
            Assert.Equal(typeof(AuthorizeAttribute), actualAttribute[0].GetType());

        }

        [Fact]
        public void SeatControllerAutherizeTests()
        {
            //Arrange
            var playListRepositoryMock = new Mock<IPlayListRepository>();
            var reservedSeatRepositoryMock = new Mock<IReservedSeatRepository>();

            SeatController controller = new SeatController(playListRepositoryMock.Object, reservedSeatRepositoryMock.Object);
            var controllerType = controller.GetType();
            var method = controllerType.GetMethod("RemoveSeats");

            //Act
            var attrib = method.GetCustomAttributes(typeof(AuthorizeAttribute), true).FirstOrDefault() as AuthorizeAttribute;
            if (attrib == null)
            {
                throw new Exception();
            }
            //Assert
            Assert.Contains("Desk", attrib.Roles);
            Assert.DoesNotContain("Member", attrib.Roles);
        }

        [Fact]
        public void UsersControllerAutherizeTests()
        {
            //Arrange
            UsersController controller = new UsersController(userManagerMock.Object);
            var controllerType = controller.GetType();
            //var method = controllerType.GetMethod("Manage");

            //Act
            var attrib = controllerType.GetCustomAttributes(typeof(AuthorizeAttribute), true).FirstOrDefault() as AuthorizeAttribute;
            if (attrib == null)
            {
                throw new Exception();
            }

            //Assert
            Assert.DoesNotContain("Desk", attrib.Roles);
            Assert.DoesNotContain("Member", attrib.Roles);
            Assert.Contains("Admin", attrib.Roles);
            Assert.Contains("Manager", attrib.Roles);

        }
    }
}
