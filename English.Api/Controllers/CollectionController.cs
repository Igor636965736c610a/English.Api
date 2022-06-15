using English.Core.Dto;
using English.Infrastructure.Commands.Collection;
using English.Infrastructure.Commands.Word;
using English.Infrastructure.DTO;
using English.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace English.Api.Controllers
{
    [Authorize]
    [Route("controller")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionServices _collectionServices;
        public CollectionController(ICollectionServices collectionServices)
        {
            _collectionServices = collectionServices;
        }

        [HttpPost("createCollection")]
        public async Task Post([FromBody] CreateCollection CollectionRequest)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            await _collectionServices.AddCollection(CollectionRequest.CollectionName, userId);
        }

        [HttpPost("createWord")]
        public async Task Post([FromBody] CreateCollection collectionRequest, CreateWord wordRequest)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            await _collectionServices.AddWord
                (wordRequest.PolishWord, wordRequest.EnglishWord, collectionRequest.CollectionName, userId);
        }

        [HttpGet("collectionName")]
        public async Task<CollectionDto> GetCollection(string collectionName)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _collectionServices.GetCollection(collectionName, userId);
        }

        [HttpGet("collectionName/englishWord")]
        public async Task<WordDto> GetEnglishWord(string collectionName, string englishWord)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _collectionServices.GetWordEnglish(englishWord, collectionName, userId);
        }

        [HttpGet("collectionName/polishWord")]
        public async Task<WordDto> GetPolishWord(string collectionName, string polishWord)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _collectionServices.GetWordPolish(polishWord, collectionName, userId);
        }
    }
}
