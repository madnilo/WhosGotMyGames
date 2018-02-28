using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Friend
    {
        [DisplayName("Amigo")]
        public int FriendId { get; set; }
        public string Name { get; set; }

        //relationships
        public List<Lending> Lendings { get; set; }

        //inverse navigation
        public ApplicationUser ApplicationUser { get; set; }
    }
}
