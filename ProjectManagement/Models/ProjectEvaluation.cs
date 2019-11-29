using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class ProjectEvaluation
    {
        [Key]
        public int ProjectEvalId { get; set; }
        //foreign key
        [Required]
        [Display(Name = "Member 1 ID ")]
        public string member1_id { get; set; }

        [Display(Name = "Member 2 ID ")]
        public string member2_id { get; set; }

        [Display(Name = "Member 3 ID ")]
        public string member3_id { get; set; }

        [Display(Name = "Member 1 Marks")]
        public int mem1_marks { get; set; }

        [Display(Name = "Member 2 Marks ")]
        public int mem2_marks { get; set; }

        [Display(Name = "Member 3 Marks ")]
        public int mem3_marks { get; set; }

        [Display(Name = "Total Marks")]
        public int totmarks { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        
        public int Pid { get; set; }
        [ForeignKey("Pid")]
        CreateProject cp { get; set; }

        [ForeignKey("member1_id")]
        Student s1 { get; set; }

        [ForeignKey("member2_id")]
        Student s2 { get; set; }

        [ForeignKey("member3_id")]
        Student s3 { get; set; }


    }
}