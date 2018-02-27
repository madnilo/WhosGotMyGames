using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhosGotMyGames.Data;
using WhosGotMyGames.Models.Entities;

namespace WhosGotMyGames.Controllers
{
    public class LendingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LendingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lendings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lending.ToListAsync());
        }

        // GET: Lendings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .SingleOrDefaultAsync(m => m.LendingId == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // GET: Lendings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LendingId,DateBorrowed,DateReturned")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lending);
        }

        // GET: Lendings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending.SingleOrDefaultAsync(m => m.LendingId == id);
            if (lending == null)
            {
                return NotFound();
            }
            return View(lending);
        }

        // POST: Lendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LendingId,DateBorrowed,DateReturned")] Lending lending)
        {
            if (id != lending.LendingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingExists(lending.LendingId))
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
            return View(lending);
        }

        // GET: Lendings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .SingleOrDefaultAsync(m => m.LendingId == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // POST: Lendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lending = await _context.Lending.SingleOrDefaultAsync(m => m.LendingId == id);
            _context.Lending.Remove(lending);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendingExists(int id)
        {
            return _context.Lending.Any(e => e.LendingId == id);
        }
    }
}
