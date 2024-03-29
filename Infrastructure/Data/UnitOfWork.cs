﻿using Infrastructure.Repositories;
using Infrastructure.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new UserRepository(context);
            Tickets = new TicketRepository(context);
            Boards = new BoardRepository(context);
            Activities = new ActivityRepository(context);
        }

        public UserRepository? Users { get; private set;}
        public TicketRepository? Tickets { get; private set; }

        public BoardRepository? Boards { get; private set; }

        public ActivityRepository? Activities { get; private set; }

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
