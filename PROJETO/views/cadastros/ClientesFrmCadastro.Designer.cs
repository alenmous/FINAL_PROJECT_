namespace PROJETO.views.cadastros
{
    partial class ClientesFrmCadastro
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
            this.rbPessoaFisica = new System.Windows.Forms.RadioButton();
            this.rbPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.lbOBCliente = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbOBSexo = new System.Windows.Forms.Label();
            this.lbSexo = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lbCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCodCidade = new System.Windows.Forms.Label();
            this.txtCodCidade = new System.Windows.Forms.TextBox();
            this.lbOBCodCidade = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.lbTelefone = new System.Windows.Forms.Label();
            this.lbCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbOBBairro = new System.Windows.Forms.Label();
            this.lbOBEmail = new System.Windows.Forms.Label();
            this.lbLogradouro = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.lbOBLogradouro = new System.Windows.Forms.Label();
            this.lbComplemento = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.dtNascimento = new System.Windows.Forms.DateTimePicker();
            this.lbNascimento = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbOBStatus = new System.Windows.Forms.Label();
            this.txtCPFouCNPJ = new System.Windows.Forms.TextBox();
            this.txtCodCondicao = new System.Windows.Forms.TextBox();
            this.lbCodigoCondicao = new System.Windows.Forms.Label();
            this.txtCondicao = new System.Windows.Forms.TextBox();
            this.btnBuscarCidades = new System.Windows.Forms.Button();
            this.lbCondicaoPg = new System.Windows.Forms.Label();
            this.btnBuscarCondicaoPG = new System.Windows.Forms.Button();
            this.lbCpfOuCnpj = new System.Windows.Forms.Label();
            this.lbRG = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbApelido = new System.Windows.Forms.Label();
            this.txtApelido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(591, 312);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(26, 109);
            this.txtCodigo.Size = new System.Drawing.Size(78, 24);
            this.txtCodigo.TabIndex = 40;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(26, 89);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(699, 312);
            // 
            // rbPessoaFisica
            // 
            this.rbPessoaFisica.AutoSize = true;
            this.rbPessoaFisica.Checked = true;
            this.rbPessoaFisica.Location = new System.Drawing.Point(27, 25);
            this.rbPessoaFisica.Name = "rbPessoaFisica";
            this.rbPessoaFisica.Size = new System.Drawing.Size(109, 21);
            this.rbPessoaFisica.TabIndex = 10;
            this.rbPessoaFisica.TabStop = true;
            this.rbPessoaFisica.Text = "Pessoa física";
            this.rbPessoaFisica.UseVisualStyleBackColor = true;
            this.rbPessoaFisica.CheckedChanged += new System.EventHandler(this.rbPessoaFisica_CheckedChanged);
            // 
            // rbPessoaJuridica
            // 
            this.rbPessoaJuridica.AutoSize = true;
            this.rbPessoaJuridica.Location = new System.Drawing.Point(144, 25);
            this.rbPessoaJuridica.Name = "rbPessoaJuridica";
            this.rbPessoaJuridica.Size = new System.Drawing.Size(126, 21);
            this.rbPessoaJuridica.TabIndex = 20;
            this.rbPessoaJuridica.Text = "Pessoa Jurídica";
            this.rbPessoaJuridica.UseVisualStyleBackColor = true;
            this.rbPessoaJuridica.CheckedChanged += new System.EventHandler(this.rbPessoaJuridica_CheckedChanged);
            // 
            // lbOBCliente
            // 
            this.lbOBCliente.AutoSize = true;
            this.lbOBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBCliente.Location = new System.Drawing.Point(98, 89);
            this.lbOBCliente.Name = "lbOBCliente";
            this.lbOBCliente.Size = new System.Drawing.Size(13, 17);
            this.lbOBCliente.TabIndex = 1607;
            this.lbOBCliente.Text = "*";
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCliente.ForeColor = System.Drawing.Color.Black;
            this.lbCliente.Location = new System.Drawing.Point(110, 89);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(51, 17);
            this.lbCliente.TabIndex = 1606;
            this.lbCliente.Text = "Cliente";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(113, 108);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(293, 27);
            this.txtNome.TabIndex = 50;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // lbOBSexo
            // 
            this.lbOBSexo.AutoSize = true;
            this.lbOBSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBSexo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBSexo.Location = new System.Drawing.Point(680, 90);
            this.lbOBSexo.Name = "lbOBSexo";
            this.lbOBSexo.Size = new System.Drawing.Size(13, 17);
            this.lbOBSexo.TabIndex = 1613;
            this.lbOBSexo.Text = "*";
            // 
            // lbSexo
            // 
            this.lbSexo.AutoSize = true;
            this.lbSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSexo.ForeColor = System.Drawing.Color.Black;
            this.lbSexo.Location = new System.Drawing.Point(692, 90);
            this.lbSexo.Name = "lbSexo";
            this.lbSexo.Size = new System.Drawing.Size(39, 17);
            this.lbSexo.TabIndex = 1612;
            this.lbSexo.Text = "Sexo";
            // 
            // cmbSexo
            // 
            this.cmbSexo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino"});
            this.cmbSexo.Location = new System.Drawing.Point(696, 108);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(102, 28);
            this.cmbSexo.TabIndex = 65;
            // 
            // lbCidade
            // 
            this.lbCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCidade.AutoSize = true;
            this.lbCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCidade.Location = new System.Drawing.Point(117, 191);
            this.lbCidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(52, 17);
            this.lbCidade.TabIndex = 576;
            this.lbCidade.Text = "Cidade";
            // 
            // txtCidade
            // 
            this.txtCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCidade.Enabled = false;
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.Location = new System.Drawing.Point(120, 214);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtCidade.MaxLength = 100;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(232, 27);
            this.txtCidade.TabIndex = 130;
            // 
            // lblCodCidade
            // 
            this.lblCodCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCodCidade.AutoSize = true;
            this.lblCodCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCidade.Location = new System.Drawing.Point(26, 191);
            this.lblCodCidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodCidade.Name = "lblCodCidade";
            this.lblCodCidade.Size = new System.Drawing.Size(81, 17);
            this.lblCodCidade.TabIndex = 577;
            this.lblCodCidade.Text = "Cód Cidade";
            // 
            // txtCodCidade
            // 
            this.txtCodCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCidade.Location = new System.Drawing.Point(26, 214);
            this.txtCodCidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCidade.MaxLength = 6;
            this.txtCodCidade.Name = "txtCodCidade";
            this.txtCodCidade.Size = new System.Drawing.Size(82, 27);
            this.txtCodCidade.TabIndex = 120;
            this.txtCodCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCidade.Enter += new System.EventHandler(this.txtCodCidade_Enter);
            this.txtCodCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            this.txtCodCidade.Leave += new System.EventHandler(this.txtCodCidade_Leave);
            // 
            // lbOBCodCidade
            // 
            this.lbOBCodCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbOBCodCidade.AutoSize = true;
            this.lbOBCodCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBCodCidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBCodCidade.Location = new System.Drawing.Point(11, 191);
            this.lbOBCodCidade.Name = "lbOBCodCidade";
            this.lbOBCodCidade.Size = new System.Drawing.Size(13, 17);
            this.lbOBCodCidade.TabIndex = 578;
            this.lbOBCodCidade.Text = "*";
            // 
            // txtRG
            // 
            this.txtRG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRG.Location = new System.Drawing.Point(525, 262);
            this.txtRG.Margin = new System.Windows.Forms.Padding(4);
            this.txtRG.MaxLength = 20;
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(122, 27);
            this.txtRG.TabIndex = 200;
            this.txtRG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            this.txtRG.Leave += new System.EventHandler(this.txtRG_Leave);
            // 
            // lbEmail
            // 
            this.lbEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(23, 245);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(47, 17);
            this.lbEmail.TabIndex = 579;
            this.lbEmail.Text = "E-mail";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefone.Location = new System.Drawing.Point(464, 214);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefone.MaxLength = 15;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(163, 27);
            this.txtTelefone.TabIndex = 150;
            this.txtTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            this.txtTelefone.Leave += new System.EventHandler(this.txtTelefone_Leave);
            // 
            // lbTelefone
            // 
            this.lbTelefone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTelefone.AutoSize = true;
            this.lbTelefone.BackColor = System.Drawing.Color.Transparent;
            this.lbTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelefone.ForeColor = System.Drawing.Color.Black;
            this.lbTelefone.Location = new System.Drawing.Point(461, 191);
            this.lbTelefone.Name = "lbTelefone";
            this.lbTelefone.Size = new System.Drawing.Size(64, 17);
            this.lbTelefone.TabIndex = 580;
            this.lbTelefone.Text = "Telefone";
            // 
            // lbCelular
            // 
            this.lbCelular.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCelular.AutoSize = true;
            this.lbCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCelular.ForeColor = System.Drawing.Color.Black;
            this.lbCelular.Location = new System.Drawing.Point(632, 191);
            this.lbCelular.Name = "lbCelular";
            this.lbCelular.Size = new System.Drawing.Size(52, 17);
            this.lbCelular.TabIndex = 581;
            this.lbCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelular.Location = new System.Drawing.Point(635, 214);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(4);
            this.txtCelular.MaxLength = 15;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(163, 27);
            this.txtCelular.TabIndex = 160;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            this.txtCelular.Leave += new System.EventHandler(this.txtCelular_Leave);
            // 
            // lbCep
            // 
            this.lbCep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCep.AutoSize = true;
            this.lbCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCep.ForeColor = System.Drawing.Color.Black;
            this.lbCep.Location = new System.Drawing.Point(697, 138);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(35, 17);
            this.lbCep.TabIndex = 582;
            this.lbCep.Text = "CEP";
            // 
            // txtCep
            // 
            this.txtCep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(697, 157);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4);
            this.txtCep.MaxLength = 9;
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(101, 27);
            this.txtCep.TabIndex = 110;
            // 
            // lbBairro
            // 
            this.lbBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBairro.AutoSize = true;
            this.lbBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBairro.ForeColor = System.Drawing.Color.Black;
            this.lbBairro.Location = new System.Drawing.Point(548, 138);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(46, 17);
            this.lbBairro.TabIndex = 583;
            this.lbBairro.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(549, 157);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(4);
            this.txtBairro.MaxLength = 100;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(142, 27);
            this.txtBairro.TabIndex = 100;
            this.txtBairro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(26, 262);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 27);
            this.txtEmail.TabIndex = 170;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lbOBBairro
            // 
            this.lbOBBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbOBBairro.AutoSize = true;
            this.lbOBBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBBairro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBBairro.Location = new System.Drawing.Point(533, 138);
            this.lbOBBairro.Name = "lbOBBairro";
            this.lbOBBairro.Size = new System.Drawing.Size(13, 17);
            this.lbOBBairro.TabIndex = 584;
            this.lbOBBairro.Text = "*";
            // 
            // lbOBEmail
            // 
            this.lbOBEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbOBEmail.AutoSize = true;
            this.lbOBEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBEmail.Location = new System.Drawing.Point(12, 245);
            this.lbOBEmail.Name = "lbOBEmail";
            this.lbOBEmail.Size = new System.Drawing.Size(13, 17);
            this.lbOBEmail.TabIndex = 586;
            this.lbOBEmail.Text = "*";
            // 
            // lbLogradouro
            // 
            this.lbLogradouro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLogradouro.AutoSize = true;
            this.lbLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogradouro.ForeColor = System.Drawing.Color.Black;
            this.lbLogradouro.Location = new System.Drawing.Point(26, 138);
            this.lbLogradouro.Name = "lbLogradouro";
            this.lbLogradouro.Size = new System.Drawing.Size(82, 17);
            this.lbLogradouro.TabIndex = 587;
            this.lbLogradouro.Text = "Logradouro";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogradouro.Location = new System.Drawing.Point(26, 157);
            this.txtLogradouro.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogradouro.MaxLength = 255;
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(242, 27);
            this.txtLogradouro.TabIndex = 70;
            this.txtLogradouro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // lbOBLogradouro
            // 
            this.lbOBLogradouro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbOBLogradouro.AutoSize = true;
            this.lbOBLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBLogradouro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBLogradouro.Location = new System.Drawing.Point(11, 138);
            this.lbOBLogradouro.Name = "lbOBLogradouro";
            this.lbOBLogradouro.Size = new System.Drawing.Size(13, 17);
            this.lbOBLogradouro.TabIndex = 588;
            this.lbOBLogradouro.Text = "*";
            // 
            // lbComplemento
            // 
            this.lbComplemento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbComplemento.AutoSize = true;
            this.lbComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComplemento.ForeColor = System.Drawing.Color.Black;
            this.lbComplemento.Location = new System.Drawing.Point(366, 138);
            this.lbComplemento.Name = "lbComplemento";
            this.lbComplemento.Size = new System.Drawing.Size(94, 17);
            this.lbComplemento.TabIndex = 589;
            this.lbComplemento.Text = "Complemento";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComplemento.Location = new System.Drawing.Point(368, 157);
            this.txtComplemento.Margin = new System.Windows.Forms.Padding(4);
            this.txtComplemento.MaxLength = 200;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(173, 27);
            this.txtComplemento.TabIndex = 90;
            this.txtComplemento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // lbNumero
            // 
            this.lbNumero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNumero.AutoSize = true;
            this.lbNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.ForeColor = System.Drawing.Color.Black;
            this.lbNumero.Location = new System.Drawing.Point(274, 138);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(58, 17);
            this.lbNumero.TabIndex = 590;
            this.lbNumero.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(276, 157);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumero.MaxLength = 6;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(84, 27);
            this.txtNumero.TabIndex = 80;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            // 
            // dtNascimento
            // 
            this.dtNascimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtNascimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNascimento.Location = new System.Drawing.Point(199, 262);
            this.dtNascimento.Name = "dtNascimento";
            this.dtNascimento.Size = new System.Drawing.Size(319, 27);
            this.dtNascimento.TabIndex = 180;
            // 
            // lbNascimento
            // 
            this.lbNascimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNascimento.AutoSize = true;
            this.lbNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNascimento.ForeColor = System.Drawing.Color.Black;
            this.lbNascimento.Location = new System.Drawing.Point(196, 242);
            this.lbNascimento.Name = "lbNascimento";
            this.lbNascimento.Size = new System.Drawing.Size(134, 17);
            this.lbNascimento.TabIndex = 591;
            this.lbNascimento.Text = "Data de nascimento";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "ATIVO",
            "INATIVO"});
            this.cmbStatus.Location = new System.Drawing.Point(715, 25);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(84, 28);
            this.cmbStatus.TabIndex = 30;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(713, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 593;
            this.lblStatus.Text = "Status";
            // 
            // lbOBStatus
            // 
            this.lbOBStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbOBStatus.AutoSize = true;
            this.lbOBStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOBStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOBStatus.Location = new System.Drawing.Point(700, 7);
            this.lbOBStatus.Name = "lbOBStatus";
            this.lbOBStatus.Size = new System.Drawing.Size(13, 17);
            this.lbOBStatus.TabIndex = 594;
            this.lbOBStatus.Text = "*";
            // 
            // txtCPFouCNPJ
            // 
            this.txtCPFouCNPJ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCPFouCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPFouCNPJ.Location = new System.Drawing.Point(655, 262);
            this.txtCPFouCNPJ.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPFouCNPJ.MaxLength = 20;
            this.txtCPFouCNPJ.Name = "txtCPFouCNPJ";
            this.txtCPFouCNPJ.Size = new System.Drawing.Size(143, 27);
            this.txtCPFouCNPJ.TabIndex = 210;
            this.txtCPFouCNPJ.Enter += new System.EventHandler(this.txtCodCidade_Enter);
            this.txtCPFouCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            this.txtCPFouCNPJ.Leave += new System.EventHandler(this.txtCPFouCNPJ_Leave);
            // 
            // txtCodCondicao
            // 
            this.txtCodCondicao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodCondicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCondicao.Location = new System.Drawing.Point(26, 313);
            this.txtCodCondicao.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCondicao.MaxLength = 100;
            this.txtCodCondicao.Name = "txtCodCondicao";
            this.txtCodCondicao.Size = new System.Drawing.Size(96, 27);
            this.txtCodCondicao.TabIndex = 220;
            this.txtCodCondicao.TabStop = false;
            this.txtCodCondicao.Enter += new System.EventHandler(this.txtCodCidade_Enter);
            this.txtCodCondicao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            this.txtCodCondicao.Leave += new System.EventHandler(this.txtCodCondicao_Leave);
            // 
            // lbCodigoCondicao
            // 
            this.lbCodigoCondicao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCodigoCondicao.AutoSize = true;
            this.lbCodigoCondicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbCodigoCondicao.Location = new System.Drawing.Point(26, 295);
            this.lbCodigoCondicao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCodigoCondicao.Name = "lbCodigoCondicao";
            this.lbCodigoCondicao.Size = new System.Drawing.Size(52, 17);
            this.lbCodigoCondicao.TabIndex = 595;
            this.lbCodigoCondicao.Text = "Código";
            // 
            // txtCondicao
            // 
            this.txtCondicao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCondicao.Enabled = false;
            this.txtCondicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicao.Location = new System.Drawing.Point(127, 313);
            this.txtCondicao.Margin = new System.Windows.Forms.Padding(4);
            this.txtCondicao.MaxLength = 100;
            this.txtCondicao.Name = "txtCondicao";
            this.txtCondicao.ReadOnly = true;
            this.txtCondicao.Size = new System.Drawing.Size(237, 27);
            this.txtCondicao.TabIndex = 230;
            // 
            // btnBuscarCidades
            // 
            this.btnBuscarCidades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarCidades.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscarCidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCidades.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCidades.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCidades.Location = new System.Drawing.Point(360, 213);
            this.btnBuscarCidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCidades.Name = "btnBuscarCidades";
            this.btnBuscarCidades.Size = new System.Drawing.Size(100, 28);
            this.btnBuscarCidades.TabIndex = 140;
            this.btnBuscarCidades.Text = "BUSCAR";
            this.btnBuscarCidades.UseVisualStyleBackColor = false;
            this.btnBuscarCidades.Click += new System.EventHandler(this.btnBuscarCidades_Click);
            // 
            // lbCondicaoPg
            // 
            this.lbCondicaoPg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCondicaoPg.AutoSize = true;
            this.lbCondicaoPg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbCondicaoPg.Location = new System.Drawing.Point(125, 295);
            this.lbCondicaoPg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCondicaoPg.Name = "lbCondicaoPg";
            this.lbCondicaoPg.Size = new System.Drawing.Size(163, 17);
            this.lbCondicaoPg.TabIndex = 596;
            this.lbCondicaoPg.Text = "Condição de Pagamento";
            // 
            // btnBuscarCondicaoPG
            // 
            this.btnBuscarCondicaoPG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarCondicaoPG.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscarCondicaoPG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCondicaoPG.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCondicaoPG.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCondicaoPG.Location = new System.Drawing.Point(372, 312);
            this.btnBuscarCondicaoPG.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCondicaoPG.Name = "btnBuscarCondicaoPG";
            this.btnBuscarCondicaoPG.Size = new System.Drawing.Size(100, 28);
            this.btnBuscarCondicaoPG.TabIndex = 240;
            this.btnBuscarCondicaoPG.Text = "BUSCAR";
            this.btnBuscarCondicaoPG.UseVisualStyleBackColor = false;
            this.btnBuscarCondicaoPG.Click += new System.EventHandler(this.btnBuscarCondicaoPG_Click);
            // 
            // lbCpfOuCnpj
            // 
            this.lbCpfOuCnpj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCpfOuCnpj.AutoSize = true;
            this.lbCpfOuCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCpfOuCnpj.ForeColor = System.Drawing.Color.Black;
            this.lbCpfOuCnpj.Location = new System.Drawing.Point(653, 243);
            this.lbCpfOuCnpj.Name = "lbCpfOuCnpj";
            this.lbCpfOuCnpj.Size = new System.Drawing.Size(81, 17);
            this.lbCpfOuCnpj.TabIndex = 598;
            this.lbCpfOuCnpj.Text = "CPF / CNPJ";
            // 
            // lbRG
            // 
            this.lbRG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbRG.AutoSize = true;
            this.lbRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRG.ForeColor = System.Drawing.Color.Black;
            this.lbRG.Location = new System.Drawing.Point(525, 243);
            this.lbRG.Name = "lbRG";
            this.lbRG.Size = new System.Drawing.Size(29, 17);
            this.lbRG.TabIndex = 599;
            this.lbRG.Text = "RG";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(181, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 600;
            this.label1.Text = "*";
            // 
            // lblCpf
            // 
            this.lblCpf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCpf.AutoSize = true;
            this.lblCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCpf.Location = new System.Drawing.Point(640, 243);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(13, 17);
            this.lblCpf.TabIndex = 601;
            this.lblCpf.Text = "*";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(11, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 603;
            this.label2.Text = "*";
            // 
            // lbApelido
            // 
            this.lbApelido.AutoSize = true;
            this.lbApelido.Location = new System.Drawing.Point(411, 88);
            this.lbApelido.Name = "lbApelido";
            this.lbApelido.Size = new System.Drawing.Size(55, 17);
            this.lbApelido.TabIndex = 1614;
            this.lbApelido.Text = "Apelido";
            // 
            // txtApelido
            // 
            this.txtApelido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApelido.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApelido.Location = new System.Drawing.Point(414, 109);
            this.txtApelido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApelido.MaxLength = 50;
            this.txtApelido.Name = "txtApelido";
            this.txtApelido.Size = new System.Drawing.Size(275, 27);
            this.txtApelido.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(398, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 17);
            this.label3.TabIndex = 1616;
            this.label3.Text = "*";
            // 
            // ClientesFrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(841, 389);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApelido);
            this.Controls.Add(this.lbApelido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRG);
            this.Controls.Add(this.lbCpfOuCnpj);
            this.Controls.Add(this.lbOBSexo);
            this.Controls.Add(this.lbCondicaoPg);
            this.Controls.Add(this.btnBuscarCondicaoPG);
            this.Controls.Add(this.txtCondicao);
            this.Controls.Add(this.lbSexo);
            this.Controls.Add(this.lbCodigoCondicao);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.txtCodCondicao);
            this.Controls.Add(this.btnBuscarCidades);
            this.Controls.Add(this.txtCPFouCNPJ);
            this.Controls.Add(this.lbNascimento);
            this.Controls.Add(this.lbOBLogradouro);
            this.Controls.Add(this.txtLogradouro);
            this.Controls.Add(this.lbOBCliente);
            this.Controls.Add(this.lbLogradouro);
            this.Controls.Add(this.lbCliente);
            this.Controls.Add(this.lbOBBairro);
            this.Controls.Add(this.lbOBStatus);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.lbBairro);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lbCep);
            this.Controls.Add(this.rbPessoaJuridica);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lbCelular);
            this.Controls.Add(this.rbPessoaFisica);
            this.Controls.Add(this.txtRG);
            this.Controls.Add(this.lbOBCodCidade);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtCodCidade);
            this.Controls.Add(this.dtNascimento);
            this.Controls.Add(this.lblCodCidade);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.lbCidade);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtComplemento);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbComplemento);
            this.Controls.Add(this.lbOBEmail);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.lbTelefone);
            this.Name = "ClientesFrmCadastro";
            this.Text = "Cadastro de Clientes";
            this.Controls.SetChildIndex(this.lbTelefone, 0);
            this.Controls.SetChildIndex(this.txtCidade, 0);
            this.Controls.SetChildIndex(this.txtTelefone, 0);
            this.Controls.SetChildIndex(this.lbOBEmail, 0);
            this.Controls.SetChildIndex(this.lbComplemento, 0);
            this.Controls.SetChildIndex(this.lbEmail, 0);
            this.Controls.SetChildIndex(this.txtComplemento, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.lbCidade, 0);
            this.Controls.SetChildIndex(this.lbNumero, 0);
            this.Controls.SetChildIndex(this.lblCodCidade, 0);
            this.Controls.SetChildIndex(this.dtNascimento, 0);
            this.Controls.SetChildIndex(this.txtCodCidade, 0);
            this.Controls.SetChildIndex(this.txtNumero, 0);
            this.Controls.SetChildIndex(this.lbOBCodCidade, 0);
            this.Controls.SetChildIndex(this.txtRG, 0);
            this.Controls.SetChildIndex(this.rbPessoaFisica, 0);
            this.Controls.SetChildIndex(this.lbCelular, 0);
            this.Controls.SetChildIndex(this.cmbStatus, 0);
            this.Controls.SetChildIndex(this.txtCelular, 0);
            this.Controls.SetChildIndex(this.rbPessoaJuridica, 0);
            this.Controls.SetChildIndex(this.lbCep, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.txtCep, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lbBairro, 0);
            this.Controls.SetChildIndex(this.txtBairro, 0);
            this.Controls.SetChildIndex(this.lbOBStatus, 0);
            this.Controls.SetChildIndex(this.lbOBBairro, 0);
            this.Controls.SetChildIndex(this.lbCliente, 0);
            this.Controls.SetChildIndex(this.lbLogradouro, 0);
            this.Controls.SetChildIndex(this.lbOBCliente, 0);
            this.Controls.SetChildIndex(this.txtLogradouro, 0);
            this.Controls.SetChildIndex(this.lbOBLogradouro, 0);
            this.Controls.SetChildIndex(this.lbNascimento, 0);
            this.Controls.SetChildIndex(this.txtCPFouCNPJ, 0);
            this.Controls.SetChildIndex(this.btnBuscarCidades, 0);
            this.Controls.SetChildIndex(this.txtCodCondicao, 0);
            this.Controls.SetChildIndex(this.cmbSexo, 0);
            this.Controls.SetChildIndex(this.lbCodigoCondicao, 0);
            this.Controls.SetChildIndex(this.lbSexo, 0);
            this.Controls.SetChildIndex(this.txtCondicao, 0);
            this.Controls.SetChildIndex(this.btnBuscarCondicaoPG, 0);
            this.Controls.SetChildIndex(this.lbCondicaoPg, 0);
            this.Controls.SetChildIndex(this.lbOBSexo, 0);
            this.Controls.SetChildIndex(this.lbCpfOuCnpj, 0);
            this.Controls.SetChildIndex(this.lbRG, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblCpf, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.btnSalvar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.lbApelido, 0);
            this.Controls.SetChildIndex(this.txtApelido, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.RadioButton rbPessoaFisica;
        public System.Windows.Forms.RadioButton rbPessoaJuridica;
        protected System.Windows.Forms.Label lbOBCliente;
        protected System.Windows.Forms.Label lbCliente;
        protected System.Windows.Forms.TextBox txtNome;
        protected System.Windows.Forms.Label lbOBSexo;
        protected System.Windows.Forms.Label lbSexo;
        protected System.Windows.Forms.ComboBox cmbSexo;
        protected System.Windows.Forms.Label lbCidade;
        protected System.Windows.Forms.TextBox txtCidade;
        protected System.Windows.Forms.Label lblCodCidade;
        protected System.Windows.Forms.TextBox txtCodCidade;
        protected System.Windows.Forms.Label lbOBCodCidade;
        protected System.Windows.Forms.TextBox txtRG;
        protected System.Windows.Forms.Label lbEmail;
        protected System.Windows.Forms.TextBox txtTelefone;
        protected System.Windows.Forms.Label lbTelefone;
        protected System.Windows.Forms.Label lbCelular;
        protected System.Windows.Forms.TextBox txtCelular;
        protected System.Windows.Forms.Label lbCep;
        protected System.Windows.Forms.TextBox txtCep;
        protected System.Windows.Forms.Label lbBairro;
        protected System.Windows.Forms.TextBox txtBairro;
        protected System.Windows.Forms.TextBox txtEmail;
        protected System.Windows.Forms.Label lbOBBairro;
        protected System.Windows.Forms.Label lbOBEmail;
        protected System.Windows.Forms.Label lbLogradouro;
        protected System.Windows.Forms.TextBox txtLogradouro;
        protected System.Windows.Forms.Label lbOBLogradouro;
        protected System.Windows.Forms.Label lbComplemento;
        protected System.Windows.Forms.TextBox txtComplemento;
        protected System.Windows.Forms.Label lbNumero;
        protected System.Windows.Forms.TextBox txtNumero;
        protected System.Windows.Forms.DateTimePicker dtNascimento;
        protected System.Windows.Forms.Label lbNascimento;
        public System.Windows.Forms.ComboBox cmbStatus;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.Label lbOBStatus;
        protected System.Windows.Forms.TextBox txtCPFouCNPJ;
        protected System.Windows.Forms.TextBox txtCodCondicao;
        protected System.Windows.Forms.Label lbCodigoCondicao;
        protected System.Windows.Forms.TextBox txtCondicao;
        protected System.Windows.Forms.Button btnBuscarCidades;
        protected System.Windows.Forms.Label lbCondicaoPg;
        protected System.Windows.Forms.Button btnBuscarCondicaoPG;
        protected System.Windows.Forms.Label lbCpfOuCnpj;
        protected System.Windows.Forms.Label lbRG;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label lblCpf;
        protected System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbApelido;
        protected System.Windows.Forms.TextBox txtApelido;
        protected System.Windows.Forms.Label label3;
    }
}
