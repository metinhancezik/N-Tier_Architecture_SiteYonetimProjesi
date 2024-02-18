using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string role { get; set; }

        [ForeignKey("SiteYoneticisi")]
        public int YoneticiID { get; set; }
        public SiteYoneticisi SiteYoneticisi { get; set; }

    }
}
