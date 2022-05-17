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
        Task<Collection> GetCollection(Guid id);
        Task<Collection> GetCollection(string name);
        Task<Word> GetWordById(Guid id, string collectionName);
        Task<Word> GetWordEnglish(string englishWord, string collectionName);
        Task<Word> GetWordPolish(string polishWord, string collectionName);
        Task<IEnumerable<Collection>> GetAllCollection();
        Task<IEnumerable<Word>> GetAllWords(string collectionName);
        Task AddCollection(Collection collection);
        Task AddWord(Word word, string collectionName);
    }
}
