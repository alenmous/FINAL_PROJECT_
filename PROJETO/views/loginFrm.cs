using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.views
{
    public partial class loginFrm : Form
    {
        UsuariosController usuariosController;

        public loginFrm()
        {
            InitializeComponent();
            usuariosController = new UsuariosController();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string emailOuApelido = txtUsuario.Text;
            string senha = txtSenha.Text;

            Usuarios user = usuariosController.ValidarLogin(emailOuApelido, senha);

            if (user != null)
            {
                // Armazena os dados do usuário logado
                LoggedUser.Login(user);

                this.Hide();
                principalFrm frmPrincipal = new principalFrm();
                frmPrincipal.Show();
            }
            else
            {
                // Credenciais inválidas
                MessageBox.Show("Email/Apelido ou senha incorretos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
