using ClinicManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Models
{
    public class Appointmentfixing
    {
        [Key]
        [Display(Name ="Appointment ID")]
        public int AppointmentId { get; set; }
        [Display(Name ="Patient ID")]
        [Required(ErrorMessage ="Please fill Patient ID field") ]
        public int PatientID { get; set; }
        [Display(Name = "Specialization Required")]
        [Required(ErrorMessage ="Please fill SpecializationRequired field")]
        public string SpecializationRequired { get; set; }
        [Display(Name ="Doctor Name")]
        [Required(ErrorMessage ="Please fill the Doctor Name field")]
        public string DoctorName { get; set; }

        [Display(Name = "Visit Date")]
        [Required(ErrorMessage = "Visit Date is required.")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string VisitDate { get; set; }
        [Required(ErrorMessage ="Please fill the Visit Time field")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "Visit Time")]
        public DateTime VisitTime { get; set; }
    }
   
}

