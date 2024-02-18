using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.DaireDTOs
{
    public class DaireAddDTO
    {
        public int DaireID { get; set; }
        public string DaireNo { get; set; }
        public int BlokID { get; set; }
        public int KatNumarasi { get; set; }
        public string ExtraInformation { get; set; }
        public bool Active { get; set; } = true;
    }
}
