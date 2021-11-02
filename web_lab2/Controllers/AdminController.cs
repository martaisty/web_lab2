using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using web_lab2.Abstractions;
using web_lab2.Models;

namespace web_lab2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _uof;

        public AdminController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        // GET
        public async Task<IActionResult> Books()
        {
            return View(new List<Book>(await _uof.Books.GetAllAsync()));
        }
    }
}