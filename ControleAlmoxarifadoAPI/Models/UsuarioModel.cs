using ControleAlmoxarifadoAPI.Enums;

namespace ControleAlmoxarifadoAPI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public NivelUsuario Nivel { get; set; }
        public StatusUsuario Status { get; set; }
    }
}
