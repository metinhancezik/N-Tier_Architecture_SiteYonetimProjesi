using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Aidat
    {
        [Key]
        public int AidatID { get; set; }

        [ForeignKey("Daire")]
        public int DaireID { get; set; }
        public Daire Daire { get; set; }
        public int Tutar { get; set; }
        public int Odenmis { get; set; }
        public DateTime Date { get; set; }
    }
}
