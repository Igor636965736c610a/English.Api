using English.Infrastructure.Commands.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Commands.Word
{
    public class CreateWord : ICommand
    {
        public string EnglishWord { get; set; }
        public string PolishWord { get; set; }
    }
}
