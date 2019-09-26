using Models.Usuario.Enum;

namespace Models.Usuario
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public TipoUsuarioEnum tipo { get; set; }
        public bool excluido { get; set; }
    }
}

