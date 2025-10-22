using PROJETO.data;
using PROJETO.models.bases;
using PROJETO.models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Linq;

namespace PROJETO.dao
{
    public class CategoriasDAO
    {
        private Banco banco = new Banco();
        Operacao operacao = new Operacao();

        public string AdicionarCategoria(Categoria categoria)
        {
            try
            {
                string sql = "INSERT INTO tb_categorias (Nome) " +
                             "VALUES (@Nome)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Nome", categoria.Nome),

                };
                var result = banco.ExecutarComando(sql, parametros);
                if (result)
                    return "OK";
                else
                    return "NOT";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string AtualizarCategoria(Categoria categoria)
        {
            try
            {
                string sql = "UPDATE tb_categorias SET Nome = @Nome " +
                             "WHERE Id = @Id";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Nome", categoria.Nome),
                    new SqlParameter("@Id", categoria.ID)
                };
                var result = banco.ExecutarComando(sql, parametros);
                if (result)
                    return "OK";
                else
                    return "NOT";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public Categoria BuscarCategoriaPorId(int id)
        {
            try
            {
                string query = "SELECT * FROM tb_categorias WHERE Id = @Id";
                SqlParameter parametro = new SqlParameter("@Id", id);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    return CreateCategoriaFromDataRow(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar Categoria por ID", ex);
                return null;
            }
        }

        public List<Categoria> BuscarCategoriaPorNome(string valorPesquisa)
        {
            try
            {
                string query = "SELECT * FROM tb_categorias WHERE Nome LIKE @ValorPesquisa";
                SqlParameter parametro = new SqlParameter("@ValorPesquisa", "%" + valorPesquisa + "%");
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                return CreateCategoriasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar Categoria por nome", ex);
                return new List<Categoria>();
            }
        }

        public List<Categoria> ListarCategoria()
        {
            try
            {
                string sql = "SELECT * FROM tb_categorias ORDER BY Id ASC"; // Ordena os Categorias pelo ID em ordem ascendente
                DataTable dataTable = banco.ExecutarConsulta(sql, null);

                return CreateCategoriasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar Categorias", ex);
                return new List<Categoria>();
            }
        }

        public bool ExcluirCategoria(int categoriaId)
        {
            try
            {
                string sql = "DELETE FROM tb_categorias WHERE Id = @Id";
                SqlParameter[] parametros = { new SqlParameter("@Id", categoriaId) };
                banco.ExecutarComando(sql, parametros);
                return true;
            }
            catch (SqlException ex)
            {
                if (operacao.IsForeignKeyViolation(ex))
                {
                    MessageBox.Show("Não foi possível excluir a Categoria selecionada, pois ela está sendo utilizada em outros registros." +
                        " Por favor, remova todas as referências desta Categoria em outros registros antes de tentar excluí-la novamente.");
                }
                else
                {
                    // Outro tratamento de exceção, se necessário
                    operacao.HandleException("Erro ao excluir Categoria", ex);
                }
                return false;
            }
        }
        public List<Categoria> Pesquisar(string filtro)
        {
            try
            {
                string query = @"SELECT * FROM tb_categorias 
                         WHERE Nome LIKE @Filtro";

                SqlParameter[] parametros = {
                new SqlParameter("@Filtro", "%" + filtro + "%")
            };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                return CreateCategoriasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar Categoria", ex);
                return new List<Categoria>();
            }
        }


        private Categoria CreateCategoriaFromDataRow(DataRow row)
        {
            return new Categoria
            {
                ID = Convert.ToInt32(row["Id"]),
                Nome = row["Nome"].ToString(),
            };
        }

        private List<Categoria> CreateCategoriasListFromDataTable(DataTable dataTable)
        {
            List<Categoria> categorias = new List<Categoria>();
            foreach (DataRow row in dataTable.Rows)
            {
                categorias.Add(CreateCategoriaFromDataRow(row));
            }
            return categorias;
        }
    }
}
