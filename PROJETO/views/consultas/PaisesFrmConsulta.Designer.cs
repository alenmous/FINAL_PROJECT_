namespace PROJETO.views.consultas
{
    partial class PaisesFrmConsulta
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
            this.pais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ddi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pais,
            this.sigla,
            this.ddi,
            this.dtC,
            this.dtu,
            this.status});
            // 
            // pais
            // 
            this.pais.Text = "Pais";
            this.pais.Width = 180;
            // 
            // sigla
            // 
            this.sigla.Text = "Sigla";
            // 
            // ddi
            // 
            this.ddi.Text = "DDI";
            // 
            // dtC
            // 
            this.dtC.Text = "Data Cadastro";
            this.dtC.Width = 130;
            // 
            // dtu
            // 
            this.dtu.Text = "Data Alteração";
            this.dtu.Width = 130;
            // 
            // status
            // 
            this.status.Text = "Status";
            // 
            // PaisesFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "PaisesFrmConsulta";
            this.Text = "Consultar Países";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader pais;
        private System.Windows.Forms.ColumnHeader sigla;
        private System.Windows.Forms.ColumnHeader ddi;
        private System.Windows.Forms.ColumnHeader dtC;
        private System.Windows.Forms.ColumnHeader dtu;
        private System.Windows.Forms.ColumnHeader status;
    }
}
