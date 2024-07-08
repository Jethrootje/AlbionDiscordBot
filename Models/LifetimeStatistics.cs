using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class LifetimeStatistics
    {
        public PvE PvE { get; set; }
        public Gathering Gathering { get; set; }
        public GatheringCraftingType Crafting { get; set; }
        public int CrystalLeague { get; set; }
        public int FishingFame { get; set; }
        public int FarmingFame { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
