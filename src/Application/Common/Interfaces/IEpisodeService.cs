using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEpisodeService
    {
        Task<List<Episode>> GetEpisodesByIdsAsync(int[] episodeIdArray);
        Task<Episode> AddEpisodeAsync(Episode episode);

        Task<List<Episode>> GetEpisodesAsync();
        
    }
}
