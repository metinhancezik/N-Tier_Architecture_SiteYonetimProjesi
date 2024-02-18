using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AidatView
    {
        public int SiteID { get; set; }
        public int AidatID { get; set; }
        public int BlokID { get; set; }
        public int DaireID { get; set; }
        public string OturanKisiName { get; set; }
        public decimal Tutar { get; set; }
        public decimal Odenmis { get; set; }
        public DateTime Date { get; set; }
    }
}
