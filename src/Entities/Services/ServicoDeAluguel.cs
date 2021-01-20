using System;

namespace src.Entities.Services
{
    class ServicoDeAluguel
    {
        public double PrecoPorDia { get; private set; }
        public double PrecoPorHora { get; private set; }

        private ImpostosBrasil _ImpostosBrasil = new ImpostosBrasil();

        public ServicoDeAluguel(double precoPorDia, double precoPorHora)
        {
            PrecoPorDia = precoPorDia;
            PrecoPorHora = precoPorHora;
        }

        public void ProcessarRecibo(AluguelDeVeiculo aluguelDeVeiculo)
        {
            TimeSpan duracao = aluguelDeVeiculo.Devolucao.Subtract(aluguelDeVeiculo.Retirada);

            double valorServico;
            if (duracao.TotalHours <= 12.0)
            {
                valorServico = PrecoPorHora * Math.Ceiling(duracao.TotalHours);
            }
            else
            {
                valorServico = PrecoPorDia * Math.Ceiling(duracao.TotalDays);
            }

            double valorImposto = _ImpostosBrasil.Imposto(valorServico);

            aluguelDeVeiculo.Recibo = new Recibo(valorServico, valorImposto);
        }
    }
}
