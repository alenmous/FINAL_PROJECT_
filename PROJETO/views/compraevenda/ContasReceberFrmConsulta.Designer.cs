namespace PROJETO.views.compraevenda
{
    partial class ContasReceberFrmConsulta
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
            this.SuspendLayout();
            // 
            // rbPago
            // 
            this.rbPago.CheckedChanged += new System.EventHandler(this.rbPago_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(627, 515);
            this.btnExcluir.Visible = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(843, 513);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(735, 513);
            // 
            // rbAtivos
            // 
            this.rbAtivos.Location = new System.Drawing.Point(553, 26);
            this.rbAtivos.Size = new System.Drawing.Size(104, 21);
            this.rbAtivos.Text = "A RECEBER";
            this.rbAtivos.CheckedChanged += new System.EventHandler(this.rbAtivos_CheckedChanged);
            // 
            // rbInativos
            // 
            this.rbInativos.CheckedChanged += new System.EventHandler(this.rbInativos_CheckedChanged);
            // 
            // ContasReceberFrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Name = "ContasReceberFrmConsulta";
            this.Text = "Consultar Contas a Receber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
