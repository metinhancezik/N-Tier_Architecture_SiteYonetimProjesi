using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EvSahibiKiraci
    {
        [Key]
        public int EvSahibiID { get; set; }

        [ForeignKey("Daire")]
        public int  DaireID { get; set; }
        public Daire Daire { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Telefon { get; set; }
        public string Mail { get; set; }
        public string Role { get; set; }
    }
}
