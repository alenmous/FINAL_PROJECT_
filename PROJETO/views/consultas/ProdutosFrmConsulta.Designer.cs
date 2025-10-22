namespace PROJETO.views.consultas
{
    partial class ProdutosFrmConsulta
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
            this.Categoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Compra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Venda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Unidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QTD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Criacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Referencia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Categoria,
            this.Produto,
            this.Descrição,
            this.Marca,
            this.Compra,
            this.Venda,
            this.Unidade,
            this.QTD,
            this.Criacao,
            this.Alteracao,
            this.Status,
            this.Referencia});
            // 
            // Categoria
            // 
            this.Categoria.Text = "Categoria";
            this.Categoria.Width = 150;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 200;
            // 
            // Descrição
            // 
            this.Descrição.Text = "Descrição";
            this.Descrição.Width = 250;
            // 
            // Marca
            // 
            this.Marca.Text = "Marca";
            this.Marca.Width = 100;
            // 
            // Compra
            // 
            this.Compra.Text = "Preço de Compra";
            this.Compra.Width = 80;
            // 
            // Venda
            // 
            this.Venda.Text = "Venda";
            this.Venda.Width = 80;
            // 
            // Unidade
            // 
            this.Unidade.Text = "Unidade";
            this.Unidade.Width = 80;
            // 
            // QTD
            // 
            this.QTD.Text = "QTD";
            // 
            // Criacao
            // 
            this.Criacao.Text = "Criação";
            this.Criacao.Width = 130;
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
            // Referencia
            // 
            this.Referencia.Text = "Referência";
            this.Referencia.Width = 80;
            // 
            // ProdutosFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "ProdutosFrmConsulta";
            this.Text = "Consultar Produtos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Categoria;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Descrição;
        private System.Windows.Forms.ColumnHeader Marca;
        private System.Windows.Forms.ColumnHeader Compra;
        private System.Windows.Forms.ColumnHeader Venda;
        private System.Windows.Forms.ColumnHeader Unidade;
        private System.Windows.Forms.ColumnHeader QTD;
        private System.Windows.Forms.ColumnHeader Criacao;
        private System.Windows.Forms.ColumnHeader Alteracao;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Referencia;
    }
}
