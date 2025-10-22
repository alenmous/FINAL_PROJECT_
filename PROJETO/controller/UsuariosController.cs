using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller
{
    internal class UsuariosController
    {
        private UsuariosDAO usuariosDAO = new UsuariosDAO();

        public string AdicionarUsuario(Usuarios usuario)
        {
            return usuariosDAO.AdicionarUsuario(usuario);
        }

        public string AtualizarUsuarioComSenha(Usuarios Usuario)
        {
            return usuariosDAO.AtualizarUsuarioComSenha(Usuario);
        }
        public string AtualizarUsuarioSemSenha(Usuarios Usuario)
        {
            return usuariosDAO.AtualizarUsuarioSemSenha(Usuario);
        }
        public Usuarios AtualizarSenha(Usuarios Usuario)
        {
            return usuariosDAO.AtualizarSenha(Usuario);
        }
        public bool ExcluirUsuario(int UsuarioId)
        {
            return usuariosDAO.ExcluirUsuario(UsuarioId);
        }

        public Usuarios BuscarUsuarioPorId(int id)
        {
            return usuariosDAO.BuscarUsuarioPorId(id);
        }

        public Usuarios BuscarEmailOuApelido(string func)
        {
            return usuariosDAO.BuscarPorEmailOuApelido(func);
        }

        public List<Usuarios> ListarUsuarios(string status)
        {
            return usuariosDAO.ListarUsuarios(status);
        }

        public string CriptografarDados(string dados)
        {
            return usuariosDAO.CriptografarDadosSHA256(dados);
        }
        public Usuarios ValidarLogin(string emailOuApelido, string senha)
        {
            string SenhaCriptografada = CriptografarDados(senha);
            return usuariosDAO.ValidarLogin(emailOuApelido, SenhaCriptografada);
        }
        public List<Usuarios> Pesquisar(string pesquisa, string status)
        {
            return usuariosDAO.Pesquisar(pesquisa, status);
        }

        public void Incluir()
        {
            UsuariosFrmCadastro frm = new UsuariosFrmCadastro();
            frm.Text = "Incluir Funcionário";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.txtSenha.Size = new Size(513, 27);
            frm.ShowDialog();
        }
        public void Alterar(Usuarios funcionario)
        {
            if (funcionario != null)
            {
                UsuariosFrmCadastro frm = new UsuariosFrmCadastro();
                frm.ConhecaObj(funcionario);
                frm.Text = "Alterar Funcionário";
                frm.CarregarCampos();
                frm.dtDemissao.Visible = true;
                frm.lbdemi.Visible = true;
                frm.cbDemissao.Visible = true;
                frm.ShowDialog();
            }
        }

        public void Excluir(Usuarios funcionario)
        {
            if (funcionario != null)
            {
                UsuariosFrmCadastro frm = new UsuariosFrmCadastro();
                frm.ConhecaObj(funcionario);
                frm.Text = "Excluir Funcionário";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.dtDemissao.Visible = true;
                frm.lbdemi.Visible = true;
                frm.cbDemissao.Visible = true;
                frm.ShowDialog();
            }
        }

        public void Visualizar(Usuarios funcionario)
        {
            if (funcionario != null)
            {
                UsuariosFrmCadastro frm = new UsuariosFrmCadastro();
                frm.ConhecaObj(funcionario);
                frm.Text = "Consultar Funcionário";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.dtDemissao.Visible = true;
                frm.lbdemi.Visible = true;
                frm.cbDemissao.Visible = true;
                frm.ShowDialog();
            }
        }


    }
}
