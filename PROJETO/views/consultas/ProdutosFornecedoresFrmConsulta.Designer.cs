namespace PROJETO.views.consultas
{
    partial class ProdutosFornecedoresFrmConsulta
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
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Criação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alteração = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Medida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Venda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Produto,
            this.Fornecedor,
            this.Criação,
            this.Alteração,
            this.Status,
            this.Medida,
            this.Venda});
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 200;
            // 
            // Fornecedor
            // 
            this.Fornecedor.Text = "Fornecedor";
            this.Fornecedor.Width = 200;
            // 
            // Criação
            // 
            this.Criação.Text = "Criação";
            this.Criação.Width = 130;
            // 
            // Alteração
            // 
            this.Alteração.Text = "Alteração";
            this.Alteração.Width = 130;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // Medida
            // 
            this.Medida.Text = "UN Medida";
            this.Medida.Width = 80;
            // 
            // Venda
            // 
            this.Venda.Text = "R$ Venda";
            this.Venda.Width = 100;
            // 
            // ProdutosFornecedoresFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "ProdutosFornecedoresFrmConsulta";
            this.Text = "Consultar Produtos do fornecedor.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Fornecedor;
        private System.Windows.Forms.ColumnHeader Criação;
        private System.Windows.Forms.ColumnHeader Alteração;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Medida;
        private System.Windows.Forms.ColumnHeader Venda;
    }
}
