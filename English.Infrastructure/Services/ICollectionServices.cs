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
        Task AddCollection(string collectionName);
        Task AddWord(string polishWord, string englishWord, string collectionName);
        Task<CollectionDto> GetCollection(Guid id);
        Task<CollectionDto> GetCollection(string name);
        Task<WordDto> GetWordEnglish(Guid id, string collectionName);
        Task<WordDto> GetWordEnglish(string englishWord, string collectionName);
        Task<WordDto> GetWordPolish(Guid id, string collectionName);
        Task<WordDto> GetWordPolish(string polishWord, string collectionName);
    }
}
