using English.Core.Dto;
using English.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Services
{
    public interface ICollectionServices
    {
        Task AddCollection(string collectionName, Guid userId);
        Task AddWord(string polishWord, string englishWord, string collectionName, Guid userId);
        Task<CollectionDto> GetCollection(Guid id, Guid userId);
        Task<CollectionDto> GetCollection(string name, Guid userId);
        Task<WordDto> GetWordById(Guid id, string collectionName, Guid userId);
        Task<WordDto> GetWordEnglish(string englishWord, string collectionName, Guid userId);
        Task<WordDto> GetWordPolish(string polishWord, string collectionName, Guid userId);
        Task<IEnumerable<CollectionDto>> GetAllCollections(Guid userId);
        Task<IEnumerable<WordDto>> GetAllWords(string collectionName, Guid userId);
        Task RemoveCollection(string collectionName, Guid userId);
        Task RemoveCollection(Guid id, Guid userId);
        Task RemoveWordByPolishWord(string polishWord, string collectionName, Guid userId);
        Task RemoveWordByEnglishWord(string englishWord, string collectionName, Guid userId);
        Task RemoveWordById(Guid id, string collectionName, Guid userId);
        Task ChangeSkillLevel(Guid id, string collectionName, Guid userId, int skillLevel);
    }
}
