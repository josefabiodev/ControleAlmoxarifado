namespace ControleAlmoxarifadoAPI.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Endereco { get; set; }
        public string? Contato { get; set; }
        public string? CNPJ { get; set; }
    }
}
