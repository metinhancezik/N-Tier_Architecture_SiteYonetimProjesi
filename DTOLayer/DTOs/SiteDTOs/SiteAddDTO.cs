using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SiteDTOs
{
    public class SiteAddDTO
    {
     
        public string SiteName { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public int BlokSayısı { get; set; }
        public int DaireSayısı { get; set; }
        public string IsitmaTipi { get; set; }
        public bool Active { get; set; } = true;
    }
}
