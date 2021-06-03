using DesafioFWK_Domain.Commands.Fruits;

namespace DesafioFWK_Domain.Validation.Fruits
{
    public class FruitSellValidation : FruitValidation<FruitCommand>
    {
        public FruitSellValidation()
        {
            ValidateId();
        }
    }
}
