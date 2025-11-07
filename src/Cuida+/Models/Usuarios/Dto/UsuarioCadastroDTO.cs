#nullable enable
namespace Cuida_.Models.Usuarios.Dto
{
    public class UsuarioCadastroDTO
    {

        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public string? ConfirmarSenha { get; set; }
        public string? TipoRegistro { get; set; }

        public string? CPF { get; set; }
        public int? CadUnico { get; set; }
        public string? CRM { get; set; }
        public string? Especialidade { get; set; }
        public string? NomeClinica { get; set; }
        public string? CNPJ { get; set; }
    }
}
