using System;
using System.Collections.Generic;
using System.Text;
using PugJudge.Domain.Models;

namespace PugJudge.Domain.ViewModels
{
    public class CharacterProgressionViewModel
    {
        public CharacterProgressionViewModel(Character character, List<Raid> raids)
        {
            Character = character;
            Raids = raids;
        }

        public Character Character { get; set; }

        public List<Raid> Raids { get; set; }
    }
}
