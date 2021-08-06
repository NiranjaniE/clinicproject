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
    public class DoctordetailsController : Controller
    {
        private readonly ClinicContext _context;
        

        public DoctordetailsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Doctordetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctordetails.ToListAsync());
        }

        // GET: Doctordetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctordetails = await _context.Doctordetails
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctordetails == null)
            {
                return NotFound();
            }

            return View(doctordetails);
        }

        // GET: Doctordetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctordetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,FirstName,LastName,Sex,Age,Date_of_Birth,Specialization,FromTime,ToTime,PhoneNumber")] Doctordetails doctordetails)
        {

            if (ModelState.IsValid)
            {
                _context.Add(doctordetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctordetails);
        }

        // GET: Doctordetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctordetails = await _context.Doctordetails.FindAsync(id);
            if (doctordetails == null)
            {
                return NotFound();
            }
            return View(doctordetails);
        }

        // POST: Doctordetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorID,FirstName,LastName,Sex,Age,Date_of_Birth,Specialization,FromTime,ToTime,PhoneNumber")] Doctordetails doctordetails)
        {
            if (id != doctordetails.DoctorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctordetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctordetailsExists(doctordetails.DoctorID))
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
            return View(doctordetails);
        }

        // GET: Doctordetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctordetails = await _context.Doctordetails
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctordetails == null)
            {
                return NotFound();
            }

            return View(doctordetails);
        }

        // POST: Doctordetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctordetails = await _context.Doctordetails.FindAsync(id);
            _context.Doctordetails.Remove(doctordetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctordetailsExists(int id)
        {
            return _context.Doctordetails.Any(e => e.DoctorID == id);
        }
    }
}
