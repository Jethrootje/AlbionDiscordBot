using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class Item
    {
        public string Type { get; set; }
        public int? Count { get; set; }
        public int? Quality { get; set; }
        public List<object> ActiveSpells { get; set; }
        public List<object> PassiveSpells { get; set; }
        public LegendarySoul LegendarySoul { get; set; }
    }
}
