using System;
using System.Collections.Generic;
using System.Text;

namespace src.Entities
{
    class AluguelDeVeiculo
    {
        public DateTime Retirada { get; private set; }
        public DateTime Devolucao { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public Recibo Recibo { get; private set; }

        public AluguelDeVeiculo(DateTime retirada, DateTime devolucao, Veiculo veiculo)
        {
            Retirada = retirada;
            Devolucao = devolucao;
            Veiculo = veiculo;
            Recibo = null;
        }
    }
}
