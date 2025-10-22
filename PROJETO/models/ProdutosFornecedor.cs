using PROJETO.models;
using PROJETO.models.bases;
using System;

namespace PROJETO.Models
{
    public class ProdutosFornecedor : Pai
    {
        public Produto oProduto { get; set; } = new Produto();
        public Fornecedores oFornecedor { get; set; } = new Fornecedores();
        public string Status { get; set; } = "";

        public ProdutosFornecedor() : base() { }

        public ProdutosFornecedor(int id, Produto produto, Fornecedores fornecedor, string status,
               DateTime dataCriacao, DateTime dataUltAlteracao) : base(id, dataCriacao, dataUltAlteracao)
        {
            Status = status;
            oFornecedor = fornecedor;
            oProduto = produto;
        }
    }
}
