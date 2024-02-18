using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DaireValidator : AbstractValidator<Daire>
    {
        
        

            public DaireValidator()
            {
                RuleFor(x => x.BlokID).NotEmpty().WithMessage("Blok Id Boş Geçilemez");
                RuleFor(x => x.KatNumarasi).NotEmpty().WithMessage("Kat Numarası Boş Geçilemez");
                RuleFor(x => x.DaireNo).NotEmpty().WithMessage("Daire Numarası Boş Geçilemez");
               

        }


        }
}
