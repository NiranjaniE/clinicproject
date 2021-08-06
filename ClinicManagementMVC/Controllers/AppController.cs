using ClinicManagementMVC.Models;
using ClinicManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Controllers
{
    public class AppController : Controller
    {
        public readonly IAppointment<Appointmentfixing> _arepo;
        private ClinicContext _context;

        public AppController(IAppointment<Appointmentfixing> repo, ClinicContext context)
        {
            _arepo = repo;
            _context = context;
        }
        public IActionResult AddSpecialization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialization(String SpecializationRequired)
        {
            try
            {
                TempData["spec"] = SpecializationRequired;
                return RedirectToAction("AddAppointment", "App");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult AddAppointment()
        {
            return View();

        }
        [HttpPost]
        [HttpGet]
        public IActionResult AddAppointment(Appointmentfixing appointment)
        {
            var docs = _context.Doctordetails.ToList();
            ViewBag.items = docs.Where(i => i.Specialization == Convert.ToString(TempData["spec"])).Select(i => i.FirstName).ToList();
            Appointmentfixing fix = new Appointmentfixing();
            fix.PatientID = appointment.PatientID;
            fix.SpecializationRequired = Convert.ToString(TempData["spec"]);
            fix.DoctorName = appointment.DoctorName;
            fix.VisitDate = appointment.VisitDate;
            fix.VisitTime = appointment.VisitTime;


            return View();
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //[HttpGet]
        //public IActionResult IndexApp()
        //{
        //    List<Appointmentfixing> appointment = _arepo.GetAll().ToList();
        //    return View(appointment);
        //}
        //[HttpGet]
        //public IActionResult Specialization()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddApp(string Specialization)
        //{
        //    TempData["spec"] = Specialization;
        //    ViewBag.fname = (from s in _context.Doctordetails
        //                     where s.Specialization == Convert.ToString(TempData["spec"])
        //                     select s.FirstName).ToList();
        //    ViewBag.lname = (from s in _context.Doctordetails
        //                     where s.Specialization == Convert.ToString(TempData["spec"])
        //                     select s.LastName).ToList();
        //    ViewBag.did = (from s in _context.Doctordetails
        //                   where s.Specialization == Convert.ToString(TempData["spec"])
        //                   select s.DoctorID).ToList();
        //    List<Appointmentfixing> IsAppointmentAvailable = _context.AppointmentTable.Where(e => e.DoctorID == appointment.DoctorID &&
        //                      e.VisitDate == appointment.VisitDate &&
        //                       e.VisitTime == appointment.AppointmentTime).ToList();
        //    int c = IsAppointmentAvailable.Count();
        //    if (c == 0)
        //    {
        //        _arepo.AddApp(appointment);
        //        ViewBag.Message = "Record added successfully";
        //        return View(appointment);
        //        return View("AddApp", appointment);

        //    }
        //    else
        //    {
        //        ViewBag.Message = "This slot is already booked.Please choose another slot";
        //        return RedirectToAction("Specialization");
        //        return View("AddApp", appointment);
        //    }
        //}

        //[HttpPost]
        //public IActionResult AppSave(Appointmentfixing appointment)
        //{
        //    ViewBag.IfPageLoad = false;

        //    List<Appointmentfixing> count = _context.AppointmentTable.Where(e => e.DoctorID == appointment.DoctorID &&
        //                       e.AppointmentDate == appointment.AppointmentDate &&
        //                       e.AppointmentTime == appointment.AppointmentTime).ToList();
        //    int c = count.Count();
        //    if (c == 0)
        //    {
        //        _arepo.AddApp(appointment);
        //        ViewBag.Message = "Record added successfully";
        //        return RedirectToAction("Indexes", "Doctor");

        //    }
        //    else
        //    {
        //        ViewBag.Message = "This slot is already booked.Please choose another slot";
        //        return RedirectToAction("Specialization");
        //    }
        //}


        //public IActionResult DeleteApp(int id)
        //{
        //    Appointmentfixing app = _arepo.GetByID(id);
        //    return View(app);
        //}
        //[HttpPost]
        //public IActionResult DeleteApp(Appointmentfixing app)
        //{
        //    _arepo.Delete(app);
        //    return RedirectToAction("Indexes", "Doctor");
        //}

    }
}
