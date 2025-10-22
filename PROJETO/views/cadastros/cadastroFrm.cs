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

namespace PROJETO.views.cadastros
{
    public partial class cadastroFrm : paiFrm
    {
        public cadastroFrm()
        {
            InitializeComponent();
            Operacao.DisableCopyPaste(this);
        }

        // Metodos publicos
        public virtual void ConhecaObj(object obj)
        {

        }

        public virtual void CarregarCampos()// carregar campos do form.
        {
            this.txtCodigo.Text = txtCodigo.Text.ToString();
        }

        public virtual void Verificar()
        {
            Salvar();
        }

        public virtual void DesbloquearCampos()// carregar campos do form.
        {
            this.txtCodigo.Enabled = true;
        }

        public virtual void BloquearCampos()// carregar campos do form.
        {
            this.txtCodigo.Enabled = false;
        }

        protected virtual void AlterarEdit()
        {

        }

        protected virtual void LimparCampos()// limpar campos do form.
        {
            this.txtCodigo.Clear();
        }
        protected virtual void Salvar()//Salvar
        {
            Sair();
        }
        public void btnSalvar_Click(object sender, EventArgs e)
        {
            Verificar();
        }


    }
}
