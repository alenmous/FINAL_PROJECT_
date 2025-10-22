using PROJETO.data;
using PROJETO.models.bases;
using PROJETO.models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
namespace PROJETO.dao
{
    public class MarcasDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();

        public string AdicionarMarca(Marca marca)
        {
            try
            {
                string sql = "INSERT INTO tb_marcas (marca, descricao, data_criacao, data_ult_alteracao) " +
                             "VALUES (@Marca, @Descricao, @DataCriacao, @DataUltimaAlteracao)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Marca", marca.Nome),
                    new SqlParameter("@Descricao", marca.Descricao),
                    new SqlParameter("@DataCriacao", marca.DataCriacao),
                    new SqlParameter("@DataUltimaAlteracao", marca.DataUltimaAlteracao)
                };
                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AtualizarMarca(Marca marca)
        {
            try
            {
                string sql = "UPDATE tb_marcas SET marca = @Marca, descricao = @Descricao, " +
                             "data_criacao = @DataCriacao, data_ult_alteracao = @DataUltimaAlteracao " +
                             "WHERE id_marca = @Id";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Marca", marca.Nome),
                    new SqlParameter("@Descricao", marca.Descricao),
                    new SqlParameter("@DataCriacao", marca.DataCriacao),
                    new SqlParameter("@DataUltimaAlteracao", marca.DataUltimaAlteracao),
                    new SqlParameter("@Id", marca.ID)
                };
                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool ExcluirMarca(int marcaId)
        {
            try
            {
                string sql = "DELETE FROM tb_marcas WHERE id_marca = @Id";
                SqlParameter parametro = new SqlParameter("@Id", marcaId);
                banco.ExecutarComando(sql, new[] { parametro });
                return true;
            }
            catch (SqlException ex)
            {
                operacao.HandleException("Erro ao excluir marca", ex);
                return false;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao excluir marca", ex);
                return false;
            }
        }

        public Marca BuscarMarcaPorId(int id)
        {
            try
            {
                string query = "SELECT * FROM tb_marcas WHERE id_marca = @Id";
                SqlParameter parametro = new SqlParameter("@Id", id);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateMarcaFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar marca por ID", ex);
                return null;
            }
        }

        public List<Marca> ListarMarcas()
        {
            try
            {
                string sql = "SELECT * FROM tb_marcas";
                DataTable dataTable = banco.ExecutarConsulta(sql, null);
                return CreateMarcasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar marcas", ex);
                return new List<Marca>();
            }
        }

        private Marca CreateMarcaFromDataRow(DataRow row)
        {
            return new Marca
            {
                ID = Convert.ToInt32(row["id_marca"]),
                Nome = row["marca"].ToString(),
                Descricao = row["descricao"].ToString(),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"])
            };
        }

        private List<Marca> CreateMarcasListFromDataTable(DataTable dataTable)
        {
            List<Marca> marcas = new List<Marca>();
            foreach (DataRow row in dataTable.Rows)
            {
                marcas.Add(CreateMarcaFromDataRow(row));
            }
            return marcas;
        }

        public List<Marca> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_marcas 
                         WHERE (marca LIKE @Filtro )";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Marca> listaMarca = new List<Marca>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaMarca.Add(CreateMarcaFromDataRow(row));
                }

                return listaMarca;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar marca", ex);
                return new List<Marca>();
            }
        }
    }
}
