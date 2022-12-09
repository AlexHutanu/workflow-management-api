using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteUser : IRequest<User>
    {
        public Guid UserId { get; set; }
    }
}
