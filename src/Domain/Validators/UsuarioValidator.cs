using FluentValidation;
using RegressivaAPI.Domain.Entities;

namespace RegressivaAPI.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.login).NotEmpty().WithMessage("O login é obrigatório.");
            RuleFor(x => x.senha).NotEmpty().WithMessage("A senha é obrigatória.");
            RuleFor(x => x.status).InclusiveBetween(0, 1).WithMessage("O status deve ser 0 ou 1.");
        }
    }
}
