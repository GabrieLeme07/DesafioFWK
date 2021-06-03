using DesafioFWK_Domain.Commands.Fruits;
using System;

namespace DesafioFWK_Domain.Validation.Fruits
{
    public class FruitSellCommand : FruitCommand
    {
        public FruitSellCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new FruitSellValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
