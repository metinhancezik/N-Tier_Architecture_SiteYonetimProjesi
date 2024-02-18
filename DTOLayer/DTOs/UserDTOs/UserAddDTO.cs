using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.UserDTOs
{
    public class UserAddDTO
    {
        public int UserID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int YoneticiID { get; set; }
        public bool Active { get; set; } = true;
    }
}
