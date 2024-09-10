namespace CadastroCliente.Dto
{
    public class ClienteRequest
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public string Endereco { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
    }
}
