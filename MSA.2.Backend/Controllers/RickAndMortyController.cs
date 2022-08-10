using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MSA._2.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickAndMortyController : ControllerBase
    {
        private readonly HttpClient _client;

        public RickAndMortyController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _client = clientFactory.CreateClient("rickandmorty");
        }

        [HttpGet]
        [Route("character search")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRickAndMortyCharacter (string characterName)
        {
            var res = await _client.GetAsync("/?name=" + characterName);
            var content = await res.Content.ReadAsStringAsync();

            return Ok(content);
        }
    }
}
