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
        protected InMemoryCollectionRepository(EnglishAppContext context)
        {
            _context = context;
        }

        public async Task<Collection> GetCollection(Guid id, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(y => y.Id == userId);
            return await _context.Collections.FirstOrDefaultAsync(x => x.Id == id && x.User == user);
        }

        public async Task<Collection> GetCollection(string name, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(y => y.Id == userId);
            return await _context.Collections.FirstOrDefaultAsync(x => x.Name == name && x.User == user);
        }

        public async Task<Word> GetWordById(Guid id, string collectionName, Guid userId)
        {
            var collection = await GetCollection(collectionName, userId);
            return await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection && x.Id == id);
        }

        public async Task<Word> GetWordEnglish(string englishWord, string collectionName, Guid userId)
        {
            var collection = await GetCollection(collectionName, userId);
            return await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection && x.EnglishWord == englishWord);
        }

        public async Task<Word> GetWordPolish(string polishWord, string collectionName, Guid userId)
        {
            var collection = await GetCollection(collectionName, userId);
            return await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection && x.PolishWord == polishWord);
        }

        public async Task AddCollection(Collection collection, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            await _context.Collections.AddAsync(collection);
            collection.User = user;
            await _context.SaveChangesAsync();
        }

        public async Task AddWord(Word word, string collectionName, Guid userId)
        {
            var collection = await GetCollection(collectionName, userId);
            await _context.Words.AddAsync(word);
            word.Collection = collection;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Word>> GetAllWords(string collectioName, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Collection>> GetAllCollection()
        {
            throw new NotImplementedException();
        }
    }
}