using ClinicManagementMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementMVC.Models;

namespace ClinicManagementMVC.Models
{
    public class ClinicContext:DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        { }

        public DbSet<Login>LoginTable { get; set; }
        public DbSet<Patientdetails> PatientTable { get; set; }
        
        public DbSet<Doctordetails> Doctordetails{ get; set; }
        public DbSet<Appointmentfixing> AppointmentTable { get; set; }
        public DbSet<Register> RegisterTable { get; set; }

    }
}
