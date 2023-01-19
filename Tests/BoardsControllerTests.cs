using Application.Commands;
using Application.Queries;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Moq;
using WebAPI.Controllers;
using WebAPI.Models.Board;

namespace Tests
{
    [TestClass]
    public class BoardsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();

        [TestMethod]
        public async Task GetAllBoardsIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllBoards>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BoardsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);
            await controller.Get();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllBoards>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetBoardIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetBoard>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BoardsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.GetById(Guid.NewGuid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetBoard>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task CreateBoardIsCalled()
        {

            var newBoard = new WriteBoardModel()
            {
                Name = "TestBoard",
                Description = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateBoard>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BoardsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.Post(newBoard);

            _mockMediator.Verify(x => x.Send(It.IsAny<CreateBoard>(), It.IsAny<CancellationToken>()), Times.Once());          
        }

        [TestMethod]
        public async Task UpdateBoardIsCalled()
        {
            var board = new WriteBoardModel()
            {
                Name = "TestBoard",
                Description = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateBoard>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BoardsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.Update(Guid.NewGuid(), board);

            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateBoard>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteBoardIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteBoard>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BoardsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.Delete(Guid.NewGuid());
        }
    }
}