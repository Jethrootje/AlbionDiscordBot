using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class LegendarySoul
    {
        public string Id { get; set; }
        public int? Subtype { get; set; }
        public int? Era { get; set; }
        public object Name { get; set; }
        public DateTime? LastEquipped { get; set; }
        public string AttunedPlayer { get; set; }
        public string AttunedPlayerName { get; set; }
        public long? Attunement { get; set; }
        public long? AttunementSpentSinceReset { get; set; }
        public long? AttunementSpent { get; set; }
        public int? Quality { get; set; }
        public string CraftedBy { get; set; }
        public List<Trait> Traits { get; set; }
        public float? PvPFameGained { get; set; }
    }
}
