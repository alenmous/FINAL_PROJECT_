using PROJETO.controller.compraevenda;
using PROJETO.controller;
using PROJETO.models.compraevenda;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROJETO.models.bases;
using System.Globalization;
using PROJETO.views.consultas;
using System.IO;
using System.Linq; // Adicionado para usar .ToList() e .Count

namespace PROJETO.views.compraevenda
{
    public partial class VendaFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {

        Clientes oCliente;
        Venda aVenda;
        ItemVenda oItemVenda;
        VendasController vendasController;
        ProdutosController produtosController;
        ClientesController clientesController;
        int estoqueItens = 0;
        string tipoProdServ = "P";
        int ID_CONDICAO = 0;
        int IdSelecionado = 0;
        string NomeSelecionado = "";
        decimal valorUnit = 0m;
        int NumNFe;
        int SerieNFe;
        int ModeloNFe;
        bool permiteExclusao = true;
        private bool AutorizadoSalvar = false;
        Dictionary<int, Image> imagensProdutos = new Dictionary<int, Image>();  // Definir um dicionário para armazenar as imagens dos produtos/serviços
        DateTime dtCriacao;
        DateTime dtEmissao;
        DateTime dtCancelamento;
        CondicaoPagamento aCondicao;
        CondicaoPagamentoController condicaoPagamentoController;

        public VendaFrmCadastro()
        {
            InitializeComponent();
            InicializarDataGridView();
            Operacao.DisableCopyPaste(this);
            aVenda = new Venda();
            oItemVenda = new ItemVenda();
            oCliente = new Clientes();
            produtosController = new ProdutosController();
            vendasController = new VendasController();
            clientesController = new ClientesController();
            condicaoPagamentoController = new CondicaoPagamentoController();
            aCondicao = new CondicaoPagamento();

        }
        public void BuscarNFE()
        {
            NumNFe = vendasController.BuscarNFE("NUMERO") + 1;
            ModeloNFe = vendasController.BuscarNFE("MODELO"); // vai ser 55
            SerieNFe = vendasController.BuscarNFE("SERIE"); // vai ser 1
        }
        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar")
                Salvar();
            else if (btnSalvar.Text == "Cancelar")
            {
                CancelarVenda();
            }
            else if (btnSalvar.Text == "Emitir")
            {
                //
            }
        }
        protected virtual void CancelarVenda()
        {

            string mensagem = "Tem certeza que deseja cancelar a Compra?";

            DialogResult resultado = MessageBox.Show(mensagem, $"Confirmação de Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    aVenda.NumNfv = NumNFe;
                    aVenda.SerieNfv = SerieNFe;
                    aVenda.ModeloNfv = ModeloNFe;
                    aVenda.Cliente.ID = Convert.ToInt32(txtCodCliente.Text);
                    vendasController.CancelarVenda(aVenda);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao Cancelar compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void InicializarDataGridView()
        {
            // Configurações iniciais do DataGridView
            DgItensVenda.AutoGenerateColumns = false;

            // Adiciona a coluna de exclusão como DataGridViewImageColumn
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.Name = "DeleteColumn";
            deleteColumn.HeaderText = "Excluir";
            deleteColumn.Width = 80; // Largura da coluna
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Ajusta o layout da imagem
            DgItensVenda.Columns.Add(deleteColumn);

            // Adiciona as outras colunas com os tamanhos especificados
            DataGridViewTextBoxColumn numeroItemColumn = new DataGridViewTextBoxColumn();
            numeroItemColumn.Name = "numero_item";
            numeroItemColumn.HeaderText = "Item";
            numeroItemColumn.Width = 50;
            DgItensVenda.Columns.Add(numeroItemColumn);

            DataGridViewTextBoxColumn codigoColumn = new DataGridViewTextBoxColumn();
            codigoColumn.Name = "codigo";
            codigoColumn.HeaderText = "Código";
            codigoColumn.Width = 60;
            DgItensVenda.Columns.Add(codigoColumn);

            DataGridViewTextBoxColumn descricaoColumn = new DataGridViewTextBoxColumn();
            descricaoColumn.Name = "descricao";
            descricaoColumn.HeaderText = "Descrição";
            descricaoColumn.Width = 250;
            DgItensVenda.Columns.Add(descricaoColumn);

            DataGridViewTextBoxColumn quantidadeColumn = new DataGridViewTextBoxColumn();
            quantidadeColumn.Name = "quantidade";
            quantidadeColumn.HeaderText = "QTD";
            quantidadeColumn.Width = 50;
            DgItensVenda.Columns.Add(quantidadeColumn);

            DataGridViewTextBoxColumn descontoColumn = new DataGridViewTextBoxColumn();
            descontoColumn.Name = "desconto";
            descontoColumn.HeaderText = "Desconto";
            descontoColumn.Width = 100; // Defina o tamanho adequado para a coluna de desconto
            DgItensVenda.Columns.Add(descontoColumn);

            DataGridViewTextBoxColumn valorUnitarioColumn = new DataGridViewTextBoxColumn();
            valorUnitarioColumn.Name = "valor_unitario";
            valorUnitarioColumn.HeaderText = "R$ Unit.";
            valorUnitarioColumn.Width = 130;
            DgItensVenda.Columns.Add(valorUnitarioColumn);

            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            subTotalColumn.Name = "sub_total";
            subTotalColumn.HeaderText = "Subtotal";
            subTotalColumn.Width = 130;
            DgItensVenda.Columns.Add(subTotalColumn);

            DataGridViewTextBoxColumn tipoColumn = new DataGridViewTextBoxColumn();
            tipoColumn.Name = "tipo";
            tipoColumn.HeaderText = "Tipo";
            tipoColumn.Width = 30;
            DgItensVenda.Columns.Add(tipoColumn);
        }
        protected override void LimparCampos()
        {
            txtCodCliente.Clear();
            txtCliente.Clear();
            txtCodProduto.Clear();
            txtCPFeCNPJ.Clear();
            txtProduto.Clear();
            txtQtd.Text = "1";
            txtUnitario.Clear();
            txtProdTotal.Clear();
            txtDesconto.Text = "0";
            pbFoto.Image = Properties.Resources.semimagem;
        }
        private void CarregaLV()
        {
            int cod = Convert.ToInt32(txtCodCondicao.Text);
            ParcelasController aCTLParcela = new ParcelasController();
            List<Parcela> dados = aCTLParcela.BuscarParcelasPorIDCondicao(cod); ;
            PreencherListView(dados);
        }

        // ####################################################################
        // MÉTODO PreencherListView CORRIGIDO
        // ####################################################################
        private void PreencherListView(IEnumerable<Parcela> dados)
        {
            lvParcelas.Items.Clear();

            // 1. USA O TOTAL JÁ EXIBIDO NA TELA. Esta é a "fonte da verdade".
            //    Isso garante que as parcelas SEMPRE baterão com o total da nota.
            decimal custoTotalComAdicionais = ParseDecimalText(txtTotalNota.Text);

            // 2. Converte para lista para saber o total e qual é a última
            var listaParcelas = dados.ToList();
            int totalDeParcelas = listaParcelas.Count;

            if (totalDeParcelas == 0) return; // Sai se não houver parcelas

            decimal totalCalculadoAteAgora = 0m;

            // 3. Itera por todas as parcelas
            for (int i = 0; i < totalDeParcelas; i++)
            {
                var parcela = listaParcelas[i];
                decimal valorParcela;

                // 4. Verifica se NÃO é a última parcela
                if (i < totalDeParcelas - 1)
                {
                    // Calcula a parcela pela porcentagem
                    decimal valorCalculado = (parcela.Porcentagem / 100) * custoTotalComAdicionais;

                    // Arredonda para 2 casas decimais (o valor que será exibido)
                    valorParcela = Math.Round(valorCalculado, 2, MidpointRounding.AwayFromZero);

                    // Soma ao total acumulado
                    totalCalculadoAteAgora += valorParcela;
                }
                else
                {
                    // 5. É A ÚLTIMA PARCELA
                    // O valor é a diferença, para garantir que a soma feche 100%
                    valorParcela = custoTotalComAdicionais - totalCalculadoAteAgora;
                }

                // 6. Adiciona o item no ListView
                ListViewItem item = new ListViewItem(parcela.NumParcela.ToString());
                item.SubItems.Add(parcela.DiasTotais.ToString());
                item.SubItems.Add(parcela.Forma.ID.ToString());
                item.SubItems.Add(parcela.Forma.Forma);
                item.SubItems.Add(parcela.Porcentagem.ToString()); // Mostra a porcentagem original
                item.SubItems.Add(valorParcela.ToString("F2"));   // Adiciona o valor calculado/corrigido

                item.Tag = parcela;
                lvParcelas.Items.Add(item);
            }
        }
        public virtual void Popular(Venda aVenda)
        {
            // Formata os valores de preço para exibição correta
            CultureInfo cultura = CultureInfo.InvariantCulture;
            NumNFe = aVenda.NumNfv;
            ModeloNFe = aVenda.ModeloNfv;
            SerieNFe = aVenda.SerieNfv;
            txtCodCliente.Text = aVenda.Cliente.ID.ToString();
            txtCliente.Text = aVenda.Cliente.Nome;
            dtCriacao = aVenda.DataCriacao;
            dtEmissao = aVenda.DataEmissao;
            txtFrete.Text = aVenda.ValorFrete.ToString("0.##", cultura);
            txtSeguro.Text = aVenda.ValorSeguro.ToString("0.##", cultura);
            txtOutras.Text = aVenda.ValorOutrasDespesas.ToString("0.##", cultura);
            txtTotalNota.Text = aVenda.ValorTotal.ToString("0.##", cultura);
            txtCodCondicao.Text = aVenda.CondicaoPagamento.ID.ToString();
            txtCondicao.Text = aVenda.CondicaoPagamento.Condicao;
            string documento = "";
            oCliente = aVenda.Cliente;
            if (oCliente.TipoCliente == "F")
                if (oCliente.CPF != null)
                    documento = oCliente.CPF.ToString();
                else
                    documento = oCliente.RG.ToString();
            else if (oCliente.TipoCliente == "J")
                documento = oCliente.CPF.ToString();


            txtCPFeCNPJ.Text = Operacao.FormatarDocumento(documento);

            int codigo = Convert.ToInt32(NumNFe);
            int modelo = Convert.ToInt32(ModeloNFe);
            int serie = Convert.ToInt32(SerieNFe);
            int cliente = Convert.ToInt32(txtCodCliente.Text);

            ItensVendaController aCTLItensVenda = new ItensVendaController();
            List<ItemVenda> ItemVenda = aCTLItensVenda.BuscarItensVendaPorChave2(codigo, modelo, serie);

            PopularItens(ItemVenda);
            CarregaLV();
        }
        public void PopularItens(List<ItemVenda> List)
        {
            if (List == null)
            {
                throw new ArgumentNullException(nameof(List), "A lista de itens não pode ser null.");
            }

            DgItensVenda.Rows.Clear();
            int itemNumber = DgItensVenda.Rows.Count + 1;
            foreach (ItemVenda Item in List)
            {
                DgItensVenda.Rows.Add(Properties.Resources.Lixeira_x32,
                itemNumber,
                Item.IdItem.ToString(),
                Item.Descricao.ToString(),
                Item.QtdItem.ToString(),
                Item.Desconto.ToString(),
                Item.PrecoUnitario.ToString("F2"),
                Item.TotalItem.ToString("F2"),
                Item.TipoItem.ToString());
            }
        }

        // ####################################################################
        // MÉTODO Salvar CORRIGIDO
        // ####################################################################
        protected override void Salvar()
        {
            if (AutorizadoSalvar)
            {
                if (DgItensVenda.Rows.Count > 0)
                {
                    if (VerificarCamposVazios())
                    {
                        Venda venda = new Venda();
                        venda.Cliente = new Clientes();
                        List<ContasReceber> listaContasReceber = new List<ContasReceber>();
                        venda.CondicaoPagamento = new CondicaoPagamento();
                        venda.Cliente.ID = Convert.ToInt32(txtCodCliente.Text);
                        venda.CondicaoPagamento.ID = oCliente.CondicaoPagamento.ID;
                        venda.NumNfv = NumNFe;
                        venda.ModeloNfv = ModeloNFe;
                        venda.SerieNfv = SerieNFe;

                        // CORREÇÃO: Usar ParseDecimalText para ler os valores da tela
                        venda.ValorTotal = ParseDecimalText(txtTotalNota.Text);
                        venda.ValorFrete = ParseDecimalText(txtFrete.Text);
                        venda.ValorSeguro = ParseDecimalText(txtSeguro.Text);
                        venda.ValorOutrasDespesas = ParseDecimalText(txtOutras.Text);

                        venda.DataCriacao = DateTime.Now;
                        venda.DataEmissao = DateTime.Now;
                        venda.DataSaida = DateTime.Now;
                        venda.ItensVenda = ItensListView(venda.NumNfv, venda.ModeloNfv, venda.SerieNfv, venda.Cliente.ID);


                        // Criar as contas a receber baseadas nas parcelas
                        foreach (ListViewItem item in lvParcelas.Items)
                        {
                            ContasReceber aContareceber = new ContasReceber();
                            aContareceber.NumNFC = venda.NumNfv;
                            aContareceber.ModeloNFC = venda.ModeloNfv;
                            aContareceber.SerieNFC = venda.SerieNfv;
                            aContareceber.NumParcela = Convert.ToInt32(item.SubItems[0].Text);
                            aContareceber.Cliente.ID = venda.Cliente.ID;
                            aContareceber.Condicao.ID = venda.CondicaoPagamento.ID;

                            // CORREÇÃO: Usar ParseDecimalText para ler o valor da parcela (subitem 5)
                            aContareceber.Valor = ParseDecimalText(item.SubItems[5].Text);

                            aContareceber.Situacao = "A RECEBER";
                            aContareceber.DataCriacao = DateTime.Now;
                            aContareceber.DataVencimento = DateTime.Now.AddDays(Convert.ToInt32(item.SubItems[1].Text));
                            aContareceber.DataUltAlteracao = DateTime.Now;
                            aContareceber.FormaPagamento.ID = Convert.ToInt32(item.SubItems[2].Text);
                            aContareceber.Taxa = aCondicao.Taxa;
                            aContareceber.Desconto = aCondicao.Desconto;
                            aContareceber.Multa = aCondicao.Multa;
                            //DataBaixa
                            listaContasReceber.Add(aContareceber);
                        }
                        venda.ContasReceber = listaContasReceber;

                        bool result = vendasController.AdicionarVenda(venda);

                        if (!result)
                        {
                            MessageBox.Show("Erro ao salvar a venda.");
                        }
                        else
                        {
                            MessageBox.Show("venda salva com sucesso!");
                        }
                        this.Close();
                    }

                }
                return;
            }
        }

        // ####################################################################
        // MÉTODO ItensListView CORRIGIDO
        // ####################################################################
        public List<ItemVenda> ItensListView(int Num_nfc, int Modelo_nfc, int Serie_nfc, int Id_cliente)
        {
            var vLista = new List<ItemVenda>();
            foreach (DataGridViewRow vLinha in DgItensVenda.Rows)
            {
                ItemVenda ItensVenda = new ItemVenda();
                ItensVenda.NumNfv = Num_nfc;
                ItensVenda.ModeloNfv = Modelo_nfc;
                ItensVenda.SerieNfv = Serie_nfc;
                ItensVenda.Cliente.ID = Id_cliente;
                ItensVenda.TipoItem = Convert.ToString(vLinha.Cells["tipo"].Value);
                ItensVenda.IdItem = Convert.ToInt32(vLinha.Cells["codigo"].Value);
                ItensVenda.QtdItem = Convert.ToInt32(vLinha.Cells["quantidade"].Value);

                // CORREÇÃO: Usar ParseDecimalText para garantir a cultura
                ItensVenda.PrecoUnitario = ParseDecimalText(vLinha.Cells["valor_unitario"].Value.ToString());
                ItensVenda.Desconto = ParseDecimalText(vLinha.Cells["desconto"].Value.ToString());

                // CORREÇÃO CRÍTICA: O TotalItem é o sub_total da LINHA, não o total da NOTA.
                ItensVenda.TotalItem = ParseDecimalText(vLinha.Cells["sub_total"].Value.ToString());

                ItensVenda.DataCriacao = DateTime.Now;
                vLista.Add(ItensVenda);
            }
            return vLista;
        }

        private bool VerificarCamposVazios()
        {
            List<string> camposFaltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(txtCodCliente.Text))
            {
                camposFaltantes.Add("Código do Cliente");
            }
            if (string.IsNullOrWhiteSpace(txtFrete.Text))
            {
                // Deixando o frete ser 0
                txtFrete.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txtOutras.Text))
            {
                // Deixando outras ser 0
                txtOutras.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txtSeguro.Text))
            {
                // Deixando seguro ser 0
                txtSeguro.Text = "0";
            }
            if (camposFaltantes.Count > 0)
            {
                string camposFaltantesStr = string.Join(", ", camposFaltantes);
                MessageBox.Show("Os seguintes campos são obrigatórios e não foram preenchidos: " + camposFaltantesStr, "Campos em Falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void BuscarClientePorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento)) // caso não tenha nada no txt.
            {
                // Abrir formulário de consulta de cliente se o documento estiver vazio
                using (ClientesFrmConsulta frm = new ClientesFrmConsulta())
                {
                    frm.btnSair.Text = "Selecionar";
                    frm.ShowDialog();

                    // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                    int IdSelecionado = frm.IdSelecionado;
                    txtCodCliente.Text = IdSelecionado.ToString();

                    oCliente = clientesController.BuscarClientePorId(IdSelecionado);
                    if (oCliente != null) // Encontrou o cliente
                    {
                        aCondicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId(oCliente.CondicaoPagamento.ID);
                        FuncoesCliente();
                    }
                    else
                    {
                        MessageBox.Show("Documento não encontrado.");
                    }
                }
            }
            else
            {
                oCliente = clientesController.BuscarClientePorDocumento2(documento);
                if (oCliente != null)
                {
                    FuncoesCliente();
                }
                else
                {
                    MessageBox.Show("Documento não encontrado.");
                }
            }
        }

        private void FuncoesCliente()
        {
            txtCodCliente.Text = oCliente.ID.ToString();
            txtCliente.Text = oCliente.Nome;
            pnVendas.Enabled = true;
            pnCliente.Enabled = false; // Bloquear o painel de cliente
            pnProd.Enabled = true;
            string documentoCliente = string.IsNullOrWhiteSpace(oCliente.CPF) ? oCliente.RG : oCliente.CPF;
            txtCPFeCNPJ.Text = Operacao.FormatarDocumento(documentoCliente);

        }

        // Método para atualizar os números dos itens após exclusão
        private void AtualizarNumerosItens()
        {
            for (int i = 0; i < DgItensVenda.Rows.Count; i++)
            {
                DgItensVenda.Rows[i].Cells["numero_item"].Value = i + 1;
            }
        }


        public void DesabilitarBotoes()
        {
            txtFrete.Enabled = false;
            txtSeguro.Enabled = false;
            txtOutras.Enabled = false;
            btnSalvar.Enabled = false;
        }

        private void CalculoDescontos()
        {
            if (!string.IsNullOrWhiteSpace(txtQtd.Text) && !string.IsNullOrWhiteSpace(txtUnitario.Text))
            {
                // Remover o símbolo de moeda 'R$' e converter o valor para decimal com normalização adequada
                decimal valorUnitario = ParseDecimalText(txtUnitario.Text);
                // Converter a quantidade para inteiro
                int quantidade;
                if (int.TryParse(txtQtd.Text, out quantidade))
                {
                    // Calcular o valor total do produto
                    decimal valorTotal = quantidade * valorUnitario;

                    // Aplicar desconto, se houver
                    decimal desconto = 0;
                    if (!string.IsNullOrWhiteSpace(txtDesconto.Text))
                    {
                        desconto = ParseDecimalText(txtDesconto.Text);
                        // Verificar se o desconto não deixa o valor total negativo
                        if (valorTotal - desconto >= 0)
                        {
                            valorTotal -= desconto;
                        }
                        else
                        {
                            MessageBox.Show("O desconto não pode resultar em um valor total negativo.", "Erro de Desconto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDesconto.Text = "0";
                            return;
                        }
                    }

                    // Exibir o valor unitário sem o símbolo de moeda
                    txtUnitario.Text = valorUnitario.ToString("0.00");

                    // Exibir o valor total
                    txtProdTotal.Text = valorTotal.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("Quantidade inválida.", "Erro de Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtd.Text = "1";
                    txtProdTotal.Text = "0.00";
                }
            }
            else
            {
                txtProdTotal.Text = "0.00";
            }
        }

        /// <summary>
        /// Converte texto de entrada de usuário (possivelmente contendo 'R$', '.' como milhares e ',' como decimais)
        /// para decimal de forma robusta. Aceita formatos como "1.234,56", "1234.56", "0,9", "0.9".
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private decimal ParseDecimalText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0m;

            string s = input.Replace("R$", "").Trim();
            bool hasDot = s.Contains(".");
            bool hasComma = s.Contains(",");

            if (hasDot && hasComma)
            {
                // formato típico BR: "1.234,56" -> remove pontos (milhar) e transforma vírgula em ponto
                s = s.Replace(".", "").Replace(",", ".");
            }
            else if (hasComma && !hasDot)
            {
                // "0,9" -> "0.9"
                s = s.Replace(",", ".");
            }
            else
            {
                // se só tem ponto (ex.: "0.9" ou "1234.56") mantém o ponto como separador decimal
                // se não tem separadores, mantém a string como está
            }

            decimal value;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                return value;

            // fallback: tenta com cultura atual
            if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                return value;

            return 0m;
        }

        // ####################################################################
        // MÉTODOS 'CalcularCustoTotalComAdicionais' e 'CustoTotal' REMOVIDOS
        // Eles eram a fonte do bug de R$ 0,10, pois não consideravam o desconto.
        // O método 'AtualizarTotalNota' já faz este trabalho corretamente.
        // ####################################################################

        private void BuscarProduto(int id)
        {
            Produto produto = produtosController.BuscarProdutoPorId(id);

            if (produto == null)
            {
                MessageBox.Show("Produto não encontrado para o código especificado.");
                limparItens();
            }
            else if (produto.Status == "I")
            {
                MessageBox.Show("O produto associado a este código está inativo.");
                limparItens();
            }
            else
            {
                txtProduto.Text = produto.Nome;
                estoqueItens = produto.QtdEstoque;
                valorUnit = produto.PrecoVenda;
                txtUnitario.Text = produto.PrecoVenda.ToString();

                // Verifica se há uma foto e a carrega
                if (produto.Foto != null && produto.Foto.Length > 0)
                {
                    pbFoto.BackgroundImage = null;
                    using (MemoryStream ms = new MemoryStream(produto.Foto))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }
            }

        }

        private void limparItens()
        {
            txtDesconto.Text = "0";
            txtCodProduto.Clear();
            txtProduto.Clear();
            txtQtd.Text = "1";
            txtProdTotal.Clear();
            txtUnitario.Clear();
            pbFoto.Image = Properties.Resources.semimagem;
        }

        // ####################################################################
        // MÉTODO AtualizarTotalNota CORRIGIDO
        // ####################################################################
        private void AtualizarTotalNota()
        {
            decimal totalNota = 0;

            foreach (DataGridViewRow row in DgItensVenda.Rows)
            {
                if (row.Cells["sub_total"].Value != null)
                {
                    // CORREÇÃO: Usar o ParseDecimalText para ler o sub_total da grid
                    // Isso evita erros de cultura (ex: "9,90" vs "9.90")
                    decimal subTotal = ParseDecimalText(row.Cells["sub_total"].Value.ToString());

                    // O ParseDecimalText retorna 0 se falhar, então podemos somar diretamente
                    totalNota += subTotal;
                }
            }

            decimal frete = 0;
            decimal seguro = 0;
            decimal outras = 0;

            // Isso já estava correto, usando o ParseDecimalText
            frete = ParseDecimalText(txtFrete.Text);
            seguro = ParseDecimalText(txtSeguro.Text);
            outras = ParseDecimalText(txtOutras.Text);


            decimal custoTotal = frete + seguro + outras + totalNota;

            // Atualiza o txtTotalNota. "F2" garante o formato "10,50" (na cultura pt-BR)
            txtTotalNota.Text = custoTotal.ToString("F2");
        }
        private void LiberarCondicaoPagamento()
        {
            if (DgItensVenda.Rows.Count > 0)
            {

                if (aCondicao != null)
                {
                    txtCodCondicao.Text = aCondicao.ID.ToString();
                    txtCondicao.Text = aCondicao.Condicao;
                    CarregaLV(); // Agora o CarregaLV() vai chamar o PreencherListView() correto
                }
            }
            else
            {
                gbCondicao.Enabled = false;
                txtCodCondicao.Text = "";
                txtCondicao.Text = "";
            }
        }
        private void LiberarFrete(bool valor)
        {
            txtFrete.Enabled = valor;
            txtOutras.Enabled = valor;
            txtSeguro.Enabled = valor;
        }

        /////////////////////////////////////////////////////////////////////////##############################################################################################

        private void txtCPFeCNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevenir o som de "ding" do sistema ao pressionar Enter
                e.SuppressKeyPress = true;
                // Chamar o método de busca
                BuscarClientePorDocumento(txtCPFeCNPJ.Text.Trim());
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientePorDocumento(txtCPFeCNPJ.Text.Trim());
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
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
            CalculoDescontos();
        }

        private void txtCodProduto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProduto.Text))
            {
                txtCodProduto.Clear();
            }
            else if (int.TryParse(txtCodProduto.Text, out int cod) && cod > 0)
            {
                BuscarProduto(cod);
                CalculoDescontos(); // Atualiza o cálculo quando o código do produto é preenchido corretamente
            }
            else
            {
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                txtCodProduto.Clear();
            }
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            txtProdTotal.Clear();


            using (ProdutosFrmConsulta frm = new ProdutosFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, acessa os valores do produto selecionado
                IdSelecionado = frm.IdSelecionado;
                NomeSelecionado = frm.NomeSelecionado;
                estoqueItens = Convert.ToInt32(frm.Und);

                txtCodProduto.Text = IdSelecionado.ToString();
                txtProduto.Text = NomeSelecionado;
                BuscarProduto(IdSelecionado);
                CalculoDescontos();
            }

        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
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
            } // Permite apenas números, um ponto decimal e teclas de controle (como Backspace)
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

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            CalculoDescontos();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCodProduto.Text))
            {
                MessageBox.Show("Por favor, insira o código do produto ou serviço.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQtd.Text) || !int.TryParse(txtQtd.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Por favor, insira uma quantidade válida.");
                return;
            }

            // Verifica valor mínimo do produto (mínimo R$ 0,01)
            decimal prodTotal = ParseDecimalText(txtProdTotal.Text);
            if (prodTotal < 0.01m)
            {
                MessageBox.Show("O valor do produto deve ser no mínimo R$ 0,01. Verifique quantidade, valor unitário e desconto.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = int.Parse(txtCodProduto.Text);
            string tipo = "P";
            // Verifica se o item já existe no DataGridView
            if (VerificarItemDuplicado(id, tipo))
            {
                MessageBox.Show("Item com o mesmo código e tipo já foi adicionado.");
                limparItens();
                return;
            }

            // Define o desconto como 0 se o campo estiver vazio, usando parser robusto
            decimal desconto = string.IsNullOrWhiteSpace(txtDesconto.Text) ? 0 : ParseDecimalText(txtDesconto.Text);
            decimal valorUnitario = valorUnit; // Valor unitário do item, ajuste conforme necessário

            if (tipo == "P")
            {
                // Verifica o estoque do produto
                if (quantidade > estoqueItens)
                {
                    MessageBox.Show($"Quantidade de Produtos excede o estoque disponível ({estoqueItens}).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            //decimal subtotalSemDesconto = valorUnitario * quantidade;
            // O subtotal COM desconto é o que está em txtProdTotal.Text
            decimal subtotalComDesconto = ParseDecimalText(txtProdTotal.Text);
            btnFinaliza.Enabled = true;
            // Adicionar o item ao DataGridView
            int itemNumber = DgItensVenda.Rows.Count + 1;
            DgItensVenda.Rows.Add(
                Properties.Resources.Lixeira_x32, // Imagem de lixeira
                itemNumber,
                id.ToString(),
                txtProduto.Text,
                quantidade,
                desconto.ToString("F2"), // Salva o desconto formatado
                valorUnitario.ToString("F2"),
                subtotalComDesconto.ToString("F2"), // Salva o subtotal formatado
                tipo

            );

            // Adicionar a imagem correspondente ao dicionário
            imagensProdutos[id] = pbFoto.Image; // Supondo que pbFoto contenha a imagem do produto

            // Atualiza o valor total da nota
            AtualizarTotalNota();

            // Limpar os campos após adicionar o item
            limparItens();
            valorUnit = 0;
            estoqueItens = 0;

        }

        private bool VerificarItemDuplicado(int id, string tipo)
        {
            foreach (DataGridViewRow row in DgItensVenda.Rows)
            {
                if (row.Cells["codigo"].Value != null && row.Cells["tipo"].Value != null)
                {
                    if (Convert.ToInt32(row.Cells["codigo"].Value) == id && row.Cells["tipo"].Value.ToString() == tipo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void txtCodCondicao_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão    
        }

        private void txtCodCondicao_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
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

        private void txtFrete_Leave(object sender, EventArgs e)
        {
            AtualizarTotalNota();
        }

        private void btnFinaliza_Click(object sender, EventArgs e)
        {
            if (btnFinaliza.Text == "FINALIZAR VENDA")
            {
                gbCondicao.Enabled = true;
                permiteExclusao = false;
                pnVendas.Enabled = false;
                btnFinaliza.Text = "LIBERAR PRODUTOS";
                txtCodCondicao.Text = aCondicao.ID.ToString();
                txtCondicao.Text = aCondicao.Condicao;
            }
            else
            {
                gbCondicao.Enabled = false;
                DgItensVenda.ReadOnly = false;
                pnVendas.Enabled = true;
                permiteExclusao = true;
                lvParcelas.Items.Clear();
                txtFrete.Clear();
                txtOutras.Clear();
                txtSeguro.Clear();
                btnFinaliza.Text = "FINALIZAR VENDA";

            }
            AtualizarTotalNota();
        }

        private void btnFinalizaCondicao_Click(object sender, EventArgs e)
        {
            if (btnFinalizaCondicao.Text == "FINALIZAR CONDIÇÃO")
            {
                LiberarFrete(false);
                btnFinalizaCondicao.Text = "LIBERAR CONDIÇÃO"; // muda o texto do botão
                btnFinalizaCondicao.Enabled = true; //mantem o botão aberto
                txtTotalNota.Enabled = true; // mantem a nota aberta.
                AtualizarTotalNota();// chama para recalcular as parcelas 
                LiberarCondicaoPagamento(); // <-- É AQUI QUE O CÁLCULO DAS PARCELAS ACONTECE
                AutorizadoSalvar = true;
                btnBuscarCondicao.Enabled = false;
                txtCodCondicao.Enabled = false;

            }
            else if (btnFinalizaCondicao.Text == "LIBERAR CONDIÇÃO")
            {
                LiberarFrete(true);
                btnFinalizaCondicao.Text = "FINALIZAR CONDIÇÃO";
                btnFinalizaCondicao.Enabled = true;
                AtualizarTotalNota();// chama para recalcular as parcelas 
                LiberarCondicaoPagamento();
                AutorizadoSalvar = false;
                btnBuscarCondicao.Enabled = true;
                txtCodCondicao.Enabled = true;
            }
        }

        private void DgItensVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text != "Consultar uma Venda")// desabilita o botão caso seja no form de consulta. não precisa excluir se vc está apenas consultando.
            {
                if (e.ColumnIndex == DgItensVenda.Columns["DeleteColumn"].Index && e.RowIndex >= 0 && permiteExclusao)
                {
                    // Exibe um MessageBox para confirmar a exclusão
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este item?", "Confirmar Exclusão",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verifica se o usuário confirmou a exclusão
                    if (result == DialogResult.Yes)
                    {
                        // Remove o item da DataGridView
                        DgItensVenda.Rows.RemoveAt(e.RowIndex);

                        // Atualiza o número do item após exclusão
                        AtualizarNumerosItens();

                        // Atualiza o total da nota após exclusão
                        AtualizarTotalNota();
                        if (DgItensVenda.Rows.Count == 0)
                        {
                            btnFinaliza.Enabled = false;
                        }
                    }
                }
            }
        }

        // Adicione handlers Leave para txtSeguro e txtOutras, assim como vc fez para txtFrete
        private void txtSeguro_Leave(object sender, EventArgs e)
        {
            AtualizarTotalNota();
        }

        private void txtOutras_Leave(object sender, EventArgs e)
        {
            AtualizarTotalNota();
        }

        // Adicione KeyPress para txtSeguro e txtOutras
        private void txtSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFrete_KeyPress(sender, e); // Reutiliza a mesma lógica de validação
        }

        private void txtOutras_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFrete_KeyPress(sender, e); // Reutiliza a mesma lógica de validação
        }

    }
}