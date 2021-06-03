using DesafioFWK_Domain.Commands.Fruits;

namespace DesafioFWK_Domain.Validation.Fruits
{
    public class FruitUpdateValidation : FruitValidation<FruitCommand>
    {
        public FruitUpdateValidation()
        {
            ValidateId();
        }
    }
}
