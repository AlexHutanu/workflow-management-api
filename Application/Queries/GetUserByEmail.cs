using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUserByEmail
    {
        public string Email { get; set; }

        public GetUserByEmail(string email)
        {
            Email = email;
        }
    }
}
