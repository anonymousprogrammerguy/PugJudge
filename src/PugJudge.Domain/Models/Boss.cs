using System;
using System.Collections.Generic;
using System.Text;

namespace PugJudge.Domain.Models
{
    public class Boss
    {
        public string Name { get; set; }

        public int LfrKills { get; set; }

        public int NormalKills { get; set; }

        public int HeroicKills { get; set; }

        public int MythicKills { get; set; }
    }
}
