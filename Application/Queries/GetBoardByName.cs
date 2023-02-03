using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetBoardByName : IRequest<IEnumerable<BoardEntity>>
    {
        public string Name { get; }

        public GetBoardByName(string name)
        {
            Name = name;
        }
    }
}
