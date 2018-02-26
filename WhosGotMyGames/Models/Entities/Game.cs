using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhosGotMyGames.Models.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        public string CoverUrl { get; set; }
        public int MyProperty { get; set; }

    }
}
