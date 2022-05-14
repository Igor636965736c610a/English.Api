using System;
using English.Infrastructure.Commands.Collection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Commands.Collection
{
    public class CreateCollection : ICommand
    {
        public string CollectionName { get; set; }
    }
}
