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
        Task<Collection> GetCollection(Guid id, User user);
        Task<Collection> GetCollection(string name, User user);
        Task<Word> GetWordById(Guid id, Collection collection);
        Task<Word> GetWordEnglish(string englishWord, Collection collection);
        Task<Word> GetWordPolish(string polishWord, Collection collection);
        Task<IEnumerable<Collection>> GetAllCollections(User user);
        Task<IEnumerable<Word>> GetAllWords(Collection collection);
        Task AddCollection(Collection collection);
        Task AddWord(Word word);
        Task UpdateWord(Word word);
        Task UpdateCollection(Collection collection);
        Task RemoveWord(Word word);
        Task RemoveCollection(Collection collection);
        Task ChangeSkillLevel(Word word, int skillLevel);
        Task<IQueryable<Word>> ChangeManySkillLevel(List<Guid> skillLevels, Collection collection);
        Task UpdateWords(IQueryable<Word> words);
    }
}
