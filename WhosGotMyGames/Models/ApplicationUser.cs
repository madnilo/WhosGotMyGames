using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WhosGotMyGames.Models.Entities;

namespace WhosGotMyGames.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //relationships
        public List<Game> Games { get; set; }
        public List<Friend> Friends { get; set; }
        public List<Lending> Lendings { get; set; }
    }
}
