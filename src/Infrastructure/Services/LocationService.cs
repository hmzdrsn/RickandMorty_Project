using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var data = await _context.Locations.FindAsync(id);
            if (data == null)
            {
                throw new NotFoundException($"{id} not found !");
            }
            return data;
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            var data = await _context.Locations.ToListAsync();
            return data;
        }
    }
}
