using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.DTO
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}