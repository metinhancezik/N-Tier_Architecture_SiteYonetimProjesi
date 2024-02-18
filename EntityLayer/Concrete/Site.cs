using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Site
    {

        [Key]
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public int BlokSayısı { get; set; }
        public int DaireSayısı { get; set; }
        public string IsitmaTipi { get; set; }

    }
}
