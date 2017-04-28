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
        public async Task<List<Raid>> LookupCharacter(Character character)
        {
            string response;

            // Query Blizzard API for character progression.
            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync(
                    $"https://us.api.battle.net/wow/character/{character.Realm}/{character.Name}?fields=progression&locale=en_US&apikey=vdq5nvkccw77cf373edfs6bjh4mgxh7h");
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

        public async Task<List<Raid>> GetRaidProgression(Character character)
        {
            string response;

            // Query Blizzard API for character progression.
            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync(
                    $"https://us.api.battle.net/wow/character/{character.Realm}/{character.Name}?fields=progression&locale=en_US&apikey=vdq5nvkccw77cf373edfs6bjh4mgxh7h");
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

        public async Task<List<Achievement>> GetAchievementProgression(Character character)
        {
            // Query Blizzard API for character achievements.
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(
                    $"https://us.api.battle.net/wow/character/{character.Realm}/{character.Name}?fields=achievements&locale=en_US&apikey=vdq5nvkccw77cf373edfs6bjh4mgxh7h");


                var json = JsonConvert.DeserializeObject<JObject>(response);

                var jsonArray = JArray.Parse(json.GetValue("achievements")["achievementsCompleted"].ToString());

                // Get the relevent raid achievements.
                var achievements =
                    jsonArray.Where(
                            achievement =>
                                achievement.Value<long>() == 10840 || achievement.Value<long>() == 10842 ||
                                achievement.Value<long>() == 10843 || achievement.Value<long>() == 10844 ||
                                achievement.Value<long>() == 10845 || achievement.Value<long>() == 10846 ||
                                achievement.Value<long>() == 10847 || achievement.Value<long>() == 10848 ||
                                achievement.Value<long>() == 10849 || achievement.Value<long>() == 10850)
                        .Select(achievement => new Achievement {Id = (int) achievement.Value<long>()})
                        .ToList();

                foreach (var achievement in achievements)
                    switch (achievement.Id)
                    {
                        case 10840:
                            achievement.Title = "Skorpyron";
                            break;
                        case 10842:
                            achievement.Title = "Chronomatic Anomaly";
                            break;
                        case 10843:
                            achievement.Title = "Trilliax";
                            break;
                        case 10844:
                            achievement.Title = "Spellblade Aluriel";
                            break;
                        case 10845:
                            achievement.Title = "Star Augur Etraeus";
                            break;
                        case 10846:
                            achievement.Title = "High Botanist Tel\'arn";
                            break;
                        case 10847:
                            achievement.Title = "Tichondrius";
                            break;
                        case 10848:
                            achievement.Title = "Krosus";
                            break;
                        case 10849:
                            achievement.Title = "Grand Magistrix Elisande";
                            break;
                        case 10850:
                            achievement.Title = "Gul\'dan";
                            break;
                        default:
                            achievement.Title = "Error";
                            break;
                    }

                return achievements;
            }
        }

        public async Task<int> GetCharacterItemLevel(Character character)
        {
            string response;

            // Query Blizzard API for character progression.
            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync(
                    $"https://us.api.battle.net/wow/character/{character.Realm}/{character.Name}?fields=items&locale=en_US&apikey=vdq5nvkccw77cf373edfs6bjh4mgxh7h");
            }

            var json = JsonConvert.DeserializeObject<JObject>(response);

            var itemLevel = (int) json.GetValue("items")["averageItemLevelEquipped"];

            return itemLevel;
        }
    }
}