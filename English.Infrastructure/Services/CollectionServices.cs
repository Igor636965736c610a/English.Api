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
        private readonly IUserRepository _userRepository;
        public CollectionServices(IMapper mapper, ICollectionRepository collectionRepository, IUserRepository userRepository)
        {
            _collectionRepository = collectionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task AddCollection(string collectionName, Guid userId)
        {
            var userValidation = await _userRepository.GetUserById(userId);
            if (userValidation is not null)
            {
                throw new InvalidOperationException();
            }
            var nameValidation = await _collectionRepository.GetCollection(collectionName, userId);
            if (nameValidation is not null)
            {
                throw new InvalidOperationException();
            }
            var id = Guid.NewGuid();
            List<Word> listWord = new List<Word>();
            var collection = new Collection(collectionName, listWord, id);
            await _collectionRepository.AddCollection(collection, userId);
        }

        public async Task AddWord(string polishWord, string englishWord, string collectionName, Guid userId)
        {
            var validationUserId = await _userRepository.GetUserById(userId);
            if(validationUserId is null)
            {
                throw new Exception("xd");
            }
            var validationCollectionName = await _collectionRepository.GetCollection(collectionName, userId);
            if (validationCollectionName is null)
            {
                throw new Exception("x");
            }
            var validationPolsihWord = await _collectionRepository.GetWordPolish(polishWord, collectionName, userId);
            if (validationPolsihWord is not null)
            {
                throw new Exception("y");
            }
            var validationEnglishWord = await _collectionRepository.GetWordEnglish(englishWord, collectionName, userId);
            if (validationEnglishWord is not null)
            {
                throw new Exception("z");
            }
            Guid id = Guid.NewGuid();
            var word = new Word(englishWord, polishWord, id);
            await _collectionRepository.AddWord(word, collectionName, userId);
        }

        public Task<CollectionDto> GetCollection(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDto> GetCollection(string name, Guid userId)
        {
            var validationUserId = await _userRepository.GetUserById(userId);
            if(validationUserId is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(name, userId);
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

        public async Task<WordDto> GetWordEnglish(string englishWord, string collectionName, Guid userId)
        {
            var validationUserId = await _userRepository.GetUserById(userId);
            if (validationUserId is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordEnglish(englishWord, collectionName, userId);
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

        public async Task<WordDto> GetWordPolish(string polishWord, string collectionName, Guid userId)
        {
            var validationUserId = await _userRepository.GetUserById(userId);
            if (validationUserId is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordEnglish(polishWord, collectionName, userId);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }
    }
}
