using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Lending
    {
        public int LendingId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
    }
}
