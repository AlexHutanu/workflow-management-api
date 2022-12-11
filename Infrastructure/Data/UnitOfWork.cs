using Infrastructure.Interfaces.IConfiguration;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public UserRepository? Users { get; private set;}
        public BugTicketRepository? BugTickets { get; private set; }

        public BoardRepository? Boards { get; private set; }

        public ActivityRepository? Activities { get; private set; }

        public UnitOfWork( ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
            BugTickets = new BugTicketRepository(_context, _logger); 
            Boards = new BoardRepository(context, _logger);
            Activities = new ActivityRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  void Dispose()
        {
            _context.Dispose();
        }
    }
}
