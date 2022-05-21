using Microsoft.EntityFrameworkCore;
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

        public async Task<Collection> GetCollection(Guid id)
            => await _context.Collections.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Collection> GetCollection(string name)
            => await _context.Collections.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<Word> GetWordById(Guid id, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            List<Word> words = new List<Word>();
            var xd = await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection);
            words.Add(xd);
            return words.FirstOrDefault(y => y.Id == id);
        }

        public async Task<Word> GetWordEnglish(string englishWord, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            List<Word> words = new List<Word>();
            var xd = await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection);
            words.Add(xd);
            return words.FirstOrDefault(y => y.EnglishWord == englishWord);
        }

        public async Task<Word> GetWordPolish(string polishWord, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            List<Word> words = new List<Word>();
            var xd = await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection);
            words.Add(xd);
            return words.FirstOrDefault(y => y.PolishWord == polishWord);
        }

        public async Task AddCollection(Collection collection)
        {
            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();
        }

        public async Task AddWord(Word word, string collectionName)
        {
            var collection = await GetCollection(collectionName);
            await _context.Words.AddAsync(word);
            word.Collection = collection;
            await _context.SaveChangesAsync();
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