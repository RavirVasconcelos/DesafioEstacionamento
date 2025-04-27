using DesafioFundamentos.Models.Entities.Enums;

namespace DesafioFundamentos.Models.Entities
{
    class Veiculo
    {
        public string Placa { get; set; }
        public TipoVeiculo Tipo { get; set; }

        public Veiculo(string placa, TipoVeiculo tipo)
        {
            Placa = placa;
            Tipo = tipo;
        }
    }
}
