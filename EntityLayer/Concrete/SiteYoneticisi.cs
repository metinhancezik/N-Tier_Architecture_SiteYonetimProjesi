﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SiteYoneticisi
    {
        [Key]
        public int YoneticiID { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adres { get; set; }
        public int Phone { get; set; }

        [ForeignKey("Site")]
        public int SiteID { get; set; }
        public string BlokName { get; set; }
        public Site Site { get; set; }

    }
}
