using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Game
    {
        [DisplayName("Jogo")]
        public int GameId { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        public string CoverUrl { get; set; }

        //relationships
        public List<Lending> Lendings { get; set; }

        //inverse navigation
        public ApplicationUser ApplicationUser { get; set; }

    }
}
