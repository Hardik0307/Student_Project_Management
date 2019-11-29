using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class CreateProject
    {
        [Key]
        public int Pid { get; set; }

        [Required(ErrorMessage = "Project Definition is Required.")]
        [Display(Name ="Project Definition")]
        public string Pdef { get; set; }

        [Required(ErrorMessage = "Submission Deadline is Required.")]
        [Display(Name = "Submission Deadline")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SubmissionDeadline { get; set; }

        [Required(ErrorMessage = "Selection Deadline is Required.")]
        [Display(Name = "Selection Deadline")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SelectionDeadline { get; set; }

        [Required(ErrorMessage = "Targeted Semester is Required.")]
        [Display(Name = "Semester")]
       
        public int Psem { get; set; }

        [Display(Name = "Project Description")]
        public string Pdesp { get; set; }

        [Display(Name = "Faculty ID")]
        public string FacultyId { get; set; }

        [Required(ErrorMessage = "Project Subject is Required.")]
        [Display(Name = "Project Subject")]
        public string Psub { get; set; }

        [Required(ErrorMessage = "Project Year is Required.")]
        [Display(Name = "Project Year")]
        public int PTarYear { get; set; }

        [Required(ErrorMessage = "Total Marks is Required.")]
        [Display(Name = "Total Marks")]
        [Range(20, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int totalMarks { get; set; }

        [ForeignKey("FacultyId")]
        Student f = new Student();

        //ICollection<SubmittedProject> sp { get; set;}
    }
}