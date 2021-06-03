using DesafioFWK_Domain.Commands.Fruits;

namespace DesafioFWK_Domain.Validation.Fruits
{
    public class FruitDeleteValidation : FruitValidation<FruitCommand>
    {
        public FruitDeleteValidation()
        {
            ValidateId();
        }
    }
}
