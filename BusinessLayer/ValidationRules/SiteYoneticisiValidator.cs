using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SiteYoneticisiValidator:AbstractValidator<SiteYoneticisi>
    {
        public SiteYoneticisiValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı İsmi Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı Boş Geçilemez");
            RuleFor(x => x.SiteID).NotEmpty().WithMessage("Site boş geçilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Boş Geçilemez");
           

        }


    }
}
