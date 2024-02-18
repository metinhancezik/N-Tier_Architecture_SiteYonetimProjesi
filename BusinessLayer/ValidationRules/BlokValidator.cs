using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlokValidator: AbstractValidator<Blok>
	{

		public BlokValidator()
		{
			RuleFor(x => x.BlokName ).NotEmpty().WithMessage("Blok İsmi Boş Geçilemez");
            RuleFor(x => x.SiteID).NotEmpty().WithMessage("Site Id Boş Geçilemez");

        }
	}
}
