using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.data
{
    internal class Banco
    {


        private static string connectionString;

        static Banco()
        {
            string raizProjeto = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string caminhoBanco = Path.Combine(raizProjeto, "data", "db.mdf");

            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
                          AttachDbFilename={caminhoBanco};
                          Integrated Security=True;
                          Connect Timeout=30;";
        }



        public SqlConnection Abrir()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                return cnn;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu um erro SQL ao abrir a conexão. Detalhes: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao abrir a conexão. Detalhes: " + ex.Message);
                return null;
            }
        }

        public void Fechar(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu um erro SQL ao fechar a conexão. Detalhes: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao fechar a conexão. Detalhes: " + ex.Message);
            }
        }
        // Método para executar o comando dentro de uma transação

        public bool ExecutarComando(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = Abrir())
            {
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    HandleSqlException(ex, transaction);
                    return false;
                }
            }
        }

        public string ExecutarComandostr(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = Abrir())
            {
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return HandleSqlException(ex, transaction);
                }
            }
        }

        private string HandleSqlException(Exception ex, SqlTransaction transaction)
        {
            try
            {
                if (ex is SqlException sqlEx)
                {
                    switch (sqlEx.Number)
                    {
                        case 547: // Violation of FOREIGN KEY constraint
                            MessageBox.Show("Não é possível excluir este registro porque está vinculado a outros serviços.",
                                            "Erro de Exclusão",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return "FKViolation";
                        case 2601: // Violation of UNIQUE KEY constraint
                        case 2627: // Violation of UNIQUE KEY constraint
                            MessageBox.Show("Já existe um registro com os mesmos dados.",
                                            "Erro de Chave Única",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return "UniqueViolation";
                        default:
                            MessageBox.Show("Erro ao executar operação no banco de dados: " + ex.Message,
                                            "Erro",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao executar operação no banco de dados: " + ex.Message,
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                transaction.Rollback();
                return "Error";
            }
            catch (Exception innerEx)
            {
                MessageBox.Show("Erro ao executar operação no banco de dados: " + innerEx.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return "Error";
            }
        }



        public object ExecutarComandoScalar(string sql, SqlParameter[] parameters)
        {
            object result = null;

            using (SqlConnection connection = Abrir())
            {
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        result = command.ExecuteScalar();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ocorreu um erro ao executar o comando no banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }



        public DataTable ExecutarConsulta(string sql, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = Abrir())
            {
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ocorreu um erro ao executar a consulta no banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataTable;
        }
    }
}
