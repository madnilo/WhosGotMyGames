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
    public class FriendsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public FriendsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Friends
        public IActionResult Index()
        {
            return View(_unitOfWork.FriendsRepository.GetAll());
        }

        // GET: Friends/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = _unitOfWork.FriendsRepository.Find(f => f.FriendId == id.Value).FirstOrDefault();
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FriendId,Name")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FriendsRepository.Add(friend);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friends/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = _unitOfWork.FriendsRepository.Get(id.Value);
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FriendId,Name")] Friend friend)
        {
            if (id != friend.FriendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.FriendsRepository.Update(friend);
                    _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.FriendsRepository.Get(friend.FriendId) == null)
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
            return View(friend);
        }

        // GET: Friends/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = _unitOfWork.FriendsRepository.Get(id.Value);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var friend = _unitOfWork.FriendsRepository.Get(id);
            _unitOfWork.FriendsRepository.Remove(friend);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

    }
}
