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

        public Collection GetCollection(Guid id)
            => _name.SingleOrDefault(x => x.Id == id);

        public Collection GetCollection(string name)
            => _name.SingleOrDefault(x => x.Name == name);

        public Word GetWordEnglish(Guid id, string collectionName)
        {
            var word = GetCollection(collectionName);
            var _englishWord = word.Word.SingleOrDefault(x => x.Id == id);
            return _englishWord;
        }

        public Word GetWordEnglish(string englishWord, string collectionName)
        {
            var word = GetCollection(collectionName);
            var _englishWord = word.Word.SingleOrDefault(x => x.EnglishWord == englishWord);
            return _englishWord;
        }

        public Word GetWordPolish(string polishWord, string collectionName)
        {
            var word = GetCollection(collectionName);
            var _polishWord = word.Word.SingleOrDefault(x => x.PolishWord == polishWord);
            return _polishWord;
        }

        public Word GetWordPolish(Guid id, string collectionName)
        {
            var word = GetCollection(collectionName);
            var _polishWord = word.Word.SingleOrDefault(x => x.Id == id);
            return _polishWord;
        }

        public void AddCollection(Collection collection)
            => _name.Add(collection);

        public void AddWord(Word word, string collectionName)
        {
            var _collectionName = GetCollection(collectionName);
            _collectionName.Word.Add(word);
        }

        public IEnumerable<Word> GetAllWords(string collectioName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collection> GetAllCollection()
        {
            throw new NotImplementedException();
        }
    }
}