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

        //// GET: Friends/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var friend = await _context.Friend
        //        .SingleOrDefaultAsync(m => m.FriendId == id);
        //    if (friend == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(friend);
        //}

        //// GET: Friends/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Friends/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FriendId,Name")] Friend friend)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(friend);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(friend);
        //}

        //// GET: Friends/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var friend = await _context.Friend.SingleOrDefaultAsync(m => m.FriendId == id);
        //    if (friend == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(friend);
        //}

        //// POST: Friends/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FriendId,Name")] Friend friend)
        //{
        //    if (id != friend.FriendId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(friend);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FriendExists(friend.FriendId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(friend);
        //}

        //// GET: Friends/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var friend = await _context.Friend
        //        .SingleOrDefaultAsync(m => m.FriendId == id);
        //    if (friend == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(friend);
        //}

        //// POST: Friends/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var friend = await _context.Friend.SingleOrDefaultAsync(m => m.FriendId == id);
        //    _context.Friend.Remove(friend);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FriendExists(int id)
        //{
        //    return _context.Friend.Any(e => e.FriendId == id);
        //}
    }
}
