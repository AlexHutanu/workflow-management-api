using Application.Commands;
using Application.Queries;
using AutoMapper;
using Infrastructure.Enums;
using Infrastructure.Interfaces;
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
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
        [TestMethod]
        public async Task GetAllBugTicketsIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllTickets>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new TicketsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);
            await controller.Get();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllTickets>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetBugTicketIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new TicketsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.GetById(Guid.NewGuid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetTicket>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task CreateBugTicketIsCalled()
        {

            var newBugTicket = new WriteTicketModel()
            {
                Name = "TestBugTicket",
                Description = "Test",
                Assignee = "Test",
                Deadline = 0,
                Status = TicketStatus.TODO,
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new TicketsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.Post(newBugTicket);

            _mockMediator.Verify(x => x.Send(It.IsAny<CreateTicket>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateBugTicketIsCalled()
        {
            var newBugTicket = new WriteTicketModel()
            {
                Name = "TestBugTicket",
                Description = "Test",
                Assignee = "Test",
                Deadline = 0, 
                Status = TicketStatus.DONE,

            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new TicketsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.Update(Guid.NewGuid(), newBugTicket);

            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateTicket>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteBugTicketIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteTicket>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new TicketsController(_mockMediator.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            await controller.Delete(Guid.NewGuid());
        }
    }
}
