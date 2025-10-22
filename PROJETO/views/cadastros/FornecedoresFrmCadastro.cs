using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
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
    public partial class FornecedoresFrmCadastro : PROJETO.views.cadastros.ClientesFrmCadastro
    {
        private FornecedoresController fornecedoresController;
        private Fornecedores oFornecedor;
        Fornecedores FornecedorAntigo;
        private enum TipoFornecedor { PessoaFisica, PessoaJuridica }
        private TipoFornecedor tipoFornecedorAtual;
        private bool isBrasil = false;
        Fornecedores fornecedorAntigo;

        public FornecedoresFrmCadastro()
        {
            InitializeComponent();
            Instanciar();
            Operacao.DisableCopyPaste(this);
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
            if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
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
            txtInscEstadual.Enabled = false;
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
            btnBuscarCondicaoPG.Enabled = true;
            txtCodCondicao.Enabled = true;
            txtCondicao.Enabled = true;
            txtInscEstadual.Enabled = true;

        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Fornecedores fornecedor)
            {
                oFornecedor = fornecedor;
                CarregarCampos();
            }
        }
        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
                Salvar();
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este fornecedor?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExcluirFornecedor();
                }
            }
        }
        private void ExcluirFornecedor()
        {
            if (oFornecedor != null)
            {
                try
                {
                    var result = fornecedoresController.ExcluirFornecedor(oFornecedor.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o fornecedor. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o fornecedor devido a outros registros estarem vinculados a este fornecedor.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o fornecedor. Detalhes: " + ex.Message);
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
            FornecedorAntigo = new Fornecedores();
            oFornecedor = new Fornecedores();
            fornecedoresController = new FornecedoresController();
        }
        private void ConfigurarEstadoInicial()
        {
            // Configurações iniciais padrão
            rbPessoaFisica.Checked = true;
            AtualizarTipoFornecedor(TipoFornecedor.PessoaFisica, true);
        }
        private void AtualizarTipoFornecedor(TipoFornecedor tipo, bool limparCampos)
        {
            tipoFornecedorAtual = tipo;

            if (tipo == TipoFornecedor.PessoaFisica)
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
            if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
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

            // Validações específicas por tipo de fornecedor e país
            if (isBrasil)
            {
                if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
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
            lblInscEst.Visible = false;
            txtInscEstadual.Visible = false;

            // Configuração de textos e tamanhos
            lbCliente.Text = "Fornecedor";
            lbApelido.Text = "Apelido";
            lbNascimento.Text = "Data de nascimento";
            lbCpfOuCnpj.Text = "CPF";
            txtInscEstadual.Visible = false;

            txtApelido.Size = new Size(324, 27);
            dtNascimento.Size = new Size(319, 27);

            // Configuração de estado
            tipoFornecedorAtual = TipoFornecedor.PessoaFisica;
            

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
            txtInscEstadual.Visible = true;
            lblInscEst.Visible = true;
            txtInscEstadual.Visible = true;

            txtCodCidade.Leave += new EventHandler(txtCodCidade_Leave);

            // Configuração de textos e tamanhos
            lbCliente.Text = "Razão Social";
            lbApelido.Text = "Nome Fantasia";
            lbNascimento.Text = "Data Fundação";
            lbCpfOuCnpj.Text = "CNPJ";

            txtApelido.Size = new Size(197, 27);
            dtNascimento.Size = new Size(448, 27);
            txtInscEstadual.Size = new Size(225, 27);

            // Configuração de estado
            tipoFornecedorAtual = TipoFornecedor.PessoaJuridica;

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

            if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
            {
                cmbSexo.SelectedIndex = 0;
            }
        }
        protected override void Salvar()
        {
            // Validate mandatory fields upfront
            if (!ValidarCamposObrigatorios())
                return;

            PreencherObjetoFornecedor();

            // Determine creation vs update
            oFornecedor.DataUltimaAlteracao = DateTime.Now;
            if (oFornecedor.ID == 0)
                oFornecedor.DataCriacao = DateTime.Now;

            string resultado = (oFornecedor.ID == 0)
                ? fornecedoresController.AdicionarFornecedor(oFornecedor)
                : fornecedoresController.AtualizarFornecedor(oFornecedor);

            // Display operation result
            if (resultado == "OK")
            {
                MessageBox.Show("Fornecedor salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Erro ao salvar fornecedor: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherObjetoFornecedor()
        {
            oFornecedor.TipoFornecedor = (tipoFornecedorAtual == TipoFornecedor.PessoaFisica) ? "F" : "J";
            oFornecedor.NomeFantasia = txtNome.Text;
            oFornecedor.RazaoSocial = txtApelido.Text;
            oFornecedor.InscricaoEstadual = txtInscEstadual.Text;
            oFornecedor.DataFundacao = dtNascimento.Value;
            oFornecedor.Email = txtEmail.Text.Trim();
            oFornecedor.Telefone = txtTelefone.Text.Trim();
            oFornecedor.Celular = txtCelular.Text.Trim();
            oFornecedor.CEP = txtCep.Text.Trim();
            oFornecedor.Bairro = txtBairro.Text.Trim();
            oFornecedor.Endereco = txtLogradouro.Text.Trim();
            oFornecedor.Complemento = txtComplemento.Text.Trim();
            oFornecedor.Numero = string.IsNullOrEmpty(txtNumero.Text) ? 0 : Convert.ToInt32(txtNumero.Text);
            oFornecedor.StatusFornecedor = cmbStatus.Text.Substring(0, 1); // First character only
            oFornecedor.CondicaoPagamento.ID = Convert.ToInt32(txtCodCondicao.Text);

            if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
            {
                oFornecedor.RG = txtRG.Text.Trim();
                oFornecedor.CNPJ = txtCPFouCNPJ.Text.Trim();
            }
            else
            {

                oFornecedor.RG = null;
                oFornecedor.CNPJ = txtCPFouCNPJ.Text.Trim();
                oFornecedor.CPF = null;
            }

            oFornecedor.Cidade.ID = Convert.ToInt32(txtCodCidade.Text);
        }

        public override void CarregarCampos()
        {
            if (oFornecedor == null || oFornecedor.ID == 0)
            {
                LimparCampos();
                return;
            }

            // Configurar tipo de cliente
            if (oFornecedor.TipoFornecedor == "F")
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
            txtCodigo.Text = oFornecedor.ID.ToString();
            txtNome.Text = oFornecedor.NomeFantasia;
            txtApelido.Text = oFornecedor.RazaoSocial;
            dtNascimento.Value = oFornecedor.DataFundacao;
            txtEmail.Text = oFornecedor.Email;
            txtTelefone.Text = oFornecedor.Telefone;
            txtCelular.Text = oFornecedor.Celular;
            txtCep.Text = oFornecedor.CEP;
            txtBairro.Text = oFornecedor.Bairro;
            txtLogradouro.Text = oFornecedor.Endereco;
            txtComplemento.Text = oFornecedor.Complemento;
            txtInscEstadual.Text = oFornecedor.InscricaoEstadual;
            txtNumero.Text = oFornecedor.Numero > 0 ? oFornecedor.Numero.ToString() : "";
            cmbStatus.Text = oFornecedor.StatusFornecedor == "A" ? "Ativo" : "Inativo";
            txtCodCondicao.Text = oFornecedor.CondicaoPagamento.ID.ToString();
            txtCondicao.Text = oFornecedor.CondicaoPagamento.Condicao;

            // Carregar cidade
            if (oFornecedor.Cidade != null && oFornecedor.Cidade.ID > 0)
            {
                txtCodCidade.Text = oFornecedor.Cidade.ID.ToString();
                txtCidade.Text = oFornecedor.Cidade.Cidade;
                isBrasil = oFornecedor.Cidade.OEstado?.OPais?.Pais.Equals("Brasil", StringComparison.OrdinalIgnoreCase) ?? false;
                AtualizarCamposDocumentacao();
            }

            // Carregar campos específicos por tipo
            if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
            {
                txtRG.Text = oFornecedor.RG;
                txtCPFouCNPJ.Text = oFornecedor.CNPJ;// nao tenho o campo CPF está sendo utilizado o mesmo campo de CNPJ
            }
            else
            {
                txtCPFouCNPJ.Text = oFornecedor.CNPJ;
            }


            // Guardar cópia do fornecedor original para comparação
            FornecedorAntigo = oFornecedor;
            rbPessoaFisica.Enabled = false;
            rbPessoaJuridica.Enabled = false;
        }
        private void ValidarDocumento()
        {
            string documento = txtCPFouCNPJ.Text.Trim();

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

            if (tipoFornecedorAtual == TipoFornecedor.PessoaFisica)
            {
                documentoValido = Operacao.IsCpf(documento);
                mensagemErro = "CPF inválido";
            }
            else if (tipoFornecedorAtual == TipoFornecedor.PessoaJuridica)
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

            string resultado = fornecedoresController.BuscarFornecedorPorDocumento(documento);
            if (resultado != "OK" && documento != (tipoFornecedorAtual == TipoFornecedor.PessoaFisica ? FornecedorAntigo.CPF : FornecedorAntigo.CNPJ))
            {
                MessageBox.Show("Documento já cadastrado. Por favor, insira um documento único.",
                                "Documento Duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return true; // Documento duplicado
            }

            return false; // Documento único
        }

        protected override void txtCPFouCNPJ_Leave(object sender, EventArgs e)
        {
            ValidarDocumento();
        }

        protected override void txtRG_Leave(object sender, EventArgs e)
        {
            string documento = txtRG.Text.Trim();

            // Se o campo estiver vazio, sai do método
            if (string.IsNullOrEmpty(documento))
            {
                return;
            }

            // Verifica se o documento já existe no banco de dados
            var result = fornecedoresController.BuscarFornecedorPorRG(documento);
            if (result != "OK" && documento != FornecedorAntigo.RG)
            {
                MessageBox.Show("Erro, " + result);
                txtRG.Text = "";
                txtRG.Focus();
                return;
            }
        }

    }


}
