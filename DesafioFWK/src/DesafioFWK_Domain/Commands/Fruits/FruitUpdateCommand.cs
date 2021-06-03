using DesafioFWK_Domain.Validation.Fruits;
using System;

namespace DesafioFWK_Domain.Commands.Fruits
{
    public class FruitUpdateCommand : FruitCommand
    {
        public FruitUpdateCommand(
            Guid id,
            string nome,
            string descricao,
            string imagem,
            int estoque,
            double valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Imagem = imagem;
            Estoque = estoque;
            Valor = valor;
        }
        public override bool IsValid()
        {
            ValidationResult = new FruitUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
