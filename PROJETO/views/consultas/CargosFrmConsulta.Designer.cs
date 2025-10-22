namespace PROJETO.views.consultas
{
    partial class CargosFrmConsulta
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
            this.Cargo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Cargo,
            this.Cadastro,
            this.Alteracao,
            this.Status});
            // 
            // Cargo
            // 
            this.Cargo.Text = "Cargo";
            this.Cargo.Width = 200;
            // 
            // Cadastro
            // 
            this.Cadastro.Text = "Cadastro";
            this.Cadastro.Width = 130;
            // 
            // Alteracao
            // 
            this.Alteracao.Text = "Alteracao";
            this.Alteracao.Width = 130;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // CargosFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "CargosFrmConsulta";
            this.Text = "Consultar Cargos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Cargo;
        private System.Windows.Forms.ColumnHeader Cadastro;
        private System.Windows.Forms.ColumnHeader Alteracao;
        private System.Windows.Forms.ColumnHeader Status;
    }
}
