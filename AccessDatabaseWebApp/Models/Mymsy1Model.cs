using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccessDatabaseWebApp.Models
{
    public class Mymsy1Model
    {
        
        public String Sorts { get; set; }
        [Display(Name = "Object Name")]
        public String objname { get; set; }
        public String Description { get; set; }
        [Display(Name = "Object Type")]
        public String objtype { get; set; }
        public String Key1 { get; set; }
    }
}
