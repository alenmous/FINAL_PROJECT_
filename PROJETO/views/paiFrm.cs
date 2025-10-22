using Microsoft.Win32;
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
    public partial class paiFrm : Form
    {
        public paiFrm()
        {
            InitializeComponent();

        }
        //Metodos Virtuais
        protected virtual void Sair()
        {
            Close();
        }

        //Metodos Privados
        private void btnSair_Click(object sender, EventArgs e)
        {
            Sair();
        }
       
    }
}
