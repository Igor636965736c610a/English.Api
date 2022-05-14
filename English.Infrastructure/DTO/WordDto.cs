using English.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.Dto
{
    public class WordDto
    {
        public string EnglishWord { get; set; }
        public string PolishWord { get; set; }
        public Guid Id { get; set; }
    }
}