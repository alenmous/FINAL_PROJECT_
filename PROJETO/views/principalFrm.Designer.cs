namespace PROJETO.views
{
    partial class principalFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ttFinanceiro = new System.Windows.Forms.ToolStripMenuItem();
            this.stripFinForma = new System.Windows.Forms.ToolStripMenuItem();
            this.stripFinCondicao = new System.Windows.Forms.ToolStripMenuItem();
            this.stripFinContaPg = new System.Windows.Forms.ToolStripMenuItem();
            this.stripFinContaReceber = new System.Windows.Forms.ToolStripMenuItem();
            this.ttConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConPaises = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConEstados = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConCidades = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConFonecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.ttAlmoxarife = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAlmCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAlmVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAlmProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAlmMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAlmCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAlmVinculo = new System.Windows.Forms.ToolStripMenuItem();
            this.ttSair = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SlateGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttFinanceiro,
            this.ttConsultas,
            this.ttAlmoxarife,
            this.ttSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ttFinanceiro
            // 
            this.ttFinanceiro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripFinForma,
            this.stripFinCondicao,
            this.stripFinContaPg,
            this.stripFinContaReceber});
            this.ttFinanceiro.ForeColor = System.Drawing.Color.White;
            this.ttFinanceiro.Name = "ttFinanceiro";
            this.ttFinanceiro.Size = new System.Drawing.Size(83, 23);
            this.ttFinanceiro.Text = "Financeiro";
            // 
            // stripFinForma
            // 
            this.stripFinForma.Name = "stripFinForma";
            this.stripFinForma.Size = new System.Drawing.Size(228, 24);
            this.stripFinForma.Text = "Forma de Pagamento";
            this.stripFinForma.Visible = false;
            // 
            // stripFinCondicao
            // 
            this.stripFinCondicao.Name = "stripFinCondicao";
            this.stripFinCondicao.Size = new System.Drawing.Size(228, 24);
            this.stripFinCondicao.Text = "Condição de Pagamento";
            this.stripFinCondicao.Visible = false;
            // 
            // stripFinContaPg
            // 
            this.stripFinContaPg.Name = "stripFinContaPg";
            this.stripFinContaPg.Size = new System.Drawing.Size(228, 24);
            this.stripFinContaPg.Text = "Contas a Pagar";
            this.stripFinContaPg.Visible = false;
            this.stripFinContaPg.Click += new System.EventHandler(this.stripFinContaPg_Click);
            // 
            // stripFinContaReceber
            // 
            this.stripFinContaReceber.Name = "stripFinContaReceber";
            this.stripFinContaReceber.Size = new System.Drawing.Size(228, 24);
            this.stripFinContaReceber.Text = "Contas a Receber";
            this.stripFinContaReceber.Visible = false;
            this.stripFinContaReceber.Click += new System.EventHandler(this.stripFinContaReceber_Click);
            // 
            // ttConsultas
            // 
            this.ttConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripConPaises,
            this.stripConEstados,
            this.stripConCidades,
            this.stripConCargos,
            this.stripConUsuarios,
            this.stripConClientes,
            this.stripConFonecedores});
            this.ttConsultas.ForeColor = System.Drawing.Color.White;
            this.ttConsultas.Name = "ttConsultas";
            this.ttConsultas.Size = new System.Drawing.Size(81, 23);
            this.ttConsultas.Text = "Consultas";
            // 
            // stripConPaises
            // 
            this.stripConPaises.Name = "stripConPaises";
            this.stripConPaises.Size = new System.Drawing.Size(160, 24);
            this.stripConPaises.Text = "Países";
            this.stripConPaises.Visible = false;
            // 
            // stripConEstados
            // 
            this.stripConEstados.Name = "stripConEstados";
            this.stripConEstados.Size = new System.Drawing.Size(160, 24);
            this.stripConEstados.Text = "Estados";
            this.stripConEstados.Visible = false;
            // 
            // stripConCidades
            // 
            this.stripConCidades.Name = "stripConCidades";
            this.stripConCidades.Size = new System.Drawing.Size(160, 24);
            this.stripConCidades.Text = "Cidades";
            this.stripConCidades.Visible = false;
            // 
            // stripConCargos
            // 
            this.stripConCargos.Name = "stripConCargos";
            this.stripConCargos.Size = new System.Drawing.Size(160, 24);
            this.stripConCargos.Text = "Cargos";
            this.stripConCargos.Visible = false;
            // 
            // stripConUsuarios
            // 
            this.stripConUsuarios.Name = "stripConUsuarios";
            this.stripConUsuarios.Size = new System.Drawing.Size(160, 24);
            this.stripConUsuarios.Text = "Usuarios";
            this.stripConUsuarios.Visible = false;
            // 
            // stripConClientes
            // 
            this.stripConClientes.Name = "stripConClientes";
            this.stripConClientes.Size = new System.Drawing.Size(160, 24);
            this.stripConClientes.Text = "Clientes";
            this.stripConClientes.Visible = false;
            this.stripConClientes.Click += new System.EventHandler(this.stripConClientes_Click);
            // 
            // stripConFonecedores
            // 
            this.stripConFonecedores.Name = "stripConFonecedores";
            this.stripConFonecedores.Size = new System.Drawing.Size(160, 24);
            this.stripConFonecedores.Text = "Fornecedores";
            this.stripConFonecedores.Visible = false;
            this.stripConFonecedores.Click += new System.EventHandler(this.stripConFonecedores_Click);
            // 
            // ttAlmoxarife
            // 
            this.ttAlmoxarife.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripAlmCompra,
            this.stripAlmVenda,
            this.stripAlmProduto,
            this.stripAlmMarca,
            this.stripAlmCategoria,
            this.stripAlmVinculo});
            this.ttAlmoxarife.ForeColor = System.Drawing.Color.White;
            this.ttAlmoxarife.Name = "ttAlmoxarife";
            this.ttAlmoxarife.Size = new System.Drawing.Size(85, 23);
            this.ttAlmoxarife.Text = "Almoxarife";
            // 
            // stripAlmCompra
            // 
            this.stripAlmCompra.Name = "stripAlmCompra";
            this.stripAlmCompra.Size = new System.Drawing.Size(221, 24);
            this.stripAlmCompra.Text = "Compras";
            this.stripAlmCompra.Visible = false;
            this.stripAlmCompra.Click += new System.EventHandler(this.stripAlmCompra_Click);
            // 
            // stripAlmVenda
            // 
            this.stripAlmVenda.Name = "stripAlmVenda";
            this.stripAlmVenda.Size = new System.Drawing.Size(221, 24);
            this.stripAlmVenda.Text = "Vendas";
            this.stripAlmVenda.Visible = false;
            this.stripAlmVenda.Click += new System.EventHandler(this.stripAlmVenda_Click);
            // 
            // stripAlmProduto
            // 
            this.stripAlmProduto.Name = "stripAlmProduto";
            this.stripAlmProduto.Size = new System.Drawing.Size(221, 24);
            this.stripAlmProduto.Text = "Produtos";
            this.stripAlmProduto.Visible = false;
            this.stripAlmProduto.Click += new System.EventHandler(this.stripAlmProduto_Click);
            // 
            // stripAlmMarca
            // 
            this.stripAlmMarca.Name = "stripAlmMarca";
            this.stripAlmMarca.Size = new System.Drawing.Size(221, 24);
            this.stripAlmMarca.Text = "Marcas";
            this.stripAlmMarca.Visible = false;
            this.stripAlmMarca.Click += new System.EventHandler(this.stripAlmMarca_Click);
            // 
            // stripAlmCategoria
            // 
            this.stripAlmCategoria.Name = "stripAlmCategoria";
            this.stripAlmCategoria.Size = new System.Drawing.Size(221, 24);
            this.stripAlmCategoria.Text = "Categorias";
            this.stripAlmCategoria.Visible = false;
            this.stripAlmCategoria.Click += new System.EventHandler(this.stripAlmCategoria_Click);
            // 
            // stripAlmVinculo
            // 
            this.stripAlmVinculo.Name = "stripAlmVinculo";
            this.stripAlmVinculo.Size = new System.Drawing.Size(221, 24);
            this.stripAlmVinculo.Text = "Produto -> Fornecedor";
            this.stripAlmVinculo.Visible = false;
            this.stripAlmVinculo.Click += new System.EventHandler(this.stripAlmVinculo_Click);
            // 
            // ttSair
            // 
            this.ttSair.ForeColor = System.Drawing.Color.White;
            this.ttSair.Name = "ttSair";
            this.ttSair.Size = new System.Drawing.Size(43, 23);
            this.ttSair.Text = "Sair";
            this.ttSair.Click += new System.EventHandler(this.ttSair_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 22);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(71, 401);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(782, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 401);
            this.panel3.TabIndex = 6;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Lavender;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(71, 49);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(711, 401);
            this.panelMenu.TabIndex = 7;
            // 
            // principalFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeBox = false;
            this.Name = "principalFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.principalFrm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ttFinanceiro;
        private System.Windows.Forms.ToolStripMenuItem stripFinForma;
        private System.Windows.Forms.ToolStripMenuItem stripFinCondicao;
        private System.Windows.Forms.ToolStripMenuItem stripFinContaPg;
        private System.Windows.Forms.ToolStripMenuItem stripFinContaReceber;
        private System.Windows.Forms.ToolStripMenuItem ttConsultas;
        private System.Windows.Forms.ToolStripMenuItem stripConPaises;
        private System.Windows.Forms.ToolStripMenuItem stripConEstados;
        private System.Windows.Forms.ToolStripMenuItem stripConCidades;
        private System.Windows.Forms.ToolStripMenuItem stripConCargos;
        private System.Windows.Forms.ToolStripMenuItem stripConUsuarios;
        private System.Windows.Forms.ToolStripMenuItem stripConClientes;
        private System.Windows.Forms.ToolStripMenuItem stripConFonecedores;
        private System.Windows.Forms.ToolStripMenuItem ttAlmoxarife;
        private System.Windows.Forms.ToolStripMenuItem stripAlmCompra;
        private System.Windows.Forms.ToolStripMenuItem stripAlmVenda;
        private System.Windows.Forms.ToolStripMenuItem stripAlmProduto;
        private System.Windows.Forms.ToolStripMenuItem stripAlmMarca;
        private System.Windows.Forms.ToolStripMenuItem ttSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ToolStripMenuItem stripAlmVinculo;
        private System.Windows.Forms.ToolStripMenuItem stripAlmCategoria;
    }
}