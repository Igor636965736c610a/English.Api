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
        public SkillLevel SkillLevel { get; set; } = SkillLevel.bad;

        public Guid CollectionId { get; set; }
        public Collection Collection { get; set; }


        protected Word()
        {
        }
        public Word(string englishWord, string polishWord, Guid id, Collection collection)
        {
            Id = id;
            EnglishWord = englishWord;
            PolishWord = polishWord;
            Collection = collection;
        }
    }

    public enum SkillLevel 
    {
        bad = 0,
        average = 1,
        good = 2
    }
}
