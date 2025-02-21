using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("Yazar adı boş olamaz")
                .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır")
                .MaximumLength(75).WithMessage("Ad en fazla 75 karakter olabilir");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("Yazar soyadı boş olamaz")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır")
                .MaximumLength(75).WithMessage("Soyad en fazla 50 karakter olabilir");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email adresi boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz")
                .MaximumLength(150).WithMessage("Email en fazla 150 karakter olabilir");

            RuleFor(a => a.Biography)
                .MaximumLength(1500).WithMessage("Biyografi en fazla 1500 karakter olabilir")
                .When(a => !string.IsNullOrEmpty(a.Biography));

            RuleFor(a => a.ImageUrl)
                .MaximumLength(500).WithMessage("Resim URL'i en fazla 500 karakter olabilir")
                .When(a => !string.IsNullOrEmpty(a.ImageUrl));
        }
    }
} 