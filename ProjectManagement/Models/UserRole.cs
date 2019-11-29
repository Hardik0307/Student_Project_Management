using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class UserRole
    {
        [Key]
        public int id { get; set; }
        public string role { get; set; }
        public string userId { get; set; }

        [ForeignKey("userId")]
        public Student std { get; set; }
    }
}