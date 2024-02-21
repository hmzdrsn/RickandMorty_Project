using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var data = await _locationService.GetLocationsAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationVM model)
        {
            Location location= new Location();
            location.name = model.name;
            location.type = model.type;
            location.dimension = model.dimension;
            location.url = model.url;
            location.created = DateTime.Now;
            await _locationService.AddLocationAsync(location);
            return Ok(model);
        }
    }
}
