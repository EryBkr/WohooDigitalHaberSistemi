using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.ValidationRules.FluentValidations
{
    public class UserValidations:AbstractValidator<User>
    {
        public UserValidations()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Geçilemez");
        }
    }
}
