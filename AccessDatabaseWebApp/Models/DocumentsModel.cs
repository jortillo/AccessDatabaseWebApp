using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccessDatabaseWebApp.Models
{
    public class DocumentsModel
    {
        
        [Display(Name = "Document Name")]
        public String Document_Name { get; set; }
        [Display(Name = "Date Created")]
        public String DateCreated { get; set; }
        public String Counter { get; set; }
        [Display(Name = "Object Type")]
        public String objtype { get; set; }
        [Display(Name = "Object Name")]
        public String objname { get; set; }
        public String Description { get; set; }
        public String Location1 { get; set; }
        public String Location2 { get; set; }
        [Display(Name = "Yr.")]
        public String Sort1 { get; set; }
        [Display(Name = "Num")]
        public String Sort2 { get; set; }
        public int ytdcounter { get; set; }
        [Display(Name = "Item Count")]
        public int itemcount { get; set; }
        public String Maker { get; set; }
        [Display(Name = "Object Class")]
        public String objclass1 { get; set; }
        public String Checkedout { get; set; }
        public String Lost { get; set; }
        [Display(Name = "Object Date")]
        public String objdate { get; set; }
        public String acqsource { get; set; }
        public String acqmethod { get; set; }
        public String acqdate { get; set; }
        [Display(Name = "Object Status")]
        public String objstatus { get; set; }
        public String Key1 { get; set; }
    }
}
