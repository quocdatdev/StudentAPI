using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDemo.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        
        public string Phone { get; set; }
        
        //add comment in github
    }
}
