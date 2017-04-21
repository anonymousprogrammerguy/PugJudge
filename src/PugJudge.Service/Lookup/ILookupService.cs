using System.Threading.Tasks;

namespace PugJudge.Service.Lookup
{
    public interface ILookupService
    {
        Task<string> LookupCharacter(string name, string realm);
    }
}