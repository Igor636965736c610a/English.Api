using AutoMapper;
using English.Core.Domain;
using English.Core.Dto;
using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Services
{
    public class CollectionServices : ICollectionServices
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;
        public CollectionServices(IMapper mapper, ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }
        public async Task AddCollection(string collectionName)
        {
            var validation = await _collectionRepository.GetCollection(collectionName);
            if (validation is not null)
            {
                throw new InvalidOperationException();
            }
            var id = Guid.NewGuid();
            ISet<Word> isetWord = new HashSet<Word>();
            var collection = new Collection(collectionName, isetWord, id);
            await _collectionRepository.AddCollection(collection);
        }

        public async Task AddWord(string polishWord, string englishWord, string collectionName)
        {
            var validationCollectionName = await _collectionRepository.GetCollection(collectionName);
            if (validationCollectionName is null)
            {
                throw new Exception("x");
            }
            var validationPolsihWord = await _collectionRepository.GetWordPolish(polishWord, collectionName);
            if (validationPolsihWord is not null)
            {
                throw new Exception("y");
            }
            var validationEnglishWord = await _collectionRepository.GetWordEnglish(englishWord, collectionName);
            if (validationEnglishWord is not null)
            {
                throw new Exception("z");
            }
            Guid id = Guid.NewGuid();
            var word = new Word(englishWord, polishWord, id);
            await _collectionRepository.AddWord(word, collectionName);
        }

        public Task<CollectionDto> GetCollection(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDto> GetCollection(string name)
        {
            var collection = await _collectionRepository.GetCollection(name);
            if (collection is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Collection, CollectionDto>(collection);
        }

        public Task<WordDto> GetWordEnglish(Guid id, string collectionName)
        {
            throw new NotImplementedException();
        }

        public async Task<WordDto> GetWordEnglish(string englishWord, string collectionName)
        {
            var word = await _collectionRepository.GetWordEnglish(englishWord, collectionName);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }

        public Task<WordDto> GetWordPolish(Guid id, string collectionName)
        {
            throw new NotImplementedException();
        }

        public async Task<WordDto> GetWordPolish(string polishWord, string collectionName)
        {
            var word = await _collectionRepository.GetWordEnglish(polishWord, collectionName);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }
    }
}
