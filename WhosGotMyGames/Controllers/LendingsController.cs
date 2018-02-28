using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhosGotMyGames.Data;
using WhosGotMyGames.Models.Entities;
using WhosGotMyGames.Models.ViewModels;
using WhosGotMyGames.unitOfWork.Abstract;

namespace WhosGotMyGames.Controllers
{
    [Authorize]
    public class LendingsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public LendingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Lendings
        public IActionResult Index()
        {
            return View(_unitOfWork.LendingsRepository.GetAllFromUser(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        // GET: Lendings/Create
        public IActionResult Create()
        {
            var games = _unitOfWork.GamesRepository.GetAll().ToList();
            var availableGames = new List<SelectListItem>();
            foreach (var game in games) availableGames.Add(new SelectListItem() { Text = game.Name, Value = game.GameId.ToString() });

            var friends = _unitOfWork.FriendsRepository.GetAll().ToList();
            var sfriends = new List<SelectListItem>();
            foreach (var friend in friends) sfriends.Add(new SelectListItem() { Text = friend.Name, Value = friend.FriendId.ToString() });

            var model = new LendingViewModel()
            {
                AvailableGames = availableGames,
                Friends = sfriends,
                Lending = new Lending() { DateBorrowed = DateTime.Now, }
            };
            return View(model);
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lending lending)
        {
            if (ModelState.IsValid)
            {
                lending.Friend = _unitOfWork.FriendsRepository.Get(lending.Friend.FriendId);
                lending.Game = _unitOfWork.GamesRepository.Get(lending.Game.GameId);
                lending.ApplicationUser = _unitOfWork.LendingsRepository.GetLoggedUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _unitOfWork.LendingsRepository.Add(lending);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(lending);
        }

        public IActionResult Returned(int lendingId)
        {
            try
            {
                var lending = _unitOfWork.LendingsRepository.Get(lendingId);
                lending.DateReturned = DateTime.Now;
                _unitOfWork.LendingsRepository.Update(lending);
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_unitOfWork.LendingsRepository.Get(lendingId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        
    }
}
