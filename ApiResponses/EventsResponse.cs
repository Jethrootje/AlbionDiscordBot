using AlbionDiscordBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.ApiResponses
{
    public class EventsResponse
    {
        public int? NumberOfParticipants { get; set; }
        public int? GroupMemberCount { get; set; }
        public int? EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? Version { get; set; }
        public Player Killer { get; set; }
        public Player Victim { get; set; }
        public int? TotalVictimKillFame { get; set; }
        public string Location { get; set; }
        public List<Player> Participants { get; set; }
        public List<Player> GroupMembers { get; set; }
        public object GvGMatch { get; set; }
        public int? BattleId { get; set; }
        public string KillArea { get; set; }
        public object Category { get; set; }
        public string Type { get; set; }
    }
}
