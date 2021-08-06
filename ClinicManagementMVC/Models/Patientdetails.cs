using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Models
{
    public class Patientdetails
    {
        [Key]
        [Display(Name = "Patient ID ")]
        public int PatientID { get; set; }
        [Required]
        [Display(Name = "First Name ")]
        
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter the sex field") ]
        public string Sex { get; set; }
        [Required(ErrorMessage ="Please Enter age")]
        [Range(1, 120, ErrorMessage = "Age is beyond the limit.")]
        [Display(Name ="Age")]
        public int? Age { get; set; }
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Birth Date is required.")]
        
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Birth { get; set; }
        [Display(Name = "Reason")]
        public string reason { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([1-9]{1})([0-9]{9})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}
