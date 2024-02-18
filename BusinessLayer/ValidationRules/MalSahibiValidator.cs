using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MalSahibiValidator : AbstractValidator<EvSahibiKiraci>
    {
        public MalSahibiValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı İsmi Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı Boş Geçilemez");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon boş geçilemez");

            RuleFor(x => x.Role).NotEmpty().WithMessage("Rol Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.DaireID).NotEmpty().WithMessage("Daire Boş Geçilemez");


        }
    }
}