using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Lending
    {
        public int LendingId { get; set; }
        [DisplayName("Data do Empréstimo")]
        public DateTime DateBorrowed { get; set; }
        [DisplayName("Data de Devolução")]
        public DateTime? DateReturned { get; set; }

        //inverse navigation
        public Game Game { get; set; }
        public Friend Friend { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
