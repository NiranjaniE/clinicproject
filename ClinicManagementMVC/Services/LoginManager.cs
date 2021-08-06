using ClinicManagementMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Services
{
    public class LoginManager : ILogins<Login>
    {
        public ClinicContext _context;
        public ILogger<LoginManager> _logger;
        public LoginManager(ClinicContext context, ILogger<LoginManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Login t)
        {
            try
            {
                _context.LoginTable.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
        public IEnumerable<Login> GetAll()
        {
            try
            {
                if ((_context.LoginTable) == null)
                    return null;
                return _context.LoginTable.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }



        public int UserLogin(Login t)
        {
            var obj = _context.RegisterTable.Where(i => i.Username.Equals(t.Username) && i.Password.Equals(t.Password)).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        
        
    }
}
