using PROJETO.models.bases;

namespace PROJETO.models
{
    public class Categoria : Pai
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Foto { get; set; }

        public Categoria() : base()
        {
            ID = 0;
            Nome = string.Empty;
            Descricao = string.Empty;
            Foto = null;
        }

        public Categoria(int id, string nome, string descricao, byte[] foto) : base(id)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
            Foto = foto;
        }
    }
}
