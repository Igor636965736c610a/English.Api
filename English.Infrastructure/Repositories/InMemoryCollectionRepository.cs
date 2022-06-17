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

        public async Task<Collection> GetCollection(Guid id, User user)
            => await _context.Collections.FirstOrDefaultAsync(x => x.Id == id && x.User == user);

        public async Task<Collection> GetCollection(string name, User user)
            => await _context.Collections.FirstOrDefaultAsync(x => x.Name == name && x.User == user);

        public async Task<Word> GetWordById(Guid id, Collection collection)
            => await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection && x.Id == id);

        public async Task<Word> GetWordEnglish(string englishWord, Collection collection)
            => await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection && x.EnglishWord == englishWord);

        public async Task<Word> GetWordPolish(string polishWord, Collection collection)
            => await _context.Words.FirstOrDefaultAsync(x => x.Collection == collection && x.PolishWord == polishWord);

        public async Task AddCollection(Collection collection)
        {
            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();
        }

        public async Task AddWord(Word word)
        {
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Word>> GetAllWords(Collection collection)
            => await Task.FromResult(_context.Words.Where(x => x.Collection == collection));

        public async Task<IEnumerable<Collection>> GetAllCollections(User user)
            => await Task.FromResult(_context.Collections.Where(x => x.User == user));

        public async Task UpdateWord(Word word)
            => await Task.FromResult(_context.Words.Update(word));

        public async Task UpdateCollection(Collection collection)
            => await Task.FromResult(_context.Collections.Update(collection));

        public async Task RemoveWord(Word word)
            => await Task.FromResult(_context.Words.Remove(word));

        public async Task RemoveCollection(Collection collection)
            => await Task.FromResult(_context.Collections.Remove(collection));

        public async Task ChangeSkillLevel(Word word, int skillLevel)
        {
            word.SkillLevel = (SkillLevel)skillLevel;
            await Task.FromResult(_context.Words.Update(word));
        }
    }
}