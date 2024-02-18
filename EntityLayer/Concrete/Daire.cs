using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Daire
    {
        [Key]
        public int DaireID { get; set; } 

        [ForeignKey("Blok")]
        public int BlokID { get; set; }
        public int DaireNo { get; set; }
        
        public Blok Blok { get; set; }
        public int KatNumarasi { get; set; } 
        public string ExtraInformation { get; set; } 
     
     
    }
}
