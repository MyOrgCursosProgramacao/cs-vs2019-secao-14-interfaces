using src.Entities;
using src.Entities.Services;
using System;
using System.Globalization;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====  Seção 14: Interfaces ====");
            Console.WriteLine();

            Console.WriteLine("Dados do aluguel");
            Console.Write("Modelo do veículo: ");
            string modelo = Console.ReadLine();
            Console.Write("Retirada (dd/mm/aaaa hh:mm): ");
            string retiradaString = Console.ReadLine().Trim();
            DateTime retirada = DateTime.ParseExact(retiradaString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Devolução (dd/mm/aaaa hh:mm): ");
            string devolucaoString = Console.ReadLine().Trim();
            DateTime devolucao = DateTime.ParseExact(devolucaoString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            
            Veiculo veiculo = new Veiculo(modelo);
            AluguelDeVeiculo aluguelDeVeiculo = new AluguelDeVeiculo(retirada, devolucao, veiculo);
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Preço por hora: R$ ");
            double precoPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Preço por dia: R$ ");
            double precoPorDia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            ServicoDeAluguel servicoDeAluguel = new ServicoDeAluguel(precoPorDia, precoPorHora);
            servicoDeAluguel.ProcessarRecibo(aluguelDeVeiculo);

            Console.WriteLine();
            Console.WriteLine("Recibo");
            Console.WriteLine("Valor do serviço: R$ " + aluguelDeVeiculo.Recibo.ValorDoServico.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Valor do imposto: R$" + aluguelDeVeiculo.Recibo.Imposto.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Total: R$ " + aluguelDeVeiculo.Recibo.PagamentoTotal.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
