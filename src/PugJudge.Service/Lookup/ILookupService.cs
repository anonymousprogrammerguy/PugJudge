using System.Collections.Generic;
using System.Threading.Tasks;
using PugJudge.Domain.Models;

namespace PugJudge.Service.Lookup
{
    public interface ILookupService
    {
        Task<List<Raid>> LookupCharacter(Character character);

        Task<List<Raid>> GetRaidProgression(Character character);

        Task<List<Achievement>> GetAchievementProgression(Character character);

        Task<int> GetCharacterItemLevel(Character character);

        Task<List<PvPBracket>> GetCharacterPvP(Character character);
    }
}