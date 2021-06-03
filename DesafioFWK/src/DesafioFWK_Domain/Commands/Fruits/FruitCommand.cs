using DesafioFWK_Core.Commands;
using System;

namespace DesafioFWK_Domain.Commands.Fruits
{
    public abstract class FruitCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int Estoque { get; set; }
        public double Valor { get; set; }
    }
}
