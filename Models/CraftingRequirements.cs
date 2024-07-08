using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class CraftingRequirements
    {
        public double? Time { get; set; }
        public double? Silver { get; set; }
        public int? CraftingFocus { get; set; }
        public List<CraftResource> CraftResourceList { get; set; }
    }
}
