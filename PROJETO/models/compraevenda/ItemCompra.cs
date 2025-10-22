using PROJETO.models.bases;
using PROJETO.Models;
using System;

namespace PROJETO.models.compraevenda
{
    public class ItemCompra : Pai
    {
        public int NumNFC { get; set; }
        public int ModeloNFC { get; set; }
        public int SerieNFC { get; set; }
        public Fornecedores Fornecedor { get; set; } = new Fornecedores();
        public Produto Produto { get; set; } = new Produto();
        public int QtdProduto { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal TotalCusto { get; set; }
        public decimal PercentualCompra { get; set; }
        public decimal MediaPonderada { get; set; }
        public decimal Desconto { get; set; }

        public ItemCompra() : base()
        {
            NumNFC = 0;
            ModeloNFC = 0;
            SerieNFC = 0;
            QtdProduto = 0;
            PrecoCusto = 0m;
            TotalCusto = 0m;
            PercentualCompra = 0m;
            MediaPonderada = 0m;
            Desconto = 0m;
        }

        public ItemCompra(int numNFC, int modeloNFC, int serieNFC, Fornecedores fornecedor, Produto produto, int qtdProduto,
                          decimal precoCusto, decimal totalCusto, decimal percentualCompra, decimal mediaPonderada, decimal desconto, DateTime dataCriacao)
            : base(dataCriacao)
        {
            NumNFC = numNFC;
            ModeloNFC = modeloNFC;
            SerieNFC = serieNFC;
            Fornecedor = fornecedor;
            Produto = produto;
            QtdProduto = qtdProduto;
            PrecoCusto = precoCusto;
            TotalCusto = totalCusto;
            PercentualCompra = percentualCompra;
            MediaPonderada = mediaPonderada;
            Desconto = desconto;
        }
    }
}
