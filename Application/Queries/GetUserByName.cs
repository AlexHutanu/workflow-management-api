using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUserByName : IRequest<IEnumerable<UserEntity>>
    {
        public string Name { get; set; }

        public GetUserByName(string name)
        {
            Name = name;
        }
    }
}
