using System;
namespace KmedAPI.Poco
{
    public class Paciente
    {
        public Paciente()
        {
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
    }
}
