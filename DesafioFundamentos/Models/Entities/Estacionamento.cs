using System.Globalization;
using System.Collections.Generic;


namespace DesafioFundamentos.Models.Entities
{
    class Estacionamento
    {
        public double PrecoInicial { get; set; }
        public double PrecoPorHora { get; set; }
        public List<Veiculo> veiculos { get; set; }

        public Estacionamento(double precoInicial, double precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;

            veiculos = new List<Veiculo>();
        }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }
        public void RemoverVeiculo(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Veículo: {veiculo.Tipo}, Placa: {veiculo.Placa}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
            }
        }
        public double CalcularValorEstadia(Veiculo veiculo, int horas)
        {
            double valor = PrecoInicial + (PrecoPorHora * horas);
            return valor;
        }
    }
}
