using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AidatDTOs
{
    public class AidatAddDTO
    {
        public int AidatID { get; set; }
        public int DaireID { get; set; }
        public int Tutar { get; set; }
        public int Odenmis { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; } = true;
    }
}
