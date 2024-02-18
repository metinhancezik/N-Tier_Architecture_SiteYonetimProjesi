using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SiteWriterValidator: AbstractValidator<Site>
    {
        public SiteWriterValidator()
        {
            RuleFor(x => x.SiteName).NotEmpty().WithMessage("Site İsmi Boş Geçilemez");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Site Adresi Boş Geçilemez");
            RuleFor(x => x.Sehir).NotEmpty().WithMessage("Şehir Boş Geçilemez");
            RuleFor(x => x.BlokSayısı).NotEmpty().WithMessage("Blok Sayısı Boş Geçilemez");
            RuleFor(x => x.DaireSayısı).NotEmpty().WithMessage("Daire Sayısı Boş Geçilemez");
            RuleFor(x => x.IsitmaTipi).NotEmpty().WithMessage("Isıtma Tipi Boş Geçilemez");
        }
    }
}
