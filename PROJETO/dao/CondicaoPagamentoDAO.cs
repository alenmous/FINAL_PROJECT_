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
using PROJETO.controller;

namespace PROJETO.dao
{
    public class CondicaoPagamentoDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();

        public bool AdicionarCondicaoPagamento(CondicaoPagamento obj)
        {
            bool status = false;
            string sqlInsert = @"INSERT INTO tb_condicao_pagamento (id_condicao, condicao, parcelas, taxa, multa, desconto, data_criacao, data_ult_alteracao, status_condicao)
                         VALUES(@id_condicao, @condicao, @parcelas, @taxa, @multa, @desconto, @data_criacao, @data_ult_alteracao, @status_condicao)";
            string LastID = "SELECT ISNULL(MAX(id_condicao), 0) FROM tb_condicao_pagamento";

            try
            {
                using (SqlConnection connection = banco.Abrir())
                {
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Obter o próximo ID
                            int proximoID = Convert.ToInt32(banco.ExecutarComandoScalar(LastID, null)) + 1;
                            obj.ID = proximoID;

                            // Configurar parâmetros
                            SqlParameter[] parametros = new SqlParameter[]
                            {
                                new SqlParameter("@id_condicao", obj.ID),
                                new SqlParameter("@condicao", obj.Condicao),
                                new SqlParameter("@parcelas", obj.Parcelas),
                                new SqlParameter("@taxa", obj.Taxa),
                                new SqlParameter("@multa", obj.Multa),
                                new SqlParameter("@desconto", obj.Desconto),
                                new SqlParameter("@data_criacao", obj.DataCriacao),
                                new SqlParameter("@data_ult_alteracao", obj.DataUltimaAlteracao),
                                new SqlParameter("@status_condicao", obj.Status)
                            };

                            // Executar comando de inserção
                            banco.ExecutarComando(sqlInsert, parametros);

                            // Salvar parcelas associadas
                            foreach (Parcela parcela in obj.uParcelas)
                            {
                                if (parcela != null)
                                {
                                    ParcelasController parcelasController = new ParcelasController();
                                    parcela.ID = proximoID; // Definir o ID da condição de pagamento
                                    status = parcelasController.SalvarParcelas(parcela);
                                    if (!status)
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Aconteceu um erro ao salvar as parcelas.");
                                        return false;
                                    }
                                }
                            }

                            transaction.Commit();
                            status = true;
                            MessageBox.Show("Condição de pagamento cadastrada com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Erro ao salvar a condição de pagamento: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }

            return status;
        }

        public bool AtualizarCondicaoPagamento(CondicaoPagamento obj)
        {
            bool status = false;
            string sqlUpdate = @"UPDATE tb_condicao_pagamento 
                         SET condicao = @condicao, 
                             parcelas = @parcelas, 
                             taxa = @taxa, 
                             multa = @multa, 
                             desconto = @desconto, 
                             data_ult_alteracao = @data_ult_alteracao
                         WHERE id_condicao = @id_condicao";

            using (SqlConnection connection = banco.Abrir())
            {
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Configurar parâmetros para a atualização
                    SqlParameter[] parametrosCondicao =
                    {
                            new SqlParameter("@condicao", obj.Condicao),
                            new SqlParameter("@taxa", obj.Taxa),
                            new SqlParameter("@multa", obj.Multa),
                            new SqlParameter("@desconto", obj.Desconto),
                            new SqlParameter("@parcelas", obj.Parcelas),
                            new SqlParameter("@data_ult_alteracao", obj.DataUltimaAlteracao),
                            new SqlParameter("@id_condicao", obj.ID)
                     };

                    // Executar comando de atualização
                    banco.ExecutarComando(sqlUpdate, parametrosCondicao);

                    // Excluir todas as parcelas existentes
                    ParcelasController parcelasController = new ParcelasController();
                    List<Parcela> parcelasBanco = parcelasController.BuscarParcelasPorIDCondicao(obj.ID);

                    foreach (Parcela parcelaBanco in parcelasBanco)
                    {
                        bool resultadoExclusao = parcelasController.ExcluirParcela(parcelaBanco.Condicao.ID, parcelaBanco.NumParcela, parcelaBanco.Forma.ID);

                        if (!resultadoExclusao)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Erro ao excluir parcela.");
                            return false;
                        }
                    }

                    // Adicionar as novas parcelas
                    foreach (Parcela parcelaNova in obj.uParcelas)
                    {
                        parcelaNova.Condicao.ID = obj.ID;
                        string resultadoAdicao = parcelasController.AdicionarParcela(parcelaNova);

                        if (resultadoAdicao != "OK")
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao adicionar parcela: {resultadoAdicao}");
                            return false;
                        }
                    }

                    transaction.Commit();
                    status = true;
                    MessageBox.Show("Condição de pagamento atualizada com sucesso!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

            return status;
        }
        public int ObterProximoIdCondicaoPagamento()
        {
            try
            {
                string sql = "SELECT ISNULL(MAX(id_condicao), 0) FROM tb_condicao_pagamento";
                int ultimoId = (int)banco.ExecutarComandoScalar(sql, null);
                return ultimoId + 1;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao obter o próximo ID de condição de pagamento", ex);
                return 1; // Retorna 1 se houver um erro
            }
        }
        public bool ExcluirCondicaoPagamento(int condicaoPagamentoId)
        {
            try
            {
                string sql = "DELETE FROM tb_condicao_pagamento WHERE id_condicao = @Id";
                SqlParameter parametro = new SqlParameter("@Id", condicaoPagamentoId);
                banco.ExecutarComando(sql, new[] { parametro });
                return true;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao excluir condição de pagamento", ex);
                return false;
            }
        }
        public bool AtivarOuDesativarCondicaoPagamento(CondicaoPagamento condicao)
        {
            try
            {
                // Consultar o status atual
                string consultaStatusSql = "SELECT status_condicao FROM tb_condicao_pagamento WHERE id_condicao = @Id";
                SqlParameter[] parametrosConsulta =
                {
                    new SqlParameter("@Id", condicao.ID)
                };

                // Obter o status atual (A ou I)
                string statusAtual = banco.ExecutarComandoScalar(consultaStatusSql, parametrosConsulta)?.ToString();

                if (string.IsNullOrEmpty(statusAtual))
                {
                    MessageBox.Show("Condição de pagamento não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Determinar o novo status
                string novoStatus = statusAtual == "A" ? "I" : "A"; // Alterna entre "A" e "I"

                // Atualizar o status
                string sqlUpdate = "UPDATE tb_condicao_pagamento SET status_condicao = @Status WHERE id_condicao = @Id";
                SqlParameter[] parametrosUpdate =
                {
                    new SqlParameter("@Status", novoStatus),
                    new SqlParameter("@Id", condicao.ID)
                };

                banco.ExecutarComando(sqlUpdate, parametrosUpdate);
                return true;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao ativar ou desativar condição de pagamento", ex);
                return false;
            }
        }


        public CondicaoPagamento BuscarCondicaoPagamentoPorId(int id)
        {
            try
            {
                string query = "SELECT * FROM tb_condicao_pagamento WHERE id_condicao = @Id";
                SqlParameter parametro = new SqlParameter("@Id", id);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateCondicaoPagamentoFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar condição de pagamento por ID", ex);
                return null;
            }
        }
        public List<CondicaoPagamento> ListarCondicoesPagamento(string status)
        {
            try
            {
                string sql = "SELECT * FROM tb_condicao_pagamento";
                List<SqlParameter> parametros = new List<SqlParameter>();

                // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " WHERE status_condicao = @Status";
                    parametros.Add(new SqlParameter("@Status", status));
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
                return CreateCondicoesPagamentoListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar condições de pagamento", ex);
                return new List<CondicaoPagamento>();
            }
        }


        public List<CondicaoPagamento> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_condicao_pagamento 
                         WHERE (condicao LIKE @Filtro) 
                         AND status_condicao = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<CondicaoPagamento> listaCondicaoPagamento = new List<CondicaoPagamento>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaCondicaoPagamento.Add(CreateCondicaoPagamentoFromDataRow(row));
                }

                return listaCondicaoPagamento;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar estado", ex);
                return new List<CondicaoPagamento>();
            }
        }

        private CondicaoPagamento CreateCondicaoPagamentoFromDataRow(DataRow row)
        {
            return new CondicaoPagamento
            {
                ID = Convert.ToInt32(row["id_condicao"]),
                Condicao = row["condicao"].ToString(),
                Parcelas = Convert.ToInt32(row["parcelas"]),
                Taxa = Convert.ToDecimal(row["taxa"]),
                Multa = Convert.ToDecimal(row["multa"]),
                Desconto = Convert.ToDecimal(row["desconto"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
                Status = row["status_condicao"].ToString()
            };
        }
        private List<CondicaoPagamento> CreateCondicoesPagamentoListFromDataTable(DataTable dataTable)
        {
            List<CondicaoPagamento> condicoesPagamento = new List<CondicaoPagamento>();
            foreach (DataRow row in dataTable.Rows)
            {
                condicoesPagamento.Add(CreateCondicaoPagamentoFromDataRow(row));
            }
            return condicoesPagamento;
        }
     




    }
}
