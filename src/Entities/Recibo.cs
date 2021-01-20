using System;
using System.Globalization;

namespace src.Entities
{
    class Recibo
    {
        public double ValorDoServico { get; private set; }
        public double Imposto { get; private set; }

        public double PagamentoTotal
        {
            get { return ValorDoServico + Imposto; }
        }

        public Recibo(double valorDoServico, double imposto)
        {
            ValorDoServico = valorDoServico;
            Imposto = imposto;
        }

        public override string ToString()
        {
            return "Serviços: R$ "
                + ValorDoServico.ToString("F2", CultureInfo.InvariantCulture)
                + Environment.NewLine
                + "Impostos: R$ "
                + Imposto.ToString("F2", CultureInfo.InvariantCulture)
                + Environment.NewLine
                + "Total: R$ "
                + PagamentoTotal.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
