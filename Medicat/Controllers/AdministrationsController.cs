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
         PopulateDropdowns();
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
         PopulateDropdowns();
            return View();
        }

      private void PopulateDropdowns()
      {
         ViewData["Medicines"] =_context.Medicine.ToList();
         ViewData["Patients"] = _context.Patient.ToList();

         ViewData["PatientsList"] = new SelectList(_context.Patient.ToList(), "Id", "Name");
         ViewData["MedicinesList"] = new SelectList(_context.Medicine.ToList(), "Id", "Name");
      }

        // POST: Administrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,MedicineId,Dose,AdministrationDate,ApplicationUserId")] Administration administration)
        {
         var x = Request;
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
         PopulateDropdowns();
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,MedicineId,Dose,AdministrationDate,ApplicationUserId")] Administration administration)
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
         PopulateDropdowns();
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
