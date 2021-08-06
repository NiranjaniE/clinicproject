using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagementMVC.Models;

namespace ClinicManagementMVC.Controllers
{
    public class PatientdetailsController : Controller
    {
        private readonly ClinicContext _context;

        public PatientdetailsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Patientdetails1
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientTable.ToListAsync());
        }

        // GET: Patientdetails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientdetails = await _context.PatientTable
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientdetails == null)
            {
                return NotFound();
            }

            return View(patientdetails);
        }

        // GET: Patientdetails1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patientdetails1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,FirstName,LastName,Sex,Age,Date_of_Birth,reason,PhoneNumber")] Patientdetails patientdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientdetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientdetails);
        }

        // GET: Patientdetails1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientdetails = await _context.PatientTable.FindAsync(id);
            if (patientdetails == null)
            {
                return NotFound();
            }
            return View(patientdetails);
        }

        // POST: Patientdetails1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientID,FirstName,LastName,Sex,Age,Date_of_Birth,reason,PhoneNumber")] Patientdetails patientdetails)
        {
            if (id != patientdetails.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientdetailsExists(patientdetails.PatientID))
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
            return View(patientdetails);
        }

        // GET: Patientdetails1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientdetails = await _context.PatientTable
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientdetails == null)
            {
                return NotFound();
            }

            return View(patientdetails);
        }

        // POST: Patientdetails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientdetails = await _context.PatientTable.FindAsync(id);
            _context.PatientTable.Remove(patientdetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientdetailsExists(int id)
        {
            return _context.PatientTable.Any(e => e.PatientID == id);
        }
    }
}
