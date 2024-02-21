using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IOriginService _originService;
        private readonly ILocationService _locationService;
        private readonly IEpisodeService _episodeService;
        public CharacterController(ICharacterService characterService, IOriginService originService, ILocationService locationService, IEpisodeService episodeService)
        {
            _characterService = characterService;
            _originService = originService;
            _locationService = locationService;
            _episodeService = episodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var data = await _characterService.GetCharactersAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(CharacterVM character)
        {
            Character model = new Character();
            model.name = character.name;
            model.status = character.status;
            model.species = character.species;
            model.type = character.type;
            model.gender = character.gender;
            model.image = character.image;
            model.url = character.url;
            model.created = DateTime.Now;
            model.origin = await _originService.GetOriginByIdAsync(character.originID);
            model.location = await _locationService.GetLocationByIdAsync(character.locationID);
            model.episode = await _episodeService.GetEpisodesByIdsAsync(character.episodeArray);
            return Ok(await _characterService.AddCharacterAsync(model));
        }

    }
}
