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
using PROJETO.controller;

namespace PROJETO.dao
{
    public class EstadosDAO
    {

        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();
        PaisesController paisesController = new PaisesController();

        public string AdicionarEstado(Estados estado)
        {
            try
            {
                string sql = "INSERT INTO tb_estados (status_estado, nome, uf, id_pais, data_criacao, data_ult_alteracao) " +
                             "VALUES (@StatusEstado, @Nome, @UF, @IdPais, @DataCriacao, @DataUltimaAlteracao)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@StatusEstado", estado.StatusEstado),
                    new SqlParameter("@Nome", estado.Estado),
                    new SqlParameter("@UF", estado.UF),
                    new SqlParameter("@IdPais", estado.OPais.ID),
                    new SqlParameter("@DataCriacao", estado.DataCriacao),
                    new SqlParameter("@DataUltimaAlteracao", estado.DataUltimaAlteracao)
                };
                banco.ExecutarComando(sql, parametros);

                // Se a execução chegou até aqui, significa que a operação foi bem-sucedida
                return "OK";
            }
            catch (Exception ex)
            {
                // Se ocorreu alguma exceção, retorna a mensagem de erro
                return ex.Message;
            }
        }

        public string AtualizarEstado(Estados estado)
        {
            try
            {
                string sql = "UPDATE tb_estados SET status_estado = @StatusEstado, nome = @Nome, uf = @UF, id_pais = @IdPais, " +
                             "data_criacao = @DataCriacao, data_ult_alteracao = @DataUltimaAlteracao WHERE id_estado = @Id";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@StatusEstado", estado.StatusEstado),
                    new SqlParameter("@Nome", estado.Estado),
                    new SqlParameter("@UF", estado.UF),
                    new SqlParameter("@IdPais", estado.OPais.ID),
                    new SqlParameter("@DataCriacao", estado.DataCriacao),
                    new SqlParameter("@DataUltimaAlteracao", estado.DataUltimaAlteracao),
                    new SqlParameter("@Id", estado.ID)
                };
                banco.ExecutarComando(sql, parametros);

                // Se a execução chegou até aqui, significa que a operação foi bem-sucedida
                return "OK";
            }
            catch (Exception ex)
            {
                // Se ocorreu alguma exceção, retorna a mensagem de erro
                return ex.Message;
            }
        }

        public bool ExcluirEstado(int estadoId)
        {
            try
            {
                string sql = "DELETE FROM tb_estados WHERE id_estado = @Id";
                SqlParameter parametro = new SqlParameter("@Id", estadoId);
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

        public Estados BuscarEstadoPorId(int id)
        {
            try
            {
                string query = "SELECT * FROM tb_estados WHERE id_estado = @Id";
                SqlParameter parametro = new SqlParameter("@Id", id);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateEstadoFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar estado por ID", ex);
                return null;
            }
        }

        public List<Estados> ListarEstados(string status)
        {
            try
            {
                string sql = "SELECT * FROM tb_estados";
                List<SqlParameter> parametros = new List<SqlParameter>();

                // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " WHERE status_estado = @Status";
                    parametros.Add(new SqlParameter("@Status", status));
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
                return CreateEstadosListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar estados", ex);
                return new List<Estados>();
            }
        }


        private Estados CreateEstadoFromDataRow(DataRow row)
        {
            Paises pais = paisesController.BuscarPaisPorId(Convert.ToInt32(row["id_pais"]));

            return new Estados
            {
                ID = Convert.ToInt32(row["id_estado"]),
                Estado = row["nome"].ToString(),
                UF = row["uf"].ToString(),
                OPais = pais,
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
                StatusEstado = row["status_estado"].ToString()
            };
        }

        private List<Estados> CreateEstadosListFromDataTable(DataTable dataTable)
        {
            List<Estados> estados = new List<Estados>();
            foreach (DataRow row in dataTable.Rows)
            {
                estados.Add(CreateEstadoFromDataRow(row));
            }
            return estados;
        }


        public List<Estados> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_estados 
                         WHERE (nome LIKE @Filtro OR uf LIKE @Filtro) 
                         AND status_estado = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Estados> listaEstados = new List<Estados>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaEstados.Add(CreateEstadoFromDataRow(row));
                }

                return listaEstados;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar estado", ex);
                return new List<Estados>();
            }
        }


    }
}
