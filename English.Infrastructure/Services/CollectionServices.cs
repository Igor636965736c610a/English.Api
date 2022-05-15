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
        public void AddCollection(string collectionName)
        {
            var validation = _collectionRepository.GetCollection(collectionName);
            if (validation is not null)
            {
                throw new InvalidOperationException();
            }
            var id = Guid.NewGuid();
            ISet<Word> isetWord = new HashSet<Word>();
            var collection = new Collection(collectionName, isetWord, id);
            _collectionRepository.AddCollection(collection);
        }

        public void AddWord(string polishWord, string englishWord, string collectionName)
        {
            var validationCollectionName = _collectionRepository.GetCollection(collectionName);
            if (validationCollectionName is null)
            {
                throw new Exception("x");
            }
            var validationPolsihWord = _collectionRepository.GetWordPolish(polishWord, collectionName);
            if (validationPolsihWord is not null)
            {
                throw new Exception("y");
            }
            var validationEnglishWord = _collectionRepository.GetWordEnglish(englishWord, collectionName);
            if (validationEnglishWord is not null)
            {
                throw new Exception("z");
            }
            Guid id = Guid.NewGuid();
            var word = new Word(englishWord, polishWord, id);
            _collectionRepository.AddWord(word, collectionName);
        }

        public CollectionDto GetCollection(Guid id)
        {
            throw new NotImplementedException();
        }

        public CollectionDto GetCollection(string name)
        {
            var collection = _collectionRepository.GetCollection(name);
            if (collection is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Collection, CollectionDto>(collection);
        }

        public WordDto GetWordEnglish(Guid id, string collectionName)
        {
            throw new NotImplementedException();
        }

        public WordDto GetWordEnglish(string englishWord, string collectionName)
        {
            var word = _collectionRepository.GetWordEnglish(englishWord, collectionName);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }

        public WordDto GetWordPolish(Guid id, string collectionName)
        {
            throw new NotImplementedException();
        }

        public WordDto GetWordPolish(string polishWord, string collectionName)
        {
            var word = _collectionRepository.GetWordEnglish(polishWord, collectionName);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }
    }
}
