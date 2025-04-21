using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly MyAnimeListService _malService;

        public AnimeController(MyAnimeListService malService) {
            _malService = malService;
        }

        //Get handler for top
        [HttpGet("top")]
        public async Task<IActionResult> GetTopAnime() {
            var result = await _malService.GetTopAnimeAsync();

            if(result == null)
                return StatusCode(500, "Failed to fetch anime data from MAL");
            
            return Ok(result);
        }

        // GET: /api/anime/search?query=naruto
        [HttpGet("search")]
        public async Task<IActionResult> SearchAnime([FromQuery] string query)
        {
            var result = await _malService.SearchAnimeAsync(query);

            if (result == null)
                return StatusCode(500, "Search failed.");

            return Ok(result);
        }

        // GET: /api/anime/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeById(int id)
        {
            var result = await _malService.GetAnimeByIdAsync(id);

            if (result == null)
                return NotFound("Anime not found.");

            return Ok(result);
        }
    }
}