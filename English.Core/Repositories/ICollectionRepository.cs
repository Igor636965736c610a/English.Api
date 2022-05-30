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
        Task<Collection> GetCollection(Guid id, Guid userId);
        Task<Collection> GetCollection(string name, Guid userId);
        Task<Word> GetWordById(Guid id, string collectionName, Guid userId);
        Task<Word> GetWordEnglish(string englishWord, string collectionName, Guid userId);
        Task<Word> GetWordPolish(string polishWord, string collectionName, Guid userId);
        Task<IEnumerable<Collection>> GetAllCollection();
        Task<IEnumerable<Word>> GetAllWords(string collectionName, Guid userId);
        Task AddCollection(Collection collection, Guid userId);
        Task AddWord(Word word, string collectionName, Guid userId);
    }
}
