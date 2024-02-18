using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SiteYoneticisiDTOs
{
    public class SiteYoneticisAddiDTO
    {
        public int YoneticiID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adres { get; set; }
        public int Phone { get; set; }
        public int SiteID { get; set; }
        public string BlokName { get; set; }
        public bool Active { get; set; } = true;

    }
}
