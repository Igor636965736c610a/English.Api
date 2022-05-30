using English.Core.Dto;
using English.Infrastructure.Commands;
using English.Infrastructure.Commands.Collection;
using English.Infrastructure.Commands.User;
using English.Infrastructure.Commands.Word;
using English.Infrastructure.DTO;
using English.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace English.Api.Controllers
{
    [Route("controller")]
    public class CollectionController
    {
        private readonly ICollectionServices _collectionServices;
        public CollectionController(ICollectionServices collectionServices)
        {
            _collectionServices = collectionServices;
        }

        [HttpPost("createCollection")]
        public async Task Post([FromBody] CreateCollection CollectionRequest, CreateUser userRequest)
            => await _collectionServices.AddCollection(CollectionRequest.CollectionName, userRequest.Id);

        [HttpPost("createWord")]
        public async Task Post([FromBody] CreateCollection collectionRequest, CreateWord wordRequest, CreateUser userRequest)
            => await _collectionServices.AddWord(wordRequest.PolishWord, wordRequest.EnglishWord, collectionRequest.CollectionName, userRequest.Id);

        [HttpGet("collectionName")]
        public async Task<CollectionDto> GetCollection(string collectionName, CreateUser userRequest)
            => await _collectionServices.GetCollection(collectionName, userRequest.Id);

        [HttpGet("collectionName/englishWord")]
        public async Task<WordDto> GetEnglishWord(string collectionName, string englishWord, CreateUser userRequest)
            => await _collectionServices.GetWordEnglish(englishWord, collectionName, userRequest.Id);

        [HttpGet("collectionName/polishWord")]
        public async Task<WordDto> GetPolishWord(string collectionName, string polishWord, CreateUser userRequest)
            => await _collectionServices.GetWordPolish(polishWord, collectionName, userRequest.Id);
    }
}
