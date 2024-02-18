using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.ValidationRules
{
	public class UserValidator:AbstractValidator<User>
	{


		public UserValidator()
		{
			RuleFor(x => x.userName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Geçilemez");
			RuleFor(x => x.userPassword).NotEmpty().WithMessage("Kullanıcı Şifresi Boş Geçilemez");
			RuleFor(x => x.userPassword).MinimumLength(8).WithMessage("Şifre minumum 8 karakter olmalıdır.");
			RuleFor(x => x.userPassword).Matches(@"[A-Z]+").WithMessage("Şifrede en az bir büyük harf olmalıdır.");
			RuleFor(x => x.userPassword).Matches(@"[a-z]+").WithMessage("Şifrede en az bir küçük harf olmalıdır.");
			RuleFor(x => x.userPassword).Matches(@"[0-9]+").WithMessage("Şifrede en az bir rakam olmalıdır");
			RuleFor(x => x.phone).NotEmpty().WithMessage("Telefon Boş Geçilemez");
			RuleFor(x => x.email).NotEmpty().WithMessage("E-mail Sayısı Boş Geçilemez");
			RuleFor(x => x.role).NotEmpty().WithMessage("Rol Boş Geçilemez");
	
		}

	}
}
