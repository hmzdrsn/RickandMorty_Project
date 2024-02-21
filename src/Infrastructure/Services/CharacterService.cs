using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;

        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            await _context.Character.AddAsync(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var data = await _context.Character.Include(x=>x.origin).Include(x=>x.location).Include(x=>x.episode).ToListAsync();
            return data;
        }

        public async Task<List<Character>> GetCharactersByIdsAsync(int[] characterArray)
        {
            List<Character> list = new List<Character>();
            foreach (var item in characterArray)
            {
                var data = await _context.Character.FindAsync(item);
                list.Add(data);
            }
            return list;
        }
    }
}
