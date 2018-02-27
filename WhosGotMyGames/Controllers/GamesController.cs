using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhosGotMyGames.Data;
using WhosGotMyGames.Models.Entities;
using WhosGotMyGames.unitOfWork.Abstract;

namespace WhosGotMyGames.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Games
        public IActionResult Index()
        {
            return View(_unitOfWork.GamesRepository.GetAll());
        }

        // GET: Games/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _unitOfWork.GamesRepository.Get(id.Value);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GameId,Name,LaunchDate,CoverUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GamesRepository.Add(game);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _unitOfWork.GamesRepository.Find(item => item.GameId == id.Value).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GameId,Name,LaunchDate,CoverUrl")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var g = _unitOfWork.GamesRepository.Get(game.GameId);
                    g.CoverUrl = game.CoverUrl;
                    g.LaunchDate = game.LaunchDate;
                    g.Name = game.Name;
                    _unitOfWork.GamesRepository.Update(g);
                    _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.GamesRepository.Get(game.GameId) == null)
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
            return View(game);
        }

        // GET: Games/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _unitOfWork.GamesRepository.Find(m => m.GameId == id).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var game = _unitOfWork.GamesRepository.Get(id);
            _unitOfWork.GamesRepository.Remove(game);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

    }
}
