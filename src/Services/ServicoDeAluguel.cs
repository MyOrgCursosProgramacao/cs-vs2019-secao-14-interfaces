using System;

namespace src.Entities.Services
{
    class ServicoDeAluguel
    {
        public double PrecoPorDia { get; private set; }
        public double PrecoPorHora { get; private set; }

        private IServicoDeImpostos _servicoDeImpostos;

        public ServicoDeAluguel(double precoPorDia, double precoPorHora, IServicoDeImpostos servicoDeImpostos)
        {
            PrecoPorDia = precoPorDia;
            PrecoPorHora = precoPorHora;
            _servicoDeImpostos = servicoDeImpostos;
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

            double valorImposto = _servicoDeImpostos.Imposto(valorServico);

            aluguelDeVeiculo.Recibo = new Recibo(valorServico, valorImposto);
        }
    }
}
