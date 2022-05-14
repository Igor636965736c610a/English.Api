using English.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.DTO
{
    public class CollectionDto
    {
        public string Name { get; set; }
        public ISet<WordDto> Word { get; set; }
        public Guid Id { get; set; }
    }
}
