using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Users")]
    public class Student
    {
        [Key]
        [Required(ErrorMessage ="ID is Required.")]
        [Display(Name="ID")]
        public string Id { get; set; }
    
        [Required(ErrorMessage ="Email is Required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string emailId { get; set; }

        [Required(ErrorMessage ="Password is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage ="Phone number is Required.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"[0-9]{10}",ErrorMessage ="Phone Number is not valid.")]
        public long phone { get; set; }


        [Required(ErrorMessage ="Joining year is Required.")]
        [Display(Name ="Join Year")]
        public int joinYear { get; set; }

        [Required(ErrorMessage ="Semester is Required.")]
        [Display(Name = "Semester")]
        public int semester { get; set; }

        [Display(Name ="City")]
        public string city { get; set; }

        [Required(ErrorMessage ="Department is Required.")]
        [Display(Name="Department")]
        public string Dept { get; set; }


        public virtual ICollection<ProjectEvaluation> pe { get; set; }
    }
}