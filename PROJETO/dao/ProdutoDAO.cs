using PROJETO.controller;
using PROJETO.data;
using PROJETO.models.bases;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.dao
{
    public class ProdutosDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();
        CategoriasController categoriasController;
        MarcaController marcasController;

        public ProdutosDAO()
        {
            categoriasController = new CategoriasController();
            marcasController = new MarcaController();
        }

        public bool AtualizarProdutoEstoque(Produto produto)
        {
            try
            {
                string sql = "UPDATE tb_produtos SET qtd_estoque = @QtdEstoque, preco_custo = @PrecoCusto WHERE id_produto = @IdProduto";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@QtdEstoque", produto.QtdEstoque),
                    new SqlParameter("@PrecoCusto", produto.PrecoCusto),
                    new SqlParameter("@IdProduto", produto.ID)
                };
                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar estoque do produto: " + ex.Message);
                return false;
            }
        }
        public bool AdicionarProduto(Produto Produto)
        {
            try
            {
                string sql = "INSERT INTO tb_produtos (referencia, nome, id_categoria, descricao_produto, unidade_medida, id_marca, preco_custo, preco_venda, qtd_estoque, data_criacao, data_ult_alteracao, status_produto";
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@Nome", Produto.Nome),
                    new SqlParameter("@id_categoria", Produto.Categoria.ID),
                    new SqlParameter("@descricao_produto", Produto.DescricaoProduto),
                    new SqlParameter("@unidade_medida", Produto.UnidadeMedida),
                    new SqlParameter("@id_marca", Produto.Marca.ID),
                    new SqlParameter("@preco_custo", Produto.PrecoCusto),
                    new SqlParameter("@preco_venda", Produto.PrecoVenda),
                    new SqlParameter("@qtd_estoque", Produto.QtdEstoque),
                    new SqlParameter("@status_produto", Produto.Status),
                    new SqlParameter("@data_criacao", Produto.DataCriacao),
                    new SqlParameter("@referencia", Produto.Referencia),
                    new SqlParameter("@data_ult_alteracao", Produto.DataUltimaAlteracao)
                };

                // Verifica se a foto está presente
                if (Produto.Foto != null)
                {
                    sql += ", Foto";
                    parametros.Add(new SqlParameter("@Foto", Produto.Foto));
                }

                sql += ") VALUES (@referencia, @Nome, @id_categoria, @descricao_produto, @unidade_medida, @id_marca, @preco_custo, @preco_venda, @qtd_estoque, @data_criacao, @data_ult_alteracao, @status_produto";

                // Adicionando a coluna e o parâmetro da foto, se presente
                if (Produto.Foto != null)
                {
                    sql += ", @Foto";
                }

                sql += ")";

                // Executar o comando
                banco.ExecutarComando(sql, parametros.ToArray());

                return true;
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao adicionar Produto", ex);
                return false;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao adicionar Produto", ex);
                return false;
            }
        }
        public string AtualizarProduto(Produto Produto)
        {
            try
            {
                string sql = "UPDATE tb_produtos SET  referencia =@referencia, nome = @Nome, id_categoria = @id_categoria, descricao_produto = @descricao_produto, status_produto = @status_produto, " +
                             "unidade_medida = @unidade_medida, id_marca = @id_marca, preco_custo = @preco_custo, preco_venda = @preco_venda, " +
                             "qtd_estoque = @qtd_estoque, data_ult_alteracao = @data_ult_alteracao";

                // Adicionando a condição para atualizar a foto, se estiver presente
                if (Produto.Foto != null)
                {
                    sql += ", foto = @Foto";
                }

                sql += " WHERE id_produto = @Id";

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@Nome", Produto.Nome),
                    new SqlParameter("@id_categoria", Produto.Categoria.ID),
                    new SqlParameter("@descricao_produto", Produto.DescricaoProduto),
                    new SqlParameter("@unidade_medida", Produto.UnidadeMedida),
                    new SqlParameter("@id_marca", Produto.Marca.ID),
                    new SqlParameter("@preco_custo", Produto.PrecoCusto),
                    new SqlParameter("@preco_venda", Produto.PrecoVenda),
                    new SqlParameter("@status_produto", Produto.Status),
                    new SqlParameter("@qtd_estoque", Produto.QtdEstoque),
                    new SqlParameter("@data_ult_alteracao", Produto.DataUltimaAlteracao),
                    new SqlParameter("@referencia", Produto.Referencia),
                    new SqlParameter("@Id", Produto.ID)
                };

                // Adicionando o parâmetro da foto apenas se estiver presente
                if (Produto.Foto != null)
                {
                    parametros.Add(new SqlParameter("@Foto", Produto.Foto));
                }

                banco.ExecutarComando(sql, parametros.ToArray());

                return "OK"; // Retorna OK caso a execução seja bem sucedida
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao atualizar Produto", ex);
                return "Erro ao atualizar Produto: " + ex.Message; // Retorna mensagem de erro em caso de falha
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao atualizar Produto", ex);
                return "Erro ao atualizar Produto: " + ex.Message; // Retorna mensagem de erro em caso de falha
            }
        }
        public bool AtivarOuDesativarProdutos(Produto produto)
        {
            try
            {
                string sql = "UPDATE tb_produtos SET status_produto = @Status WHERE id_produto = @Id";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Status", produto.Status),
                    new SqlParameter("@Id", produto.ID)
                };

                banco.ExecutarComando(sql, parametros);
                return true;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao ativar ou desativar produto", ex);
                return false;
            }
        }
        public bool ExcluirProduto(int idProduto)
        {
            try
            {
                string sql = "DELETE FROM tb_produtos WHERE id_produto = @IdProduto";
                SqlParameter parametroId = new SqlParameter("@IdProduto", idProduto);
                banco.ExecutarComando(sql, new[] { parametroId });

                return true;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao excluir produto", ex);
                return false;
            }
        }
        public List<Produto> ListarProdutos(string status)
        {
            try
            {
                string query = "SELECT * FROM tb_produtos";
                if (!string.IsNullOrEmpty(status))
                {
                    query += " WHERE status_produto = @Status";
                }
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { new SqlParameter("@Status", status) });
                return CreateProdutosListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar produtos", ex);
                return new List<Produto>();
            }
        }
        private Produto CreateProdutoFromDataRow(DataRow row)
        {
            Categoria categoria = categoriasController.BuscarCategoriaPorId((int)row["id_categoria"]);
            Marca marca = marcasController.BuscarMarcaPorId((int)row["id_marca"]);
            return new Produto
            {
                Nome = Convert.ToString(row["Nome"]),
                ID = Convert.ToInt32(row["id_produto"]),
                Categoria = categoria,
                DescricaoProduto = Convert.ToString(row["Descricao_produto"]),
                UnidadeMedida = Convert.ToString(row["Unidade_medida"]),
                Marca = marca,
                PrecoCusto = Convert.ToDecimal(row["preco_custo"]),
                PrecoVenda = Convert.ToDecimal(row["preco_venda"]),
                QtdEstoque = Convert.ToInt32(row["qtd_estoque"]),
                DataCriacao = Convert.ToDateTime(row["data_Criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
                Status = Convert.ToString((row["status_produto"])),
                Foto = row["Foto"] != DBNull.Value ? (byte[])row["Foto"] : null,
                Referencia = row["referencia"].ToString(),
            };
        }
        public Produto BuscarProdutoPorId(int idProduto)
        {
            try
            {
                string query = "SELECT * FROM tb_produtos WHERE id_produto = @IdProduto";
                SqlParameter parametroId = new SqlParameter("@IdProduto", idProduto);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametroId });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateProdutoFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar produto por ID", ex);
                return null;
            }
        }
        public List<Produto> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_produtos 
                         WHERE (nome LIKE @Filtro or referencia LIKE @Filtro ) 
                         AND status_produto = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Produto> listaProdutos = new List<Produto>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaProdutos.Add(CreateProdutoFromDataRow(row));
                }

                return listaProdutos;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar cidade", ex);
                return new List<Produto>();
            }
        }
        private List<Produto> CreateProdutosListFromDataTable(DataTable dataTable)
        {
            List<Produto> produtos = new List<Produto>();
            // Para cada linha no DataTable, crie um objeto Produto e adicione à lista de produtos
            foreach (DataRow row in dataTable.Rows)
            {
                produtos.Add(CreateProdutoFromDataRow(row));
            }
            return produtos;
        }
        public List<Produto> ListarProdutoPorIDProduto(int? CategoriaId)
        {
            try
            {
                List<Produto> produtos = new List<Produto>();

                string sql = "SELECT * FROM produto";
                if (CategoriaId > 0)
                {
                    sql += " WHERE CategoriaId = @CategoriaId";
                }
                sql += " ORDER BY Id ASC";

                DataTable dataTable = new DataTable();
                using (SqlConnection connection = banco.Abrir())
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    if (CategoriaId > 0)
                    {
                        command.Parameters.AddWithValue("@CategoriaId", CategoriaId);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    produtos.Add(CreateProdutoFromDataRow(row));
                }

                return produtos;
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao listar produtos", ex);
                return new List<Produto>();
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar produtos", ex);
                return new List<Produto>();
            }
        }

    }
}
