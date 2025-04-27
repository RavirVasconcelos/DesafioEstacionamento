using System;
using System.Globalization;
using DesafioFundamentos.Models.Entities;
using DesafioFundamentos.Models.Entities.Enums;

namespace DesafioFundamentos.Application
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
            Console.Write("Digite o preço inicial: ");
            double precoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Digite o preço por hora: ");
            double precoPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            int opcao = 0;

            Console.Clear();

            while (opcao != 4)
            {
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite a placa do veículo: ");
                        string placa = Console.ReadLine();
                        Console.WriteLine("Carro ou Moto?");
                        Console.WriteLine("Carro = 1");
                        Console.WriteLine("Moto = 2");
                        int tipoVeiculo = int.Parse(Console.ReadLine());

                        Veiculo veiculo = new Veiculo(placa, (TipoVeiculo)tipoVeiculo);

                        estacionamento.CadastrarVeiculo(veiculo);
                        Console.WriteLine("Veículo cadastrado com sucesso!");
                        Console.WriteLine();

                        Console.WriteLine("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        string placaRemover;
                        Veiculo veiculoRemover = null;

                        while (veiculoRemover == null)
                        {
                            Console.Write("Digite a placa do veículo: ");
                            placaRemover = Console.ReadLine();
                            Console.WriteLine();

                            veiculoRemover = estacionamento.veiculos.Find(v => v.Placa == placaRemover);

                            if (veiculoRemover == null)
                            {
                                Console.WriteLine("Veículo não encontrado. Tente novamente.");
                                Console.WriteLine();
                            }
                            else
                            {
                                estacionamento.RemoverVeiculo(veiculoRemover);
                                Console.WriteLine($"Veículo com a placa {placaRemover} removido com sucesso!");
                                Console.WriteLine();
                            }
                        }

                        Console.Write("Digite o tempo de permanência em horas: ");
                        int horas = int.Parse(Console.ReadLine());
                        double valorEstadia = estacionamento.CalcularValorEstadia(veiculoRemover, horas);
                        Console.WriteLine($"Valor a ser pago: R$ {valorEstadia.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine();

                        Console.WriteLine("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        estacionamento.ListarVeiculos();

                        Console.WriteLine("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Obrigado e volte sempre!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}