using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class Gathering
    {
        public GatheringCraftingType Fiber { get; set; }
        public GatheringCraftingType Hide { get; set; }
        public GatheringCraftingType Ore { get; set; }
        public GatheringCraftingType Rock { get; set; }
        public GatheringCraftingType Wood { get; set; }
        public GatheringCraftingType All { get; set; }
    }
}
