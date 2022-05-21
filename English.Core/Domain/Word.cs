using English.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.Entities
{
    public class Word
    {
        public string EnglishWord { get; set; }
        public string PolishWord { get; set; }
        public Guid Id { get; protected set; }

        public Guid CollectionId { get; set; }
        public Collection Collection { get; set; }


        protected Word()
        {
        }
        public Word(string englishWord, string polishWord)
        {
            EnglishWord = englishWord;
            PolishWord = polishWord;
        }
        public Word(string englishWord, string polishWord, Guid id)
        {
            Id = id;
            EnglishWord = englishWord;
            PolishWord = polishWord;
        }
    }
}
