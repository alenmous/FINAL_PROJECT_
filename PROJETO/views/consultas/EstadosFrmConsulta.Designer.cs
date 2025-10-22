namespace PROJETO.views.consultas
{
    partial class EstadosFrmConsulta
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
            this.Estado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Uf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataCadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DTAlteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Estado,
            this.Uf,
            this.Pais,
            this.DataCadastro,
            this.DTAlteracao,
            this.Status});
            // 
            // Estado
            // 
            this.Estado.Text = "Estado";
            this.Estado.Width = 160;
            // 
            // Uf
            // 
            this.Uf.Text = "UF";
            // 
            // Pais
            // 
            this.Pais.Text = "País";
            this.Pais.Width = 150;
            // 
            // DataCadastro
            // 
            this.DataCadastro.Text = "DT-Cadastro";
            this.DataCadastro.Width = 130;
            // 
            // DTAlteracao
            // 
            this.DTAlteracao.Text = "Ultima Alteração";
            this.DTAlteracao.Width = 130;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // EstadosFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "EstadosFrmConsulta";
            this.Text = "Consultar Estados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Estado;
        private System.Windows.Forms.ColumnHeader Uf;
        private System.Windows.Forms.ColumnHeader Pais;
        private System.Windows.Forms.ColumnHeader DataCadastro;
        private System.Windows.Forms.ColumnHeader DTAlteracao;
        private System.Windows.Forms.ColumnHeader Status;
    }
}
