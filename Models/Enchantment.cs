using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class Enchantment
    {
        public int? EnchantmentLevel { get; set; }
        public double? ItemPower { get; set; }
        public double? Durability { get; set; }
        public CraftingRequirements CraftingRequirements { get; set; }
    }
}
