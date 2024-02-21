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
    public class EpisodeService : IEpisodeService
    {
        private readonly ApplicationDbContext _context;

        public EpisodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Episode> AddEpisodeAsync(Episode episode)
        {
            await _context.Episodes.AddAsync(episode);
            await _context.SaveChangesAsync();
            return episode;
        }

        public async Task<List<Episode>> GetEpisodesAsync()
        {
            var data = await _context.Episodes.ToListAsync();
            return data;
        }

        public async Task<List<Episode>> GetEpisodesByIdsAsync(int[] episodeIdArray)
        {
            List<Episode> episodes = new List<Episode>();

            foreach (var item in episodeIdArray)
            {
                var data = await _context.Episodes.FindAsync(item);
                if (data == null)
                {
                    throw new NotFoundException($"{item} not found !");
                }
                episodes.Add(data);
            }
            return episodes;
        }
    }
}
