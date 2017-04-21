using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PugJudge.Service.Lookup
{
    public class LookupService : ILookupService
    {
        public async Task<string> LookupCharacter(string name, string realm)
        {
            string response;

            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync($"https://us.api.battle.net/wow/character/{realm}/{name}?fields=progression&locale=en_US&apikey=vdq5nvkccw77cf373edfs6bjh4mgxh7h");
            }

            return response;
        }
    }
}
