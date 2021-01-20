namespace src.Entities.Services
{
    class ImpostosBrasil : IServicoDeImpostos
    {
        public double Imposto(double quantia)
        {
            if (quantia <= 100.0)
            {
                return 0.20 * quantia;
            }
            else
            {
                return 0.15 * quantia;
            }
        }
    }
}
