using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mail ini Boş Geçemezsiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifresini Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Kategori Adını En Az 2 Karakter Olmalı");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Kategori Adını En Fazla 20 Karakter Olmalı");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Kategori Adını En Az 2 Karakter Olmalı");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Kategori Adını En Fazla 20 Karakter Olmalı");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanını Boş Geçemezsiniz");
        }
    }
}
