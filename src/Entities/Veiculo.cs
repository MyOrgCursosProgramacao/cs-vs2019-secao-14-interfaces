namespace src.Entities
{
    class Veiculo
    {
        public string Modelo { get; private set; }

        public Veiculo(string modelo)
        {
            Modelo = modelo;
        }
    }
}
