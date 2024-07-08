using AlbionDiscordBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.ApiResponses
{
    public class SearchResponse
    {
        public List<Guild> Guilds { get; set; }
        public List<Player> Players { get; set; }
    }
}
