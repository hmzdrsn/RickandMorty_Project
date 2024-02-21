using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task<Location> AddLocationAsync(Location location);

    }
}
