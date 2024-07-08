using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GuildId { get; set; }
        public string GuildName { get; set; }
        public string AllianceId { get; set; }
        public string AllianceName { get; set; }
        public string Avatar { get; set; }
        public string AvatarRing { get; set; }
        public double AverageItemPower { get; set; }
        public Equipment Equipment { get; set; }
        public List<object> Inventory { get; set; }
        public int? TotalKills { get; set; }
        public int? GvgKills { get; set; }
        public int? GvgWon { get; set; }
        public int? DeathFame { get; set; }
        public int? KillFame { get; set; }
        public double? FameRatio { get; set; }
        public LifetimeStatistics LifetimeStatistics { get; set; }
    }
}
