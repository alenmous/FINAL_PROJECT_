using PROJETO.models.bases;
using System;

namespace PROJETO.models
{

    public class Produto : Pai
    {
        public string Nome { get; set; }
        public string DescricaoProduto { get; set; }
        public string UnidadeMedida { get; set; }
        public string Referencia { get; set; }
        public Marca Marca { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int QtdEstoque { get; set; }
        public Categoria Categoria { get; set; }
        public string Status { get; set; }
        public byte[] Foto { get; set; }

        public Produto() : base()
        {
            Nome = "";
            Foto = null;
            Categoria = new Categoria();
            DescricaoProduto = "";
            UnidadeMedida = "";
            Marca = new Marca();
            Status = "";
            PrecoCusto = 0m;
            PrecoVenda = 0m;
            QtdEstoque = 0;
            Referencia = "";
        }

        public Produto(string referencia, string nome, int idProduto, string descricaoProduto, Categoria categoria, string unidadeMedida, Marca marca, decimal precoCusto, decimal precoVenda, int qtdEstoque, string status, DateTime dataCriacao, DateTime dataUltAlteracao, byte[] foto)
            : base(idProduto, dataCriacao, dataUltAlteracao)
        {
            Nome = nome;
            DescricaoProduto = descricaoProduto;
            Categoria = categoria;
            UnidadeMedida = unidadeMedida;
            Marca = marca;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            QtdEstoque = qtdEstoque;
            Foto = foto;
            Status = status;
            Referencia = referencia;
        }
    }
}
