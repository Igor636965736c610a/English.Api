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
        Task<CollectionDto> GetCollection(Guid id);
        Task<CollectionDto> GetCollection(string name, Guid userId);
        Task<WordDto> GetWordEnglish(Guid id, string collectionName);
        Task<WordDto> GetWordEnglish(string englishWord, string collectionName, Guid userId);
        Task<WordDto> GetWordPolish(Guid id, string collectionName);
        Task<WordDto> GetWordPolish(string polishWord, string collectionName, Guid userId);
    }
}
