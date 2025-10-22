namespace PROJETO.views.compraevenda
{
    partial class ContasPagarFrmConsulta
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
            this.Modelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Série = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDForn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FormaPG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Emissão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Baixa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Juros = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Multa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desconto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Situação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbPago = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(627, 515);
            this.btnExcluir.Visible = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(843, 513);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(735, 513);
            this.btnIncluir.Text = "Pagar";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Modelo,
            this.Série,
            this.NParcela,
            this.IDForn,
            this.Fornecedor,
            this.FormaPG,
            this.Emissão,
            this.Vencimento,
            this.Valor,
            this.Baixa,
            this.Pagamento,
            this.Juros,
            this.Multa,
            this.Desconto,
            this.Situação});
            // 
            // rbAtivos
            // 
            this.rbAtivos.Location = new System.Drawing.Point(570, 26);
            this.rbAtivos.Size = new System.Drawing.Size(87, 21);
            this.rbAtivos.TabIndex = 1200;
            this.rbAtivos.Text = "A PAGAR";
            this.rbAtivos.CheckedChanged += new System.EventHandler(this.rbAtivos_CheckedChanged);
            // 
            // rbInativos
            // 
            this.rbInativos.Location = new System.Drawing.Point(826, 26);
            this.rbInativos.Size = new System.Drawing.Size(117, 21);
            this.rbInativos.TabIndex = 1400;
            this.rbInativos.Text = "CANCELADAS";
            this.rbInativos.CheckedChanged += new System.EventHandler(this.rbInativos_CheckedChanged);
            // 
            // Modelo
            // 
            this.Modelo.Text = "Modelo";
            // 
            // Série
            // 
            this.Série.Text = "Série";
            // 
            // NParcela
            // 
            this.NParcela.Text = "Nº";
            // 
            // IDForn
            // 
            this.IDForn.Text = "ID FRN";
            // 
            // Fornecedor
            // 
            this.Fornecedor.Text = "Fornecedor";
            this.Fornecedor.Width = 150;
            // 
            // FormaPG
            // 
            this.FormaPG.Text = "Forma Pagamento";
            this.FormaPG.Width = 150;
            // 
            // Emissão
            // 
            this.Emissão.Text = "Emissão";
            this.Emissão.Width = 130;
            // 
            // Vencimento
            // 
            this.Vencimento.Text = "Vencimento";
            this.Vencimento.Width = 130;
            // 
            // Valor
            // 
            this.Valor.Text = "Valor";
            this.Valor.Width = 100;
            // 
            // Baixa
            // 
            this.Baixa.Text = "Baixa";
            this.Baixa.Width = 130;
            // 
            // Pagamento
            // 
            this.Pagamento.Text = "Pagamento";
            this.Pagamento.Width = 100;
            // 
            // Juros
            // 
            this.Juros.Text = "Juros";
            // 
            // Multa
            // 
            this.Multa.Text = "Multa";
            // 
            // Desconto
            // 
            this.Desconto.Text = "Desconto";
            // 
            // Situação
            // 
            this.Situação.Text = "Situação";
            // 
            // rbPago
            // 
            this.rbPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPago.AutoSize = true;
            this.rbPago.Location = new System.Drawing.Point(663, 26);
            this.rbPago.Name = "rbPago";
            this.rbPago.Size = new System.Drawing.Size(75, 21);
            this.rbPago.TabIndex = 1300;
            this.rbPago.Text = "PAGOS";
            this.rbPago.UseVisualStyleBackColor = true;
            this.rbPago.CheckedChanged += new System.EventHandler(this.rbPago_CheckedChanged_1);
            // 
            // rbTodos
            // 
            this.rbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(744, 26);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(76, 21);
            this.rbTodos.TabIndex = 1350;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // ContasPagarFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rbTodos);
            this.Controls.Add(this.rbPago);
            this.Name = "ContasPagarFrmConsulta";
            this.Text = "Consultar Contas a Pagar";
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnIncluir, 0);
            this.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.Controls.SetChildIndex(this.txtPesquisar, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.btnAtualizar, 0);
            this.Controls.SetChildIndex(this.rbInativos, 0);
            this.Controls.SetChildIndex(this.rbPago, 0);
            this.Controls.SetChildIndex(this.rbTodos, 0);
            this.Controls.SetChildIndex(this.rbAtivos, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Modelo;
        private System.Windows.Forms.ColumnHeader Série;
        private System.Windows.Forms.ColumnHeader NParcela;
        private System.Windows.Forms.ColumnHeader IDForn;
        private System.Windows.Forms.ColumnHeader Fornecedor;
        private System.Windows.Forms.ColumnHeader FormaPG;
        private System.Windows.Forms.ColumnHeader Emissão;
        private System.Windows.Forms.ColumnHeader Vencimento;
        private System.Windows.Forms.ColumnHeader Valor;
        private System.Windows.Forms.ColumnHeader Baixa;
        private System.Windows.Forms.ColumnHeader Pagamento;
        private System.Windows.Forms.ColumnHeader Juros;
        private System.Windows.Forms.ColumnHeader Multa;
        private System.Windows.Forms.ColumnHeader Desconto;
        private System.Windows.Forms.ColumnHeader Situação;
        protected System.Windows.Forms.RadioButton rbPago;
        protected System.Windows.Forms.RadioButton rbTodos;
    }
}
