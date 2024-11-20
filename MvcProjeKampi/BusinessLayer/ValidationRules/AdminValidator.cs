using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Adı Boş Geçemezsiniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifreyi Boş Geçemezsiniz");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Şifreyi Boş Geçemezsiniz");
            RuleFor(x => x.AdminUserName).MinimumLength(3).MaximumLength(50).WithMessage("Kategori Adını En Az 3 En Fazla 50 Karakter Olmalı");
            RuleFor(x => x.AdminPassword).MinimumLength(3).MaximumLength(50).WithMessage("Kategori Adını En Az 3 En Fazla 50 Karakter Olmalı");
        }
    }
}
