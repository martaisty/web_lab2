using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_lab2.Abstractions;
using web_lab2.Models;

namespace web_lab2.Controllers
{
    public class SagesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public SagesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Sages
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Sages.GetAllAsync());
        }

        // GET: Sages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sage = await _uow.Sages.GetByIdAsync((int) id);
            if (sage == null)
            {
                return NotFound();
            }

            return View(sage);
        }

        // GET: Sages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Age,Photo,City")] Sage sage)
        {
            if (ModelState.IsValid)
            {
                await _uow.Sages.InsertAsync(sage);
                await _uow.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(sage);
        }

        // GET: Sages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sage = await _uow.Sages.GetByIdAsync((int) id);
            if (sage == null)
            {
                return NotFound();
            }

            return View(sage);
        }

        // POST: Sages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Photo,City")] Sage sage)
        {
            if (id != sage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _uow.Sages.UpdateAsync(sage);
                    await _uow.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _uow.Sages.ExistsAsync(sage.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(sage);
        }

        // GET: Sages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sage = await _uow.Sages.GetByIdAsync((int) id);
            if (sage == null)
            {
                return NotFound();
            }

            return View(sage);
        }

        // POST: Sages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _uow.Sages.DeleteAsync(id);
            await _uow.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}