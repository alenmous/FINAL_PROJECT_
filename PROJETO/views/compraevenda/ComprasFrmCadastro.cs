using PROJETO.controller;
using PROJETO.controller.compraevenda;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.models.compraevenda;
using PROJETO.Models;
using PROJETO.views.consultas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.compraevenda
{
    public partial class ComprasFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        CondicaoPagamentoController condicaoPagamentoController;
        CondicaoPagamento aCondicao;
        ProdutosController produtoController;
        ComprasController compraController;
        FornecedoresController fornecedoresController;
        bool permiteExclusao;
        private bool AutorizadoSalvar = false;
        Compra aCompra;
        ItemCompra oItemCompra;

        Fornecedores oFornecedor;

        public ComprasFrmCadastro()
        {
            InitializeComponent();
            Operacao.DisableCopyPaste(this);
            Instanciar();

        }
        private void DataGrid()
        {
            Dgv.RowHeadersVisible = false;
            Dgv.AutoGenerateColumns = false;
            Dgv.Columns.Clear();

            // Adiciona a coluna de exclusão como DataGridViewImageColumn
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.Name = "DeleteColumn";
            deleteColumn.HeaderText = "Excluir";
            deleteColumn.Width = 80; // Largura da coluna
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Ajusta o layout da imagem
            Dgv.Columns.Add(deleteColumn);

            // Adiciona as outras colunas do DataGridView
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_produto", HeaderText = "ID", DataPropertyName = "id_produto", Width = 60 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "produto", HeaderText = "Produto", DataPropertyName = "produto", Width = 400 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "und", HeaderText = "UND", DataPropertyName = "und", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "qtd_entrada", HeaderText = "QTD Entrada", DataPropertyName = "qtd_entrada", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "custo_atual", HeaderText = "Custo Atual", DataPropertyName = "custo_atual", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Custo_Sugerido", HeaderText = "Preço Compra", DataPropertyName = "Custo_Sugerido", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "desconto", HeaderText = "Desconto", DataPropertyName = "desconto", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "percentual_compra", HeaderText = "% Compra", DataPropertyName = "percentual_compra", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "preco_total", HeaderText = "Preço Total", DataPropertyName = "preco_total", Width = 125 });
            Dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "media_ponderada", HeaderText = "Média Ponderada", DataPropertyName = "media_ponderada", Width = 125 });

            // Ajusta a altura das linhas para acomodar as imagens
            Dgv.RowTemplate.Height = 40; // Altura das linhas em pixels

            // Calcula as proporções das coluna
            Dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv.MultiSelect = false;
        }
        private void Instanciar()
        {
            aCompra = new Compra();
            oItemCompra = new ItemCompra();
            produtoController = new ProdutosController();
            compraController = new ComprasController();
            fornecedoresController = new FornecedoresController();
            aCondicao = new CondicaoPagamento();
            condicaoPagamentoController = new CondicaoPagamentoController();
            oFornecedor = new Fornecedores();
            permiteExclusao = true; // armazena a permissão do datagrid de produtos.
            DataGrid();
        }
        protected override void LimparCampos()
        {
            dtChegada.Value = DateTime.Now;
            dtEmissao.Value = DateTime.Now;
            txtCodProduto.Clear();
            txtUND.Clear();
            txtQtd.Clear();
            txtCusto.Clear();
            txtDesconto.Clear();
            txtTotalItens.Clear();
            txtFrete.Text = "0";
            txtSeguro.Text = "0";
            txtOutras.Text = "0";
            txtProduto.Clear();
        }
        protected virtual bool VerificarCamposVazios()
        {
            List<string> camposFaltantes = new List<string>();

            // Verifica se a Data de Chegada está vazia ou no futuro
            if (dtChegada.Value == DateTime.MinValue || dtChegada.Value.Date > DateTime.Now.Date)
            {
                camposFaltantes.Add("Data de Chegada (não pode ser no futuro)");
            }

            // Verifica se a Data de Emissão está vazia ou no futuro
            if (dtEmissao.Value == DateTime.MinValue || dtEmissao.Value.Date > DateTime.Now.Date)
            {
                camposFaltantes.Add("Data de Emissão (não pode ser no futuro)");
            }

            // Verifica se o Código do Produto está vazio
            if (string.IsNullOrWhiteSpace(txtCodProduto.Text))
            {
                camposFaltantes.Add("Código do Produto");
            }

            // Verifica se a Unidade de Medida está vazia
            if (string.IsNullOrWhiteSpace(txtUND.Text))
            {
                camposFaltantes.Add("Unidade de Medida");
            }

            // Verifica se a Quantidade está vazia
            if (string.IsNullOrWhiteSpace(txtQtd.Text))
            {
                camposFaltantes.Add("Quantidade");
            }

            // Verifica se o Custo está vazio
            if (string.IsNullOrWhiteSpace(txtCusto.Text))
            {
                camposFaltantes.Add("Custo");
            }

            // Verifica se o Desconto está vazio
            if (string.IsNullOrWhiteSpace(txtDesconto.Text))
            {
                camposFaltantes.Add("Desconto");
            }

            // Verifica se o Total de Itens está vazio
            if (string.IsNullOrWhiteSpace(txtTotalItens.Text))
            {
                camposFaltantes.Add("Total de Itens");
            }

            // Exibe uma mensagem de erro se houver campos faltantes
            if (camposFaltantes.Count > 0)
            {
                string camposFaltantesStr = string.Join(", ", camposFaltantes);
                MessageBox.Show("Os seguintes campos são obrigatórios e não foram preenchidos corretamente: " + camposFaltantesStr, "Campos em Falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void VerificarNota()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo2.Text))
                LimparFornecedor();
            else if (int.TryParse(txtCodigo2.Text, out int cod) && cod > 0)
            {


                oFornecedor = fornecedoresController.BuscarFornecedorPorId(cod);

                if (oFornecedor == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparFornecedor();
                }
                else if (oFornecedor.StatusFornecedor == "I")
                {
                    MessageBox.Show("O Fornecedor associado a este código está inativo.");
                    LimparFornecedor();
                }
                else
                {
                    txtFornecedor.Text = oFornecedor.NomeFantasia;

                    int nNFC = (int)txtNumNFC.Value;
                    int nModelo = (int)txtModeloNFC.Value;
                    int nSerie = (int)txtSerieNFC.Value;
                    int codForn = Convert.ToInt32(txtCodigo2.Text);
                    VerificarEExecutarAcao(nNFC, nModelo, nSerie, codForn);

                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparFornecedor();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void VerificarEExecutarAcao(int nNFC, int nModelo, int nSerie, int codForn)
        {
            var compraExiste = compraController.VerificarSeCompraExiste(nNFC, nModelo, nSerie, codForn);

            if (compraExiste)
            {
                MessageBox.Show("Nota já cadastrada");
                txtCodigo2.Clear();
                txtFornecedor.Clear();
            }
            else
            {
                aCondicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId(oFornecedor.CondicaoPagamento.ID);
                txtCodigo2.Enabled = false;
                pnlNota.Enabled = false;// Painel de nota fica inativo 
                gbDatas.Enabled = true; // Habilita o painel de datas
            }
        }
        private void LimparFornecedor()
        {
            txtFornecedor.Clear();
            txtCodigo2.Text = "";
        }
        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar")
                Salvar();
            else if (btnSalvar.Text == "Cancelar")
            {
                CancelarCompra();
            }
            else if (btnSalvar.Text == "Emitir")
            {
                //
            }
        }
        protected virtual void CancelarCompra()
        {
            string mensagem = "Tem certeza que deseja cancelar a Compra?";

            DialogResult resultado = MessageBox.Show(mensagem, $"Confirmação de Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    aCompra.NumNFC = Convert.ToInt32(txtNumNFC.Value);
                    aCompra.SerieNFC = Convert.ToInt32(txtSerieNFC.Value);
                    aCompra.ModeloNFC = Convert.ToInt32(txtModeloNFC.Value);
                    aCompra.Fornecedor.ID = Convert.ToInt32(txtCodigo2.Text);
                    aCompra.StatusCompra = "CANCELADA";
                    aCompra.DataCancelamento = DateTime.Now;

                    compraController.CancelarCompra(aCompra);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao Cancelar compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private bool VerificaData()
        {
            // Supondo que dtChegada e dtEmissao são DateTimePickers
            DateTime dataEmissao = dtEmissao.Value.Date;
            DateTime dataChegada = dtChegada.Value.Date;
            DateTime dataAtual = DateTime.Now.Date;

            // Verificar se a data de emissão não é futura
            if (dataEmissao > dataAtual)
            {
                MessageBox.Show("A data de emissão de compra não pode ser no futuro. Apenas data de hoje ou anterior é permitida.",
                    "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar se a data de chegada não é futura
            if (dataChegada > dataAtual)
            {
                MessageBox.Show("A data de chegada não pode ser uma data futura.",
                    "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar se a data de chegada é maior ou igual à data de emissão
            if (dataChegada < dataEmissao)
            {
                MessageBox.Show("A data de chegada deve ser maior ou igual à data de emissão. Não é possível que o produto chegue antes da emissão da nota.",
                    "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected override void Salvar()
        {
            if (VerificaData())
            {
                if (lvParcelas.Items.Count == 0)
                {
                    MessageBox.Show("Nenhuma parcela adicionada. Não é possível salvar a compra.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (AutorizadoSalvar)
                {
                    if (Dgv.Rows.Count > 0)
                    {
                        CultureInfo cultura = CultureInfo.InvariantCulture;
                        txtFrete_Leave(txtFrete, EventArgs.Empty);
                        ComprasController compraController = new ComprasController();
                        List<ContasPagar> listaContasPagar = new List<ContasPagar>();
                        Compra Obj = new Compra();
                        Obj.Fornecedor = new Fornecedores();
                        Obj.Condicao = new CondicaoPagamento();
                        Obj.Fornecedor.ID = Convert.ToInt32(txtCodigo2.Text);
                        Obj.Condicao.ID = int.Parse(txtCodCondicao.Text);
                        Obj.NumNFC = int.Parse(txtNumNFC.Text);
                        Obj.ModeloNFC = int.Parse(txtModeloNFC.Text);
                        Obj.SerieNFC = int.Parse(txtSerieNFC.Text);
                        Obj.ValorTotal = decimal.Parse(txtTotalNota.Text, cultura);
                        Obj.ValorFrete = string.IsNullOrEmpty(txtFrete.Text) ? 0 : decimal.Parse(txtFrete.Text, cultura);
                        Obj.ValorSeguro = string.IsNullOrEmpty(txtSeguro.Text) ? 0 : decimal.Parse(txtSeguro.Text, cultura);
                        Obj.ValorOutrasDespesas = string.IsNullOrEmpty(txtOutras.Text) ? 0 : decimal.Parse(txtOutras.Text, cultura);
                        Obj.DataChegada = DateTime.Parse(dtChegada.Text);
                        Obj.DataEmissao = DateTime.Parse(dtEmissao.Text);
                        Obj.DataCriacao = DateTime.Now;
                        Obj.StatusCompra = "ATIVO";
                        Obj.ItensCompra = ItensListView(Obj.NumNFC, Obj.ModeloNFC, Obj.SerieNFC, Obj.Fornecedor.ID);

                        // Criar as contas a pagar baseadas nas parcelas
                        foreach (ListViewItem item in lvParcelas.Items)
                        {
                            ContasPagar aContaPagar = new ContasPagar();
                            aContaPagar.NumNFC = Obj.NumNFC;
                            aContaPagar.ModeloNFC = Obj.ModeloNFC;
                            aContaPagar.SerieNFC = Obj.SerieNFC;
                            aContaPagar.NumParcela = Convert.ToInt32(item.SubItems[0].Text);
                            aContaPagar.Fornecedor.ID = Obj.Fornecedor.ID;
                            aContaPagar.Condicao.ID = Obj.Condicao.ID;
                            aContaPagar.Valor = Convert.ToDecimal(item.SubItems[5].Text);
                            aContaPagar.Situacao = "A PAGAR";
                            aContaPagar.DataCriacao = DateTime.Now;
                            aContaPagar.DataVencimento = dtEmissao.Value.AddDays(Convert.ToInt32(item.SubItems[1].Text));
                            aContaPagar.DataUltAlteracao = DateTime.Now;
                            aContaPagar.FormaPagamento.ID = Convert.ToInt32(item.SubItems[2].Text);
                            aContaPagar.Taxa = aCondicao.Taxa;
                            aContaPagar.Desconto = aCondicao.Desconto;
                            aContaPagar.Multa = aCondicao.Multa;
                            //DataBaixa não é necessário atribuir valor, pois a conta ainda não foi paga.
                            listaContasPagar.Add(aContaPagar);
                        }

                        Obj.ContasPagar = listaContasPagar;

                        // Chamar o método AdicionarCompra no controlador CTLCompras
                        bool result = compraController.AdicionarCompra(Obj);

                        if (!result)
                        {
                            MessageBox.Show("Erro ao salvar a compra.");
                        }
                        else
                        {
                            MessageBox.Show("Compra salva com sucesso!");
                        }
                        this.Close();
                    }
                    return;
                }
            }

        }

        public List<ItemCompra> ItensListView(int Num_nfc, int Modelo_nfc, int Serie_nfc, int Id_fornecedor)
        {
            var vLista = new List<ItemCompra>();
            foreach (DataGridViewRow vLinha in Dgv.Rows)
            {
                ItemCompra ItensCompra = new ItemCompra();
                ItensCompra.NumNFC = Num_nfc;
                ItensCompra.ModeloNFC = Modelo_nfc;
                ItensCompra.SerieNFC = Serie_nfc;
                ItensCompra.Fornecedor.ID = Id_fornecedor;
                ItensCompra.Produto = produtoController.BuscarProdutoPorId(Convert.ToInt32(vLinha.Cells["id_produto"].Value));
                ItensCompra.QtdProduto = Convert.ToInt32(vLinha.Cells["qtd_entrada"].Value);
                ItensCompra.PrecoCusto = Convert.ToDecimal(vLinha.Cells["custo_sugerido"].Value);
                ItensCompra.Desconto = Convert.ToDecimal(vLinha.Cells["desconto"].Value);
                ItensCompra.PercentualCompra = Convert.ToDecimal(vLinha.Cells["percentual_compra"].Value);
                ItensCompra.MediaPonderada = Convert.ToDecimal(vLinha.Cells["media_ponderada"].Value);
                ItensCompra.DataCriacao = DateTime.Now;
                vLista.Add(ItensCompra);
            }
            return vLista;
        }


        public virtual void Popular(Compra aCompra)
        {
            permiteExclusao = false;
            // Formata os valores de preço para exibição correta
            CultureInfo cultura = CultureInfo.InvariantCulture;
            txtNumNFC.Value = aCompra.NumNFC;
            txtModeloNFC.Value = aCompra.ModeloNFC;
            txtSerieNFC.Value = aCompra.SerieNFC;
            txtCodigo2.Text = aCompra.Fornecedor.ID.ToString();
            txtFornecedor.Text = aCompra.Fornecedor.NomeFantasia;
            dtChegada.Value = aCompra.DataChegada;
            dtEmissao.Value = aCompra.DataEmissao;
            txtCodCondicao.Text = aCompra.Condicao.ID.ToString();
            txtCondicao.Text = aCompra.Condicao.Condicao;
            txtFrete.Text = aCompra.ValorFrete.ToString("0.##", cultura);
            txtSeguro.Text = aCompra.ValorSeguro.ToString("0.##", cultura);
            txtOutras.Text = aCompra.ValorOutrasDespesas.ToString("0.##", cultura);
            txtTotalNota.Text = aCompra.ValorTotal.ToString("0.##", cultura);

            int codigo = Convert.ToInt32(txtNumNFC.Value);
            int modelo = Convert.ToInt32(txtModeloNFC.Value);
            int serie = Convert.ToInt32(txtSerieNFC.Value);
            int fornecedor = Convert.ToInt32(txtCodigo2.Text);

            ItensCompraController itensCompraController = new ItensCompraController();
            List<ItemCompra> Itemcompra = itensCompraController.BuscarItemCompraPorChave2(codigo, modelo, serie, fornecedor);

            PopularItens(Itemcompra);
            CarregaLV(); // popula a condição de pagamento.
        }
        public void PopularItens(List<ItemCompra> lista)
        {

            if (lista == null || Dgv == null)
                return;

            Dgv.Rows.Clear();

            Image iconeLixeira = Properties.Resources.Lixeira_x32 ?? new Bitmap(16, 16); // fallback se estiver nulo

            foreach (ItemCompra item in lista)
            {
                if (item?.Produto != null)
                {
                    Dgv.Rows.Add(
                        iconeLixeira,
                        item.Produto.ID,
                        item.Produto.Nome,
                        item.Produto.UnidadeMedida,
                        item.QtdProduto,
                        item.Produto.PrecoCusto,
                        item.PrecoCusto,
                        item.Desconto,
                        item.PercentualCompra,
                        item.TotalCusto,
                        item.MediaPonderada
                    );
                }
            }
        }
        private void CarregaLV()
        {
            int cod = Convert.ToInt32(txtCodCondicao.Text);
            ParcelasController parcelaController = new ParcelasController();
            List<Parcela> dados = parcelaController.BuscarParcelasPorIDCondicao(cod);

            PreencherListView(dados);
            PreencherListViewPagamentos(dados);
        }
        private void PreencherListView(IEnumerable<Parcela> dados)
        {
            lvParcelas.Items.Clear();

            // Calcula o custo total com os adicionais uma vez para uso em todas as parcelas
            decimal custoTotalComAdicionais = CalcularCustoTotalComAdicionais();

            foreach (var parcela in dados)
            {
                ListViewItem item = new ListViewItem(parcela.NumParcela.ToString());
                item.SubItems.Add(parcela.DiasTotais.ToString());
                item.SubItems.Add(parcela.Forma.ID.ToString());
                item.SubItems.Add(parcela.Forma.Forma);
                item.SubItems.Add(parcela.Porcentagem.ToString());

                // Calcula o valor da parcela com base na porcentagem e no custo total com adicionais
                decimal valorParcela = (parcela.Porcentagem / 100) * custoTotalComAdicionais;
                item.SubItems.Add(valorParcela.ToString("F2")); // Adiciona o valor da parcela na posição correta

                item.Tag = parcela;
                lvParcelas.Items.Add(item);
            }
        }
        private void PreencherListViewPagamentos(IEnumerable<Parcela> dados)
        {
            lvPagamentos.Items.Clear();

            // Cálculo base de custo total com adicionais
            decimal custoTotalComAdicionais = CalcularCustoTotalComAdicionais();

            foreach (var parcela in dados)
            {
                // Cria o item com a primeira coluna (Modelo)
                ListViewItem item = new ListViewItem(txtModeloNFC.Text); // Modelo

                // Demais colunas (na ordem solicitada)
                item.SubItems.Add(txtSerieNFC.Text);                     // Série
                item.SubItems.Add(txtNumNFC.Text);                       // Número (NFC)
                item.SubItems.Add(parcela.NumParcela.ToString());        // Número da parcela (ADICIONADO)
                item.SubItems.Add(txtCodigo2.Text);                      // ID Fornecedor
                item.SubItems.Add(txtFornecedor.Text);                   // Fornecedor
                item.SubItems.Add(parcela.Forma.Forma);                  // Forma de Pagamento
                item.SubItems.Add(dtEmissao.Text);                       // Emissão

                // Vencimento (emissão + dias da parcela)
                DateTime dataVencimento = dtEmissao.Value.AddDays(parcela.DiasTotais);
                item.SubItems.Add(dataVencimento.ToShortDateString());   // Vencimento

                // Valor da parcela (porcentagem sobre o total com adicionais)
                decimal valorParcela = (parcela.Porcentagem / 100m) * custoTotalComAdicionais;
                item.SubItems.Add(valorParcela.ToString("F2"));          // Valor

                // Campos de baixa/pagamento ainda vazios
                item.SubItems.Add("N/A");                                // Baixa
                item.SubItems.Add("N/A");                                // Pagamento

                // Juros / Multa / Desconto (obtidos da condição, se houver)
                item.SubItems.Add(aCondicao?.Taxa.ToString("F2") ?? "0,00");     // Juros
                item.SubItems.Add(aCondicao?.Multa.ToString("F2") ?? "0,00");    // Multa
                item.SubItems.Add(aCondicao?.Desconto.ToString("F2") ?? "0,00"); // Desconto

                // Situação inicial
                item.SubItems.Add("A PAGAR");                            // Situação

                // Guarda referência à parcela
                item.Tag = parcela;

                lvPagamentos.Items.Add(item);
            }
        }



        private decimal CalcularCustoTotalComAdicionais()
        {
            decimal custoItens = CustoTotal();

            decimal frete = string.IsNullOrEmpty(txtFrete.Text) ? 0 : decimal.Parse(txtFrete.Text, CultureInfo.InvariantCulture);
            decimal seguro = string.IsNullOrEmpty(txtSeguro.Text) ? 0 : decimal.Parse(txtSeguro.Text, CultureInfo.InvariantCulture);
            decimal outras = string.IsNullOrEmpty(txtOutras.Text) ? 0 : decimal.Parse(txtOutras.Text, CultureInfo.InvariantCulture);

            return custoItens + frete + seguro + outras;
        }


        private decimal CustoTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow vLinha in Dgv.Rows)
            {
                total += Convert.ToDecimal(vLinha.Cells["qtd_entrada"].Value) * Convert.ToDecimal(vLinha.Cells["custo_sugerido"].Value);
            }
            return total;
        }
        private void AtualizarTotalNota()
        {
            decimal custoItens = CustoTotal(); // Método para calcular o custo total dos itens da compra

            // Adicionar valores de frete, seguro e outras despesas
            decimal frete = string.IsNullOrEmpty(txtFrete.Text) ? 0 : decimal.Parse(txtFrete.Text, CultureInfo.InvariantCulture);
            decimal seguro = string.IsNullOrEmpty(txtSeguro.Text) ? 0 : decimal.Parse(txtSeguro.Text, CultureInfo.InvariantCulture);
            decimal outras = string.IsNullOrEmpty(txtOutras.Text) ? 0 : decimal.Parse(txtOutras.Text, CultureInfo.InvariantCulture);

            decimal totalNota = custoItens + frete + seguro + outras;

            // Atualizar o valor do txtTotalNota
            txtTotalNota.Text = totalNota.ToString("N2", CultureInfo.InvariantCulture);
        }
        public void AdicionarItens()
        {

            // 1. Validações Básicas e Análise de TextBoxes
            int idProdutoInt;
            if (!int.TryParse(txtCodProduto.Text, out idProdutoInt) || idProdutoInt <= 0)
            {
                MessageBox.Show("Código do Produto inválido. Deve ser um número inteiro positivo.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ProdutoJaAdicionado(idProdutoInt.ToString()))
            {
                MessageBox.Show("Este produto já foi adicionado na lista.", "Item Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Produto produtoDetalhes = produtoController.BuscarProdutoPorId(idProdutoInt);
            if (produtoDetalhes == null)
            {
                MessageBox.Show("Produto não encontrado para o ID informado.", "Erro de Busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LimparProdutos(); // Assumindo que isso limpa os campos relacionados ao produto se não for encontrado
                return;
            }

            int qtdEntrada;
            if (!int.TryParse(txtQtd.Text, out qtdEntrada) || qtdEntrada <= 0)
            {
                MessageBox.Show("Quantidade de Entrada inválida. Deve ser um número inteiro positivo.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Analisar Custo Sugerido: Substituir vírgula por ponto, depois analisar com InvariantCulture
            decimal custoSugerido;
            string custoSugeridoText = txtCusto.Text.Replace(',', '.');
            if (!decimal.TryParse(custoSugeridoText, NumberStyles.Any, CultureInfo.InvariantCulture, out custoSugerido) || custoSugerido < 0)
            {
                MessageBox.Show("Preço de Compra (Custo) inválido. Deve ser um número positivo ou zero. Verifique o formato numérico (use ponto '.' para decimais ou vírgula ',' que será convertida).", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Analisar Desconto Unitário: Substituir vírgula por ponto, depois analisar com InvariantCulture
            decimal descontoUnitario = 0;
            string descontoText = txtDesconto.Text.Replace(',', '.');
            if (!string.IsNullOrEmpty(descontoText))
            {
                if (!decimal.TryParse(descontoText, NumberStyles.Any, CultureInfo.InvariantCulture, out descontoUnitario))
                {
                    MessageBox.Show("Desconto Unitário inválido. Insira um número válido. Verifique o formato numérico (use ponto '.' para decimais ou vírgula ',' que será convertida).", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (descontoUnitario < 0) descontoUnitario = 0; // Garantir que o desconto não seja negativo

            // 2. Calcular 'Preco Total Do Item' para a nova linha
            decimal precoTotalDoItem = (custoSugerido - descontoUnitario) * qtdEntrada;
            if (precoTotalDoItem < 0) precoTotalDoItem = 0;

            // 3. Adicionar a linha ao DataGridView
            Dgv.Rows.Add(
                Properties.Resources.Lixeira_x32,    // 0: Excluir (Image)
                produtoDetalhes.ID,                  // 1: id_produto (int)
                produtoDetalhes.Nome,                // 2: produto (string)
                produtoDetalhes.QtdEstoque,          // 3: und (string) -> QTD EM ESTOQUE DO PRODUTO (do banco de dados)
                qtdEntrada,                          // 4: qtd_entrada (int)
                produtoDetalhes.PrecoCusto,          // 5: custo_atual (decimal)
                custoSugerido,                       // 6: Custo_Sugerido (decimal)
                descontoUnitario,                    // 7: desconto (decimal)
                0m,                                  // 8: percentual_compra (decimal, inicial)
                precoTotalDoItem,                    // 9: preco_total (decimal, cálculo inicial)
                0m                                   // 10: media_ponderada (decimal, inicial)
            );

            // 4. Acionar Recálculos para TODOS os itens no DGV
            PercentualItem(); // Calcula percentual_compra para todos
            NovoPrecoItens(); // Calcula media_ponderada para todos
        }
        private void LimparText()
        {
            txtCodProduto.Clear();
            txtProduto.Clear();
            txtUND.Clear();
            txtQtd.Clear();
            txtCusto.Clear();
            txtDesconto.Clear();
            txtTotalItens.Clear();
        }
        public void PercentualItem()
        {
            decimal totalQtdEntrada = 0;

            // Primeira passagem: Calcular a quantidade total de todas as linhas válidas
            foreach (DataGridViewRow vLinha in Dgv.Rows)
            {
                if (vLinha.IsNewRow) continue;

                if (vLinha.Cells["qtd_entrada"] != null && vLinha.Cells["qtd_entrada"].Value != null)
                {
                    if (decimal.TryParse(vLinha.Cells["qtd_entrada"].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentQtd))
                    {
                        totalQtdEntrada += currentQtd;
                    }
                }
            }

            // Segunda passagem: Calcular e definir a porcentagem para cada item
            foreach (DataGridViewRow vLinha in Dgv.Rows)
            {
                if (vLinha.IsNewRow) continue;

                if (vLinha.Cells["qtd_entrada"] != null && vLinha.Cells["percentual_compra"] != null)
                {
                    decimal currentQtd = 0;
                    if (vLinha.Cells["qtd_entrada"].Value != null && decimal.TryParse(vLinha.Cells["qtd_entrada"].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out currentQtd))
                    {
                        decimal calculatedPercentage = 0m;
                        if (totalQtdEntrada > 0)
                        {
                            calculatedPercentage = (currentQtd / totalQtdEntrada) * 100;
                            vLinha.Cells["percentual_compra"].Value = Math.Round(calculatedPercentage, 8);
                        }
                        else
                        {
                            vLinha.Cells["percentual_compra"].Value = 0m;
                        }
                    }
                    else
                    {
                        vLinha.Cells["percentual_compra"].Value = 0m;
                    }
                }
            }
        }
        private void NovoPrecoItens()
        {
            // Analisar Custos de Despesas Gerais - Substituir vírgula por ponto, depois analisar com InvariantCulture
            decimal frete = 0;
            string freteText = txtFrete.Text.Replace(',', '.');
            if (!string.IsNullOrEmpty(freteText))
                decimal.TryParse(freteText, NumberStyles.Any, CultureInfo.InvariantCulture, out frete);

            decimal seguro = 0;
            string seguroText = txtSeguro.Text.Replace(',', '.');
            if (!string.IsNullOrEmpty(seguroText))
                decimal.TryParse(seguroText, NumberStyles.Any, CultureInfo.InvariantCulture, out seguro);

            decimal outrosCustos = 0;
            string outrosCustosText = txtOutras.Text.Replace(',', '.');
            if (!string.IsNullOrEmpty(outrosCustosText))
                decimal.TryParse(outrosCustosText, NumberStyles.Any, CultureInfo.InvariantCulture, out outrosCustos);


            foreach (DataGridViewRow vLinha in Dgv.Rows)
            {
                if (vLinha.IsNewRow) continue;

                // Recuperar Valores da linha atual do DataGridView
                int productId;
                if (vLinha.Cells["id_produto"] == null || vLinha.Cells["id_produto"].Value == null || !int.TryParse(vLinha.Cells["id_produto"].Value.ToString(), out productId)) continue;

                Produto produtoDetalhes = produtoController.BuscarProdutoPorId(productId);
                if (produtoDetalhes == null)
                {
                    // Opcional: Lidar com o caso de produto não encontrado, talvez removendo a linha ou exibindo um erro.
                    continue;
                }

                decimal custoProdutoAtual = produtoDetalhes.PrecoCusto;
                if (custoProdutoAtual < 0) custoProdutoAtual = 0;

                decimal qtdEstoqueAtual = produtoDetalhes.QtdEstoque;
                if (qtdEstoqueAtual < 0) qtdEstoqueAtual = 0;


                decimal percentualCompra = 0;
                if (vLinha.Cells["percentual_compra"] != null && vLinha.Cells["percentual_compra"].Value != null)
                    decimal.TryParse(vLinha.Cells["percentual_compra"].Value.ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out percentualCompra);

                decimal initialUnitPurchasePrice = 0;
                if (vLinha.Cells["Custo_Sugerido"] != null && vLinha.Cells["Custo_Sugerido"].Value != null)
                    decimal.TryParse(vLinha.Cells["Custo_Sugerido"].Value.ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out initialUnitPurchasePrice);

                int qtdEntradaEstoque = 0;
                if (vLinha.Cells["qtd_entrada"] != null && vLinha.Cells["qtd_entrada"].Value != null)
                    int.TryParse(vLinha.Cells["qtd_entrada"].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out qtdEntradaEstoque);

                decimal descontoUnitario = 0;
                if (vLinha.Cells["desconto"] != null && vLinha.Cells["desconto"].Value != null)
                    decimal.TryParse(vLinha.Cells["desconto"].Value.ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out descontoUnitario);


                // Calcular para Média Ponderada
                decimal ratFrete = (percentualCompra / 100m) * frete;
                decimal ratSeguro = (percentualCompra / 100m) * seguro;
                decimal ratOutrosCustos = (percentualCompra / 100m) * outrosCustos;

                decimal finalEffectiveUnitCostForAverage = (initialUnitPurchasePrice + ratFrete + ratSeguro + ratOutrosCustos) - descontoUnitario;
                if (finalEffectiveUnitCostForAverage < 0) finalEffectiveUnitCostForAverage = 0;

                // Calcular Média Ponderada
                decimal mediaPond = 0;
                if (qtdEstoqueAtual + qtdEntradaEstoque > 0)
                {
                    mediaPond = ((qtdEstoqueAtual * custoProdutoAtual) + (qtdEntradaEstoque * finalEffectiveUnitCostForAverage)) / (qtdEstoqueAtual + qtdEntradaEstoque);
                }
                else
                {
                    mediaPond = finalEffectiveUnitCostForAverage;
                }

                // Atualizar Células do DataGridView
                vLinha.Cells["media_ponderada"].Value = Math.Round(mediaPond, 8);
            }
        }


        private bool ProdutoJaAdicionado(string idProduto)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells["id_produto"].Value != null && row.Cells["id_produto"].Value.ToString() == idProduto)
                {
                    return true;
                }
            }
            return false;
        }

        //  EVENTOS  DE CONTROLES  EVENTOS  DE CONTROLES EVENTOS  DE CONTROLES  EVENTOS  DE CONTROLES  EVENTOS  DE CONTROLES  EVENTOS  DE CONTROLES EVENTOS  DE CONTROLES  EVENTOS  DE CONTROLES   
        private void txtFrete_Leave(object sender, EventArgs e)
        {
            AtualizarTotalNota();
        }

        private void txtFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números, um ponto decimal e teclas de controle (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Permite apenas um ponto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Bloqueia qualquer modificação com Ctrl
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }
        }

        private void btnBuscarFornecedor_Click(object sender, EventArgs e)
        {
            using (FornecedoresFrmConsulta frm = new FornecedoresFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                txtCodigo2.Text = IdSelecionado.ToString();
                txtFornecedor.Text = NomeSelecionado;

                VerificarNota();
            }
        }

        private void txtCodigo2_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão      
        }

        private void txtCodigo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtCodigo2_Leave(object sender, EventArgs e)
        {
            VerificarNota();
        }

        private void dtEmissao_Leave(object sender, EventArgs e)
        {


        }

        private void txtNumNFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado é o ponto (.) ou a vírgula (,)
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Se for, cancela o evento de pressionar a tecla
                e.Handled = true;
            }
        }

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProduto.Text))
                LimparProdutos();
            else if (int.TryParse(txtCodProduto.Text, out int cod) && cod > 0)
            {
                Produto produto = produtoController.BuscarProdutoPorId(cod);

                if (produto == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparProdutos();
                }
                else
                {
                    txtProduto.Text = produto.Nome;
                    txtUND.Text = produto.QtdEstoque.ToString();

                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparProdutos();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void LimparProdutos()
        {
            txtProduto.Clear();
            txtCodProduto.Clear();
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            using (ProdutosFrmConsulta frm = new ProdutosFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                //  frm.fornecedor_selecionado = txtFornecedor.Text;
                frm.ShowDialog();
                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;
                string unidade = frm.Und;

                txtCodProduto.Text = IdSelecionado.ToString();
                txtProduto.Text = NomeSelecionado;
                txtUND.Text = unidade;
                txtCodProduto_Leave(txtCodProduto, EventArgs.Empty);

            }
        }

        private void txtCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números, um ponto decimal e teclas de controle (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Permite apenas um ponto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Bloqueia qualquer modificação com Ctrl
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }
        }

        private void txtQtd_Leave(object sender, EventArgs e)
        {
            try
            {
                CultureInfo cultura = CultureInfo.InvariantCulture; // Usar a cultura atual do sistema
                // Tenta converter os valores dos campos para os cálculos
                decimal qtd = string.IsNullOrWhiteSpace(txtQtd.Text) ? 0 : decimal.Parse(txtQtd.Text, cultura);
                decimal custo = string.IsNullOrWhiteSpace(txtCusto.Text) ? 0 : decimal.Parse(txtCusto.Text, cultura);
                decimal desconto = string.IsNullOrWhiteSpace(txtDesconto.Text) ? 0 : decimal.Parse(txtDesconto.Text, cultura);

                // Calcula o total
                decimal total = (qtd * custo) - (qtd * desconto);

                // Atualiza o campo txtTotal com o valor calculado
                txtTotalItens.Text = total.ToString("0.00");
            }
            catch (FormatException)
            {
                // Exibe uma mensagem de erro se a conversão falhar
                MessageBox.Show("Por favor, insira valores válidos.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposVazios())
            {
                AdicionarItens();
                LimparText();
                txtTotalNota.Text = Convert.ToString(CustoTotal());
                btnFinaliza.Enabled = true;
            }
        }

        // BOTÃO FINALIZAR E IR PARA CONDIÇÃO DE PAGAMENTO
        private void btnFinaliza_Click(object sender, EventArgs e)
        {
            if (btnFinaliza.Text == "FINALIZAR E  IR PARA CONDIÇÃO DE PAGAMENTO")
            {
                LimparProdutos();
                pnProdutos.Enabled = false;
                pnProdutos.Enabled = true;
                permiteExclusao = false;
                btnFinaliza.Text = "LIBERAR CADASTRO DE PRODUTOS";
                btnFinaliza.BackColor = Color.DarkRed;
                txtCodCondicao.Text = aCondicao.ID.ToString();
                txtCondicao.Text = aCondicao.Condicao;
                pnProdutos.Enabled = false;
                btnFinalizaCondicao.Enabled = true;
                pnCondicao.Enabled = true;
            }
            else
            {
                LimparProdutos();
                pnProdutos.Enabled = true;
                pnProdutos.Enabled = false;
                Dgv.ReadOnly = false;
                permiteExclusao = true;
                lvParcelas.Items.Clear();
                txtFrete.Text = "0";
                txtOutras.Text = "0";
                txtSeguro.Text = "0";
                btnFinaliza.Text = "FINALIZAR E  IR PARA CONDIÇÃO DE PAGAMENTO";
                btnFinaliza.BackColor = Color.SaddleBrown;
                pnProdutos.Enabled = true ;
                btnFinalizaCondicao.Enabled = false;
                pnCondicao.Enabled = false;
            }
        }



        private void LiberarFrete(bool valor)
        {
            txtFrete.Enabled = valor;
            txtSeguro.Enabled = valor;
            txtOutras.Enabled = valor;

        }
        private void LiberarCondicaoPagamento()
        {
            if (Dgv.Rows.Count > 0)
            {
                if (aCondicao != null)
                {
                    txtCodCondicao.Text = aCondicao.ID.ToString();
                    txtCondicao.Text = aCondicao.Condicao;
                    CarregaLV();
                }
            }
            else
            {
                txtCodCondicao.Text = "";
                txtCondicao.Text = "";
            }
        }

        private void txtCodCondicao_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCodCondicao.Text))
                LimparCondicao();
            else if (int.TryParse(txtCodCondicao.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, verifique o estado correspondente

                aCondicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId(cod);

                if (aCondicao == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparCondicao();
                }
                else
                {
                    txtCondicao.Text = aCondicao.Condicao;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparCondicao();
            }
            lvParcelas.Items.Clear();
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void LimparCondicao()
        {
            txtCondicao.Clear();
            txtCodCondicao.Clear();
        }

        private void btnBuscarCondicao_Click(object sender, EventArgs e)
        {
            using (CondicaoPagamentoFrmConsulta frm = new CondicaoPagamentoFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                txtCodCondicao.Text = IdSelecionado.ToString();
                txtCondicao.Text = NomeSelecionado;
                aCondicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId(IdSelecionado);
                lvParcelas.Items.Clear();
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (VerificaData())
            {
                pnProdutos.Enabled = true;
                Dgv.Enabled = true; // habilita o Datagrid de produtos.
                gbDatas.Enabled =false; // desabilita as datas.
                btnFinaliza.Enabled = true;
            }
            else
            {
                pnProdutos.Enabled = false;
                Dgv.Enabled = false; // desabilita o Datagrid de produtos.
                btnFinaliza.Enabled = false;
            }
        }


        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Dgv.Columns["DeleteColumn"].Index && e.RowIndex >= 0 && permiteExclusao)
            {
                // Confirmação de exclusão
                var resultado = MessageBox.Show("Você tem certeza que deseja excluir este item?",
                    "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    Dgv.Rows.RemoveAt(e.RowIndex);
                    PercentualItem();
                    NovoPrecoItens();
                    txtTotalNota.Text = Convert.ToString(CustoTotal());
                }
            }
        }

        private void btnFinalizaCondicao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodCondicao.Text) || string.IsNullOrEmpty(txtCondicao.Text))
            {
                MessageBox.Show("Nenhuma condição de pagamento encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnFinalizaCondicao.Text == "FINALIZAR E LANÇAR PAGAMENTO")
            {
                btnFinalizaCondicao.Text = "CANCELAR E LIBERAR CONDIÇÃO"; // muda o texto do botão
                LiberarFrete(false);
                AtualizarTotalNota();// chama para recalcular as parcelas 
                LiberarCondicaoPagamento();
                btnFinalizaCondicao.BackColor = Color.DarkRed;
                AutorizadoSalvar = true; // autoriza a operação do botão salvar.
                btnSalvar.Enabled = true; // libera o botão salvar.
                pnCondicao.Enabled = false;// Bloqueia o painel condição de pagamento.
                btnFinaliza.Enabled = false;// bloqueia o botão finalizar compra que se refere a cadastro de  produtos.
            }
            else 
            {
                LiberarFrete(true);
                AtualizarTotalNota();// chama para recalcular as parcelas 
                LiberarCondicaoPagamento(); // libera a condição de pagamento.
                txtFrete.Text = "0";
                txtOutras.Text = "0";
                txtSeguro.Text = "0";
                btnFinalizaCondicao.Text = "FINALIZAR E LANÇAR PAGAMENTO";
                btnFinalizaCondicao.BackColor = Color.SaddleBrown;
                btnFinalizaCondicao.Enabled = true;
                btnSalvar.Enabled = false;
                AutorizadoSalvar = false;
                pnCondicao.Enabled = true; // libera o painel condição de pagamento.
                btnFinaliza.Enabled = true; // libera o botão finalizar compra que se refere a cadastro de  produtos.
                lvParcelas.Items.Clear();
                lvPagamentos.Items.Clear();
            }
        }
    }
}
