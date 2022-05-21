using English.Core.Domain;
using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Repositories
{
    public class InMemoryCollectionRepository : ICollectionRepository
    {
        private readonly EnglishAppContext _context;
        public InMemoryCollectionRepository(EnglishAppContext context)
        {
            _context = context;
        }


        private static ISet<Collection> _name = new HashSet<Collection>
        {

        };

        public Task<Collection> GetCollection(Guid id)
            => Task.FromResult(_context.Collections.FirstOrDefault(x => x.Id == id));

        public Task<Collection> GetCollection(string name)
            => Task.FromResult(_context.Collections.FirstOrDefault(x => x.Name == name));

        public async Task<Word> GetWordById(Guid id, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            return collection.Word.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Word> GetWordEnglish(string englishWord, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            return collection.Word.FirstOrDefault(x => x.EnglishWord == englishWord);
        }

        public async Task<Word> GetWordPolish(string polishWord, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            return collection.Word.FirstOrDefault(x => x.PolishWord == polishWord);
        }

        public Task AddCollection(Collection collection)
            => Task.FromResult(_context.Collections.Add(collection));

        public async Task AddWord(Word word, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            collection.Word.Add(word);
        }

        public async Task<IEnumerable<Word>> GetAllWords(string collectioName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Collection>> GetAllCollection()
        {
            throw new NotImplementedException();
        }
    }
}