using DesafioFWK_Domain.Commands.Fruits;
using FluentValidation;

namespace DesafioFWK_Domain.Validation.Fruits
{
    public abstract class FruitValidation<T> : AbstractValidator<T> where T : FruitCommand
    {
        protected void ValidateId()
            => RuleFor(e => e.Id)
            .NotEmpty();

        protected void ValidateName()
            => RuleFor(e => e.Nome)
            .NotEmpty();

        protected void ValidatePrice()
            => RuleFor(e => e.Valor)
            .NotNull();
    }
}
