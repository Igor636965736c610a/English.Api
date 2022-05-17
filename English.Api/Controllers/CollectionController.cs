using English.Core.Dto;
using English.Infrastructure.Commands.Collection;
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
        public async Task Post([FromBody] CreateCollection request)
            => await _collectionServices.AddCollection(request.CollectionName);


        [HttpPost("createWord")]
        public async Task Post([FromBody] CreateCollection collectionRequest, CreateWord wordRequest)
            => await _collectionServices.AddWord(wordRequest.PolishWord, wordRequest.EnglishWord, collectionRequest.CollectionName);


        [HttpGet("collectionName")]
        public async Task<CollectionDto> GetCollection(string collectionName)
            => await _collectionServices.GetCollection(collectionName);

        [HttpGet("collectionName/englishWord")]
        public async Task<WordDto> GetEnglishWord(string collectionName, string englishWord)
            => await _collectionServices.GetWordEnglish(englishWord, collectionName);

        [HttpGet("collectionName/polishWord")]
        public async Task<WordDto> GetPolishWord(string collectionName, string polishWord)
            => await _collectionServices.GetWordPolish(polishWord, collectionName);
    }
}
