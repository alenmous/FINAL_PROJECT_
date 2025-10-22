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
    public class FornecedoresDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();
        private CidadesController aCTLCidades = new CidadesController();

        public string AdicionarFornecedor(Fornecedores fornecedor)
        {
            try
            {
                string sql = "INSERT INTO tb_fornecedores (rg, tipo_fornecedor, id_condicao_pagamento, status_fornecedor, nome_fantasia, razao_social, data_fundacao, insc_municipal, insc_estadual, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, id_cidade, data_criacao, data_ult_alteracao) " +
                             "VALUES ( @rg, @tipo_fornecedor, @id_condicao_pagamento, @StatusFornecedor, @NomeFantasia, @RazaoSocial, @DataFundacao, @InscricaoMunicipal, @InscricaoEstadual, @CNPJ, @Email, @Telefone, @Celular, @CEP, @Endereco, @Numero, @Complemento, @Bairro, @IdCidade, @DataCriacao, @DataUltimaAlteracao)";
                SqlParameter[] parametros =
                {
                    CriarParametro("@StatusFornecedor", fornecedor.StatusFornecedor),
                    CriarParametro("@NomeFantasia", fornecedor.NomeFantasia),
                    CriarParametro("@RazaoSocial", fornecedor.RazaoSocial),
                    CriarParametro("@DataFundacao", fornecedor.DataFundacao),
                    CriarParametro("@InscricaoMunicipal", fornecedor.InscricaoMunicipal),
                    CriarParametro("@InscricaoEstadual", fornecedor.InscricaoEstadual),
                    CriarParametro("@CNPJ", fornecedor.CNPJ),
                    CriarParametro("@Email", fornecedor.Email),
                    CriarParametro("@Telefone", fornecedor.Telefone),
                    CriarParametro("@Celular", fornecedor.Celular),
                    CriarParametro("@CEP", fornecedor.CEP),
                    CriarParametro("@rg", fornecedor.RG),
                    CriarParametro("@tipo_fornecedor", fornecedor.TipoFornecedor),
                    CriarParametro("@Endereco", fornecedor.Endereco),
                    CriarParametro("@Numero", fornecedor.Numero),
                    CriarParametro("@Complemento", fornecedor.Complemento),
                    CriarParametro("@Bairro", fornecedor.Bairro),
                    CriarParametro("@IdCidade", fornecedor.Cidade.ID),
                    CriarParametro("@id_condicao_pagamento", fornecedor.CondicaoPagamento.ID),
                    CriarParametro("@DataCriacao", fornecedor.DataCriacao),
                    CriarParametro("@DataUltimaAlteracao", fornecedor.DataUltimaAlteracao)
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
        private SqlParameter CriarParametro(string nome, object valor)
        {
            return new SqlParameter(nome, valor ?? DBNull.Value);
        }

        public string AtualizarFornecedor(Fornecedores fornecedor)
        {
            try
            {
                string sql = "UPDATE  tb_fornecedores SET rg = @rg, tipo_fornecedor = @tipo_fornecedor, id_condicao_pagamento = @id_condicao_pagamento, status_fornecedor = @StatusFornecedor, nome_fantasia = @NomeFantasia, razao_social = @RazaoSocial, data_fundacao = @DataFundacao, insc_municipal = @InscricaoMunicipal, insc_estadual = @InscricaoEstadual, " +
                             "cnpj = @CNPJ, email = @Email, telefone = @Telefone, celular = @Celular, cep = @CEP, endereco = @Endereco, numero = @Numero, complemento = @Complemento, bairro = @Bairro, " +
                             "id_cidade = @IdCidade, data_ult_alteracao = @DataUltimaAlteracao WHERE id_fornecedor = @Id";
                SqlParameter[] parametros =
                {
                    CriarParametro("@StatusFornecedor", fornecedor.StatusFornecedor),
                    CriarParametro("@NomeFantasia", fornecedor.NomeFantasia),
                    CriarParametro("@RazaoSocial", fornecedor.RazaoSocial),
                    CriarParametro("@DataFundacao", fornecedor.DataFundacao),
                    CriarParametro("@InscricaoMunicipal", fornecedor.InscricaoMunicipal),
                    CriarParametro("@InscricaoEstadual", fornecedor.InscricaoEstadual),
                    CriarParametro("@CNPJ", fornecedor.CNPJ),
                    CriarParametro("@Email", fornecedor.Email),
                    CriarParametro("@Telefone", fornecedor.Telefone),
                    CriarParametro("@Celular", fornecedor.Celular),
                    CriarParametro("@CEP", fornecedor.CEP),
                    CriarParametro("@Endereco", fornecedor.Endereco),
                    CriarParametro("@Numero", fornecedor.Numero),
                    CriarParametro("@rg", fornecedor.RG),
                    CriarParametro("@tipo_fornecedor", fornecedor.TipoFornecedor),
                    CriarParametro("@Complemento", fornecedor.Complemento),
                    CriarParametro("@Bairro", fornecedor.Bairro),
                    CriarParametro("@IdCidade", fornecedor.Cidade.ID),
                    CriarParametro("@id_condicao_pagamento", fornecedor.CondicaoPagamento.ID),
                    CriarParametro("@DataUltimaAlteracao", fornecedor.DataUltimaAlteracao),
                    CriarParametro("@Id", fornecedor.ID)
                };
                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool ExcluirFornecedor(int fornecedorId)
        {
            try
            {
                string sql = "DELETE FROM tb_fornecedores WHERE id_fornecedor = @Id";
                SqlParameter parametro = new SqlParameter("@Id", fornecedorId);
                banco.ExecutarComando(sql, new[] { parametro });
                return true; // Retorne true para indicar sucesso
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao excluir fornecedor", ex);
                return false; // Retorne false para indicar falha
            }
        }
        public string BuscarFornecedorPorCPFouCNPJ(string cpfoucnpj)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tb_fornecedores WHERE cnpj = @CPFouCNPJ";
                SqlParameter parametro = new SqlParameter("@CPFouCNPJ", cpfoucnpj);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0 && (int)dataTable.Rows[0][0] > 0)
                {
                    return "Fornecedor já cadastrado";
                }

                return "OK";
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar fornecedor por CPF ou CNPJ", ex);
                return "Erro ao buscar fornecedor";
            }
        }
        public string BuscarFornecedorPorRG(string cpfoucnpj)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tb_fornecedores WHERE rg = @rg";
                SqlParameter parametro = new SqlParameter("@rg", cpfoucnpj);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0 && (int)dataTable.Rows[0][0] > 0)
                {
                    return "Fornecedor já cadastrado";
                }

                return "OK";
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar fornecedor por CPF ou CNPJ", ex);
                return "Erro ao buscar fornecedor";
            }
        }
        public Fornecedores BuscarFornecedorPorNome(string nomeFantasia)
        {
            try
            {
                string query = "SELECT * FROM tb_fornecedores WHERE nome_fantasia LIKE @nomeFantasia";
                SqlParameter parametro = new SqlParameter("@nomeFantasia", $"%{nomeFantasia}%");
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateFornecedorFromDataRow(row);
                }

                return null; // Retorna null se nenhum fornecedor for encontrado
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar fornecedor por nome fantasia", ex);
                return null; // Retorna null em caso de erro
            }
        }

        public Fornecedores BuscarFornecedorPorId(int id)
        {
            try
            {
                string query = "SELECT * FROM tb_fornecedores WHERE id_fornecedor = @Id";
                SqlParameter parametro = new SqlParameter("@Id", id);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateFornecedorFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar fornecedor por ID", ex);
                return null;
            }
        }

        public List<Fornecedores> ListarFornecedores(string status)
        {
            try
            {
                string sql = "SELECT * FROM tb_fornecedores";
                List<SqlParameter> parametros = new List<SqlParameter>();

                // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " WHERE status_fornecedor = @Status";
                    parametros.Add(new SqlParameter("@Status", status));
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
                return CreateFornecedoresListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao listar fornecedores", ex);
                return new List<Fornecedores>();
            }
        }

        public List<Fornecedores> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_fornecedores
                         WHERE (nome_fantasia LIKE @Filtro OR razao_social LIKE @Filtro OR rg LIKE @Filtro OR 
                                cnpj LIKE @Filtro OR email LIKE @Filtro  OR insc_estadual LIKE @Filtro  OR insc_municipal LIKE @Filtro) 
                                AND status_fornecedor = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Fornecedores> listaFornecedores = new List<Fornecedores>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaFornecedores.Add(CreateFornecedorFromDataRow(row));
                }

                return listaFornecedores;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar cidade", ex);
                return new List<Fornecedores>();
            }
        }

        private Fornecedores CreateFornecedorFromDataRow(DataRow row)
        {
            CondicaoPagamentoController aCTLCond = new CondicaoPagamentoController();
            var condicao = aCTLCond.BuscarCondicaoPagamentoPorId(Convert.ToInt32(row["id_condicao_pagamento"]));
            return new Fornecedores
            {
                ID = Convert.ToInt32(row["id_fornecedor"]),
                StatusFornecedor = row["status_fornecedor"].ToString(),
                NomeFantasia = row["nome_fantasia"].ToString(),
                RazaoSocial = row["razao_social"].ToString(),
                DataFundacao = Convert.ToDateTime(row["data_fundacao"]),
                InscricaoMunicipal = row["insc_municipal"].ToString(),
                InscricaoEstadual = row["insc_estadual"].ToString(),
                CNPJ = row["cnpj"].ToString(),
                RG = row["rg"].ToString(),
                Email = row["email"].ToString(),
                Telefone = row["telefone"].ToString(),
                Celular = row["celular"].ToString(),
                CEP = row["cep"].ToString(),
                Endereco = row["endereco"].ToString(),
                Numero = Convert.ToInt32(row["numero"]),
                Complemento = row["complemento"].ToString(),
                Bairro = row["bairro"].ToString(),
                Cidade = aCTLCidades.BuscarCidadePorId(Convert.ToInt32(row["id_cidade"])), // Supondo que você tenha um método para buscar a cidade pelo ID
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
                CondicaoPagamento = condicao,
                TipoFornecedor = row["tipo_fornecedor"].ToString(),
            };
        }

        private List<Fornecedores> CreateFornecedoresListFromDataTable(DataTable dataTable)
        {
            List<Fornecedores> fornecedores = new List<Fornecedores>();
            // Para cada linha no DataTable, crie um objeto Fornecedores e adicione à lista de fornecedores
            foreach (DataRow row in dataTable.Rows)
            {
                fornecedores.Add(CreateFornecedorFromDataRow(row));
            }
            return fornecedores;
        }


        public Fornecedores BuscarFornecedorPorCNPJouRG(string documento)
        {
            try
            {
                string query = "SELECT * FROM tb_fornecedores WHERE cnpj = @Documento OR rg = @Documento";
                SqlParameter parametro = new SqlParameter("@Documento", documento);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateFornecedorFromDataRow(row);
                }

                return null; // Retorna null se não encontrar o fornecedor
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar fornecedor por documento", ex);
                return null;
            }
        }
        public Fornecedores BuscarFornRGCpf(string documento)
        {
            try
            {
                string query = "SELECT * FROM tb_fornecedores WHERE cnpj = @Documento OR rg = @Documento";
                SqlParameter parametro = new SqlParameter("@Documento", documento);
                DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateFornecedorFromDataRow(row);
                }

                return null; // Retorna null se não encontrar o fornecedor
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                operacao.HandleException("Erro ao buscar fornecedor por documento", ex);
                return null;
            }
        }
    }
}