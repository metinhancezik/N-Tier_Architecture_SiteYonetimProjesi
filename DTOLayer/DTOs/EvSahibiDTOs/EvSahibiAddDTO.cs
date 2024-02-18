using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.EvSahibiDTOs
{
    public class EvSahibiAddDTO
    {
        public int EvSahibiID { get; set; }
        public int DaireID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Telefon { get; set; }
        public string Mail { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; } = true;
    }
}
