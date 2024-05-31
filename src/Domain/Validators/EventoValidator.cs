using FluentValidation;
using RegressivaAPI.Domain.Entities;

namespace RegressivaAPI.Domain.Validators
{
    public class EventoValidator : AbstractValidator<Evento>
    {
        public EventoValidator()
        {
            RuleFor(x => x.nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.modified_by_user_id).GreaterThan(0).WithMessage("O ID do usuário modificador é obrigatório.");
        }
    }
}
