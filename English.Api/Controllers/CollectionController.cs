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
        public void Post([FromBody] CreateCollection request)
        {
            _collectionServices.AddCollection(request.CollectionName);
        }

        [HttpPost("createWord")]
        public void Post([FromBody] CreateCollection collectionRequest, CreateWord wordRequest)
        {
            _collectionServices.AddWord(wordRequest.PolishWord, wordRequest.EnglishWord, collectionRequest.CollectionName);
        }

        [HttpGet("collectionName")]
        public CollectionDto GetCollection(string collectionName)
                => _collectionServices.GetCollection(collectionName);

        [HttpGet("collectionName/englishWord")]
        public WordDto GetEnglishWord(string collectionName, string englishWord)
        {
            var word = _collectionServices.GetWordEnglish(englishWord, collectionName);
            return word;
        }

        [HttpGet("collectionName/polishWord")]
        public WordDto GetPolishWord(string collectionName, string polishWord)
        {
            var word = _collectionServices.GetWordPolish(polishWord, collectionName);
            return word;
        }
    }
}
