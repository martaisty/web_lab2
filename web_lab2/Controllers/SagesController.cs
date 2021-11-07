using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_lab2.Abstractions;
using web_lab2.Models;
using web_lab2.Models.Admin;

namespace web_lab2.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Create([Bind("Name,Age,Photo,City")] SageUpsert svm)
        {
            if (ModelState.IsValid)
            {
                Sage sage = new Sage
                {
                    Name = svm.Name,
                    Age = svm.Age,
                    City = svm.City
                };
                CopyImageToSage(sage, svm.Photo);

                await _uow.Sages.InsertAsync(sage);
                await _uow.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(svm);
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

            var svm = new SageUpsert()
            {
                Id = sage.Id,
                Age = sage.Age,
                City = sage.City,
                // Books = sage.Books,
                Name = sage.Name
            };
            return View(svm);
        }

        // POST: Sages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Photo,City")] SageUpsert svm)
        {
            if (id != svm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Sage sage = await _uow.Sages.GetByIdAsync(id);
                sage.Name = svm.Name;
                sage.Age = svm.Age;
                sage.City = svm.City;
                CopyImageToSage(sage, svm.Photo);

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

            return View(svm);
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

        private void CopyImageToSage(Sage sage, IFormFile file)
        {
            if (file != null)
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int) file.Length);
                }

                sage.Photo = imageData;
            }
        }
    }
}