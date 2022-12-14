using Application.Commands;
using Application.Queries;
using AutoMapper;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Dtos.BoardDtos;
using WebAPI.Dtos.UserDtos;

namespace Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllUsersIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetUsers();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetUserIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUser>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetById(Guid.NewGuid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetUser>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task CreateUserIsCalled()
        {

            var newUser = new UserPostPutDto()
            {
                Name = "TestUser",
                Email = "Test",
                Password = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateUser>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

            await controller.PostUser(newUser);

            _mockMediator.Verify(x => x.Send(It.IsAny<CreateUser>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateUserIsCalled()
        {
            var newUser = new UserPostPutDto()
            {
                Name = "TestBoard",
                Email = "Test",
                Password = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateUser>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

            await controller.UpdateUser(Guid.NewGuid(), newUser);

            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateUser>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteUserIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteUser>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

            await controller.DeleteUser(Guid.NewGuid());
        }
    }
}
