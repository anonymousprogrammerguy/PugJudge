using System;
using System.Collections.Generic;
using System.Text;
using PugJudge.Domain.Models;

namespace PugJudge.Domain.ViewModels
{
    public class CharacterProgressionViewModel
    {
        public CharacterProgressionViewModel(Character character, List<Raid> raids, List<Achievement> achievements)
        {
            Character = character;
            Raids = raids;
            Achievements = achievements;
        }

        public Character Character { get; set; }

        public List<Raid> Raids { get; set; }

        public List<Achievement> Achievements { get; set; }

        public List<PvPBracket> PvPBrackets { get; set; }

        public string ProgressionClass { get; set; } = "text-success";
    }
}
