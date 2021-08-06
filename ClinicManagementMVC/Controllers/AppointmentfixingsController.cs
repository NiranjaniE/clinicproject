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
    public class AppointmentfixingsController : Controller
    {
        private readonly ClinicContext _context;

        public AppointmentfixingsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Appointmentfixings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentTable.ToListAsync());
        }

        // GET: Appointmentfixings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentfixing = await _context.AppointmentTable
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentfixing == null)
            {
                return NotFound();
            }

            return View(appointmentfixing);
        }

        // GET: Appointmentfixings/Create
        public IActionResult Create()
        {
            ViewBag.DoctorList = _context.Doctordetails.Select(x => new { Id = x.DoctorID, Name = $"{x.FirstName} {x.LastName}" }).ToList();
            var pList = _context.Doctordetails.ToList();
            return View();



        }

        // POST: Appointmentfixings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,PatientID,SpecializationRequired,DoctorName,VisitDate,VisitTime")] Appointmentfixing appointmentfixing)
        {


            if (ModelState.IsValid)
            {

                _context.Add(appointmentfixing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = "Please enter all fields";
                return RedirectToAction("Error", "Logins");
                
            }




        }

        // GET: Appointmentfixings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.DoctorList = _context.Doctordetails.Select(x => new { Id = x.DoctorID, Name = $"{x.FirstName} {x.LastName}" }).ToList();
            var appointmentfixing = await _context.AppointmentTable.FindAsync(id);
            if (appointmentfixing == null)
            {
                return NotFound();
            }
            return View(appointmentfixing);
        }

        // POST: Appointmentfixings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,PatientID,SpecializationRequired,DoctorName,VisitDate,VisitTime")] Appointmentfixing appointmentfixing)
        {
            if (id != appointmentfixing.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentfixing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentfixingExists(appointmentfixing.AppointmentId))
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
            return View(appointmentfixing);
        }

        // GET: Appointmentfixings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentfixing = await _context.AppointmentTable
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentfixing == null)
            {
                return NotFound();
            }

            return View(appointmentfixing);
        }

        // POST: Appointmentfixings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentfixing = await _context.AppointmentTable.FindAsync(id);
            _context.AppointmentTable.Remove(appointmentfixing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentfixingExists(int id)
        {
            return _context.AppointmentTable.Any(e => e.AppointmentId == id);
        }
    }
}