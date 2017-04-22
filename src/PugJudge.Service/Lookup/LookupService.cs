using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PugJudge.Domain.Models;

namespace PugJudge.Service.Lookup
{
    public class LookupService : ILookupService
    {
        public async Task<List<Raid>> LookupCharacter(string name, string realm)
        {
            string response;

            // Query Blizzard API for character progression.
            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync(
                    $"https://us.api.battle.net/wow/character/{realm}/{name}?fields=progression&locale=en_US&apikey=vdq5nvkccw77cf373edfs6bjh4mgxh7h");
            }

            var json = JsonConvert.DeserializeObject<JObject>(response);

            // Get the relevent raids.
            var raids = json.GetValue("progression")["raids"]
                .Where(x => x["name"].Value<string>() == "The Emerald Nightmare" ||
                            x["name"].Value<string>() == "Trial of Valor" ||
                            x["name"].Value<string>() == "The Nighthold")
                .Select(raid => raid.ToObject<Raid>())
                .ToList();

            return raids;
        }
    }
}