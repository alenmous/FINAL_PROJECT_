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
using System.Windows.Forms;
using PROJETO.controller.compraevenda;

namespace PROJETO.dao.compraevenda
{
    public class ContasPagarDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();

        public string AdicionarContaPagar(ContasPagar contaPagar)
        {
            try
            {
                string sql = "INSERT INTO tb_contas_pagar (num_nfc, modelo_nfc, serie_nfc, num_parcela, id_fornecedor, id_condicao, valor, situacao,  data_vencimento, data_criacao, data_ult_alteracao,id_forma, Taxa, Multa, Desconto) " +
                             "VALUES (@NumNFC, @ModeloNFC, @SerieNFC, @NumParcela, @IdFornecedor, @IdCondicao, @Valor, @Situacao,  @DataVencimento, @DataCriacao, @DataUltAlteracao, @FormaPagamento, @Taxa, @Multa, @Desconto)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", contaPagar.NumNFC),
                    new SqlParameter("@ModeloNFC", contaPagar.ModeloNFC),
                    new SqlParameter("@SerieNFC", contaPagar.SerieNFC),
                    new SqlParameter("@NumParcela", contaPagar.NumParcela),
                    new SqlParameter("@IdFornecedor", contaPagar.Fornecedor.ID),
                    new SqlParameter("@IdCondicao", contaPagar.Condicao.ID),
                    new SqlParameter("@Valor", contaPagar.Valor),
                    new SqlParameter("@Situacao", contaPagar.Situacao),
                    new SqlParameter("@DataVencimento", contaPagar.DataVencimento),
                    new SqlParameter("@DataCriacao", contaPagar.DataCriacao),
                    new SqlParameter("@DataUltAlteracao", contaPagar.DataUltAlteracao),
                    new SqlParameter("@FormaPagamento", contaPagar.FormaPagamento.ID),
                    new SqlParameter("@Taxa", contaPagar.Taxa),
                    new SqlParameter("@Multa",contaPagar.Multa),
                    new SqlParameter("@Desconto", contaPagar.Desconto)

                };
                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AtualizarContaPagar(ContasPagar contaPagar)
        {
            try
            {
                string sql = "UPDATE tb_contas_pagar SET Taxa = @Taxa, Multa = @Multa, Desconto = @Desconto, " +
                             "data_vencimento = @DataVencimento, data_ult_alteracao = @DataUltAlteracao " +
                             "WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", contaPagar.NumNFC),
                    new SqlParameter("@ModeloNFC", contaPagar.ModeloNFC),
                    new SqlParameter("@SerieNFC", contaPagar.SerieNFC),
                    new SqlParameter("@NumParcela", contaPagar.NumParcela),
                    new SqlParameter("@DataVencimento", contaPagar.DataVencimento),
                    new SqlParameter("@DataUltAlteracao", contaPagar.DataUltAlteracao),
                    new SqlParameter("@Taxa", contaPagar.Taxa),
                    new SqlParameter("@Multa", contaPagar.Multa),
                    new SqlParameter("@Desconto", contaPagar.Desconto)
                 };

                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool CancelarParcela(ContasPagar contaPagar)
        {
            try
            {
                string sql = "UPDATE tb_contas_pagar SET situacao = @Situacao " +
                             "WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela AND id_fornecedor = @IdFornecedor";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@Situacao", contaPagar.Situacao),
                    new SqlParameter("@NumNFC", contaPagar.NumNFC),
                    new SqlParameter("@ModeloNFC", contaPagar.ModeloNFC),
                    new SqlParameter("@SerieNFC", contaPagar.SerieNFC),
                    new SqlParameter("@NumParcela", contaPagar.NumParcela),
                    new SqlParameter("@IdFornecedor", contaPagar.Fornecedor.ID)
                };

                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception ex)
            {
                // Idealmente, você deve logar o erro aqui para poder investigá-lo depois
                operacao.HandleException("Erro ao cancelar parcela", ex);
                return false;
            }
        }

        public string Quitar(ContasPagar contaPagar)
        {
            try
            {
                using (SqlConnection connection = banco.Abrir())
                {
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = "UPDATE tb_contas_pagar SET Taxa =@Taxa, Multa =@Multa, Desconto =@Desconto, id_forma =@FormaPagamento, id_fornecedor = @IdFornecedor, id_condicao = @IdCondicao, valor = @Valor, situacao = @Situacao, " +
                                         "data_baixa = @DataBaixa, data_vencimento = @DataVencimento, data_ult_alteracao = @DataUltAlteracao, Pagamento = @Pagamento  WHERE " +
                                         "num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela AND id_fornecedor = @IdFornecedor";
                            SqlParameter[] parametros =
                            {
                                new SqlParameter("@IdFornecedor", contaPagar.Fornecedor.ID),
                                new SqlParameter("@IdCondicao", contaPagar.Condicao.ID),
                                new SqlParameter("@Valor", contaPagar.Valor),
                                new SqlParameter("@Situacao", contaPagar.Situacao),
                                new SqlParameter("@DataBaixa", (object) contaPagar.DataBaixa ?? DBNull.Value),
                                new SqlParameter("@DataVencimento", contaPagar.DataVencimento),
                                new SqlParameter("@DataUltAlteracao", contaPagar.DataUltAlteracao),
                                new SqlParameter("@NumNFC", contaPagar.NumNFC),
                                new SqlParameter("@ModeloNFC", contaPagar.ModeloNFC),
                                new SqlParameter("@SerieNFC", contaPagar.SerieNFC),
                                new SqlParameter("@NumParcela", contaPagar.NumParcela),
                                new SqlParameter("@Pagamento", contaPagar.Pagamento),
                                new SqlParameter("@FormaPagamento", contaPagar.FormaPagamento.ID),
                                new SqlParameter("@Taxa", contaPagar.Taxa),
                                new SqlParameter("@Multa",contaPagar.Multa),
                                new SqlParameter("@Desconto", contaPagar.Desconto)
                                        };
                            var result = banco.ExecutarComando(sql, parametros);
                            if (result)
                            {
                                // Verifica se é a última parcela a ser paga
                                Compra aCompra = new Compra
                                {
                                    NumNFC = contaPagar.NumNFC,
                                    ModeloNFC = contaPagar.ModeloNFC,
                                    SerieNFC = contaPagar.SerieNFC,
                                    StatusCompra = "FINALIZADO",
                                    Fornecedor = new Fornecedores { ID = contaPagar.Fornecedor.ID }

                                };
                                ComprasController controller = new ComprasController();
                                string status = controller.BaixaCompra(aCompra);
                                if (status != "OK")
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Aconteceu um erro ao salvar as parcelas.");
                                    return "NOT";
                                }

                            }
                            else
                                transaction.Rollback();

                            transaction.Commit();
                            return "OK";

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



        public bool ExcluirContaPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor, int numParcela)
        {
            try
            {
                string sql = "DELETE FROM tb_contas_pagar WHERE num_nfc = @NumNFC AND id_fornecedor = @id_fornecedor AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND num_parcela = @NumParcela";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@NumParcela", numParcela),
                     new SqlParameter("@id_fornecedor", numFornecedor)
                };
                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao excluir conta a pagar", ex);
                return false;
            }
        }
        public List<ContasPagar> BuscarContasPorNomeFornecedor(string nomeFornecedor)
        {
            try
            {
                // Primeiro, precisamos buscar o ID do fornecedor com base no nome
                FornecedoresController fornecedoresController = new FornecedoresController();
                Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorNome(nomeFornecedor);

                if (fornecedor == null)
                {
                    // Se o fornecedor não existir, retornamos uma lista vazia
                    return new List<ContasPagar>();
                }

                int idFornecedor = fornecedor.ID;

                string sql = "SELECT * FROM tb_contas_pagar WHERE id_fornecedor = @IdFornecedor";
                SqlParameter[] parametros =
                {
            new SqlParameter("@IdFornecedor", idFornecedor)
        };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                List<ContasPagar> contasPagarList = new List<ContasPagar>();

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasPagar contaPagar = CreateContaPagarFromDataRow(row);
                    contasPagarList.Add(contaPagar);
                }

                return contasPagarList;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar contas a pagar por nome do fornecedor", ex);
                return new List<ContasPagar>();
            }
        }

        public ContasPagar BuscarContaPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor, int numParcela)
        {
            try
            {
                string sql = "SELECT * FROM tb_contas_pagar WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor= @id_fornecedor AND num_parcela = @NumParcela";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@NumParcela", numParcela),
                    new SqlParameter("@id_fornecedor", numFornecedor)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateContaPagarFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar conta a pagar", ex);
                return null;
            }
        }
        public List<ContasPagar> BuscarContas(int numNFC, int modeloNFC, int serieNFC, int numFornecedor, int parcelaNFC)
        {
            try
            {
                string sql = "SELECT * FROM tb_contas_pagar WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor= @id_fornecedor AND num_parcela = @num_parcela";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@id_fornecedor", numFornecedor),
                     new SqlParameter("@num_parcela", parcelaNFC)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                List<ContasPagar> contas = new List<ContasPagar>();

                foreach (DataRow row in dataTable.Rows)
                {
                    contas.Add(CreateContaPagarFromDataRow(row));
                }

                return contas;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar contas a pagar", ex);
                return new List<ContasPagar>();
            }
        }
        public bool VerificarExistenciaDeNota(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            try
            {
                // Consulta SQL para verificar se existe alguma nota com a situação "PAGO"
                string sql = @"
                    SELECT COUNT(*) AS Contagem
                    FROM tb_contas_pagar 
                    WHERE num_nfc = @NumNFC 
                        AND modelo_nfc = @ModeloNFC 
                        AND serie_nfc = @SerieNFC 
                        AND id_fornecedor = @id_fornecedor 
                        AND situacao = 'PAGO'";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@id_fornecedor", numFornecedor)
                };

                // Executa a consulta e obtém o resultado
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                // Verifica se encontrou algum registro
                if (dataTable.Rows.Count > 0)
                {
                    int contagem = Convert.ToInt32(dataTable.Rows[0]["Contagem"]);
                    return contagem > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar contas a pagar", ex);
                return false; // Retorna false em caso de erro
            }
        }



        public ContasPagar VerificarContasAPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            try
            {
                string sql = "SELECT * FROM tb_contas_pagar WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor= @id_fornecedor";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@id_fornecedor", numFornecedor)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateContaPagarFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar conta a pagar", ex);
                return null;
            }
        }
        private ContasPagar CreateContaPagarFromDataRow(DataRow row)
        {
            FornecedoresController fornecedoresController = new FornecedoresController();
            CondicaoPagamentoController condicaoController = new CondicaoPagamentoController();
            FormaPagamentoController formaController = new FormaPagamentoController();

            Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorId(Convert.ToInt32(row["id_fornecedor"]));
            CondicaoPagamento condicao = condicaoController.BuscarCondicaoPagamentoPorId(Convert.ToInt32(row["id_condicao"]));
            FormaPagamento forma = formaController.BuscarFormaPagamentoPorId(Convert.ToInt32(row["id_forma"]));

            return new ContasPagar
            {
                NumNFC = Convert.ToInt32(row["num_nfc"]),
                ModeloNFC = Convert.ToInt32(row["modelo_nfc"]),
                SerieNFC = Convert.ToInt32(row["serie_nfc"]),
                NumParcela = Convert.ToInt32(row["num_parcela"]),
                Fornecedor = fornecedor,
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
        public List<ContasPagar> ListarContasPagar(string status)
        {
            List<ContasPagar> contasPagarList = new List<ContasPagar>();

            try
            {
                // Consulta SQL que se adapta ao status "TODOS"
                string sql;
                SqlParameter[] parametros;

                if (status == "TODOS")
                {
                    // Consulta para listar todas as contas a pagar
                    sql = @"SELECT * FROM tb_contas_pagar 
                    ORDER BY 
                        CASE WHEN situacao = 'PAGO' THEN 1 ELSE 0 END ASC, 
                        data_vencimento ASC";
                    parametros = new SqlParameter[] { };
                }
                else
                {
                    // Consulta para listar contas a pagar com status específico
                    sql = @"SELECT * FROM tb_contas_pagar 
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
                    ContasPagar contaPagar = CreateContaPagarFromDataRow(row);
                    contasPagarList.Add(contaPagar);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a pagar", ex);
            }

            return contasPagarList;
        }



        public List<ContasPagar> ListarContasPagarComData(string status, DateTime dataInicio, DateTime dataFim, string tipoData)
        {
            List<ContasPagar> contasPagarList = new List<ContasPagar>();

            try
            {
                string sql = "SELECT * FROM tb_contas_pagar";

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
                    ContasPagar contaPagar = CreateContaPagarFromDataRow(row);
                    contasPagarList.Add(contaPagar);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a pagar", ex);
            }

            return contasPagarList;
        }


        public List<ContasPagar> ListarContasPagarComFiltro(string status, DateTime Data1, DateTime Data2)
        {
            List<ContasPagar> contasPagarList = new List<ContasPagar>();

            try
            {
                string sql = "SELECT * FROM tb_contas_pagar WHERE situacao = @Status";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Status", status)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasPagar contaPagar = CreateContaPagarFromDataRow(row);
                    contasPagarList.Add(contaPagar);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a pagar", ex);
            }

            return contasPagarList;
        }
        public List<ContasPagar> ListarTodasContasPagar()
        {
            List<ContasPagar> contasPagarList = new List<ContasPagar>();

            try
            {
                string sql = "SELECT * FROM tb_contas_pagar";
                DataTable dataTable = banco.ExecutarConsulta(sql, null);

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasPagar contaPagar = CreateContaPagarFromDataRow(row);
                    contasPagarList.Add(contaPagar);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar todas as contas a pagar", ex);
            }

            return contasPagarList;
        }
        public List<ContasPagar> ListarContasAPagarPorNumero(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            List<ContasPagar> contasPagarList = new List<ContasPagar>();

            try
            {
                string sql = "SELECT * FROM tb_contas_pagar " +
                             "WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC " +
                             "AND serie_nfc = @SerieNFC AND id_fornecedor = @NumFornecedor";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@NumFornecedor", numFornecedor)
                };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                foreach (DataRow row in dataTable.Rows)
                {
                    ContasPagar contaPagar = CreateContaPagarFromDataRow(row);
                    contasPagarList.Add(contaPagar);
                }
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar contas a pagar por número", ex);
            }

            return contasPagarList;
        }
        public List<ContasPagar> Pesquisar(string filtro, string status)
        {
            try
            {

                string query = @"
                SELECT c.*
                FROM tb_contas_pagar c
                INNER JOIN tb_fornecedores f ON c.id_fornecedor = f.id_fornecedor
                WHERE 
                    (f.razao_social LIKE @Filtro 
                    OR f.nome_fantasia LIKE @Filtro
                    OR f.rg LIKE @Filtro
                    OR f.cnpj LIKE @Filtro
                    OR f.email LIKE @Filtro
                    OR CONCAT(c.num_nfc, c.modelo_nfc, c.serie_nfc, c.id_fornecedor) = @FiltroExato)
                    AND (@Status = '' OR c.situacao = @Status)";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@FiltroExato", filtro),
                    new SqlParameter("@Status", status)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<ContasPagar> listaCompras = new List<ContasPagar>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaCompras.Add(CreateContaPagarFromDataRow(row));
                }

                return listaCompras;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar compra", ex);
                return new List<ContasPagar>();
            }
        }

    }
}
