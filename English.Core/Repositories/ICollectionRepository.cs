using English.Core.Domain;
using English.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.Repositories
{
    public interface ICollectionRepository
    {
        Collection GetCollection(Guid id);
        Collection GetCollection(string name);
        Word GetWordEnglish(Guid id, string collectionName);
        Word GetWordEnglish(string englishWord, string collectionName);
        Word GetWordPolish(Guid id, string collectionName);
        Word GetWordPolish(string polishWord, string collectionName);
        IEnumerable<Collection> GetAllCollection();
        IEnumerable<Word> GetAllWords(string collectionName);
        void AddCollection(Collection collection);
        void AddWord(Word word, string collectionName);
    }
}
