namespace PROJETO.views.compraevenda
{
    partial class VendaFrmConsulta
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
            this.CódigC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CondPG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Seguro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Outros = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Saida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Emissão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cancelamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Text = "Cancelar";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(627, 513);
            this.btnAlterar.Visible = false;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(735, 513);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Modelo,
            this.Série,
            this.CódigC,
            this.Cliente,
            this.CondPG,
            this.Total,
            this.Frete,
            this.Seguro,
            this.Outros,
            this.Saida,
            this.Emissão,
            this.Cancelamento,
            this.Cadastro});
            // 
            // Modelo
            // 
            this.Modelo.Text = "Modelo";
            // 
            // Série
            // 
            this.Série.Text = "Série";
            // 
            // CódigC
            // 
            this.CódigC.Text = "Cód C";
            // 
            // Cliente
            // 
            this.Cliente.Text = "Cliente";
            this.Cliente.Width = 130;
            // 
            // CondPG
            // 
            this.CondPG.Text = "Cond PG";
            this.CondPG.Width = 130;
            // 
            // Total
            // 
            this.Total.Text = "R$ TOTAL";
            this.Total.Width = 100;
            // 
            // Frete
            // 
            this.Frete.Text = "Frete";
            // 
            // Seguro
            // 
            this.Seguro.Text = "Seguro";
            // 
            // Outros
            // 
            this.Outros.Text = "Outros";
            // 
            // Saida
            // 
            this.Saida.Text = "Saida";
            this.Saida.Width = 130;
            // 
            // Emissão
            // 
            this.Emissão.Text = "Emissão";
            this.Emissão.Width = 130;
            // 
            // Cancelamento
            // 
            this.Cancelamento.Text = "Cancelamento";
            this.Cancelamento.Width = 130;
            // 
            // Cadastro
            // 
            this.Cadastro.Text = "Cadastro";
            this.Cadastro.Width = 130;
            // 
            // VendaFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "VendaFrmConsulta";
            this.Text = "Consultar Vendas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Modelo;
        private System.Windows.Forms.ColumnHeader Série;
        private System.Windows.Forms.ColumnHeader CódigC;
        private System.Windows.Forms.ColumnHeader Cliente;
        private System.Windows.Forms.ColumnHeader CondPG;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader Frete;
        private System.Windows.Forms.ColumnHeader Seguro;
        private System.Windows.Forms.ColumnHeader Outros;
        private System.Windows.Forms.ColumnHeader Saida;
        private System.Windows.Forms.ColumnHeader Emissão;
        private System.Windows.Forms.ColumnHeader Cancelamento;
        private System.Windows.Forms.ColumnHeader Cadastro;
    }
}
