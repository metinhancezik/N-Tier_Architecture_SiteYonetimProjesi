using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.GiderDTOs
{
    public class GiderAddDTO
    {
        public int SiteID { get; set; }
        public string HarcamaCinsi { get; set; }
        public string Sirket { get; set; }
        public string ExtraInformation { get; set; }
        public int HarcananTutar { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; } = true;
    }
}
