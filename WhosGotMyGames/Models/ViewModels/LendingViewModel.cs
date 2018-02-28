using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosGotMyGames.Models.Entities;

namespace WhosGotMyGames.Models.ViewModels
{
    public class LendingViewModel
    {
        public Lending Lending { get; set; }
        public List<SelectListItem> AvailableGames { get; set; } //games that are currently with the user
        public List<SelectListItem> Friends { get; set; }
    }
}
