using DesafioFWK_Domain.Commands.Fruits;

namespace DesafioFWK_Domain.Validation.Fruits
{
    public class FruitAddValidation : FruitValidation<FruitCommand>
    {
        public FruitAddValidation()
        {
            ValidateName();
            ValidatePrice();
        }
    }
}
