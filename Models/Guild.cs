using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class Guild
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FounderId { get; set; }
        public string FounderName { get; set; }
        public DateTime? Founded { get; set; }
        public string AllianceTag { get; set; }
        public string AllianceId { get; set; }
        public string AllianceName { get; set; }
        public string Logo { get; set; }
        public int? KillFame { get; set; }
        public int? DeathFame { get; set; }
        public int? AttacksWon { get; set; }
        public int? DefensesWon { get; set; }
        public int? MemberCount { get; set; }
    }
}
