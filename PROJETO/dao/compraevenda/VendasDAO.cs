using PROJETO.controller.compraevenda;
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

namespace PROJETO.dao.compraevenda
{
    public class VendasDAO
    {
        private Banco banco = new Banco();

        public bool AdicionarVenda(Venda venda)
        {
            bool status = false;
            using (SqlConnection connection = banco.Abrir())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Inserir a venda
                        string sql = "INSERT INTO tb_vendas (num_nfv, modelo_nfv, serie_nfv, id_cliente, id_condicao, valor_total, data_emissao, data_criacao, data_saida, valor_frete, valor_seguro, valor_outras_despesas) " +
                                     "VALUES (@NumNFv, @ModeloNFv, @SerieNFv, @IdCliente, @IdCondicao, @ValorTotal, @DataEmissao, @DataCriacao, @DataSaida, @Frete, @Seguro, @Outras)";
                        SqlParameter[] parametros =
                        {
                            new SqlParameter("@NumNFv", venda.NumNfv),
                            new SqlParameter("@ModeloNFv", venda.ModeloNfv),
                            new SqlParameter("@SerieNFv", venda.SerieNfv),
                            new SqlParameter("@IdCliente", venda.Cliente.ID),
                            new SqlParameter("@IdCondicao", venda.CondicaoPagamento.ID),
                            new SqlParameter("@ValorTotal", venda.ValorTotal),
                            new SqlParameter("@DataSaida", venda.DataSaida),
                            new SqlParameter("@DataCriacao", venda.DataCriacao),
                            new SqlParameter("@DataEmissao", venda.DataEmissao),
                            new SqlParameter("@Frete", venda.ValorFrete),
                            new SqlParameter("@Seguro", venda.ValorSeguro),
                            new SqlParameter("@Outras", venda.ValorOutrasDespesas)
                        };
                        banco.ExecutarComando(sql, parametros);

                        // Inserir os itens da venda e atualizar o estoque
                        foreach (ItemVenda itemVenda in venda.ItensVenda)
                        {
                            if (itemVenda != null)
                            {
                                // Adicionar item de venda
                                ItensVendaController itensVendaController = new ItensVendaController();
                                itemVenda.NumNfv = venda.NumNfv;
                                itemVenda.SerieNfv = venda.SerieNfv;
                                itemVenda.ModeloNfv = venda.ModeloNfv;
                                itemVenda.Cliente.ID = venda.Cliente.ID;
                                status = itensVendaController.AdicionarItemVenda(itemVenda);
                                if (!status)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Aconteceu um erro ao salvar os itens da venda.");
                                    return false;
                                }

                                // Atualizar estoque do produto se itemVenda.TipoItem == "P"
                                if (itemVenda.TipoItem == "P")
                                {
                                    ProdutosController CTLProduto = new ProdutosController();
                                    Produto produto = CTLProduto.BuscarProdutoPorId(itemVenda.IdItem);
                                    int estoqueantigo = produto.QtdEstoque;
                                    produto.ID = itemVenda.IdItem;
                                    produto.PrecoVenda = itemVenda.PrecoUnitario;
                                    produto.QtdEstoque = estoqueantigo - itemVenda.QtdItem;
                                    status = CTLProduto.AtualizarEstoque(produto);
                                    if (!status)
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Aconteceu um erro ao atualizar o estoque do produto.");
                                        return false;
                                    }
                                }

                            }
                        }

                        // Inserir as contas a pagar
                        ContasReceberController aCTLContasReceber = new ContasReceberController();
                        foreach (ContasReceber contaReceber in venda.ContasReceber)
                        {
                            var status2 = aCTLContasReceber.AdicionarContaReceber(contaReceber);
                            if (status2 != "OK")
                            {
                                transaction.Rollback();
                                MessageBox.Show("Aconteceu um erro ao salvar as contas a receber.");
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


        public List<Venda> BuscarListaVendasPorChave(int numNF, int ModeloNfv, int SerieNfv)
        {
            try
            {
                string sql = "SELECT * FROM tb_vendas WHERE num_nfv = @NumNFv AND modelo_nfv = @ModeloNfv AND serie_nfv = @SerieNfv";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFv", numNF),
                    new SqlParameter("@ModeloNfv", ModeloNfv),
                    new SqlParameter("@SerieNfv", SerieNfv),

                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                List<Venda> vendas = new List<Venda>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Venda venda = CreateVendaFromDataRow(row);
                    vendas.Add(venda);
                }

                return vendas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Venda>();
            }
        }

        public Venda BuscarVendaPorChave(int numNF, int ModeloNfv, int SerieNfv, int idCliente)
        {
            try
            {
                string sql = "SELECT * FROM tb_vendas WHERE num_nfv = @NumNfv AND modelo_nfv = @ModeloNfv AND serie_nfv = @SerieNfv AND id_cliente = @IdCliente";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNFv", numNF),
                    new SqlParameter("@ModeloNfv", ModeloNfv),
                    new SqlParameter("@SerieNfv", SerieNfv),
                    new SqlParameter("@IdCliente", idCliente)
                };
                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateVendaFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool ExisteVendaPorChave(int numNF, int ModeloNfv, int SerieNfv, int idCliente)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM tb_vendas WHERE num_nf = @NumNF AND modelo_nf = @ModeloNfv AND serie_nf = @SerieNfv AND id_cliente = @IdCliente";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@NumNF", numNF),
                    new SqlParameter("@ModeloNfv", ModeloNfv),
                    new SqlParameter("@SerieNfv", SerieNfv),
                    new SqlParameter("@IdCliente", idCliente)
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

        public bool CancelarVenda(Venda venda)
        {
            bool status = false;

            using (SqlConnection connection = banco.Abrir())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Obter os itens da venda
                        ItensVendaController itensVendaController = new ItensVendaController();
                        List<ItemVenda> itensVenda = itensVendaController.BuscarItensVendaPorChave2(venda.NumNfv, venda.ModeloNfv, venda.SerieNfv);

                        // Verificar se a venda possui itens
                        if (itensVenda == null || itensVenda.Count == 0)
                        {
                            MessageBox.Show("Nenhum item encontrado para esta venda. Cancelamento abortado.");
                            return false;
                        }

                        // Atualiza a data de cancelamento da venda
                        string sql = "UPDATE tb_vendas SET data_cancelamento = @DataCancelamento WHERE num_nfv = @NumNFv AND modelo_nfv = @ModeloNfv AND serie_nfv = @SerieNfv AND id_cliente = @IdCliente";
                        SqlParameter[] parametros =
                        {
                            new SqlParameter("@DataCancelamento", DateTime.Today),
                            new SqlParameter("@NumNFv", venda.NumNfv),
                            new SqlParameter("@ModeloNfv", venda.ModeloNfv),
                            new SqlParameter("@SerieNfv", venda.SerieNfv),
                            new SqlParameter("@IdCliente", venda.Cliente.ID)
                        };

                        banco.ExecutarComando(sql, parametros);

                        // Iterar sobre os itens da venda para ajustar o estoque
                        foreach (ItemVenda itemVenda in itensVenda)
                        {
                            if (itemVenda != null)
                            {
                                // Atualizar o estoque do produto
                                ProdutosController CTLProduto = new ProdutosController();
                                Produto produto = CTLProduto.BuscarProdutoPorId(itemVenda.IdItem);
                                int estoqueAntigo = produto.QtdEstoque;
                                produto.QtdEstoque = estoqueAntigo + itemVenda.QtdItem; // Devolver a quantidade vendida ao estoque
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
                        ContasReceberController contasReceberController = new ContasReceberController();
                        List<ContasReceber> contas = contasReceberController.VerificarListaContasAReceber(venda.NumNfv, venda.ModeloNfv, venda.SerieNfv, venda.Cliente.ID);
                        foreach (ContasReceber conta in contas)
                        {
                            conta.Situacao = "CANCELADA"; // Definir a nova situação da parcela
                            status = contasReceberController.CancelarParcela(conta); // Chamar o método para cancelar a parcela
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
        public List<Venda> ListarVendas(DateTime? dataInicio, DateTime? dataFim, bool? cancelada, string nomeCliente, string tipoData)
        {
            try
            {
                string sql = "SELECT * FROM tb_vendas WHERE 1 = 1";

                // Adiciona filtros de data, se fornecidos, com base no tipo de data selecionado
                if (!string.IsNullOrEmpty(tipoData))
                {
                    if (tipoData == "EMISSAO")
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

                // Adiciona filtro de venda cancelada, se fornecido
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

                // Adiciona filtro de nome do cliente, se fornecido e não vazio
                if (!string.IsNullOrEmpty(nomeCliente))
                {
                    sql += " AND id_cliente IN (SELECT id_cliente FROM tb_clientes WHERE nome LIKE @NomeCliente)";
                }

                SqlParameter[] parametros =
                {
                    new SqlParameter("@DataInicio", dataInicio),
                    new SqlParameter("@DataFim", dataFim),
                    new SqlParameter("@NomeCliente", "%" + nomeCliente + "%")
                };

                DataTable dataTable = banco.ExecutarConsulta(sql, parametros);
                return CreateVendasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Venda>();
            }
        }
        public List<Venda> ListarVendas(bool? statusCancelada)
        {
            try
            {
                string sql = "SELECT * FROM tb_vendas WHERE 1 = 1";

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
                return CreateVendasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Venda>();
            }
        }

        private Venda CreateVendaFromDataRow(DataRow row)
        {
            ClientesController aCTLClientes = new ClientesController();
            Clientes cliente = aCTLClientes.BuscarClientePorId(Convert.ToInt32(row["id_cliente"]));
            CondicaoPagamentoController aCTLCond = new CondicaoPagamentoController();
            CondicaoPagamento condicao = aCTLCond.BuscarCondicaoPagamentoPorId((Convert.ToInt32(row["id_condicao"])));

            return new Venda
            {
                NumNfv = Convert.ToInt32(row["num_nfv"]),
                ModeloNfv = Convert.ToInt32(row["modelo_nfv"]),
                SerieNfv = Convert.ToInt32(row["serie_nfv"]),
                Cliente = cliente,
                CondicaoPagamento = condicao,
                ValorTotal = Convert.ToDecimal(row["valor_total"]),
                ValorFrete = Convert.ToDecimal(row["valor_frete"]),
                ValorSeguro = Convert.ToDecimal(row["valor_seguro"]),
                ValorOutrasDespesas = Convert.ToDecimal(row["valor_outras_despesas"]),
                DataEmissao = Convert.ToDateTime(row["data_emissao"]),
                DataCancelamento = row["data_cancelamento"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["data_cancelamento"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataSaida = Convert.ToDateTime(row["data_saida"])
            };
        }

        private List<Venda> CreateVendasListFromDataTable(DataTable dataTable)
        {
            List<Venda> vendas = new List<Venda>();
            foreach (DataRow row in dataTable.Rows)
            {
                vendas.Add(CreateVendaFromDataRow(row));
            }
            return vendas;
        }
        public int BuscarNFe(string tipo)
        {
            try
            {
                string campo;
                switch (tipo)
                {
                    case "MODELO":
                        campo = "modelo_nfv";
                        break;
                    case "SERIE":
                        campo = "serie_nfv";
                        break;
                    case "NUMERO":
                    default:
                        campo = "num_nfv";
                        break;
                }

                string query = $"SELECT TOP 1 {campo} FROM tb_vendas ORDER BY data_criacao DESC";
                DataTable dataTable = banco.ExecutarConsulta(query, null);

                if (dataTable.Rows.Count > 0 && int.TryParse(dataTable.Rows[0][campo].ToString(), out int result))
                {
                    return result;
                }

                return 1; // Retorna 1 se não encontrar o valor ou não puder converter para int
            }
            catch (Exception ex)
            {
                // Trate exceções genéricas, se aplicável
                throw new Exception("Erro ao buscar NFe", ex);
            }
        }


    }
}