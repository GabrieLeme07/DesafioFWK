using DesafioFWK_Domain.Validation.Fruits;
using System;

namespace DesafioFWK_Domain.Commands.Fruits
{
    public class FruitAddCommand : FruitCommand
    {
        public FruitAddCommand() => Id = Guid.NewGuid();

        public FruitAddCommand(
            string nome,
            string descricao,
            string imagem,
            int estoque,
            double valor) : this()
        {
            Nome = nome;
            Descricao = descricao;
            Imagem = imagem;
            Estoque = estoque;
            Valor = valor;
        }
        public override bool IsValid()
        {
            ValidationResult = new FruitAddValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
