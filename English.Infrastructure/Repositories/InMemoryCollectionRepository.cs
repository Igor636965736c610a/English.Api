using English.Core.Domain;
using English.Core.Entities;
using English.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Repositories
{
    public class InMemoryCollectionRepository : ICollectionRepository
    {
        private static ISet<Collection> _name = new HashSet<Collection>
        {

        };

        public Task<Collection> GetCollection(Guid id)
            => Task.FromResult(_name.FirstOrDefault(x => x.Id == id));

        public Task<Collection> GetCollection(string name)
            => Task.FromResult(_name.FirstOrDefault(x => x.Name == name));

        public async Task<Word> GetWordById(Guid id, string collectionName)
        {
            var _collectionName = await GetCollection(collectionName);
            Word word = _collectionName.Word.FirstOrDefault(x => x.Id == id);
            return word;
        }

        public async Task<Word> GetWordEnglish(string englishWord, string collectionName)
        {
            var _collectionName = await GetCollection(collectionName);
            Word word = _collectionName.Word.FirstOrDefault(x => x.EnglishWord == englishWord);
            return word;
        }

        public async Task<Word> GetWordPolish(string polishWord, string collectionName)
        {
            var wordCollection = await GetCollection(collectionName);
            Word word = wordCollection.Word.SingleOrDefault(x => x.PolishWord == polishWord);
            return word;
        }

        public Task AddCollection(Collection collection)
            => Task.FromResult(_name.Add(collection));

        public async Task AddWord(Word word, string collectionName)
        {
            var _collectionName = await GetCollection(collectionName);
            _collectionName.Word.Add(word);
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