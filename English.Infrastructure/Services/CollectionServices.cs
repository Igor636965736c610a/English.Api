using AutoMapper;
using English.Core.Domain;
using English.Core.Dto;
using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure.Commands.Word;
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
            var user = await _userRepository.GetUserById(userId);
            if(user is null)
            {
                throw new InvalidOperationException();
            }
            var nameValidation = await _collectionRepository.GetCollection(collectionName, user);
            if (nameValidation is not null)
            {
                throw new InvalidOperationException();
            }
            var id = Guid.NewGuid();
            var collection = new Collection(collectionName, id, user);
            await _collectionRepository.AddCollection(collection);
        }

        public async Task AddWord(string polishWord, string englishWord, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if(user is null)
            {
                throw new Exception("xd");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("x");
            }
            var _polishWord = await _collectionRepository.GetWordPolish(polishWord, collection);
            if (_polishWord is not null)
            {
                throw new Exception("y");
            }
            var _englishWord = await _collectionRepository.GetWordEnglish(englishWord, collection);
            if (_englishWord is not null)
            {
                throw new Exception("z");
            }
            Guid id = Guid.NewGuid();
            var word = new Word(englishWord, polishWord, id, collection);
            await _collectionRepository.AddWord(word);
        }

        public async Task<CollectionDto> GetCollection(Guid id, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(id, user);
            if (collection is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Collection, CollectionDto>(collection);
        }

        public async Task<CollectionDto> GetCollection(string name, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if(user is null)
            { 
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(name, user);
            if (collection is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Collection, CollectionDto>(collection);
        }

        public async Task<WordDto> GetWordById(Guid id, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordById(id, collection);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }

        public async Task<WordDto> GetWordEnglish(string englishWord, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if(collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordEnglish(englishWord, collection);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }

        public async Task<WordDto> GetWordPolish(string polishWord, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if(collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordEnglish(polishWord, collection);
            if (word is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<Word, WordDto>(word);
        }

        public async Task<IEnumerable<CollectionDto>> GetAllCollections(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collections = await _collectionRepository.GetAllCollections(user);
            if(collections is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<IEnumerable<Collection>, IEnumerable<CollectionDto>>(collections);
        }

        public async Task<IEnumerable<WordDto>> GetAllWords(string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collections = await _collectionRepository.GetCollection(collectionName, user);
            if (collections is null)
            {
                throw new Exception("null");
            }
            var words = await _collectionRepository.GetAllWords(collections);
            if (words is null)
            {
                throw new Exception("null");
            }    

            return _mapper.Map<IEnumerable<Word>, IEnumerable<WordDto>>(words);
        }

        public async Task RemoveCollection(string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }

            await _collectionRepository.RemoveCollection(collection);
        }

        public async Task RemoveCollection(Guid id, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(id, user);
            if (collection is null)
            {
                throw new Exception("null");
            }

            await _collectionRepository.RemoveCollection(collection);
        }

        public async Task RemoveWordByPolishWord(string polishWord, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordPolish(polishWord, collection);
            if (word is null)
            {
                throw new Exception("null");
            }

            await _collectionRepository.RemoveWord(word);
        }

        public async Task RemoveWordByEnglishWord(string englishWord, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordEnglish(englishWord, collection);
            if (word is null)
            {
                throw new Exception("null");
            }

            await _collectionRepository.RemoveWord(word);
        }

        public async Task RemoveWordById(Guid id, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordById(id, collection);
            if (word is null)
            {
                throw new Exception("null");
            }

            await _collectionRepository.RemoveWord(word);
        }

        public async Task ChangeSkillLevel(Guid id, string collectionName, Guid userId, int skillLevel)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }
            var word = await _collectionRepository.GetWordById(id, collection);
            if (word is null)
            {
                throw new Exception("null");
            }
            if(skillLevel > 2)
            {
                throw new Exception("Out of range skill level");
            }

            await _collectionRepository.ChangeSkillLevel(word, skillLevel);
        }

        public async Task ChangeManySkillLevels(List<ChangeManySkillLevel> skillLevels, string collectionName, Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("null");
            }
            var collection = await _collectionRepository.GetCollection(collectionName, user);
            if (collection is null)
            {
                throw new Exception("null");
            }
            foreach (var skill in skillLevels)
            {
                if(skill.SkillLevel > 2)
                {
                    throw new Exception($"Word with id : {skill.Id} has out of range skill level");
                }
            }

            List<Guid> wordsIDs = skillLevels.Select(skill => skill.Id).ToList();
            var filtered = await _collectionRepository.ChangeManySkillLevels(wordsIDs, collection);
            foreach (var word in filtered)
            {
                var skillLevel = skillLevels.First(x => x.Id == word.Id);
                word.SkillLevel = (SkillLevel)skillLevel.SkillLevel;
            }
            await _collectionRepository.UpdateWords(filtered);
        }
    }
}
