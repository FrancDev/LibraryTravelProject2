using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryTravelProject.Models;

namespace LibraryTravelProject.Controllers
{
    public class LibroesController : Controller
    {
        private readonly LibrosDbContext _context;

        public LibroesController(LibrosDbContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libros.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Editorial)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

    }
}
