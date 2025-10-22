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

namespace PROJETO.dao
{
    public class ClientesDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();
        private CidadesController cidadesController = new CidadesController();

        public string AdicionarCliente(Clientes cliente)
        {
            try
            {
                string sql = "INSERT INTO tb_clientes (tipo_cliente, status_cliente, nome, sexo, apelido, rg, cpf, email, telefone, celular, cep, endereco, numero, complemento, bairro, id_cidade, data_nasc, id_condicao_pagamento, data_criacao, data_ult_alteracao) " +
                             "VALUES (@tipo_cliente, @StatusCliente, @Nome, @Sexo, @Apelido, @RG, @CPF, @Email, @Telefone, @Celular, @CEP, @Endereco, @Numero, @Complemento, @Bairro, @IdCidade, @DataNasc, @id_condicao_pagamento, @DataCriacao, @DataUltimaAlteracao)";

                SqlParameter[] parametros = {
                    CriarParametro("@tipo_cliente", cliente.TipoCliente),
                    CriarParametro("@StatusCliente", cliente.StatusCliente),
                    CriarParametro("@Nome", cliente.Nome),
                    CriarParametro("@Sexo", cliente.Sexo),
                    CriarParametro("@Apelido", cliente.Apelido),
                    CriarParametro("@RG", cliente.RG),
                    CriarParametro("@CPF", cliente.CPF),
                    CriarParametro("@Email", cliente.Email),
                    CriarParametro("@Telefone", cliente.Telefone),
                    CriarParametro("@Celular", cliente.Celular),
                    CriarParametro("@CEP", cliente.CEP),
                    CriarParametro("@Endereco", cliente.Endereco),
                    CriarParametro("@Numero", cliente.Numero),
                    CriarParametro("@Complemento", cliente.Complemento),
                    CriarParametro("@Bairro", cliente.Bairro),
                    CriarParametro("@IdCidade", cliente.Cidade.ID),
                    CriarParametro("@DataNasc", cliente.DataNasc),
                    CriarParametro("@id_condicao_pagamento", cliente.CondicaoPagamento.ID),
                    CriarParametro("@DataCriacao", cliente.DataCriacao),
                    CriarParametro("@DataUltimaAlteracao", cliente.DataUltimaAlteracao)
                };

                banco.ExecutarComando(sql, parametros);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private SqlParameter CriarParametro(string nome, object valor)
        {
            return new SqlParameter(nome, valor ?? DBNull.Value);
        }

        public bool ClienteJaExiste(string rg, string cpf)
        {
            string sql = "SELECT COUNT(*) FROM tb_clientes WHERE rg = @RG OR cpf = @CPF";
            SqlParameter[] parametros =
            {
                new SqlParameter("@RG", rg),
                new SqlParameter("@CPF", cpf)
            };

            object resultado = banco.ExecutarComandoScalar(sql, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        public string AtualizarCliente(Clientes cliente)
        {
            try
            {
                string sql = "UPDATE tb_clientes SET tipo_cliente = @tipo_cliente, status_cliente = @StatusCliente, nome = @Nome, sexo = @Sexo, apelido = @Apelido, rg = @RG, cpf = @CPF, email = @Email, " +
                             "telefone = @Telefone, celular = @Celular, cep = @CEP, endereco = @Endereco, numero = @Numero, complemento = @Complemento, bairro = @Bairro, " +
                             "id_cidade = @IdCidade, data_nasc = @DataNasc, data_ult_alteracao = @DataUltimaAlteracao, id_condicao_pagamento = @id_condicao_pagamento WHERE id_cliente = @Id";

                SqlParameter[] parametros = {
                    CriarParametro("@tipo_cliente", cliente.TipoCliente),
                    CriarParametro("@StatusCliente", cliente.StatusCliente),
                    CriarParametro("@Nome", cliente.Nome),
                    CriarParametro("@Sexo", cliente.Sexo),
                    CriarParametro("@Apelido", cliente.Apelido),
                    CriarParametro("@RG", cliente.RG),
                    CriarParametro("@CPF", cliente.CPF),
                    CriarParametro("@Email", cliente.Email),
                    CriarParametro("@Telefone", cliente.Telefone),
                    CriarParametro("@Celular", cliente.Celular),
                    CriarParametro("@CEP", cliente.CEP),
                    CriarParametro("@Endereco", cliente.Endereco),
                    CriarParametro("@Numero", cliente.Numero),
                    CriarParametro("@Complemento", cliente.Complemento),
                    CriarParametro("@Bairro", cliente.Bairro),
                    CriarParametro("@IdCidade", cliente.Cidade.ID),
                    CriarParametro("@DataNasc", cliente.DataNasc),
                    CriarParametro("@id_condicao_pagamento", cliente.CondicaoPagamento.ID),
                    CriarParametro("@DataUltimaAlteracao", cliente.DataUltimaAlteracao),
                    CriarParametro("@Id", cliente.ID)
                };

                banco.ExecutarComando(sql, parametros);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public bool ExcluirCliente(int clienteId)
        {
            try
            {
                string sql = "DELETE FROM tb_clientes WHERE id_cliente = @Id";
                SqlParameter parametro = new SqlParameter("@Id", clienteId);
                banco.ExecutarComando(sql, new[] { parametro });
                return true; // Retorne true para indicar sucesso
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao excluir cliente", ex);
                return false; // Retorne false para indicar falha
            }
        }

        public Clientes BuscarClientePorId(int id)
        {
            try
            {
                string query = "SELECT * FROM tb_clientes WHERE id_cliente = @Id";
                SqlParameter parametro = new SqlParameter("@Id", id);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateClienteFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar cliente por ID", ex);
                return null;
            }
        }
        public string BuscarClientePorCPFouCNPJ(string cpfoucnpj)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tb_clientes WHERE cpf = @CPFouCNPJ";
                SqlParameter parametro = new SqlParameter("@CPFouCNPJ", cpfoucnpj);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0 && (int)dataTable.Rows[0][0] > 0)
                {
                    return "Cliente já cadastrado";
                }

                return "OK";
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar cliente por CPF ou CNPJ", ex);
                return "Erro ao buscar cliente";
            }
        }


        public string BuscarClientePorRG(string cpfoucnpj)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tb_clientes WHERE rg = @rg";
                SqlParameter parametro = new SqlParameter("@rg", cpfoucnpj);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0 && (int)dataTable.Rows[0][0] > 0)
                {
                    return "Cliente já cadastrado";
                }

                return "OK";
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar cliente por CPF ou CNPJ", ex);
                return "Erro ao buscar cliente";
            }
        }

        public Clientes BuscarClientePorCPFouCNPJ2(string documento)
        {

            try
            {
                string query = "SELECT * FROM tb_clientes WHERE cpf = @Documento OR rg = @Documento";
                SqlParameter parametro = new SqlParameter("@Documento", documento);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateClienteFromDataRow(row);
                }

                return null; // Retorna null se não encontrar o cliente
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar cliente por documento", ex);
                return null;
            }
        }


        public List<Clientes> ListarClientes(string status)
        {
            try
            {
                string sql = "SELECT * FROM tb_clientes";
                List<SqlParameter> parametros = new List<SqlParameter>();

                // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " WHERE status_cliente = @Status";
                    parametros.Add(new SqlParameter("@Status", status));
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
                return CreateClientesListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar clientes", ex);
                return new List<Clientes>();
            }
        }

        public List<Clientes> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_clientes 
                         WHERE (nome LIKE @Filtro OR apelido LIKE @Filtro OR rg LIKE @Filtro OR cpf LIKE @Filtro OR email LIKE @Filtro) 
                         AND status_cliente = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Clientes> listaClientes = new List<Clientes>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaClientes.Add(CreateClienteFromDataRow(row));
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar cidade", ex);
                return new List<Clientes>();
            }
        }


        private Clientes CreateClienteFromDataRow(DataRow row)
        {
            CondicaoPagamentoController aCTLCond = new CondicaoPagamentoController();
            var condicao = aCTLCond.BuscarCondicaoPagamentoPorId(Convert.ToInt32(row["id_condicao_pagamento"]));
            return new Clientes
            {
                ID = Convert.ToInt32(row["id_cliente"]),
                StatusCliente = row["status_cliente"].ToString(),
                Nome = row["nome"].ToString(),
                Sexo = row["sexo"].ToString(),
                Apelido = row["apelido"].ToString(),
                RG = row["rg"].ToString(),
                CPF = row["cpf"].ToString(),
                Email = row["email"].ToString(),
                Telefone = row["telefone"].ToString(),
                Celular = row["celular"].ToString(),
                CEP = row["cep"].ToString(),
                Endereco = row["endereco"].ToString(),
                Numero = Convert.ToInt32(row["numero"]),
                Complemento = row["complemento"].ToString(),
                Bairro = row["bairro"].ToString(),
                Cidade = cidadesController.BuscarCidadePorId(Convert.ToInt32(row["id_cidade"])), // Supondo que você tenha um método para buscar a cidade pelo ID
                DataNasc = Convert.ToDateTime(row["data_nasc"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
                CondicaoPagamento = condicao,
                TipoCliente = row["tipo_cliente"].ToString()
            };
        }

        private List<Clientes> CreateClientesListFromDataTable(DataTable dataTable)
        {
            List<Clientes> clientes = new List<Clientes>();
            // Para cada linha no DataTable, crie um objeto Clientes e adicione à lista de clientes
            foreach (DataRow row in dataTable.Rows)
            {
                clientes.Add(CreateClienteFromDataRow(row));
            }
            return clientes;
        }


    }
}
