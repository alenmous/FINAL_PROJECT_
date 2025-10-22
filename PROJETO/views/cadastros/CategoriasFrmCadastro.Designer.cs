namespace PROJETO.views.cadastros
{
    partial class CategoriasFrmCadastro
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
            this.lbNumero = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(69, 72);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(177, 72);
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.ForeColor = System.Drawing.Color.Black;
            this.lbNumero.Location = new System.Drawing.Point(92, 14);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(69, 17);
            this.lbNumero.TabIndex = 1602;
            this.lbNumero.Text = "Categoria";
            // 
            // txtProduto
            // 
            this.txtProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtProduto.Location = new System.Drawing.Point(95, 33);
            this.txtProduto.MaxLength = 20;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(239, 27);
            this.txtProduto.TabIndex = 1601;
            // 
            // CategoriasFrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(346, 113);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.txtProduto);
            this.Name = "CategoriasFrmCadastro";
            this.Text = "Cadastrar Categoria";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CategoriasFrmCadastro_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CategoriasFrmCadastro_KeyPress);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.btnSalvar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.txtProduto, 0);
            this.Controls.SetChildIndex(this.lbNumero, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.TextBox txtProduto;
    }
}
