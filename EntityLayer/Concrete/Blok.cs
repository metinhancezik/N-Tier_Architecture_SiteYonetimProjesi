using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blok
    {
        [Key]
        public int BlokID { get; set; } 
        [ForeignKey("Site")]
        public int SiteID { get; set; } 
        public string BlokName { get; set; }
        public Site Site { get; set; }
        
    }
}
