using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class Trait
    {
        public double? Roll { get; set; }
        public List<object> PendingRolls { get; set; }
        public List<object> PendingTraits { get; set; }
        public double? Value { get; set; }
        public string TraitName { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
    }
}
