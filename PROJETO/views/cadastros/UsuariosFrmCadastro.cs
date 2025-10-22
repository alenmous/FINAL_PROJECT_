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
    public partial class UsuariosFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        Usuarios oUsuario;
        UsuariosController usuariosController;
        UsuariosFrmConsulta usuariosFrmConsulta;

        public UsuariosFrmCadastro()
        {
            InitializeComponent();
            oUsuario = new Usuarios();
            usuariosController = new UsuariosController();
            usuariosFrmConsulta = new UsuariosFrmConsulta();
            Operacao.DisableCopyPaste(this);
        }
        public void SetConsultaCidades(object obj)
        {
            usuariosFrmConsulta = (UsuariosFrmConsulta)obj;
        }

        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Usuarios func)
            {
                oUsuario = func;
                CarregarCampos();
            }
        }

        protected override void LimparCampos()
        {
            txtNome.Clear();
            cmbSexo.SelectedIndex = 0;
            txtRG.Clear();
            txtCPF.Clear();
            txtCodCargo.Clear();
            txtCargo.Clear();
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
            cmbStatus.SelectedIndex = 0;
            txtSenha.Clear();
            dtDemissao.Value = DateTime.Now;
        }

        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtNome.Enabled = false;
            cmbSexo.Enabled = false;
            txtRG.Enabled = false;
            txtCPF.Enabled = false;
            txtCodCargo.Enabled = false;
            txtCargo.Enabled = false;
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
            cmbStatus.Enabled = false;
            txtSenha.Enabled = false;
            btnBuscarCargo.Enabled = false;
            btnBuscarCidades.Enabled = false;
            dtDemissao.Enabled = false;
            cbDemissao.Enabled = false;
        }

        public override void DesbloquearCampos()
        {
            base.BloquearCampos();
            txtNome.Enabled = true;
            cmbSexo.Enabled = true;
            txtRG.Enabled = true;
            txtCPF.Enabled = true;
            txtCodCargo.Enabled = true;
            txtCargo.Enabled = true;
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
            cmbStatus.Enabled = true;
            txtSenha.Enabled = true;
            btnBuscarCargo.Enabled = true;
            btnBuscarCidades.Enabled = true;
            dtDemissao.Enabled = true;
            cbDemissao.Enabled = true;
        }

        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = oUsuario.ID.ToString();
            txtNome.Text = oUsuario.Nome;
            cmbSexo.Text = oUsuario.Sexo == "M" ? "Masculino" : oUsuario.Sexo == "F" ? "Feminino" : oUsuario.Sexo;
            txtRG.Text = oUsuario.RG;
            txtCPF.Text = oUsuario.CPF;
            txtCodCargo.Text = oUsuario.Cargo.ID.ToString();
            txtCargo.Text = oUsuario.Cargo.Cargo;
            txtApelido.Text = oUsuario.Apelido;
            dtNascimento.Value = oUsuario.DataNascimento;
            txtEmail.Text = oUsuario.Email;
            txtTelefone.Text = oUsuario.Telefone;
            txtCelular.Text = oUsuario.Celular;
            txtCep.Text = oUsuario.CEP;
            txtCodCidade.Text = oUsuario.Cidade.ID.ToString();
            txtCidade.Text = oUsuario.Cidade.Cidade;
            txtBairro.Text = oUsuario.Bairro;
            txtLogradouro.Text = oUsuario.Endereco;
            txtComplemento.Text = oUsuario.Complemento;
            txtNumero.Text = oUsuario.Numero.ToString();
            dtDemissao.Value = (DateTime)oUsuario.Demissao;
            cbDemissao.Checked = oUsuario.Demissao != new DateTime(2001, 1, 1);
            cmbStatus.Text = oUsuario.StatusUsuario == "I" ? "Inativo" : oUsuario.StatusUsuario == "A" ? "Ativo" : oUsuario.StatusUsuario;
            if (txtCPF.Text != "")
            {
                lbCPF.Visible = true;
                txtCPF.Enabled = true;
                var result = VerificarPais();
                if (result)
                    lbrg.Visible = true;
                else
                    lbrg.Visible = false;
            }
            txtRG.Enabled = true;
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
                    ExcluirUsuario();
                }
            }
        }
        private void ExcluirUsuario()
        {
            if (oUsuario != null)
            {
                try
                {
                    var result = usuariosController.ExcluirUsuario(oUsuario.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o funcionário. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o funcionário devido a outros registros estarem vinculados a este funcionário.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o funcionário. Detalhes: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    // Trate outras exceções gerais, se necessário
                    MessageBox.Show("Ocorreu um erro inesperado. Detalhes: " + ex.Message);
                }
            }
        }

        private bool VerificarObrigatoriedadeCPF()
        {
            if (txtCPF.Enabled)
            {
                // Verifica se RG e CPF estão preenchidos
                if (string.IsNullOrWhiteSpace(txtRG.Text) || string.IsNullOrWhiteSpace(txtCPF.Text))
                {
                    MessageBox.Show("Documento RG e CPF são obrigatórios para clientes brasileiros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {

                if (string.IsNullOrWhiteSpace(txtRG.Text))
                {
                    var result = VerificarPais();
                    if (result && string.IsNullOrWhiteSpace(txtRG.Text))
                    {
                        MessageBox.Show("Documento RG é obrigatório para clientes brasileiros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }


        private bool VerificarCamposVazios()
        {
            List<string> camposFaltantes = new List<string>();

            if (!VerificarObrigatoriedadeCPF())
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                camposFaltantes.Add("Nome");
            }

            if (string.IsNullOrWhiteSpace(cmbSexo.Text))
            {
                camposFaltantes.Add("SEXO");
            }
            if (string.IsNullOrWhiteSpace(txtCodCargo.Text))
            {
                camposFaltantes.Add("Codigo da cidade");
            }
            if (dtNascimento.Value == DateTime.Today)
            {
                camposFaltantes.Add("Data de nascimento");
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                camposFaltantes.Add("E-mail");
            }

            if (string.IsNullOrWhiteSpace(txtCodCidade.Text))
            {
                camposFaltantes.Add("Código da cidade");
            }
            else
            {
                if (!int.TryParse(txtCodCidade.Text, out int codCidade) || codCidade <= 0)
                {
                    camposFaltantes.Add("Código da cidade (deve ser um número maior que zero)");
                }
            }

            if (string.IsNullOrWhiteSpace(txtBairro.Text))
            {
                camposFaltantes.Add("Bairro");
            }
            if (string.IsNullOrWhiteSpace(txtLogradouro.Text))
            {
                camposFaltantes.Add("Logradouro");
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                camposFaltantes.Add("Status");
            }
            // Verificação da data de nascimento
            if (dtNascimento.Value > DateTime.Now)
            {
                camposFaltantes.Add("Data (não pode ser uma data futura)");
            }


            if (camposFaltantes.Count > 0)
            {
                string camposFaltantesStr = string.Join(", ", camposFaltantes);
                MessageBox.Show("Os seguintes campos são obrigatórios e não foram preenchidos: " + camposFaltantesStr, "Campos em Falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        protected override void Salvar()
        {
            if (VerificarCamposVazios())
            {
                try
                {
                    oUsuario.Nome = txtNome.Text;
                    oUsuario.Sexo = cmbSexo.Text[0].ToString();
                    oUsuario.RG = txtRG.Text;
                    oUsuario.CPF = txtCPF.Text;
                    oUsuario.Cargo.ID = Convert.ToInt32(txtCodCargo.Text);
                    oUsuario.Apelido = txtApelido.Text;
                    oUsuario.DataNascimento = dtNascimento.Value;
                    oUsuario.Email = txtEmail.Text;
                    oUsuario.Telefone = txtTelefone.Text;
                    oUsuario.Celular = txtCelular.Text;
                    oUsuario.CEP = txtCep.Text;
                    oUsuario.Cidade.ID = Convert.ToInt32(txtCodCidade.Text);
                    oUsuario.Bairro = txtBairro.Text;
                    oUsuario.Endereco = txtLogradouro.Text;
                    oUsuario.Complemento = txtComplemento.Text;
                    if(cbDemissao.Checked)
                    {
                        oUsuario.Demissao = dtDemissao.Value;
                    }
                    else
                    {
                        oUsuario.Demissao = null;
                    }
                    if (txtNumero.Text.Length > 0)
                    {
                        oUsuario.Numero = Convert.ToInt32(txtNumero.Text);
                    }
                    oUsuario.StatusUsuario = cmbStatus.Text[0].ToString();

                    if (oUsuario.ID == 0)
                    {
                        if (txtSenha.Text != "")
                        {
                            if (txtSenha.Text != "")
                            {
                                string senha = usuariosController.CriptografarDados(txtSenha.Text);
                                oUsuario.DataCriacao = DateTime.Now;
                                oUsuario.Senha = senha;
                                var result = usuariosController.AdicionarUsuario(oUsuario);
                                if (result == "OK")
                                    Close();
                                else
                                    MessageBox.Show("Erro ao adicionar funcionário: " + result);
                            }
                        }
                        else
                        {
                            MessageBox.Show("A senha deve ter pelo menos 6 caracteres.", "Senha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        oUsuario.DataUltimaAlteracao = DateTime.Now;
                        if (txtSenha.Text != "")
                        {
                            if (txtSenha.TextLength >= 6)
                            {
                                string senha = usuariosController.CriptografarDados(txtSenha.Text);
                                oUsuario.Senha = senha;
                                var result = usuariosController.AtualizarUsuarioComSenha(oUsuario);
                                if (result == "OK")
                                    Close();
                                else
                                    MessageBox.Show("Erro ao atualizar funcionário: " + result);
                            }
                            else
                            {
                                MessageBox.Show("Senha minima de 6 caractéres é exigida.");
                                return;
                            }

                        }
                        else
                        {
                            var result = usuariosController.AtualizarUsuarioSemSenha(oUsuario);
                            if (result == "OK")
                                Close();
                            else
                                MessageBox.Show("Erro ao atualizar funcionário: " + result);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Certifique-se de que os campos numéricos foram preenchidos corretamente." + ex.Message, "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado ao salvar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }

        private void txtApelido_Leave(object sender, EventArgs e)
        {
            string apelido = txtApelido.Text;
            if (!string.IsNullOrEmpty(apelido))
            {
                var resultado = usuariosController.BuscarEmailOuApelido(apelido);
                if (resultado != null)
                {
                    if ((resultado.ID > 0) && (resultado.ID != Convert.ToInt32(txtCodigo.Text)))
                    {
                        MessageBox.Show("Usuário já cadastrado !!");
                        txtApelido.Clear();
                    }
                }
            }

        }

        private void txtCodCargo_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão
        }

        private void txtCodCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtCodCargo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCargo.Text))
            {
                txtCodCargo.Clear();
                txtCargo.Clear();
            }
            else if (int.TryParse(txtCodCargo.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, defina o valor do txtCargo
                CargosController cargosController = new CargosController();
                Cargos Valida = cargosController.BuscarCargoPorId(cod);
                if (Valida == null)
                {
                    MessageBox.Show("Código inexistente.");
                    txtCodCargo.Clear();
                    txtCargo.Clear();
                    txtCodCargo.Focus();
                }
                else
                {
                    txtCargo.Text = Valida.Cargo;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                txtCodCargo.Clear();
                txtCargo.Clear();
                txtCodCargo.Focus();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }

        private void btnBuscarCargo_Click(object sender, EventArgs e)
        {
            using (CargosFrmConsulta frm = new CargosFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                // Agora, defina os valores nos campos do seu formulário de cadastro
                txtCodCargo.Text = IdSelecionado.ToString();
                txtCargo.Text = NomeSelecionado;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string apelidoOuEmail = txtEmail.Text;
            if (!string.IsNullOrEmpty(apelidoOuEmail))
            {

                var result = Operacao.IsEmail(apelidoOuEmail);
                if (result)
                {
                    var resultado = usuariosController.BuscarEmailOuApelido(apelidoOuEmail);
                    if (resultado != null)
                    {
                        if ((resultado.ID) > 0 && (resultado.ID != Convert.ToInt32(txtCodigo.Text)))
                        {
                            MessageBox.Show("Usuário já cadastrado !!");
                            txtEmail.Clear();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Por favor insira um endereço de e-mail válido!");
                    txtEmail.Focus();
                }

            }
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

        private void txtCodCidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCidade.Text))
            {
                // Se o campo txtCodCidade estiver vazio, limpe também o campo txtCidade
                txtCodCidade.Clear();
                txtCidade.Clear();
            }
            else if (int.TryParse(txtCodCidade.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, verifique a cidade correspondente
                CidadesController cidadesController = new CidadesController();
                Cidades cidade = cidadesController.BuscarCidadePorId(cod);

                if (cidade == null)
                {
                    MessageBox.Show("Código inexistente.");
                    Limpar();
                }
                else
                {
                    txtCidade.Text = cidade.Cidade;
                    var result = VerificarPais();
                    if (result)
                    {
                        lblRg.Text = "RG";
                        lbCPF.Visible = true;
                        txtCPF.Enabled = true;
                        txtRG.Enabled = true;
                        lbrg.Visible = true;
                    }
                    else // Não é brasileiro
                    {
                        lblRg.Text = "Documento";
                        txtCPF.Enabled = false;
                        lbCPF.Visible = false;
                        txtRG.Enabled = true;
                        lbrg.Visible = false;
                    }
                    VerificarAtivo(cidade);
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                Limpar();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }
        private void VerificarAtivo(Cidades cidade)
        {
            if (cidade.StatusCidade == "I")
            {
                var result = MessageBox.Show("A cidade associada a este código está inativa. Deseja continuar?",
                                             "Cidade Inativa",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    txtCidade.Text = cidade.Cidade;
                else
                    Limpar();
            }
            else
                txtCidade.Text = cidade.Cidade;
        }
        private bool VerificarPais()
        {
            if (txtCodCidade.Text != string.Empty)
            {
                CidadesController cidadesController = new CidadesController();
                Cidades cidade = cidadesController.BuscarCidadePorId(Convert.ToInt32(txtCodCidade.Text));
                bool obrigatorioRGouCPF = cidade.OEstado.OPais.Pais.Equals("Brasil", StringComparison.OrdinalIgnoreCase);
                return obrigatorioRGouCPF;
            }
            else { return false; }

        }

        private void Limpar()
        {
            txtCodCidade.Clear();
            txtCidade.Clear();
            txtCodCidade.Focus();
        }
        protected virtual void LimparEndereco()
        { // if valor = false nao vai limpar o txtCep
            txtCep.Clear();
            txtCodCidade.Enabled = false;
            txtNumero.Clear();
            txtLogradouro.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            txtCPF.Clear();
        }

        private void Brasileiro()
        {
            lbrg.Visible = true;
            lbCPF.Visible = true;
            txtCPF.Enabled = true;
            txtRG.Enabled = true;
        }
        private void Extrangeiro()
        {
            lbrg.Visible = false;
            lbCPF.Visible = false;
            txtCPF.Enabled = false;
            txtRG.Enabled = true;
        }

        private void btnBuscarCidades_Click(object sender, EventArgs e)
        {

            using (CidadesFrmConsulta frm = new CidadesFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                // Agora, defina os valores nos campos do seu formulário de cadastro
                txtCodCidade.Text = IdSelecionado.ToString();
                txtCidade.Text = NomeSelecionado;
                if (IdSelecionado > 0)
                {
                    // Busque a cidade correspondente
                    CidadesController cidadesController = new CidadesController();
                    Cidades cidade = cidadesController.BuscarCidadePorId(IdSelecionado);

                    if (cidade != null)
                    {
                        VerificarAtivo(cidade);
                        LimparEndereco();
                        var result = VerificarPais();
                        if (result)
                            Brasileiro();
                        else
                            Extrangeiro();

                    }
                    else
                    {
                        MessageBox.Show("Código inexistente.");
                        Limpar();
                    }
                }
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            string documento = txtCPF.Text.Trim();

            if (!string.IsNullOrEmpty(documento))
            {
                bool isValid = Operacao.IsCpf(documento);

                if (!isValid)
                {
                    MessageBox.Show("CPF inválido. Por favor, insira um documento válido.");
                    txtCPF.Focus();
                }
            }
        }

        private void cbDemissao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDemissao.Checked)
            {
                dtDemissao.Enabled = true;
                dtDemissao.Value = DateTime.Now;
            }
            else
            {
                dtDemissao.Enabled = false;
                dtDemissao.Value = DateTime.Now;
            }
        }
    }
}
