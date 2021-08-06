using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagementMVC.Models;
using Microsoft.Extensions.Logging;
using ClinicManagementMVC.Services;

namespace ClinicManagementMVC.Controllers
{
    public class LoginsController : Controller
    {
        private readonly ClinicContext _context;

        public readonly ILogger<LoginsController> _logger;
        public readonly ILogins<Login> _repo;
        public LoginsController(ILogger<LoginsController> logger, ILogins<Login> repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Login> userLogin = _repo.GetAll().ToList();
            return View(userLogin);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Login userLogin)
        {
            _repo.Add(userLogin);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login userLogin)
        {
            var obj = _repo.UserLogin(userLogin);
            try
            {
                if (obj != 0)
                {
                    TempData["Success"] = "Logged in Successfully";
                    return RedirectToAction("Success");
                }
                else
                {
                    TempData["Message"] = "Please enter the correct User Name or Password";
                    return RedirectToAction("Login");
                }
            }
            catch(Exception e)

            {
                _logger.LogDebug(e.Message);
            }
            return RedirectToAction("Login","Logins");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}
