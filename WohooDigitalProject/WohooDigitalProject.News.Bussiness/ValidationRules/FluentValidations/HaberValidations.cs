using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.ValidationRules.FluentValidations
{
    public class HaberValidations:AbstractValidator<Haber>
    {
        public HaberValidations()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(p => p.Image).NotEmpty().WithMessage("Resim Boş Geçilemez");
            
        }
    }
}
