using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class ActiveProject
    {
        [Key]
        public int ActId { get; set; }
        // foreign key
        [Required(ErrorMessage ="Project Title is required.")]
        [Display(Name ="Project Title")]
        public string PrjTitle { get; set; }

        [Required(ErrorMessage = "Member 1 ID is required.")]
        [Display(Name ="Member 1 ID ")]
        public string member1_id { get; set; }

        //[Required(ErrorMessage = "Member 2 ID is required.")]
        [Display(Name = "Member 2 ID ")]
        public string member2_id { get; set; }

        //[Required(ErrorMessage = "Member 3 ID is required.")]
        [Display(Name = "Member 3 ID ")]
        public string member3_id { get; set; }

        //[Required(ErrorMessage = "Member 1 Name is required.")]
        [Display(Name = "Member 1 Name ")]
        public string member1_name { get; set; }

        //[Required(ErrorMessage = "Member 2 Name is required.")]
        [Display(Name = "Member 2 Name ")]
        public string member2_name { get; set; }

        //[Required(ErrorMessage = "Member 3 Name is required.")]
        [Display(Name = "Member 3 Name ")]
        public string member3_name { get; set; }

        //Automatic in DB    
        public string FacultyId { get; set; } 

        public DateTime SelectionDate { get; set;}

        public int Pid { get; set; }
        [ForeignKey("Pid")]
        CreateProject cp = new CreateProject();

        [ForeignKey("FacultyId")]
        Student f = new Student();

        [ForeignKey("member1_id")]
        Student s1 { get; set; }

        [ForeignKey("member2_id")]
        Student s2 { get; set; }

        [ForeignKey("member3_id")]
        Student s3 { get; set; }





    }
}