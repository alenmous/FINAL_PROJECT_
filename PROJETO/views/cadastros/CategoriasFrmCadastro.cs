using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.cadastros
{
    public partial class CategoriasFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        CategoriasController categoriaController;
        Categoria aCategoria;
        public CategoriasFrmCadastro()
        {
            InitializeComponent();
            aCategoria = new Categoria();
            categoriaController = new CategoriasController();
            Operacao.DisableCopyPaste(this);
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Categoria Produto)
            {
                aCategoria = Produto;
                CarregarCampos();
            }
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtCodigo.Enabled = false;
            txtProduto.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtCodigo.Enabled = true;
            txtProduto.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = aCategoria.ID.ToString();
            txtCodigo.Text = aCategoria.ID.ToString();
            txtProduto.Text = aCategoria.Nome;
        }


        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
            {
                Salvar();
            }
            else if (btnSalvar.Text == "Excluir")
            {
                ConfirmarExclusaaCategoria();
            }
        }

        protected override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text))
            {
                MessageBox.Show("Campo Produto não pode estar vazio.");
                txtProduto.Focus();
                return;
            }

            aCategoria.Nome = txtProduto.Text;

            if (aCategoria.ID == 0) // Produto de patrimônios
            {
                categoriaController.AdicionarCategoria(aCategoria);
            }
            else
            {
                categoriaController.AtualizarCategoria(aCategoria);
            }

            Close();
        }



        private void ConfirmarExclusaaCategoria()
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja excluir esta Produto?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ExcluirProduto();
            }
        }


        private void ExcluirProduto()
        {
            if (aCategoria != null)
            {
                try
                {
                    CategoriasController categoriaController = new CategoriasController();
                    categoriaController.ExcluirCategoria(aCategoria.ID);
                    Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Não é possível excluir a Produto devido a outros registros estarem vinculados a esta Produto.");
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir a Produto. Detalhes: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Detalhes: " + ex.Message);
                }
            }
        }

        private void CategoriasFrmCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            Operacao.BloquearKeyDowControlC(sender, e);
        }

        private void CategoriasFrmCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }
    }
}
