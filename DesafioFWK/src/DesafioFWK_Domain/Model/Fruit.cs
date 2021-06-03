using DesafioFWK_Core.Models;

namespace DesafioFWK_Domain.Model
{
    public class Fruit : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int Estoque { get; set; }
        public double Valor { get; set; }
    }
}
