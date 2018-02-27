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
            return View(_unitOfWork.LendingsRepository.GetAll());
        }

        // GET: Lendings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = _unitOfWork.LendingsRepository.Get(id.Value);
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
        public IActionResult Create([Bind("LendingId,DateBorrowed,DateReturned")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LendingsRepository.Add(lending);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(lending);
        }

        // GET: Lendings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = _unitOfWork.LendingsRepository.Get(id.Value);
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
        public IActionResult Edit(int id, [Bind("LendingId,DateBorrowed,DateReturned")] Lending lending)
        {
            if (id != lending.LendingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.LendingsRepository.Update(lending);
                    _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.LendingsRepository.Get(id) == null)
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
    }
}
