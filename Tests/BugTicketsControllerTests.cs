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
using WebAPI.Models.Board;
using WebAPI.Models.BugTicket;

namespace Tests
{
    [TestClass]
    public class BugTicketsControllerTests
    {

        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllBugTicketsIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllBugTickets>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BugTicketsController(_mockMediator.Object, _mockMapper.Object);
            await controller.Get();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllBugTickets>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetBugTicketIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetBugTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BugTicketsController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetById(Guid.NewGuid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetBugTicket>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task CreateBugTicketIsCalled()
        {

            var newBugTicket = new WriteBugTicketModel()
            {
                Name = "TestBugTicket",
                Description = "Test",
                Asignee = "Test",
                Deadline = 0,
                Status = "Test",
                StepsToReproduce = "Test",
                ExpectedResult = "Test", 
                ActualResult= "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateBugTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BugTicketsController(_mockMediator.Object, _mockMapper.Object);

            await controller.Post(newBugTicket);

            _mockMediator.Verify(x => x.Send(It.IsAny<CreateBugTicket>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateBugTicketIsCalled()
        {
            var newBugTicket = new WriteBugTicketModel()
            {
                Name = "TestBugTicket",
                Description = "Test",
                Asignee = "Test",
                Deadline = 0, 
                Status = "Test",
                StepsToReproduce = "Test",
                ExpectedResult = "Test",
                ActualResult = "Test",
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateBugTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BugTicketsController(_mockMediator.Object, _mockMapper.Object);

            await controller.Update(Guid.NewGuid(), newBugTicket);

            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateBugTicket>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteBugTicketIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteBugTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BugTicketsController(_mockMediator.Object, _mockMapper.Object);

            await controller.Delete(Guid.NewGuid());
        }
    }
}
