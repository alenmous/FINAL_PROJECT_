namespace PROJETO.views.compraevenda
{
    partial class ComprasFrmConsulta
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
            this.CodForn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Condição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Seguro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Outras = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Chegada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Emissão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cancelamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Text = "Cancelar";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(519, 510);
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
            this.CodForn,
            this.Fornecedor,
            this.Condição,
            this.Total,
            this.Frete,
            this.Seguro,
            this.Outras,
            this.Chegada,
            this.Emissão,
            this.Cancelamento,
            this.Cadastro,
            this.Status});
            // 
            // rbAtivos
            // 
            this.rbAtivos.Location = new System.Drawing.Point(744, 30);
            // 
            // rbInativos
            // 
            this.rbInativos.Location = new System.Drawing.Point(826, 30);
            this.rbInativos.Size = new System.Drawing.Size(117, 21);
            this.rbInativos.Text = "CANCELADAS";
            // 
            // Modelo
            // 
            this.Modelo.Text = "Modelo";
            // 
            // Série
            // 
            this.Série.Text = "Série";
            // 
            // CodForn
            // 
            this.CodForn.Text = "ID FRN";
            // 
            // Fornecedor
            // 
            this.Fornecedor.Text = "Fornecedor";
            this.Fornecedor.Width = 150;
            // 
            // Condição
            // 
            this.Condição.Text = "Condição";
            this.Condição.Width = 150;
            // 
            // Total
            // 
            this.Total.Text = "Total";
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
            // Outras
            // 
            this.Outras.Text = "Outras";
            // 
            // Chegada
            // 
            this.Chegada.Text = "Chegada";
            this.Chegada.Width = 130;
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
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // ComprasFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "ComprasFrmConsulta";
            this.Text = "Consultar Compras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Modelo;
        private System.Windows.Forms.ColumnHeader Série;
        private System.Windows.Forms.ColumnHeader CodForn;
        private System.Windows.Forms.ColumnHeader Fornecedor;
        private System.Windows.Forms.ColumnHeader Condição;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader Frete;
        private System.Windows.Forms.ColumnHeader Seguro;
        private System.Windows.Forms.ColumnHeader Outras;
        private System.Windows.Forms.ColumnHeader Chegada;
        private System.Windows.Forms.ColumnHeader Emissão;
        private System.Windows.Forms.ColumnHeader Cancelamento;
        private System.Windows.Forms.ColumnHeader Cadastro;
        private System.Windows.Forms.ColumnHeader Status;
    }
}
