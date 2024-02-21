using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OriginService : IOriginService
    {
        private readonly ApplicationDbContext _context;

        public OriginService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Origin> GetOriginByIdAsync(int id)
        {
            var data = await _context.Origins.FindAsync(id);
            if (data == null)
            {
                throw new NotFoundException($"{id} not found !");
            }
            return data;
        }
    }
}
