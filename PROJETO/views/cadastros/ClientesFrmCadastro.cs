using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.views.consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.cadastros
{
    public partial class ClientesFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        private CidadesFrmConsulta cidadesFrmConsulta;
        private ClientesController clientesController;
        private Clientes oCliente;
        private enum TipoCliente { PessoaFisica, PessoaJuridica }
        private TipoCliente tipoClienteAtual;
        private bool isBrasil = false;
        Clientes ClienteAntigo;

        public ClientesFrmCadastro()
        {
            InitializeComponent();
            Instanciar();
            Operacao.DisableCopyPaste(this);
            ConfigurarEstadoInicial();
            rbPessoaFisica.CheckedChanged += rbPessoaFisica_CheckedChanged;
            rbPessoaJuridica.CheckedChanged += rbPessoaJuridica_CheckedChanged;
            rbPessoaFisica.Checked = true;
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Clientes cliente)
            {
                oCliente = cliente;
                CarregarCampos();
            }
        }
        protected override void LimparCampos()
        {
            // Limpar todos os campos do formulário
            txtCodigo.Clear();
            txtNome.Clear();
            txtApelido.Clear();
            dtNascimento.Value = DateTime.Now;
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtCep.Clear();
            txtCodCidade.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtLogradouro.Clear();
            txtComplemento.Clear();
            txtNumero.Clear();
            txtCodCondicao.Clear();
            txtCondicao.Clear();
            cmbStatus.SelectedIndex = 0;

            // Limpar campos específicos por tipo
            if (tipoClienteAtual == TipoCliente.PessoaFisica)
            {
                cmbSexo.SelectedIndex = 0;
                txtRG.Clear();
            }

            txtCPFouCNPJ.Clear();

            // Resetar estado
            isBrasil = false;
            AtualizarCamposDocumentacao();
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtNome.Enabled = false;
            txtRG.Enabled = false;
            txtCPFouCNPJ.Enabled = false;
            cmbSexo.Enabled = false;
            txtApelido.Enabled = false;
            dtNascimento.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefone.Enabled = false;
            txtCelular.Enabled = false;
            txtCep.Enabled = false;
            txtCodCidade.Enabled = false;
            txtCidade.Enabled = false;
            txtBairro.Enabled = false;
            txtLogradouro.Enabled = false;
            txtComplemento.Enabled = false;
            txtNumero.Enabled = false;
            txtCodigo.Enabled = false;
            btnBuscarCidades.Enabled = false;
            cmbStatus.Enabled = false;
            btnBuscarCondicaoPG.Enabled = false;
            txtCodCondicao.Enabled = false;
            txtCondicao.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.BloquearCampos();
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtRG.Enabled = true;
            txtCPFouCNPJ.Enabled = true;
            cmbSexo.Enabled = true;
            txtApelido.Enabled = true;
            dtNascimento.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefone.Enabled = true;
            txtCelular.Enabled = true;
            txtCep.Enabled = true;
            txtCodCidade.Enabled = true;
            txtCidade.Enabled = true;
            txtBairro.Enabled = true;
            txtLogradouro.Enabled = true;
            txtComplemento.Enabled = true;
            txtNumero.Enabled = true;
            txtCodigo.Enabled = true;
            btnBuscarCidades.Enabled = true;
            //  cmbStatus.Enabled = true;
            btnBuscarCondicaoPG.Enabled = true;
            txtCodCondicao.Enabled = true;
            txtCondicao.Enabled = true;
        }
        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
                Salvar();
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este cliente?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExcluirCliente();
                }
            }
        }
        private void ExcluirCliente()
        {
            if (oCliente != null)
            {
                try
                {
                    var result = clientesController.ExcluirCliente(oCliente.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o cliente. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o cliente devido a outros registros estarem vinculados a este cliente.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o cliente. Detalhes: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    // Trate outras exceções gerais, se necessário
                    MessageBox.Show("Ocorreu um erro inesperado. Detalhes: " + ex.Message);
                }
            }
        }
        private void Instanciar()
        {
            oCliente = new Clientes();
            clientesController = new ClientesController();
            ClienteAntigo = new Clientes();

        }
        private void ConfigurarEstadoInicial()
        {
            // Configurações iniciais padrão
            rbPessoaFisica.Checked = true;
            AtualizarTipoCliente(TipoCliente.PessoaFisica, true);
        }
        private void AtualizarTipoCliente(TipoCliente tipo, bool limparCampos)
        {
            tipoClienteAtual = tipo;

            if (tipo == TipoCliente.PessoaFisica)
            {
                ConfigurarFormularioParaPessoaFisica();
            }
            else
            {
               ConfigurarFormularioParaPessoaJuridica();
            }

            AtualizarCamposDocumentacao();

            if (limparCampos) LimparCampos();
        }
        private void AtualizarCamposDocumentacao()
        {
            // Atualiza a visibilidade e obrigatoriedade dos campos de documentação
            bool mostrarDocumentacaoBrasil = isBrasil;

            // Configuração para Pessoa Física
            if (tipoClienteAtual == TipoCliente.PessoaFisica)
            {
                if (isBrasil == true)
                {
                    lblCpf.Visible = true;
                    txtRG.Enabled = true;
                    txtCPFouCNPJ.Enabled = true;
                }
                else
                {
                    lblCpf.Visible = false;
                    txtRG.Enabled = true;
                    txtCPFouCNPJ.Enabled = true;
                }

            }
            // Configuração para Pessoa Jurídica
            else
            {
                if (isBrasil == true)
                {
                    lblCpf.Visible = mostrarDocumentacaoBrasil;
                    txtCPFouCNPJ.Enabled = mostrarDocumentacaoBrasil;
                }
                else
                {
                    lblCpf.Visible = false;
                    txtCPFouCNPJ.Enabled = true;
                }


            }


            txtCPFouCNPJ.Clear();
            txtRG.Clear();

        }

        private bool ValidarCamposObrigatorios()
        {
            List<string> erros = new List<string>();

            // Validações comuns
            if (string.IsNullOrWhiteSpace(txtNome.Text)) erros.Add("Nome");
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) erros.Add("E-mail");
            if (string.IsNullOrWhiteSpace(txtBairro.Text)) erros.Add("Bairro");
            if (string.IsNullOrWhiteSpace(txtLogradouro.Text)) erros.Add("Logradouro");
            if (string.IsNullOrWhiteSpace(cmbStatus.Text)) erros.Add("Status");
            if (dtNascimento.Value > DateTime.Now) erros.Add("Data (não pode ser futura)");

            // Validação de cidade
            if (!int.TryParse(txtCodCidade.Text, out int codCidade) || codCidade <= 0)
            {
                erros.Add("Cidade (código inválido)");
            }

            // Validações específicas por tipo de cliente e país
            if (isBrasil)
            {
                if (tipoClienteAtual == TipoCliente.PessoaFisica)
                {
                    if (string.IsNullOrWhiteSpace(txtCPFouCNPJ.Text)) erros.Add("CPF");
                    else if (!Operacao.IsCpf(txtCPFouCNPJ.Text)) erros.Add("CPF (inválido)");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtCPFouCNPJ.Text)) erros.Add("CNPJ");
                    else if (!Operacao.IsCnpj(txtCPFouCNPJ.Text)) erros.Add("CNPJ (inválido)");
                }
            }

            if (erros.Count > 0)
            {
                MessageBox.Show($"Os seguintes campos são obrigatórios:\n{string.Join("\n", erros)}",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void rbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPessoaFisica.Checked)
            {
                ConfigurarFormularioParaPessoaFisica();
            }
        }
        private void ConfigurarFormularioParaPessoaFisica()
        {
            // Configuração de controles visíveis
            cmbSexo.Visible = true;
            lbSexo.Visible = true;
            lbOBSexo.Visible = true;
            lbRG.Visible = true;
            txtRG.Visible = true;

            // Configuração de textos e tamanhos
            lbCliente.Text = "Cliente";
            lbApelido.Text = "Apelido";
            lbNascimento.Text = "Data de nascimento";
            lbCpfOuCnpj.Text = "CPF";

            // Configuração de estado
            tipoClienteAtual = TipoCliente.PessoaFisica;
            txtApelido.Size = new Size(275, 27);
            dtNascimento.Size = new Size(319, 27);

            // Atualiza campos de documentação conforme país
            AtualizarCamposDocumentacao();

            // Limpa campos específicos ao mudar o tipo
            LimparCamposAoMudarTipo();
        }
        private void rbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPessoaJuridica.Checked)
            {
                ConfigurarFormularioParaPessoaJuridica();
            }
        }
        private void ConfigurarFormularioParaPessoaJuridica()
        {
            // Configuração de controles visíveis
            cmbSexo.Visible = false;
            lbSexo.Visible = false;
            lbOBSexo.Visible = false;
            lbRG.Visible = false;
            txtRG.Visible = false;

            // Configuração de textos e tamanhos
            lbCliente.Text = "Razão Social";
            lbApelido.Text = "Nome Fantasia";
            lbNascimento.Text = "Data Fundação";
            lbCpfOuCnpj.Text = "CNPJ";


            // Configuração de estado
            tipoClienteAtual = TipoCliente.PessoaJuridica;
            txtApelido.Size = new Size(384, 27);
            dtNascimento.Size = new Size(449, 27);

            // Atualiza campos de documentação conforme país
            AtualizarCamposDocumentacao();

            // Limpa campos específicos ao mudar o tipo
            LimparCamposAoMudarTipo();
        }
        private void LimparCamposAoMudarTipo()
        {
            // Limpa campos que são específicos de cada tipo
            txtCPFouCNPJ.Clear();
            txtRG.Clear();

            if (tipoClienteAtual == TipoCliente.PessoaFisica)
            {
                cmbSexo.SelectedIndex = 0;
            }
        }
        protected override void Salvar()
        {
            // Validate mandatory fields upfront
            if (!ValidarCamposObrigatorios())
                return;

            PreencherObjetoCliente();

            // Determine creation vs update
            oCliente.DataUltimaAlteracao = DateTime.Now;
            if (oCliente.ID == 0)
                oCliente.DataCriacao = DateTime.Now;

            string resultado = (oCliente.ID == 0)
                ? clientesController.AdicionarCliente(oCliente)
                : clientesController.AtualizarCliente(oCliente);

            // Display operation result
            if (resultado == "OK")
            {
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Erro ao salvar cliente: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherObjetoCliente()
        {
            oCliente.TipoCliente = (tipoClienteAtual == TipoCliente.PessoaFisica) ? "F" : "J";
            oCliente.Nome = txtNome.Text.Trim();
            oCliente.Apelido = txtApelido.Text.Trim();
            oCliente.DataNasc = dtNascimento.Value;
            oCliente.Email = txtEmail.Text.Trim();
            oCliente.Telefone = txtTelefone.Text.Trim();
            oCliente.Celular = txtCelular.Text.Trim();
            oCliente.CEP = txtCep.Text.Trim();
            oCliente.Bairro = txtBairro.Text.Trim();
            oCliente.Endereco = txtLogradouro.Text.Trim();
            oCliente.Complemento = txtComplemento.Text.Trim();
            oCliente.Numero = string.IsNullOrEmpty(txtNumero.Text) ? 0 : Convert.ToInt32(txtNumero.Text);
            oCliente.StatusCliente = cmbStatus.Text.Substring(0, 1); // First character only
            oCliente.CondicaoPagamento.ID = Convert.ToInt32(txtCodCondicao.Text);

            if (tipoClienteAtual == TipoCliente.PessoaFisica)
            {
                oCliente.Sexo = cmbSexo.Text.Substring(0, 1); // "M" or "F"
                oCliente.RG = txtRG.Text.Trim();
                oCliente.CPF = txtCPFouCNPJ.Text.Trim();
                oCliente.CNPJ = null; // Ensure CNPJ is null for PF
            }
            else
            {
                oCliente.Sexo = null; // Not applicable for PJ
                oCliente.RG = null;
                oCliente.CNPJ = null;
                oCliente.CPF = txtCPFouCNPJ.Text.Trim(); 
            }

            oCliente.Cidade.ID = Convert.ToInt32(txtCodCidade.Text);
        }
        public override void CarregarCampos()
        {
            if (oCliente == null || oCliente.ID == 0)
            {
                LimparCampos();
                return;
            }

            // Configurar tipo de cliente
            if (oCliente.TipoCliente == "F")
            {
                rbPessoaFisica.Checked = true;
                ConfigurarFormularioParaPessoaFisica();
            }
            else
            {
                rbPessoaJuridica.Checked = true;
                ConfigurarFormularioParaPessoaJuridica();
            }

            // Carregar dados básicos
            txtCodigo.Text = oCliente.ID.ToString();
            txtNome.Text = oCliente.Nome;
            txtApelido.Text = oCliente.Apelido;
            dtNascimento.Value = oCliente.DataNasc;
            txtEmail.Text = oCliente.Email;
            txtTelefone.Text = oCliente.Telefone;
            txtCelular.Text = oCliente.Celular;
            txtCep.Text = oCliente.CEP;
            txtBairro.Text = oCliente.Bairro;
            txtLogradouro.Text = oCliente.Endereco;
            txtComplemento.Text = oCliente.Complemento;
            txtNumero.Text = oCliente.Numero > 0 ? oCliente.Numero.ToString() : "";
            cmbStatus.Text = oCliente.StatusCliente == "A" ? "Ativo" : "Inativo";
            txtCodCondicao.Text = oCliente.CondicaoPagamento.ID.ToString();
            txtCondicao.Text = oCliente.CondicaoPagamento.Condicao;

            // Carregar cidade
            if (oCliente.Cidade != null && oCliente.Cidade.ID > 0)
            {
                txtCodCidade.Text = oCliente.Cidade.ID.ToString();
                txtCidade.Text = oCliente.Cidade.Cidade;
                isBrasil = oCliente.Cidade.OEstado?.OPais?.Pais.Equals("Brasil", StringComparison.OrdinalIgnoreCase) ?? false;
                AtualizarCamposDocumentacao();
            }

            // Carregar campos específicos por tipo
            if (tipoClienteAtual == TipoCliente.PessoaFisica)
            {
                cmbSexo.Text = oCliente.Sexo == "M" ? "Masculino" : "Feminino";
                txtRG.Text = oCliente.RG;
                txtCPFouCNPJ.Text = oCliente.CPF;
            }
            else
            {
                txtCPFouCNPJ.Text = oCliente.CNPJ;
            }

            if(tipoClienteAtual == TipoCliente.PessoaJuridica)
            {
                txtCPFouCNPJ.Text = oCliente.CPF;
            }


            // Guardar cópia do cliente original para comparação
            ClienteAntigo = oCliente;
        }
        private void ValidarDocumento()
        {
            string documento = txtCPFouCNPJ.Text.Trim();

            // Verifica duplicidade independentemente de obrigatoriedade
            if (VerificarDocumentoDuplicado(documento))
            {
                txtCPFouCNPJ.Focus();
                txtCPFouCNPJ.SelectAll();
                return;
            }

            // Segue com outras validações apenas se necessário
            if (string.IsNullOrEmpty(documento))
            {
                return; // Campo vazio, não valida formato
            }

            bool documentoValido = false;
            string mensagemErro = "";

            if (tipoClienteAtual == TipoCliente.PessoaFisica)
            {
                documentoValido = Operacao.IsCpf(documento);
                mensagemErro = "CPF inválido";
            }
            else if (tipoClienteAtual == TipoCliente.PessoaJuridica)
            {
                documentoValido = Operacao.IsCnpj(documento);
                mensagemErro = "CNPJ inválido";
            }

            if (isBrasil && !documentoValido)
            {
                MessageBox.Show($"{mensagemErro}. Por favor, insira um documento válido.",
                                "Documento Inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtCPFouCNPJ.Focus();
                txtCPFouCNPJ.SelectAll();
                return;
            }

            this.AcceptButton = btnSalvar;
        }
        private bool VerificarDocumentoDuplicado(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                return false; // Documento vazio não é considerado duplicado
            }

            string resultado = clientesController.BuscarClientePorDocumento(documento);
            if (resultado != "OK" && documento != (tipoClienteAtual == TipoCliente.PessoaFisica ? ClienteAntigo.CPF : ClienteAntigo.CNPJ))
            {
                MessageBox.Show("Documento já cadastrado. Por favor, insira um documento único.",
                                "Documento Duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return true; // Documento duplicado
            }

            return false; // Documento único
        }
        protected virtual void txtCPFouCNPJ_Leave(object sender, EventArgs e)
        {
            ValidarDocumento();
        }
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            Operacao.BloquearKeyDowControlC(sender, e);
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!string.IsNullOrEmpty(email) && !Operacao.IsEmail(email))
            {
                MessageBox.Show("Endereço de e-mail inválido. Por favor, insira um e-mail válido.");
                txtEmail.Focus();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            string fone = txtTelefone.Text.Trim();

            if (!string.IsNullOrEmpty(fone) && !Operacao.IsTelefone(fone))
            {
                MessageBox.Show("Número de telefone inválido. Por favor, insira um Número válido.");
                txtTelefone.Focus();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);

        }
        private void txtCelular_Leave(object sender, EventArgs e)
        {
            string fone = txtCelular.Text.Trim();

            if (!string.IsNullOrEmpty(fone) && !Operacao.IsTelefone(fone))
            {
                MessageBox.Show("Número de celular inválido. Por favor, insira um Número válido.");
                txtCelular.Focus();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        protected virtual void txtCodCidade_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão
        }
        protected virtual void txtCodCidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCidade.Text))
            {
                LimparCamposCidade();
                return;
            }

            if (!int.TryParse(txtCodCidade.Text, out int cod) || cod <= 0)
            {
                MessageBox.Show("Código inválido. Deve ser um número maior que zero.");
                LimparCamposCidade();
                return;
            }

            CidadesController aCTLCidade = new CidadesController();
            Cidades cidade = aCTLCidade.BuscarCidadePorId(cod);

            if (cidade == null)
            {
                MessageBox.Show("Cidade não encontrada.");
                LimparCamposCidade();
                return;
            }

            if (cidade.StatusCidade == "I" &&
                MessageBox.Show("Cidade inativa. Deseja continuar?", "Confirmação",
                              MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                LimparCamposCidade();
                return;
            }

            // Atualiza estado do país
            isBrasil = cidade.OEstado.OPais.Pais.Equals("Brasil", StringComparison.OrdinalIgnoreCase);

            // Atualiza campos da cidade
            txtCidade.Text = cidade.Cidade;

            // Atualiza campos de documentação conforme país
            AtualizarCamposDocumentacao();
        }
        private void LimparCamposCidade()
        {
            txtCodCidade.Clear();
            txtCidade.Clear();
            isBrasil = false;
            AtualizarCamposDocumentacao();
        }
        protected virtual bool VerificarPais()
        {
            if (txtCodCidade.Text != string.Empty)
            {
                CidadesController aCTLCidade = new CidadesController();
                Cidades cidade = aCTLCidade.BuscarCidadePorId(Convert.ToInt32(txtCodCidade.Text));
                bool obrigatorioRGouCPF = cidade.OEstado.OPais.Pais.Equals("Brasil", StringComparison.OrdinalIgnoreCase);
                return obrigatorioRGouCPF;
            }
            else { return false; }

        }
        protected virtual void btnBuscarCidades_Click(object sender, EventArgs e)
        {
            using (var frmConsulta = new CidadesFrmConsulta())
            {
                frmConsulta.btnSair.Text = "Selecionar";

                frmConsulta.ShowDialog();

                // Sempre executa ao fechar o formulário
                ProcessarCidadeSelecionada(frmConsulta.IdSelecionado, frmConsulta.NomeSelecionado);
            }
        }

        protected virtual void ProcessarCidadeSelecionada(int idCidade, string nomeCidade)
        {
            if (idCidade <= 0)
            {
                LimparCamposCidade();
                return;
            }

            txtCodCidade.Text = idCidade.ToString();
            txtCidade.Text = nomeCidade;

            var cidade = new CidadesController().BuscarCidadePorId(idCidade);

            if (cidade == null)
            {
                MessageBox.Show("Cidade não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCamposCidade();
                return;
            }

            if (cidade.StatusCidade == "I")
            {
                var resposta = MessageBox.Show("A cidade selecionada está inativa. Deseja utilizá-la mesmo assim?",
                                            "Cidade Inativa",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

                if (resposta != DialogResult.Yes)
                {
                    LimparCamposCidade();
                    return;
                }
            }

            // Atualiza o estado do país
            isBrasil = cidade.OEstado.OPais.Pais.Equals("Brasil", StringComparison.OrdinalIgnoreCase);

            // Atualiza os campos de documentação conforme o país
            AtualizarCamposDocumentacao();

            // Limpa campos de endereço que devem ser recolhidos novamente
            LimparCamposEndereco();
        }
        private void LimparCamposEndereco()
        {
            txtCep.Clear();
            txtNumero.Clear();
            txtLogradouro.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
        }
        protected virtual void LimparEndereco()
        { // if valor = false nao vai limpar o txtCep
            txtCep.Clear();
            txtCodCidade.Enabled = false;
            txtNumero.Clear();
            txtLogradouro.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            txtCPFouCNPJ.Clear();
        }
        protected virtual void txtRG_Leave(object sender, EventArgs e)
        {
            string documento = txtRG.Text.Trim();

            // Se o campo estiver vazio, sai do método
            if (string.IsNullOrEmpty(documento))
            {
                return;
            }

            // Verifica se o documento já existe no banco de dados
            var result = clientesController.BuscarClientePorRG(documento);
            if (result != "OK" && documento != ClienteAntigo.RG)
            {
                MessageBox.Show("Erro, " + result);
                txtRG.Text = "";
                txtRG.Focus();
                return;
            }
        }
        private void txtCodCondicao_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCondicao.Text))
                LimparCondPg();
            else if (int.TryParse(txtCodCondicao.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, verifique o estado correspondente
                CondicaoPagamentoController aCTLcon = new CondicaoPagamentoController();
                CondicaoPagamento condicao = aCTLcon.BuscarCondicaoPagamentoPorId(cod);

                if (condicao == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparCondPg();
                }
                else if (condicao.Status == "I")
                {
                    MessageBox.Show("A condição de pagamento associada a este código está inativa. Por favor, selecione outra condição.");
                    LimparCondPg();
                }
                else
                {
                    txtCondicao.Text = condicao.Condicao;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparCondPg();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void LimparCondPg()
        {
            txtCondicao.Clear();
            txtCodCondicao.Clear();
        }
        private void btnBuscarCondicaoPG_Click(object sender, EventArgs e)
        {
            using (CondicaoPagamentoFrmConsulta frm = new CondicaoPagamentoFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                txtCodCondicao.Text = IdSelecionado.ToString();
                txtCondicao.Text = NomeSelecionado;
                txtCodCondicao_Leave(txtCodCondicao, EventArgs.Empty);

            }
        }

    }

}

