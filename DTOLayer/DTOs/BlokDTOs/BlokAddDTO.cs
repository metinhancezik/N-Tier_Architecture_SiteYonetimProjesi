using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.BlokDTOs
{
    public class BlokAddDTO
    {
        public int BlokID { get; set; }
        public int SiteID { get; set; }
        public string BlokName { get; set; }
        public bool Active { get; set; } = true;
    }
}
