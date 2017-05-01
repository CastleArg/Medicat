using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicat.Data;
using Medicat.Models;

namespace Medicat.Controllers
{
    public class AdministrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministrationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Administrations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administration.ToListAsync());
        }

        // GET: Administrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administration = await _context.Administration
                .SingleOrDefaultAsync(m => m.Id == id);
            if (administration == null)
            {
                return NotFound();
            }

            return View(administration);
        }

        // GET: Administrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdministrationDate")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administration);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(administration);
        }

        // GET: Administrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administration = await _context.Administration.SingleOrDefaultAsync(m => m.Id == id);
            if (administration == null)
            {
                return NotFound();
            }
            return View(administration);
        }

        // POST: Administrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdministrationDate")] Administration administration)
        {
            if (id != administration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrationExists(administration.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(administration);
        }

        // GET: Administrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administration = await _context.Administration
                .SingleOrDefaultAsync(m => m.Id == id);
            if (administration == null)
            {
                return NotFound();
            }

            return View(administration);
        }

        // POST: Administrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administration = await _context.Administration.SingleOrDefaultAsync(m => m.Id == id);
            _context.Administration.Remove(administration);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AdministrationExists(int id)
        {
            return _context.Administration.Any(e => e.Id == id);
        }
    }
}
