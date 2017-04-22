using System.Collections.Generic;
using System.Threading.Tasks;
using PugJudge.Domain.Models;

namespace PugJudge.Service.Lookup
{
    public interface ILookupService
    {
        Task<List<Raid>> LookupCharacter(string name, string realm);
    }
}