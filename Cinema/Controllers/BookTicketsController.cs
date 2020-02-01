using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.Controllers
{
    public class BookTicketsController : Controller
    {
        private readonly CinemaContext _context;

        public BookTicketsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: BookTickets
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.BookTickets.Include(b => b.Hall).Include(b => b.Movie);
            return View(await cinemaContext.ToListAsync());
        }


        public async Task<IActionResult> BookTicket(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTickets
                .Include(b => b.Hall)
                .Include(b => b.Movie)
                .FirstOrDefaultAsync(m => m.BookTicketID == id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            return View(bookTicket);
        }

        // GET: BookTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTickets
                .Include(b => b.Hall)
                .Include(b => b.Movie)
                .FirstOrDefaultAsync(m => m.BookTicketID == id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            return View(bookTicket);
        }

        // GET: BookTickets/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["HallID"] = new SelectList(_context.Halls, "Id", "Id");
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        // POST: BookTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookTicketID,MovieID,HallID")] BookTicket bookTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HallID"] = new SelectList(_context.Halls, "Id", "Id", bookTicket.HallID);
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Title", bookTicket.MovieID);
            return View(bookTicket);
        }

        // GET: BookTickets/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTickets.FindAsync(id);
            if (bookTicket == null)
            {
                return NotFound();
            }
            ViewData["HallID"] = new SelectList(_context.Halls, "Id", "Id", bookTicket.HallID);
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Title", bookTicket.MovieID);
            return View(bookTicket);
        }

        // POST: BookTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("BookTicketID,MovieID,HallID")] BookTicket bookTicket)
        {
            if (id != bookTicket.BookTicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTicketExists(bookTicket.BookTicketID))
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
            ViewData["HallID"] = new SelectList(_context.Halls, "Id", "Id", bookTicket.HallID);
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Title", bookTicket.MovieID);
            return View(bookTicket);
        }

        // GET: BookTickets/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTickets
                .Include(b => b.Hall)
                .Include(b => b.Movie)
                .FirstOrDefaultAsync(m => m.BookTicketID == id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            return View(bookTicket);
        }

        // POST: BookTickets/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTicket = await _context.BookTickets.FindAsync(id);
            _context.BookTickets.Remove(bookTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTicketExists(int id)
        {
            return _context.BookTickets.Any(e => e.BookTicketID == id);
        }
    }
}
