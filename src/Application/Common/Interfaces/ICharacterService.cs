using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICharacterService
    {
        Task<List<Character>> GetCharactersAsync();
        Task<List<Character>> GetCharactersByIdsAsync(int[] characterArray);
        Task<Character> AddCharacterAsync(Character character);
    }
}
