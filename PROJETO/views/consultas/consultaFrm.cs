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

namespace PROJETO.views.consultas
{
    public partial class consultaFrm : paiFrm
    {
        protected string oStatus = "A";


        public consultaFrm()
        {
            InitializeComponent();
            Operacao.DisableCopyPaste(this);
        }

        public virtual void SetFrmCadastro(object obj)
        {

        }
        public virtual void ConhecaObj(object obj)
        {

        }
        public virtual void CarregaLV()
        {

        }
        public virtual void Visualizar()
        {

        }
        protected virtual void Incluir()
        {

        }
        protected virtual void Alterar()
        {

        }
        protected virtual void Excluir()
        {
    
        }
       
        protected virtual void Pesquisar()
        {

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Incluir();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregaLV();
        }

        private void rbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }
        protected virtual void RadioButtons()
        {
            if (rbAtivos.Checked)
                oStatus = "A";
            else if (rbInativos.Checked)
                oStatus = "I";
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visualizar();
        }
    }
}
