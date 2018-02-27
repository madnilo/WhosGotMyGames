using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Friend
    {
        public int FriendId { get; set; }
        public string Name { get; set; }

        public List<Lending> Lendings { get; set; }
    }
}
