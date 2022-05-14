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
        void AddCollection(string collectionName);
        void AddWord(string polishWord, string englishWord, string collectionName);
        CollectionDto GetCollection(Guid id);
        CollectionDto GetCollection(string name);
        WordDto GetWordEnglish(Guid id, string collectionName);
        WordDto GetWordEnglish(string englishWord, string collectionName);
        WordDto GetWordPolish(Guid id, string collectionName);
        WordDto GetWordPolish(string polishWord, string collectionName);
    }
}
