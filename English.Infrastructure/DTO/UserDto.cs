using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.DTO
{
    public class UserDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public List<CollectionDto> Collection { get; set; }
    }
}