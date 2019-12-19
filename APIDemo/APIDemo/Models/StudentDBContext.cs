using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace APIDemo.Models
{
    public class StudentDBContext : DbContext
    {
        DbSet<Student> Students { get; set; }
    }
}