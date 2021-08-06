using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Models
{
    public class Doctordetails
    {
        [Key]
        [Display(Name ="Doctor ID")]
        public int DoctorID { get; set; }
        
        [Required(ErrorMessage = "Enter Username")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Enter the Sex field")]
        public string Sex { get; set; }
        [Required(ErrorMessage ="Please enter the Age")]
        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        public int? Age { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required.")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Birth { get; set; }
        [Required(ErrorMessage ="Please enter the Specialization") ]
        public string Specialization { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "From Time")]
        public DateTime? FromTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "To Time")]
        public DateTime? ToTime { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([1-9]{1})([0-9]{9})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
    
}
