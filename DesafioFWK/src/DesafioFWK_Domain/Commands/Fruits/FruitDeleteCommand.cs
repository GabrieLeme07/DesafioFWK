using DesafioFWK_Domain.Validation.Fruits;
using System;

namespace DesafioFWK_Domain.Commands.Fruits
{
    public class FruitDeleteCommand : FruitCommand
    {
        public FruitDeleteCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new FruitDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
