using PROJETO.controller;
using PROJETO.data;
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
using PROJETO.models.bases;


namespace PROJETO.dao.compraevenda
{
    public class ComprasDAO
    {
        private Banco banco = new Banco();
        Operacao operacao = new Operacao();

        public bool AdicionarCompra(Compra compra)
        {
            bool status = false;
            using (SqlConnection connection = banco.Abrir())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Inserir a compra
                        string sqlCompra = "INSERT INTO tb_compras (status_compra, num_nfc, modelo_nfc, serie_nfc, id_fornecedor, id_condicao, valor_total, valor_frete, valor_seguro, valor_outras_despesas, data_chegada, data_emissao, data_criacao) " +
                                           "VALUES (@status_compra, @NumNFC, @ModeloNFC, @SerieNFC, @IdFornecedor, @IdCondicao, @ValorTotal, @ValorFrete, @ValorSeguro, @ValorOutrasDespesas, @DataChegada, @DataEmissao, @DataCriacao)";
                        SqlParameter[] parametrosCompra =
                        {
                            new SqlParameter("@NumNFC", compra.NumNFC),
                            new SqlParameter("@ModeloNFC", compra.ModeloNFC),
                            new SqlParameter("@SerieNFC", compra.SerieNFC),
                            new SqlParameter("@IdFornecedor", compra.Fornecedor.ID),
                            new SqlParameter("@IdCondicao", compra.Condicao.ID),
                            new SqlParameter("@ValorTotal", compra.ValorTotal),
                            new SqlParameter("@ValorFrete", compra.ValorFrete),
                            new SqlParameter("@ValorSeguro", compra.ValorSeguro),
                            new SqlParameter("@ValorOutrasDespesas", compra.ValorOutrasDespesas),
                            new SqlParameter("@DataChegada", compra.DataChegada),
                            new SqlParameter("@DataEmissao", compra.DataEmissao),
                            new SqlParameter("@DataCriacao", compra.DataCriacao),
                            new SqlParameter("@status_compra", compra.StatusCompra)
                        };
                        banco.ExecutarComando(sqlCompra, parametrosCompra);

                        // Inserir os itens da compra e atualizar o estoque
                        foreach (ItemCompra itemCompra in compra.ItensCompra)
                        {
                            if (itemCompra != null)
                            {
                                // Adicionar item de compra
                                ItensCompraController itensCompraController = new ItensCompraController();
                                itemCompra.NumNFC = compra.NumNFC;
                                itemCompra.SerieNFC = compra.SerieNFC;
                                itemCompra.ModeloNFC = compra.ModeloNFC;
                                itemCompra.Fornecedor.ID = compra.Fornecedor.ID;
                                status = itensCompraController.AdicionarItemCompra(itemCompra);
                                if (!status)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Aconteceu um erro ao salvar os itens da compra.");
                                    return false;
                                }

                                // Atualizar estoque do produto
                                ProdutosController CTLProduto = new ProdutosController();
                                ProdutosController ProdutosController = new ProdutosController();

                                // Buscar o produto do fornecedor para obter o ID do produto real
                                Produto prod = ProdutosController.BuscarProdutoPorId(itemCompra.Produto.ID);
                                int idProdutoReal = prod.ID;

                                // Buscar o produto real pelo ID correto
                                Produto produto = CTLProduto.BuscarProdutoPorId(idProdutoReal);
                                int estoqueantigo = produto?.QtdEstoque ?? 0;

                                produto.ID = idProdutoReal; // Atualiza o ID para o produto real
                                produto.PrecoCusto = itemCompra.MediaPonderada;
                                produto.QtdEstoque = estoqueantigo + itemCompra.QtdProduto;

                                status = CTLProduto.AtualizarEstoque(produto);
                                if (!status)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Aconteceu um erro ao atualizar o estoque do produto.");
                                    return false;
                                }

                            }
                        }

                        // Inserir as contas a pagar
                        ContasPagarController contasPagarController = new ContasPagarController();
                        foreach (ContasPagar contaPagar in compra.ContasPagar)
                        {
                            var status2 = contasPagarController.AdicionarContaPagar(contaPagar);
                            if (status2 != "OK")
                            {
                                transaction.Rollback();
                                MessageBox.Show("Aconteceu um erro ao salvar as contas a pagar.");
                                return false;
                            }
                        }

                        transaction.Commit();
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                    }
                }
            }
            return status;
        }
        public string BaixaCompra(Compra compra)
        {
            try
            {
                string sql = "UPDATE tb_compras SET status_compra = @Status WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                SqlParameter[] parametros =
                {
                     new SqlParameter("@Status", compra.StatusCompra),
                     new SqlParameter("@NumNFC", compra.NumNFC),
                     new SqlParameter("@ModeloNFC", compra.ModeloNFC),
                     new SqlParameter("@SerieNFC", compra.SerieNFC),
                     new SqlParameter("@IdFornecedor", compra.Fornecedor.ID),
                };
                banco.ExecutarComando(sql, parametros);

                // Se a execução chegou até aqui, significa que a operação foi bem-sucedida
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Compra> BuscarListaComprasPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            try
            {
                string sql = "SELECT * FROM tb_compras WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@IdFornecedor", idFornecedor)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                List<Compra> compras = new List<Compra>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Compra compra = CreateCompraFromDataRow(row);
                    compras.Add(compra);
                }

                return compras;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Compra>();
            }
        }
        public Compra BuscarCompraPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            try
            {
                string sql = "SELECT * FROM tb_compras WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@IdFornecedor", idFornecedor)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateCompraFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool ExisteCompraPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM tb_compras WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFC", numNFC),
                    new SqlParameter("@ModeloNFC", modeloNFC),
                    new SqlParameter("@SerieNFC", serieNFC),
                    new SqlParameter("@IdFornecedor", idFornecedor)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dataTable.Rows[0][0]);
                    return count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool CancelarCompra(Compra compra)
        {
            bool status = false;

            using (SqlConnection connection = banco.Abrir())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Obter os itens da compra
                        ItensCompraController itensCompraController = new ItensCompraController();
                        List<ItemCompra> itensCompra = itensCompraController.BuscarItemCompraPorChave2(compra.NumNFC, compra.ModeloNFC, compra.SerieNFC, compra.Fornecedor.ID);

                        // Verificar se a compra possui itens
                        if (itensCompra == null || itensCompra.Count == 0)
                        {
                            MessageBox.Show("Nenhum item encontrado para esta compra. Cancelamento abortado.");
                            return false;
                        }

                        // Atualiza a data de cancelamento da compra
                        string sql = "UPDATE tb_compras SET data_cancelamento = @DataCancelamento, status_compra =@Status WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                        SqlParameter[] parametros =
                        {
                            new SqlParameter("@DataCancelamento", DateTime.Now),
                            new SqlParameter("@NumNFC", compra.NumNFC),
                            new SqlParameter("@ModeloNFC", compra.ModeloNFC),
                            new SqlParameter("@SerieNFC", compra.SerieNFC),
                            new SqlParameter("@IdFornecedor", compra.Fornecedor.ID),
                            new SqlParameter("@Status", compra.StatusCompra)
                        };

                        banco.ExecutarComando(sql, parametros);

                        // Iterar sobre os itens da compra para ajustar o estoque
                        foreach (ItemCompra itemCompra in itensCompra)
                        {
                            if (itemCompra != null)
                            {
                                // Buscar o produto do fornecedor para obter o ID do produto real
                                ProdutosController ProdutosController = new ProdutosController();
                                Produto prod = ProdutosController.BuscarProdutoPorId(itemCompra.Produto.ID);
                                int idProdutoReal = prod.ID;

                                // Atualizar o estoque do produto real
                                ProdutosController CTLProduto = new ProdutosController();
                                Produto produto = CTLProduto.BuscarProdutoPorId(idProdutoReal);
                                int estoqueAntigo = produto?.QtdEstoque ?? 0;

                                produto.ID = idProdutoReal; // Atualiza o ID para o produto real
                                produto.QtdEstoque = estoqueAntigo - itemCompra.QtdProduto; // Ajusta o estoque corretamente

                                status = CTLProduto.AtualizarEstoque(produto);
                                if (!status)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Aconteceu um erro ao atualizar o estoque do produto.");
                                    return false;
                                }
                            }
                        }



                        // Atualizar as parcelas das contas a pagar para "CANCELADA"
                        ContasPagarController contasPagarController = new ContasPagarController();
                        List<ContasPagar> contas = contasPagarController.VerificarListaContasAPagar(compra.NumNFC, compra.ModeloNFC, compra.SerieNFC, compra.Fornecedor.ID);
                        foreach (ContasPagar conta in contas)
                        {
                            conta.Situacao = "CANCELADA"; // Definir a nova situação da parcela
                            status = contasPagarController.CancelarParcela(conta); // Chamar o método para cancelar a parcela
                            if (!status)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Erro ao cancelar a parcela.");
                                return false;
                            }
                        }

                        transaction.Commit();
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                    }
                }
            }

            return status;
        }



        public bool CancelarCompra2(Compra compra)
        {
            bool status = false;

            using (SqlConnection connection = banco.Abrir())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Atualiza a data de cancelamento da compra
                        string sql = "UPDATE tb_compras SET data_cancelamento = @DataCancelamento WHERE num_nfc = @NumNFC AND modelo_nfc = @ModeloNFC AND serie_nfc = @SerieNFC AND id_fornecedor = @IdFornecedor";
                        SqlParameter[] parametros =
                        {
                            new SqlParameter("@DataCancelamento", DateTime.Today),
                            new SqlParameter("@NumNFC", compra.NumNFC),
                            new SqlParameter("@ModeloNFC", compra.ModeloNFC),
                            new SqlParameter("@SerieNFC", compra.SerieNFC),
                            new SqlParameter("@IdFornecedor", compra.Fornecedor.ID)
                        };

                        banco.ExecutarComando(sql, parametros);
                        transaction.Commit();
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                    }
                }
            }

            return status;
        }
        public List<Compra> ListarCompras(DateTime? dataInicio, DateTime? dataFim, bool? cancelada, string nomeFornecedor, string tipoData)
        {
            try
            {
                string sql = "SELECT * FROM tb_compras WHERE 1 = 1";

                // Adiciona filtros de data, se fornecidos, com base no tipo de data selecionado
                if (!string.IsNullOrEmpty(tipoData))
                {
                    if (tipoData == "CHEGADA")
                    {
                        if (dataInicio != null && dataFim != null)
                        {
                            sql += " AND data_chegada >= @DataInicio AND data_chegada <= @DataFim";
                        }
                    }
                    else if (tipoData == "EMISSAO")
                    {
                        if (dataInicio != null && dataFim != null)
                        {
                            sql += " AND data_emissao >= @DataInicio AND data_emissao <= @DataFim";
                        }
                    }
                    else if (tipoData == "CANCELAMENTO")
                    {
                        if (dataInicio != null && dataFim != null)
                        {
                            sql += " AND data_cancelamento >= @DataInicio AND data_cancelamento <= @DataFim";
                        }
                    }
                }

                // Adiciona filtro de compra cancelada, se fornecido
                if (cancelada != null)
                {
                    if (cancelada == true)
                    {
                        sql += " AND data_cancelamento IS NOT NULL";
                    }
                    else
                    {
                        sql += " AND data_cancelamento IS NULL";
                    }
                }

                // Adiciona filtro de nome do fornecedor, se fornecido e não vazio
                if (!string.IsNullOrEmpty(nomeFornecedor))
                {
                    sql += " AND id_fornecedor IN (SELECT id_fornecedor FROM tb_fornecedores WHERE nome_fantasia LIKE @NomeFornecedor)";
                }

                SqlParameter[] parametros =
                {
                    new SqlParameter("@DataInicio", dataInicio),
                    new SqlParameter("@DataFim", dataFim),
                    new SqlParameter("@NomeFornecedor", "%" + nomeFornecedor + "%")
                };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);
                return CreateComprasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Compra>();
            }
        }



        public List<Compra> ListarCompras(bool? statusCancelada)
        {
            try
            {
                string sql = "SELECT * FROM tb_compras WHERE 1 = 1";

                // Adiciona filtro de status cancelada, se fornecido
                if (statusCancelada != null)
                {
                    if (statusCancelada == true)
                    {
                        sql += " AND data_cancelamento IS NOT NULL";
                    }
                    else
                    {
                        sql += " AND data_cancelamento IS NULL";
                    }
                }

                DataTable dataTable = banco.ExecutarConsulta(sql, null);
                return CreateComprasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Compra>();
            }
        }

        public List<Compra> ListarComprasPorFornecedor(int CodFornecedor)
        {
            try
            {
                string sql = "SELECT * FROM tb_compras WHERE id_fornecedor = @CodFornecedor AND status_compra <> 'FINALIZADO' AND data_cancelamento IS NULL";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@CodFornecedor", CodFornecedor)
                };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);
                return CreateComprasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar compras: " + ex.Message);
                return new List<Compra>();
            }
        }
        public List<Compra> Pesquisar(string filtro, string status)
        {
            try
            {
                // Convertendo 'A' para 'ATIVO' e 'I' para 'INATIVO'
                string statusConvertido = status.ToUpper() == "A" ? "ATIVO" :
                                          status.ToUpper() == "I" ? "CANCELADA" : status;

                string query = @"
                SELECT c.*
                FROM tb_compras c
                INNER JOIN tb_fornecedores f ON c.id_fornecedor = f.id_fornecedor
                WHERE 
                    (f.razao_social LIKE @Filtro 
                    OR f.nome_fantasia LIKE @Filtro
                    OR f.rg LIKE @Filtro
                    OR f.cnpj LIKE @Filtro
                    OR f.email LIKE @Filtro
                    OR CONCAT(c.num_nfc, c.modelo_nfc, c.serie_nfc, c.id_fornecedor) = @FiltroExato)
                    AND (@Status = '' OR c.status_compra = @Status)";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@FiltroExato", filtro),
                    new SqlParameter("@Status", statusConvertido)
                };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Compra> listaCompras = new List<Compra>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaCompras.Add(CreateCompraFromDataRow(row));
                }

                return listaCompras;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar compra", ex);
                return new List<Compra>();
            }
        }


        private Compra CreateCompraFromDataRow(DataRow row)
        {
            FornecedoresController fornecedoresController = new FornecedoresController();
            Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorId(Convert.ToInt32(row["id_fornecedor"]));
            CondicaoPagamentoController condicaoPagamentoController = new CondicaoPagamentoController();
            CondicaoPagamento condicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId((Convert.ToInt32(row["id_condicao"])));


            return new Compra
            {
                NumNFC = Convert.ToInt32(row["num_nfc"]),
                ModeloNFC = Convert.ToInt32(row["modelo_nfc"]),
                SerieNFC = Convert.ToInt32(row["serie_nfc"]),
                Fornecedor = fornecedor,
                Condicao = condicao,
                ValorTotal = Convert.ToDecimal(row["valor_total"]),
                ValorFrete = Convert.ToDecimal(row["valor_frete"]),
                ValorSeguro = Convert.ToDecimal(row["valor_seguro"]),
                ValorOutrasDespesas = Convert.ToDecimal(row["valor_outras_despesas"]),
                DataChegada = Convert.ToDateTime(row["data_chegada"]),
                DataEmissao = Convert.ToDateTime(row["data_emissao"]),
                DataCancelamento = row["data_cancelamento"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["data_cancelamento"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                StatusCompra = row["status_compra"].ToString(),
            };
        }

        private List<Compra> CreateComprasListFromDataTable(DataTable dataTable)
        {
            List<Compra> compras = new List<Compra>();
            foreach (DataRow row in dataTable.Rows)
            {
                compras.Add(CreateCompraFromDataRow(row));
            }
            return compras;
        }
    }
}
