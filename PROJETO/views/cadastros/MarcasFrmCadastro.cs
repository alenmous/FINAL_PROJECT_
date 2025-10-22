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
    public partial class MarcasFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        Marca aMarca;
        MarcaController marcaController;
        public MarcasFrmCadastro()
        {
            InitializeComponent();
            aMarca = new Marca();
            marcaController = new MarcaController();
            Operacao.DisableCopyPaste(this);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }

        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Marca marca)
            {
                aMarca = marca;
                CarregarCampos();
            }
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtCodigo.Enabled = false;
            txtMarca.Enabled = false;
            txtDescricao.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtCodigo.Enabled = true;
            txtMarca.Enabled = true;
            txtDescricao.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = aMarca.ID.ToString();
            txtMarca.Text = aMarca.Nome;
            txtDescricao.Text = aMarca.Descricao;
        }

        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
            {
                Salvar();
            }
            else if (btnSalvar.Text == "Excluir")
            {
                ConfirmarExclusaoMarca();
            }
        }

        protected override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Campo Marca não pode estar vazio.");
                txtMarca.Focus();
                return;
            }

            try
            {

                aMarca.Nome = txtMarca.Text;
                aMarca.Descricao = txtDescricao.Text;

                if (aMarca.ID == 0)
                {
                    aMarca.DataCriacao = DateTime.Now;
                    marcaController.AdicionarMarca(aMarca);
                }
                else
                {
                    aMarca.DataUltimaAlteracao = DateTime.Now;
                    marcaController.AtualizarMarca(aMarca);
                }

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ConfirmarExclusaoMarca()
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja excluir esta Produto?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ExcluirMarca();
            }
        }


        private void ExcluirMarca()
        {
            if (aMarca != null)
            {
                try
                {

                    marcaController.ExcluirMarca(aMarca.ID);
                    Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Não é possível excluir a Marca devido a outros registros estarem vinculados a esta Produto.");
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir a Marca. Detalhes: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Detalhes: " + ex.Message);
                }
            }
        }

    }
}
