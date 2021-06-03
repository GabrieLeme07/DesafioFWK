using System;

namespace DesafioFWK_Application.ViewModel.Fruits
{
    public class FruitUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }
        public double Valor { get; set; }
        public double Estoque { get; set; }
    }
}
