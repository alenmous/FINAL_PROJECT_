using PROJETO.controller;
using PROJETO.data;
using PROJETO.models.compraevenda;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJETO.Models;

namespace PROJETO.dao.compraevenda
{
    public class ItensCompraDAO
    {
        private Banco banco = new Banco();


        public bool AdicionarItemCompra(ItemCompra itemCompra)
        {
            try
            {
                string sql = "INSERT INTO tb_itens_compras (num_nfc, modelo_nfc, serie_nfc, id_fornecedor, id_produto, qtd_produto, preco_custo, total_custo, percentual_compra, media_ponderada, data_criacao, Desconto) " +
                             "VALUES (@NumNFC, @ModeloNFC, @SerieNFC, @IdFornecedor, @IdProduto, @QtdProduto, @PrecoCusto, @TotalCusto, @PercentualCompra, @MediaPonderada, @DataCriacao, @Desconto)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", itemCompra.NumNFC),
                    new SqlParameter("@ModeloNFC", itemCompra.ModeloNFC),
                    new SqlParameter("@SerieNFC", itemCompra.SerieNFC),
                    new SqlParameter("@IdFornecedor", itemCompra.Fornecedor.ID),
                    new SqlParameter("@IdProduto", itemCompra.Produto.ID),
                    new SqlParameter("@QtdProduto", itemCompra.QtdProduto),
                    new SqlParameter("@PrecoCusto", itemCompra.PrecoCusto),
                    new SqlParameter("@TotalCusto", itemCompra.TotalCusto),
                    new SqlParameter("@PercentualCompra", itemCompra.PercentualCompra),
                    new SqlParameter("@MediaPonderada", itemCompra.MediaPonderada),
                    new SqlParameter("@DataCriacao", itemCompra.DataCriacao),
                    new SqlParameter("@Desconto", itemCompra.Desconto)
                };
                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ItemCompra> BuscarItemCompraPorChave2(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            try
            {
                string sql = "SELECT * FROM tb_itens_compras WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@IdFornecedor", idFornecedor)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                List<ItemCompra> itensCompra = new List<ItemCompra>();
                foreach (DataRow row in dataTable.Rows)
                {
                    itensCompra.Add(CreateItemCompraFromDataRow(row));
                }

                return itensCompra;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ItemCompra>();
            }
        }


        public ItemCompra BuscarItemCompraPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor, int idProduto)
        {
            try
            {
                string sql = "SELECT * FROM tb_itens_compras WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor AND id_produto = @IdProduto";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@IdFornecedor", idFornecedor),
                    new SqlParameter("@IdProduto", idProduto)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateItemCompraFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ItemCompra> ListarItensCompra()
        {
            try
            {
                string sql = "SELECT * FROM tb_itens_compras";
                DataTable dataTable = banco.ExecutarConsulta(sql, null);
                return CreateItensCompraListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ItemCompra>();
            }
        }

        private ItemCompra CreateItemCompraFromDataRow(DataRow row)
        {
            FornecedoresController fornecedoresController = new FornecedoresController();
            ProdutosController produtosController = new ProdutosController();
            Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorId(Convert.ToInt32(row["id_fornecedor"]));
            Produto produto = produtosController.BuscarProdutoPorId(Convert.ToInt32(row["id_produto"]));
            return new ItemCompra
            {
                NumNFC = Convert.ToInt32(row["num_nfc"]),
                ModeloNFC = Convert.ToInt32(row["modelo_nfc"]),
                SerieNFC = Convert.ToInt32(row["serie_nfc"]),
                Fornecedor = fornecedor,
                Produto = produto,
                QtdProduto = Convert.ToInt32(row["qtd_produto"]),
                PrecoCusto = Convert.ToDecimal(row["preco_custo"]),
                TotalCusto = Convert.ToDecimal(row["total_custo"]),
                PercentualCompra = Convert.ToDecimal(row["percentual_compra"]),
                MediaPonderada = Convert.ToDecimal(row["media_ponderada"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                Desconto = Convert.ToDecimal(row["desconto"]),
            };
        }

        private List<ItemCompra> CreateItensCompraListFromDataTable(DataTable dataTable)
        {
            List<ItemCompra> itensCompra = new List<ItemCompra>();
            foreach (DataRow row in dataTable.Rows)
            {
                itensCompra.Add(CreateItemCompraFromDataRow(row));
            }
            return itensCompra;
        }
    }
}
