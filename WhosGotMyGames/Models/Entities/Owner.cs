using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Game> Games { get; set; }
        public List<Friend> Friends { get; set; }
        public List<Lending> Lendings { get; set; }
    }
}
