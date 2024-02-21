using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;
        private readonly ICharacterService _characterService;

        public EpisodeController(IEpisodeService episodeService, ICharacterService characterService)
        {
            _episodeService = episodeService;
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEpisodes()
        {
            var data = await _episodeService.GetEpisodesAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddEpisode(EpisodeVM model)
        {
            Episode episode = new();
            episode.name = model.name;
            episode.air_date = model.air_date;
            episode.episode = model.episode;
            episode.url = model.url;
            episode.created = DateTime.Now;
            episode.characters = await _characterService.GetCharactersByIdsAsync(model.characterList);
            await _episodeService.AddEpisodeAsync(episode);
            return Ok(episode);
        }
    }
}
