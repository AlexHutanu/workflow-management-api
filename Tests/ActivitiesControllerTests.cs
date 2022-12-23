using Application.Commands;
using Application.Queries;
using AutoMapper;
using MediatR;
using Moq;
using WebAPI.Controllers;
using WebAPI.Models.ActivityDtos;


namespace Tests
{
    [TestClass]
    public class ActivitiesControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllActivitiesIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllActivities>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new ActivitiesController(_mockMediator.Object, _mockMapper.Object);
            await controller.Get();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllActivities>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetActivityIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetActivity>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new ActivitiesController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetById(Guid.NewGuid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetActivity>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task CreateActivityIsCalled()
        {

            var newActivity = new WriteActivityModel()
            {
                Name = "TestActivity",
                Description = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateActivity>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new ActivitiesController(_mockMediator.Object, _mockMapper.Object);

            await controller.Post(newActivity);

            _mockMediator.Verify(x => x.Send(It.IsAny<CreateActivity>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateActivityIsCalled()
        {
            var newActivity = new WriteActivityModel()
            {
                Name = "TestActivity",
                Description = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateActivity>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new ActivitiesController(_mockMediator.Object, _mockMapper.Object);

            await controller.Update(Guid.NewGuid(), newActivity);

            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateActivity>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteActivityIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteActivity>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new ActivitiesController(_mockMediator.Object, _mockMapper.Object);

            await controller.Delete(Guid.NewGuid());
        }
    }
}
