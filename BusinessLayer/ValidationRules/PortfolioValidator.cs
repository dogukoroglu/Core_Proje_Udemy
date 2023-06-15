using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı boş geçilemez!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel-1 boş geçilemez!");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel-2 boş geçilemez!");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Proje Linki boş geçilemez!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Küçük Resim-1 boş geçilemez!");
            RuleFor(x => x.Image2).NotEmpty().WithMessage("Küçük Resim-2 boş geçilemez!");
            RuleFor(x => x.Image3).NotEmpty().WithMessage("Küçük Resim-3 boş geçilemez!");
            RuleFor(x => x.Image4).NotEmpty().WithMessage("Küçük Resim-4 boş geçilemez!");
        }
    }
}
