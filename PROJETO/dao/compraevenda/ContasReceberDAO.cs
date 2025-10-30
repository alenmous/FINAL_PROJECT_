using PROJETO.controller;
using PROJETO.data;
using PROJETO.models.bases;
using PROJETO.models.compraevenda;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.dao.compraevenda
{

    public class ContasReceberDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();

        public string AdicionarContaReceber(ContasReceber contaReceber)
        {
            try
            {
                string sql = "INSERT INTO tb_contas_receber (Taxa, Multa, Desconto, num_nfc, modelo_nfc, serie_nfc, num_parcela, id_cliente, id_condicao, valor, situacao, data_vencimento, data_criacao, data_ult_alteracao, id_forma, pagamento) " +
                             "VALUES (@Taxa, @Multa, @Desconto, @NumNFC, @ModeloNFC, @SerieNFC, @NumParcela, @IdCliente, @IdCondicao, @Valor, @Situacao, @DataVencimento, @DataCriacao, @DataUltAlteracao, @FormaPagamento, @Pagamento)";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", contaReceber.NumNFC),
                    new SqlParameter("@ModeloNFC", contaReceber.ModeloNFC),
                    new SqlParameter("@SerieNFC", contaReceber.SerieNFC),
                    new SqlParameter("@NumParcela", contaReceber.NumParcela),
                    new SqlParameter("@IdCliente", contaReceber.Cliente.ID),
                    new SqlParameter("@IdCondicao", contaReceber.Condicao.ID),
                    new SqlParameter("@Valor", contaReceber.Valor),
                    new SqlParameter("@Situacao", contaReceber.Situacao),
                    new SqlParameter("@DataVencimento", contaReceber.DataVencimento),
                    new SqlParameter("@DataCriacao", contaReceber.DataCriacao),
                    new SqlParameter("@DataUltAlteracao", contaReceber.DataUltAlteracao),
                    new SqlParameter("@FormaPagamento", contaReceber.FormaPagamento.ID),
                    new SqlParameter("@Pagamento", contaReceber.Pagamento),
                    new SqlParameter("@Taxa", contaReceber.Taxa),
                    new SqlParameter("@Multa",contaReceber.Multa),
                    new SqlParameter("@Desconto", contaReceber.Desconto)
                };

                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AtualizarContaReceber(ContasReceber contaReceber)
        {
            try
            {
                string sql = "UPDATE tb_contas_receber SET Taxa = @Taxa, Multa = @Multa, Desconto = @Desconto, " +
                                 "data_vencimento = @DataVencimento, data_ult_alteracao = @DataUltAlteracao " +
                                 "WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", contaReceber.NumNFC),
                    new SqlParameter("@ModeloNFC", contaReceber.ModeloNFC),
                    new SqlParameter("@SerieNFC", contaReceber.SerieNFC),
                    new SqlParameter("@NumParcela", contaReceber.NumParcela),
                    new SqlParameter("@DataVencimento", contaReceber.DataVencimento),
                    new SqlParameter("@DataUltAlteracao", contaReceber.DataUltAlteracao),
                    new SqlParameter("@Taxa", contaReceber.Taxa),
                    new SqlParameter("@Multa",contaReceber.Multa),
                    new SqlParameter("@Desconto", contaReceber.Desconto)
                };

                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<ContasReceber> ListarContasReceberComData(string status, DateTime dataInicio, DateTime dataFim, string tipoData)
        {
            List<ContasReceber> contasReceberList = new List<ContasReceber>();

            try
            {
                string sql = "SELECT * FROM tb_contas_receber";

                // Adiciona filtro de situação, se o status não for "TODOS"
                if (status != "TODOS")
                {
                    sql += " WHERE situacao = @Status";
                }

                // Adiciona filtros de data, se fornecidos, com base no tipo de data selecionado
                if (!string.IsNullOrEmpty(tipoData))
                {
                    if (status != "TODOS")
                    {
                        sql += " AND"; // Adiciona um "AND" para concatenar com o filtro de data
                    }
                    else
                    {
                        sql += " WHERE"; // Adiciona um "WHERE" para iniciar a cláusula de data
                    }

                    if (tipoData == "EMISSAO")
                    {
                        sql += " data_criacao >= @DataInicio AND data_criacao <= @DataFim";
                    }
                    else if (tipoData == "VENCIMENTO")
                    {
                        sql += " data_vencimento >= @DataInicio AND data_vencimento <= @DataFim";
                    }
                    else if (tipoData == "BAIXA")
                    {
                        sql += " data_baixa >= @DataInicio AND data_baixa <= @DataFim";
                    }
                }

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@DataInicio", dataInicio.Date), // Garante apenas a parte da data, sem a hora
                    new SqlParameter("@DataFim", dataFim.Date.AddDays(1).AddTicks(-1)) // Ajusta para o final do dia especificado
                };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasReceber contareceber = CreateContaReceberFromDataRow(row);
                    contasReceberList.Add(contareceber);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a receber", ex);
            }

            return contasReceberList;
        }
        public List<ContasReceber> ListarContasAReceberPorNumero(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            List<ContasReceber> contasReceberList = new List<ContasReceber>();

            try
            {
                string sql = "SELECT * FROM tb_contas_receber " +
                             "WHERE num_nfc = @NumNFc AND modelo_nfc = @ModeloNFc " +
                             "AND serie_nfc = @SerieNFc AND id_cliente = @NumCliente";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFc", modeloNFC),
                    new SqlParameter("@SerieNFc", serieNFC),
                    new SqlParameter("@NumCliente", numFornecedor)
                };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasReceber contaReceber = CreateContaReceberFromDataRow(row);
                    contasReceberList.Add(contaReceber);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a Receber por número", ex);
            }

            return contasReceberList;
        }
        public ContasReceber BuscarContaReceber(int numNFC, int modeloNFC, int serieNFC, int numParcela)
        {
            try
            {
                string sql = "SELECT * FROM tb_contas_receber WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC  AND num_parcela = @NumParcela";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@NumParcela", numParcela)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateContaReceberFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar conta a receber", ex);
                return null;
            }
        }
        public List<ContasReceber> BuscarContas(int numNFC, int modeloNFC, int serieNFC, int parcelaNFC)
        {
            try
            {
                string sql = "SELECT * FROM tb_contas_receber WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @num_parcela";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                     new SqlParameter("@num_parcela", parcelaNFC)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                List<ContasReceber> contas = new List<ContasReceber>();

                foreach (DataRow row in dataTable.Rows)
                {
                    contas.Add(CreateContaReceberFromDataRow(row));
                }

                return contas;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar contas a receber", ex);
                return new List<ContasReceber>();
            }
        }
        public List<ContasReceber> ListarContasReceber(string status)
        {
            List<ContasReceber> contasReceberList = new List<ContasReceber>();

            try
            {
                // Consulta SQL que se adapta ao status "TODOS"
                string sql;
                SqlParameter[] parametros;

                if (status == "TODOS")
                {
                    // Consulta para listar todas as contas a receber
                    sql = @"SELECT * FROM tb_contas_receber 
                    ORDER BY 
                        CASE WHEN situacao = 'PAGO' THEN 1 ELSE 0 END ASC, 
                        data_vencimento ASC";
                    parametros = new SqlParameter[] { };
                }
                else
                {
                    // Consulta para listar contas a receber com status específico
                    sql = @"SELECT * FROM tb_contas_receber
                    WHERE situacao = @Status 
                    ORDER BY 
                        CASE WHEN situacao = 'PAGO' THEN 1 ELSE 0 END ASC, 
                        data_vencimento ASC";
                    parametros = new SqlParameter[]
                    {
                new SqlParameter("@Status", status)
                    };
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasReceber contaReceber = CreateContaReceberFromDataRow(row);
                    contasReceberList.Add(contaReceber);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a receber", ex);
            }

            return contasReceberList;
        }
        private ContasReceber CreateContaReceberFromDataRow(DataRow row)
        {
            ClientesController clientesController = new ClientesController();
            CondicaoPagamentoController condicaoPagamentoController = new CondicaoPagamentoController();
            FormaPagamentoController formaPagamentoController = new FormaPagamentoController();

            Clientes cliente = clientesController.BuscarClientePorId(Convert.ToInt32(row["id_cliente"]));
            CondicaoPagamento condicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId(Convert.ToInt32(row["id_condicao"]));
            FormaPagamento forma = formaPagamentoController.BuscarFormaPagamentoPorId(Convert.ToInt32(row["id_forma"]));

            return new ContasReceber
            {
                NumNFC = Convert.ToInt32(row["num_nfc"]),
                ModeloNFC = Convert.ToInt32(row["modelo_nfc"]),
                SerieNFC = Convert.ToInt32(row["serie_nfc"]),
                NumParcela = Convert.ToInt32(row["num_parcela"]),
                Cliente = cliente,
                Condicao = condicao,
                Valor = Convert.ToDecimal(row["valor"]),
                Situacao = row["situacao"].ToString(),
                DataBaixa = row["data_baixa"] != DBNull.Value ? Convert.ToDateTime(row["data_baixa"]) : DateTime.MinValue,
                DataVencimento = Convert.ToDateTime(row["data_vencimento"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
                Pagamento = row["pagamento"] != DBNull.Value ? Convert.ToDecimal(row["pagamento"]) : 0.00m,
                FormaPagamento = forma,
                Taxa = Convert.ToDecimal(row["taxa"]),
                Multa = Convert.ToDecimal(row["multa"]),
                Desconto = Convert.ToDecimal(row["desconto"]),
            };
        }
        public bool CancelarParcela(ContasReceber contaReceber)
        {
            try
            {
                string sql = "UPDATE tb_contas_receber SET situacao = @Situacao " +
                             "WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@Situacao", contaReceber.Situacao),
                    new SqlParameter("@NumNFC", contaReceber.NumNFC),
                    new SqlParameter("@ModeloNFC", contaReceber.ModeloNFC),
                    new SqlParameter("@SerieNFC", contaReceber.SerieNFC),
                    new SqlParameter("@NumParcela", contaReceber.NumParcela)

                };

                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception)
            {
                // Logar o erro para investigação
                return false;
            }
        }

        public string Quitar(ContasReceber contaReceber)
        {
            try
            {
                using (SqlConnection connection = banco.Abrir())
                {
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "UPDATE tb_contas_receber SET  Taxa = @Taxa, Multa = @Multa, Desconto =@Desconto, id_cliente = @IdCliente, id_condicao = @IdCondicao, valor = @Valor, situacao = @Situacao, " +
                                         "data_baixa = @DataBaixa, data_vencimento = @DataVencimento, data_ult_alteracao = @DataUltAlteracao, pagamento = @Pagamento, id_forma = @FormaPagamento " +
                                         "WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela";

                            SqlParameter[] parametros =
                            {
                                new SqlParameter("@IdCliente", contaReceber.Cliente.ID),
                                new SqlParameter("@IdCondicao", contaReceber.Condicao.ID),
                                new SqlParameter("@Valor", contaReceber.Valor),
                                new SqlParameter("@Situacao", contaReceber.Situacao),
                                new SqlParameter("@DataBaixa", (object) contaReceber.DataBaixa ?? DBNull.Value),
                                new SqlParameter("@DataVencimento", contaReceber.DataVencimento),
                                new SqlParameter("@DataUltAlteracao", contaReceber.DataUltAlteracao),
                                new SqlParameter("@NumNFC", contaReceber.NumNFC),
                                new SqlParameter("@ModeloNFC", contaReceber.ModeloNFC),
                                new SqlParameter("@SerieNFC", contaReceber.SerieNFC),
                                new SqlParameter("@NumParcela", contaReceber.NumParcela),
                                new SqlParameter("@Pagamento", contaReceber.Pagamento),
                                new SqlParameter("@FormaPagamento", contaReceber.FormaPagamento.ID),
                                new SqlParameter("@Taxa", contaReceber.Taxa),
                                new SqlParameter("@Multa",contaReceber.Multa),
                                new SqlParameter("@Desconto", contaReceber.Desconto)
                            };

                            bool result = banco.ExecutarComando(sql, parametros);
                            if (result)
                            {
                                transaction.Commit();
                                return "OK";
                            }
                            else
                            {
                                transaction.Rollback();
                                return "NOT";
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
