using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class SubmittedProject
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        public int Pid { get; set; } // foreign key
        [Required]
        [Display(Name ="Member 1 ID")]
        public  string member1_id { get; set; } //foreign key

        [Required]
        [Display(Name ="File")]
        public string ProjectFile { get; set; }

        [Required]
        public DateTime ProjectSubmitted { get; set; }


        [ForeignKey("Pid")]
        CreateProject cp { get; set; }
        [ForeignKey("member1_id")]
        Student s { get; set; }

    }
}