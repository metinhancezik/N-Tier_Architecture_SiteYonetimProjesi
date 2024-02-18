using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gider
    {
        [Key] public int GiderID { get; set; }

        [ForeignKey("Site")]
        public int SiteID { get; set; }
        public Site Site { get; set; }
        public string HarcamaCinsi { get; set; }
        public string Sirket { get; set; }

        public string ExtraInformation { get; set; }
        public int HarcananTutar{ get; set; }
        public DateTime Date { get; set; }
    }
}
