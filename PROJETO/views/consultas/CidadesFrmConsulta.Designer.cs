namespace PROJETO.views.consultas
{
    partial class CidadesFrmConsulta
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
            this.Cidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DDD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Estado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DtCadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DtAlteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Cidade,
            this.DDD,
            this.Estado,
            this.DtCadastro,
            this.DtAlteracao,
            this.Status});
            // 
            // Cidade
            // 
            this.Cidade.Text = "Cidade";
            this.Cidade.Width = 150;
            // 
            // DDD
            // 
            this.DDD.Text = "DDD";
            // 
            // Estado
            // 
            this.Estado.Text = "Estado";
            this.Estado.Width = 150;
            // 
            // DtCadastro
            // 
            this.DtCadastro.Text = "Data-Cadastro";
            this.DtCadastro.Width = 130;
            // 
            // DtAlteracao
            // 
            this.DtAlteracao.Text = "DT-ALTERAÇÃO";
            this.DtAlteracao.Width = 130;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // CidadesFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "CidadesFrmConsulta";
            this.Text = "Consultar Cidades";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Cidade;
        private System.Windows.Forms.ColumnHeader DDD;
        private System.Windows.Forms.ColumnHeader Estado;
        private System.Windows.Forms.ColumnHeader DtCadastro;
        private System.Windows.Forms.ColumnHeader DtAlteracao;
        private System.Windows.Forms.ColumnHeader Status;
    }
}
