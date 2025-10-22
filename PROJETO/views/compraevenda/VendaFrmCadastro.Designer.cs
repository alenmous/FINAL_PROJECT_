namespace PROJETO.views.compraevenda
{
    partial class VendaFrmCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DgItensVenda = new System.Windows.Forms.DataGridView();
            this.gbCondicao = new System.Windows.Forms.GroupBox();
            this.btnBuscarCondicao = new System.Windows.Forms.Button();
            this.txtFrete = new System.Windows.Forms.TextBox();
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.txtOutras = new System.Windows.Forms.TextBox();
            this.lbOutras = new System.Windows.Forms.Label();
            this.lbSeguro = new System.Windows.Forms.Label();
            this.lbFrete = new System.Windows.Forms.Label();
            this.lbCondicaoPg = new System.Windows.Forms.Label();
            this.txtCondicao = new System.Windows.Forms.TextBox();
            this.lbCodigoCondicao = new System.Windows.Forms.Label();
            this.txtCodCondicao = new System.Windows.Forms.TextBox();
            this.lvParcelas = new System.Windows.Forms.ListView();
            this.clParcelas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clDias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clIdForma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clForma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clPercentTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clPreco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFinaliza = new System.Windows.Forms.Button();
            this.btnFinalizaCondicao = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtTotalNota = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnVendas = new System.Windows.Forms.Panel();
            this.pnProd = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitario = new System.Windows.Forms.TextBox();
            this.txtProdTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnBuscarProduto = new System.Windows.Forms.Button();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.pnCliente = new System.Windows.Forms.Panel();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.clForn = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtCPFeCNPJ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgItensVenda)).BeginInit();
            this.gbCondicao.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnVendas.SuspendLayout();
            this.pnProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.pnCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(779, 612);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(927, 571);
            this.txtCodigo.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(950, 576);
            this.lblCodigo.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(887, 612);
            // 
            // DgItensVenda
            // 
            this.DgItensVenda.AllowUserToAddRows = false;
            this.DgItensVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgItensVenda.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DgItensVenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DgItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgItensVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgItensVenda.Location = new System.Drawing.Point(13, 10);
            this.DgItensVenda.Margin = new System.Windows.Forms.Padding(2);
            this.DgItensVenda.MultiSelect = false;
            this.DgItensVenda.Name = "DgItensVenda";
            this.DgItensVenda.ReadOnly = true;
            this.DgItensVenda.RowHeadersWidth = 51;
            this.DgItensVenda.RowTemplate.Height = 24;
            this.DgItensVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgItensVenda.Size = new System.Drawing.Size(703, 356);
            this.DgItensVenda.TabIndex = 1602;
            this.DgItensVenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgItensVenda_CellContentClick);
            // 
            // gbCondicao
            // 
            this.gbCondicao.Controls.Add(this.btnBuscarCondicao);
            this.gbCondicao.Controls.Add(this.txtFrete);
            this.gbCondicao.Controls.Add(this.txtSeguro);
            this.gbCondicao.Controls.Add(this.txtOutras);
            this.gbCondicao.Controls.Add(this.lbOutras);
            this.gbCondicao.Controls.Add(this.lbSeguro);
            this.gbCondicao.Controls.Add(this.lbFrete);
            this.gbCondicao.Controls.Add(this.lbCondicaoPg);
            this.gbCondicao.Controls.Add(this.txtCondicao);
            this.gbCondicao.Controls.Add(this.lbCodigoCondicao);
            this.gbCondicao.Controls.Add(this.txtCodCondicao);
            this.gbCondicao.Enabled = false;
            this.gbCondicao.Location = new System.Drawing.Point(12, 398);
            this.gbCondicao.Margin = new System.Windows.Forms.Padding(2);
            this.gbCondicao.Name = "gbCondicao";
            this.gbCondicao.Padding = new System.Windows.Forms.Padding(2);
            this.gbCondicao.Size = new System.Drawing.Size(722, 73);
            this.gbCondicao.TabIndex = 1605;
            this.gbCondicao.TabStop = false;
            // 
            // btnBuscarCondicao
            // 
            this.btnBuscarCondicao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarCondicao.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscarCondicao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCondicao.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCondicao.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCondicao.Location = new System.Drawing.Point(318, 41);
            this.btnBuscarCondicao.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCondicao.Name = "btnBuscarCondicao";
            this.btnBuscarCondicao.Size = new System.Drawing.Size(88, 24);
            this.btnBuscarCondicao.TabIndex = 804;
            this.btnBuscarCondicao.Text = "BUSCAR";
            this.btnBuscarCondicao.UseVisualStyleBackColor = false;
            this.btnBuscarCondicao.Click += new System.EventHandler(this.btnBuscarCondicao_Click);
            // 
            // txtFrete
            // 
            this.txtFrete.BackColor = System.Drawing.Color.White;
            this.txtFrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrete.Location = new System.Drawing.Point(418, 38);
            this.txtFrete.Margin = new System.Windows.Forms.Padding(2);
            this.txtFrete.MaxLength = 10;
            this.txtFrete.Name = "txtFrete";
            this.txtFrete.Size = new System.Drawing.Size(94, 27);
            this.txtFrete.TabIndex = 112;
            this.txtFrete.Text = "0";
            this.txtFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFrete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrete_KeyPress);
            this.txtFrete.Leave += new System.EventHandler(this.txtFrete_Leave);
            // 
            // txtSeguro
            // 
            this.txtSeguro.BackColor = System.Drawing.Color.White;
            this.txtSeguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeguro.Location = new System.Drawing.Point(516, 38);
            this.txtSeguro.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeguro.MaxLength = 10;
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(94, 27);
            this.txtSeguro.TabIndex = 111;
            this.txtSeguro.Text = "0";
            this.txtSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSeguro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrete_KeyPress);
            this.txtSeguro.Leave += new System.EventHandler(this.txtFrete_Leave);
            // 
            // txtOutras
            // 
            this.txtOutras.BackColor = System.Drawing.Color.White;
            this.txtOutras.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutras.Location = new System.Drawing.Point(615, 38);
            this.txtOutras.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutras.MaxLength = 10;
            this.txtOutras.Name = "txtOutras";
            this.txtOutras.Size = new System.Drawing.Size(89, 27);
            this.txtOutras.TabIndex = 110;
            this.txtOutras.Text = "0";
            this.txtOutras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrete_KeyPress);
            this.txtOutras.Leave += new System.EventHandler(this.txtFrete_Leave);
            // 
            // lbOutras
            // 
            this.lbOutras.AutoSize = true;
            this.lbOutras.Location = new System.Drawing.Point(615, 19);
            this.lbOutras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOutras.Name = "lbOutras";
            this.lbOutras.Size = new System.Drawing.Size(51, 17);
            this.lbOutras.TabIndex = 109;
            this.lbOutras.Text = "Outras";
            // 
            // lbSeguro
            // 
            this.lbSeguro.AutoSize = true;
            this.lbSeguro.Location = new System.Drawing.Point(513, 19);
            this.lbSeguro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSeguro.Name = "lbSeguro";
            this.lbSeguro.Size = new System.Drawing.Size(54, 17);
            this.lbSeguro.TabIndex = 108;
            this.lbSeguro.Text = "Seguro";
            // 
            // lbFrete
            // 
            this.lbFrete.AutoSize = true;
            this.lbFrete.Location = new System.Drawing.Point(415, 19);
            this.lbFrete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFrete.Name = "lbFrete";
            this.lbFrete.Size = new System.Drawing.Size(41, 17);
            this.lbFrete.TabIndex = 107;
            this.lbFrete.Text = "Frete";
            // 
            // lbCondicaoPg
            // 
            this.lbCondicaoPg.AutoSize = true;
            this.lbCondicaoPg.Location = new System.Drawing.Point(66, 19);
            this.lbCondicaoPg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCondicaoPg.Name = "lbCondicaoPg";
            this.lbCondicaoPg.Size = new System.Drawing.Size(163, 17);
            this.lbCondicaoPg.TabIndex = 90;
            this.lbCondicaoPg.Text = "Condição de Pagamento";
            // 
            // txtCondicao
            // 
            this.txtCondicao.Enabled = false;
            this.txtCondicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicao.Location = new System.Drawing.Point(68, 38);
            this.txtCondicao.Margin = new System.Windows.Forms.Padding(4);
            this.txtCondicao.MaxLength = 100;
            this.txtCondicao.Name = "txtCondicao";
            this.txtCondicao.ReadOnly = true;
            this.txtCondicao.Size = new System.Drawing.Size(242, 27);
            this.txtCondicao.TabIndex = 46;
            // 
            // lbCodigoCondicao
            // 
            this.lbCodigoCondicao.AutoSize = true;
            this.lbCodigoCondicao.Location = new System.Drawing.Point(-3, 19);
            this.lbCodigoCondicao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCodigoCondicao.Name = "lbCodigoCondicao";
            this.lbCodigoCondicao.Size = new System.Drawing.Size(52, 17);
            this.lbCodigoCondicao.TabIndex = 88;
            this.lbCodigoCondicao.Text = "Código";
            // 
            // txtCodCondicao
            // 
            this.txtCodCondicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCondicao.Location = new System.Drawing.Point(0, 38);
            this.txtCodCondicao.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCondicao.MaxLength = 100;
            this.txtCodCondicao.Name = "txtCodCondicao";
            this.txtCodCondicao.Size = new System.Drawing.Size(62, 27);
            this.txtCodCondicao.TabIndex = 45;
            this.txtCodCondicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCondicao.Enter += new System.EventHandler(this.txtCodCondicao_Enter);
            this.txtCodCondicao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodCondicao_KeyPress);
            this.txtCodCondicao.Leave += new System.EventHandler(this.txtCodCondicao_Leave);
            // 
            // lvParcelas
            // 
            this.lvParcelas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvParcelas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clParcelas,
            this.clDias,
            this.clIdForma,
            this.clForma,
            this.clPercentTotal,
            this.clPreco});
            this.lvParcelas.FullRowSelect = true;
            this.lvParcelas.GridLines = true;
            this.lvParcelas.HideSelection = false;
            this.lvParcelas.Location = new System.Drawing.Point(12, 485);
            this.lvParcelas.Margin = new System.Windows.Forms.Padding(4);
            this.lvParcelas.Name = "lvParcelas";
            this.lvParcelas.Size = new System.Drawing.Size(704, 155);
            this.lvParcelas.TabIndex = 1606;
            this.lvParcelas.UseCompatibleStateImageBehavior = false;
            this.lvParcelas.View = System.Windows.Forms.View.Details;
            // 
            // clParcelas
            // 
            this.clParcelas.Text = "Nº";
            this.clParcelas.Width = 40;
            // 
            // clDias
            // 
            this.clDias.Text = "Dias";
            this.clDias.Width = 100;
            // 
            // clIdForma
            // 
            this.clIdForma.Text = "ID.F";
            // 
            // clForma
            // 
            this.clForma.Text = "Forma PG";
            this.clForma.Width = 240;
            // 
            // clPercentTotal
            // 
            this.clPercentTotal.Text = "%  sob Total";
            this.clPercentTotal.Width = 120;
            // 
            // clPreco
            // 
            this.clPreco.Text = "Valor da parcela";
            this.clPreco.Width = 150;
            // 
            // btnFinaliza
            // 
            this.btnFinaliza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinaliza.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinaliza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinaliza.Enabled = false;
            this.btnFinaliza.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinaliza.ForeColor = System.Drawing.Color.Black;
            this.btnFinaliza.Location = new System.Drawing.Point(534, 372);
            this.btnFinaliza.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinaliza.Name = "btnFinaliza";
            this.btnFinaliza.Size = new System.Drawing.Size(182, 28);
            this.btnFinaliza.TabIndex = 1608;
            this.btnFinaliza.Text = "FINALIZAR VENDA";
            this.btnFinaliza.UseVisualStyleBackColor = false;
            this.btnFinaliza.Click += new System.EventHandler(this.btnFinaliza_Click);
            // 
            // btnFinalizaCondicao
            // 
            this.btnFinalizaCondicao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinalizaCondicao.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinalizaCondicao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizaCondicao.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizaCondicao.ForeColor = System.Drawing.Color.Black;
            this.btnFinalizaCondicao.Location = new System.Drawing.Point(738, 571);
            this.btnFinalizaCondicao.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinalizaCondicao.Name = "btnFinalizaCondicao";
            this.btnFinalizaCondicao.Size = new System.Drawing.Size(174, 29);
            this.btnFinalizaCondicao.TabIndex = 1609;
            this.btnFinalizaCondicao.Text = "FINALIZAR CONDIÇÃO";
            this.btnFinalizaCondicao.UseVisualStyleBackColor = false;
            this.btnFinalizaCondicao.Click += new System.EventHandler(this.btnFinalizaCondicao_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Lavender;
            this.panel6.Controls.Add(this.txtTotalNota);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(740, 515);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(294, 49);
            this.panel6.TabIndex = 1610;
            // 
            // txtTotalNota
            // 
            this.txtTotalNota.AutoSize = true;
            this.txtTotalNota.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNota.ForeColor = System.Drawing.Color.Black;
            this.txtTotalNota.Location = new System.Drawing.Point(166, 10);
            this.txtTotalNota.Name = "txtTotalNota";
            this.txtTotalNota.Size = new System.Drawing.Size(96, 29);
            this.txtTotalNota.TabIndex = 557;
            this.txtTotalNota.Text = "000,00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 29);
            this.label3.TabIndex = 556;
            this.label3.Text = "R$";
            // 
            // pnVendas
            // 
            this.pnVendas.Controls.Add(this.pnProd);
            this.pnVendas.Controls.Add(this.pbFoto);
            this.pnVendas.Enabled = false;
            this.pnVendas.Location = new System.Drawing.Point(738, 110);
            this.pnVendas.Name = "pnVendas";
            this.pnVendas.Size = new System.Drawing.Size(309, 399);
            this.pnVendas.TabIndex = 1612;
            // 
            // pnProd
            // 
            this.pnProd.Controls.Add(this.label5);
            this.pnProd.Controls.Add(this.txtUnitario);
            this.pnProd.Controls.Add(this.txtProdTotal);
            this.pnProd.Controls.Add(this.label7);
            this.pnProd.Controls.Add(this.label4);
            this.pnProd.Controls.Add(this.txtDesconto);
            this.pnProd.Controls.Add(this.btnAdicionar);
            this.pnProd.Controls.Add(this.txtProduto);
            this.pnProd.Controls.Add(this.lblProduto);
            this.pnProd.Controls.Add(this.label16);
            this.pnProd.Controls.Add(this.btnBuscarProduto);
            this.pnProd.Controls.Add(this.txtQtd);
            this.pnProd.Controls.Add(this.txtCodProduto);
            this.pnProd.Controls.Add(this.lblCod);
            this.pnProd.Enabled = false;
            this.pnProd.Location = new System.Drawing.Point(5, 3);
            this.pnProd.Name = "pnProd";
            this.pnProd.Size = new System.Drawing.Size(304, 183);
            this.pnProd.TabIndex = 1614;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 637;
            this.label5.Text = "R$ Unitário";
            // 
            // txtUnitario
            // 
            this.txtUnitario.Enabled = false;
            this.txtUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtUnitario.Location = new System.Drawing.Point(11, 115);
            this.txtUnitario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitario.Name = "txtUnitario";
            this.txtUnitario.ReadOnly = true;
            this.txtUnitario.Size = new System.Drawing.Size(140, 27);
            this.txtUnitario.TabIndex = 60;
            this.txtUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProdTotal
            // 
            this.txtProdTotal.Enabled = false;
            this.txtProdTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdTotal.ForeColor = System.Drawing.Color.Black;
            this.txtProdTotal.Location = new System.Drawing.Point(157, 115);
            this.txtProdTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtProdTotal.MaxLength = 100;
            this.txtProdTotal.Name = "txtProdTotal";
            this.txtProdTotal.ReadOnly = true;
            this.txtProdTotal.Size = new System.Drawing.Size(140, 27);
            this.txtProdTotal.TabIndex = 65;
            this.txtProdTotal.Text = "0";
            this.txtProdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 636;
            this.label7.Text = "R$ Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 632;
            this.label4.Text = "Desconto";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtDesconto.Location = new System.Drawing.Point(11, 67);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(57, 27);
            this.txtDesconto.TabIndex = 50;
            this.txtDesconto.Text = "0";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            this.txtDesconto.Leave += new System.EventHandler(this.txtDesconto_Leave);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdicionar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionar.Location = new System.Drawing.Point(11, 149);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(286, 28);
            this.btnAdicionar.TabIndex = 70;
            this.btnAdicionar.Text = "ADICIONAR NOVO ITEM";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtProduto
            // 
            this.txtProduto.Enabled = false;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(74, 66);
            this.txtProduto.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduto.MaxLength = 100;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(222, 27);
            this.txtProduto.TabIndex = 55;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(73, 49);
            this.lblProduto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(58, 17);
            this.lblProduto.TabIndex = 631;
            this.lblProduto.Text = "Produto";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 2);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 17);
            this.label16.TabIndex = 630;
            this.label16.Text = "Qtd";
            // 
            // btnBuscarProduto
            // 
            this.btnBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarProduto.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProduto.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarProduto.Location = new System.Drawing.Point(171, 18);
            this.btnBuscarProduto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarProduto.Name = "btnBuscarProduto";
            this.btnBuscarProduto.Size = new System.Drawing.Size(125, 27);
            this.btnBuscarProduto.TabIndex = 45;
            this.btnBuscarProduto.Text = "BUSCAR";
            this.btnBuscarProduto.UseVisualStyleBackColor = false;
            this.btnBuscarProduto.Click += new System.EventHandler(this.btnBuscarProduto_Click);
            // 
            // txtQtd
            // 
            this.txtQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtQtd.Location = new System.Drawing.Point(11, 19);
            this.txtQtd.Margin = new System.Windows.Forms.Padding(2);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(57, 27);
            this.txtQtd.TabIndex = 35;
            this.txtQtd.Text = "1";
            this.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            this.txtQtd.Leave += new System.EventHandler(this.txtQtd_Leave);
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProduto.Location = new System.Drawing.Point(74, 19);
            this.txtCodProduto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodProduto.MaxLength = 100;
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(89, 27);
            this.txtCodProduto.TabIndex = 40;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            this.txtCodProduto.Leave += new System.EventHandler(this.txtCodProduto_Leave);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(71, 2);
            this.lblCod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(87, 17);
            this.lblCod.TabIndex = 629;
            this.lblCod.Text = "Cód Produto";
            // 
            // pbFoto
            // 
            this.pbFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFoto.Image = global::PROJETO.Properties.Resources.semimagem;
            this.pbFoto.Location = new System.Drawing.Point(22, 199);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(274, 187);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFoto.TabIndex = 1613;
            this.pbFoto.TabStop = false;
            // 
            // pnCliente
            // 
            this.pnCliente.Controls.Add(this.lblCodCliente);
            this.pnCliente.Controls.Add(this.txtCodCliente);
            this.pnCliente.Controls.Add(this.btnBuscarCliente);
            this.pnCliente.Controls.Add(this.clForn);
            this.pnCliente.Controls.Add(this.txtCliente);
            this.pnCliente.Controls.Add(this.txtCPFeCNPJ);
            this.pnCliente.Controls.Add(this.label6);
            this.pnCliente.Location = new System.Drawing.Point(738, 4);
            this.pnCliente.Name = "pnCliente";
            this.pnCliente.Size = new System.Drawing.Size(309, 100);
            this.pnCliente.TabIndex = 1615;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Location = new System.Drawing.Point(8, 52);
            this.lblCodCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(52, 17);
            this.lblCodCliente.TabIndex = 576;
            this.lblCodCliente.Text = "Código";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Enabled = false;
            this.txtCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCliente.Location = new System.Drawing.Point(11, 69);
            this.txtCodCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCliente.MaxLength = 100;
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(90, 27);
            this.txtCodCliente.TabIndex = 20;
            this.txtCodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.Location = new System.Drawing.Point(197, 18);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(99, 27);
            this.btnBuscarCliente.TabIndex = 15;
            this.btnBuscarCliente.Text = "BUSCAR";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // clForn
            // 
            this.clForn.AutoSize = true;
            this.clForn.Location = new System.Drawing.Point(104, 52);
            this.clForn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.clForn.Name = "clForn";
            this.clForn.Size = new System.Drawing.Size(51, 17);
            this.clForn.TabIndex = 573;
            this.clForn.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(107, 69);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.MaxLength = 100;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(189, 27);
            this.txtCliente.TabIndex = 25;
            // 
            // txtCPFeCNPJ
            // 
            this.txtCPFeCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPFeCNPJ.Location = new System.Drawing.Point(11, 18);
            this.txtCPFeCNPJ.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPFeCNPJ.MaxLength = 100;
            this.txtCPFeCNPJ.Name = "txtCPFeCNPJ";
            this.txtCPFeCNPJ.Size = new System.Drawing.Size(178, 27);
            this.txtCPFeCNPJ.TabIndex = 10;
            this.txtCPFeCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCPFeCNPJ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCPFeCNPJ_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 574;
            this.label6.Text = "CPF / CNPJ / RG";
            // 
            // VendaFrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1051, 692);
            this.Controls.Add(this.DgItensVenda);
            this.Controls.Add(this.pnCliente);
            this.Controls.Add(this.pnVendas);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnFinalizaCondicao);
            this.Controls.Add(this.btnFinaliza);
            this.Controls.Add(this.lvParcelas);
            this.Controls.Add(this.gbCondicao);
            this.Name = "VendaFrmCadastro";
            this.Text = "Cadastrar Venda";
            this.Controls.SetChildIndex(this.gbCondicao, 0);
            this.Controls.SetChildIndex(this.lvParcelas, 0);
            this.Controls.SetChildIndex(this.btnFinaliza, 0);
            this.Controls.SetChildIndex(this.btnFinalizaCondicao, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.btnSalvar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.pnVendas, 0);
            this.Controls.SetChildIndex(this.pnCliente, 0);
            this.Controls.SetChildIndex(this.DgItensVenda, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgItensVenda)).EndInit();
            this.gbCondicao.ResumeLayout(false);
            this.gbCondicao.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnVendas.ResumeLayout(false);
            this.pnProd.ResumeLayout(false);
            this.pnProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.pnCliente.ResumeLayout(false);
            this.pnCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView DgItensVenda;
        protected System.Windows.Forms.GroupBox gbCondicao;
        protected System.Windows.Forms.Button btnBuscarCondicao;
        private System.Windows.Forms.TextBox txtFrete;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.TextBox txtOutras;
        protected System.Windows.Forms.Label lbOutras;
        protected System.Windows.Forms.Label lbSeguro;
        protected System.Windows.Forms.Label lbFrete;
        protected System.Windows.Forms.Label lbCondicaoPg;
        protected System.Windows.Forms.TextBox txtCondicao;
        protected System.Windows.Forms.Label lbCodigoCondicao;
        protected System.Windows.Forms.TextBox txtCodCondicao;
        protected System.Windows.Forms.ListView lvParcelas;
        private System.Windows.Forms.ColumnHeader clParcelas;
        private System.Windows.Forms.ColumnHeader clDias;
        private System.Windows.Forms.ColumnHeader clIdForma;
        private System.Windows.Forms.ColumnHeader clForma;
        private System.Windows.Forms.ColumnHeader clPercentTotal;
        private System.Windows.Forms.ColumnHeader clPreco;
        protected System.Windows.Forms.Button btnFinaliza;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label txtTotalNota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnVendas;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Panel pnProd;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox txtUnitario;
        protected System.Windows.Forms.TextBox txtProdTotal;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtDesconto;
        protected System.Windows.Forms.Button btnAdicionar;
        protected System.Windows.Forms.TextBox txtProduto;
        protected System.Windows.Forms.Label lblProduto;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Button btnBuscarProduto;
        protected System.Windows.Forms.TextBox txtQtd;
        protected System.Windows.Forms.TextBox txtCodProduto;
        protected System.Windows.Forms.Label lblCod;
        public System.Windows.Forms.Panel pnCliente;
        protected System.Windows.Forms.Label lblCodCliente;
        protected System.Windows.Forms.TextBox txtCodCliente;
        protected System.Windows.Forms.Button btnBuscarCliente;
        protected System.Windows.Forms.Label clForn;
        protected System.Windows.Forms.TextBox txtCliente;
        protected System.Windows.Forms.TextBox txtCPFeCNPJ;
        protected System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnFinalizaCondicao;
    }
}
