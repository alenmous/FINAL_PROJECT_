namespace PROJETO.views.consultas
{
    partial class CondicaoPagamentoFrmConsulta
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
            this.Condicao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Parcelas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Taxa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Multa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desconto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataCadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Condicao,
            this.Parcelas,
            this.Taxa,
            this.Multa,
            this.Desconto,
            this.DataCadastro,
            this.Alteracao,
            this.Status});
            // 
            // Condicao
            // 
            this.Condicao.Text = "Condição";
            this.Condicao.Width = 300;
            // 
            // Parcelas
            // 
            this.Parcelas.Text = "Parcelas";
            // 
            // Taxa
            // 
            this.Taxa.Text = "Taxa";
            this.Taxa.Width = 80;
            // 
            // Multa
            // 
            this.Multa.Text = "Multa";
            this.Multa.Width = 80;
            // 
            // Desconto
            // 
            this.Desconto.Text = "Desconto";
            this.Desconto.Width = 80;
            // 
            // DataCadastro
            // 
            this.DataCadastro.Text = "Cadastro";
            this.DataCadastro.Width = 130;
            // 
            // Alteracao
            // 
            this.Alteracao.Text = "Alteração";
            this.Alteracao.Width = 130;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // CondicaoPagamentoFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "CondicaoPagamentoFrmConsulta";
            this.Text = "Consultar Condição de pagamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Condicao;
        private System.Windows.Forms.ColumnHeader Parcelas;
        private System.Windows.Forms.ColumnHeader Taxa;
        private System.Windows.Forms.ColumnHeader Multa;
        private System.Windows.Forms.ColumnHeader Desconto;
        private System.Windows.Forms.ColumnHeader DataCadastro;
        private System.Windows.Forms.ColumnHeader Alteracao;
        private System.Windows.Forms.ColumnHeader Status;
    }
}
