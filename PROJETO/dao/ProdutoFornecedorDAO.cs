using PROJETO.controller;
using PROJETO.data;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PROJETO.DAO
{
    public class ProdutoFornecedorDAO
    {

        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();
        FornecedoresController fornecedoresController = new FornecedoresController();
        ProdutosController produtosController = new ProdutosController();
        public string AdicionarProdutoFornecedor(ProdutosFornecedor produtoFornecedor)
        {
            try
            {
                string sql = "INSERT INTO tb_produtos_fornecedores (id_produto, id_fornecedor, data_criacao, data_ult_alteracao, status_produto) " +
                             "VALUES (@id_produto, @id_fornecedor, @data_criacao, @data_ult_alteracao, @status)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@id_produto", produtoFornecedor.oProduto.ID),
                    new SqlParameter("@id_fornecedor", produtoFornecedor.oFornecedor.ID),
                    new SqlParameter("@data_criacao", produtoFornecedor.DataCriacao),
                    new SqlParameter("@data_ult_alteracao", produtoFornecedor.DataUltimaAlteracao),
                    new SqlParameter("@status", produtoFornecedor.Status)
                };

                banco.ExecutarComando(sql, parametros);
                return "OK";
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao adicionar Produto Fornecedor", ex);
                return "Erro ao adicionar Produto Fornecedor: " + ex.Message;
            }
        }

        public string AtualizarProdutoFornecedor(ProdutosFornecedor produtoFornecedor)
        {
            try
            {
                string sql = "UPDATE tb_produtos_fornecedores SET id_produto = @id_produto, id_fornecedor = @id_fornecedor, " +
                             "data_ult_alteracao = @data_ult_alteracao, status_produto = @status WHERE id_produto_fornecedor = @id";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@id", produtoFornecedor.ID),
                    new SqlParameter("@id_produto", produtoFornecedor.oProduto.ID),
                    new SqlParameter("@id_fornecedor", produtoFornecedor.oFornecedor.ID),
                    new SqlParameter("@data_ult_alteracao", produtoFornecedor.DataUltimaAlteracao),
                    new SqlParameter("@status", produtoFornecedor.Status)
                };

                banco.ExecutarComando(sql, parametros);
                return "OK";
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao atualizar Produto Fornecedor", ex);
                return "Erro ao atualizar Produto Fornecedor: " + ex.Message;
            }
        }


        public bool ExcluirProdutoFornecedor(int id)
        {
            try
            {
                string sql = "DELETE FROM tb_produtos_fornecedores WHERE id_produto_fornecedor = @id";
                SqlParameter parametro = new SqlParameter("@id", id);
                banco.ExecutarComando(sql, new[] { parametro });
                return true; // Retorne true para indicar sucesso
            }
            catch (SqlException ex)
            {
                // Trate exceções específicas do SQL Server, se necessário
                operacao.HandleException("Erro ao excluir estado", ex);
                return false; // Retorne false para indicar falha
            }
            catch (Exception ex)
            {
                // Trate outras exceções genéricas, se aplicável
                operacao.HandleException("Erro ao excluir estado", ex);
                return false; // Retorne false para indicar falha
            }
        }


        public ProdutosFornecedor BuscarProdutoFornecedorPorId(int id)
        {
            try
            {
                string sql = "SELECT * FROM tb_produtos_fornecedores WHERE id_produto_fornecedor = @id";
                SqlParameter parametro = new SqlParameter("@id", id);
                DataTable resultado = banco.ExecutarConsulta(sql, new[] { parametro });

                if (resultado.Rows.Count == 0)
                    return null;

                return CriarProdutoFornecedorDeDataRow(resultado.Rows[0]);
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao buscar Produto Fornecedor", ex);
                return null;
            }
        }
        public List<ProdutosFornecedor> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"
                                SELECT pf.*
                                FROM tb_produtos_fornecedores pf 
                                JOIN tb_produtos p ON pf.id_produto = p.id_produto
                                INNER JOIN tb_fornecedores f ON pf.id_fornecedor = f.id_fornecedor
                                WHERE (p.nome LIKE @Filtro OR f.nome_fantasia LIKE @Filtro)
                                AND pf.status_produto = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<ProdutosFornecedor> listaProdutosFornecedores = new List<ProdutosFornecedor>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaProdutosFornecedores.Add(CriarProdutoFornecedorDeDataRow(row));
                }

                return listaProdutosFornecedores;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar Produtos Fornecedores", ex);
                return new List<ProdutosFornecedor>();
            }
        }
        public List<ProdutosFornecedor> Pesquisar(string filtro, string status, string fornecedor)
        {
            try
            {
                string query = @"
                        SELECT pf.*
                        FROM tb_produtos_fornecedores pf 
                        JOIN tb_produtos p ON pf.id_produto = p.id_produto
                        INNER JOIN tb_fornecedores f ON pf.id_fornecedor = f.id_fornecedor
                        WHERE (p.nome LIKE @Filtro OR f.nome_fantasia LIKE @Filtro)
                        AND pf.status_produto = @Status
                        AND f.nome_fantasia = @Fornecedor";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@Fornecedor", fornecedor)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<ProdutosFornecedor> listaProdutosFornecedores = new List<ProdutosFornecedor>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaProdutosFornecedores.Add(CriarProdutoFornecedorDeDataRow(row));
                }

                return listaProdutosFornecedores;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar Produtos Fornecedores", ex);
                return new List<ProdutosFornecedor>();
            }
        }


        public List<ProdutosFornecedor> ListarProdutosFornecedores(string status)
        {
            try
            {
                string sql = "SELECT * FROM tb_produtos_fornecedores";
                List<SqlParameter> parametros = new List<SqlParameter>();

                // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " WHERE status_produto = @Status";
                    parametros.Add(new SqlParameter("@Status", status));
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
                return CreateProdutosFornecedoresListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar Produtos Fornecedores", ex);
                return new List<ProdutosFornecedor>();
            }
        }

        public List<ProdutosFornecedor> ListarProdutosFornecedoresPorFornecedor(string status, string fornecedor)
        {
            try
            {
                // Consulta SQL atualizada para incluir a junção com a tabela tb_fornecedores
                string sql = @"
                SELECT pf.* 
                FROM tb_produtos_fornecedores pf
                INNER JOIN tb_fornecedores f ON pf.id_fornecedor = f.id_fornecedor
                WHERE f.nome_fantasia = @Fornecedor";

                    List<SqlParameter> parametros = new List<SqlParameter>
            {
                         new SqlParameter("@Fornecedor", fornecedor)
                    };

                // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " AND pf.status_produto = @Status";
                    parametros.Add(new SqlParameter("@Status", status));
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
                return CreateProdutosFornecedoresListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar Produtos Fornecedores", ex);
                return new List<ProdutosFornecedor>();
            }
        }


        private ProdutosFornecedor CriarProdutoFornecedorDeDataRow(DataRow row)
        {
            Fornecedores oFornecedor = fornecedoresController.BuscarFornecedorPorId(Convert.ToInt32(row["id_fornecedor"]));
            Produto oProduto = produtosController.BuscarProdutoPorId(Convert.ToInt32(row["id_produto"]));

            return new ProdutosFornecedor
            {
                ID = Convert.ToInt32(row["id_produto_fornecedor"]),
                oProduto = oProduto,
                oFornecedor = oFornecedor,
                DataCriacao = row["data_criacao"] != DBNull.Value ? Convert.ToDateTime(row["data_criacao"]) : DateTime.MinValue,
                DataUltimaAlteracao = row["data_ult_alteracao"] != DBNull.Value ? Convert.ToDateTime(row["data_ult_alteracao"]) : DateTime.MinValue,
                Status = row["status_produto"].ToString()
            };
        }

        private List<ProdutosFornecedor> CreateProdutosFornecedoresListFromDataTable(DataTable dataTable)
        {
            List<ProdutosFornecedor> produtosFornecedores = new List<ProdutosFornecedor>();
            foreach (DataRow row in dataTable.Rows)
            {
                produtosFornecedores.Add(CriarProdutoFornecedorDeDataRow(row));
            }
            return produtosFornecedores;
        }

    }
}
