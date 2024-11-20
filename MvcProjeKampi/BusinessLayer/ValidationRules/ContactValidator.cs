using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Olmalı");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter Olmalı");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("En Az 3 Karakter Olmalı");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 20 Karakter Olmalı");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("En Fazla 20 Karakter Olmalı");
            RuleFor(x => x.Message).MaximumLength(50).WithMessage("En Fazla 20 Karakter Olmalı");

        }
    }
}
