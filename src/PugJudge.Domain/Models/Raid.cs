using System;
using System.Collections.Generic;
using System.Text;

namespace PugJudge.Domain.Models
{
    public class Raid
    {
        public string Name { get; set; }

        public List<Boss> Bosses { get; set; }
    }
}
