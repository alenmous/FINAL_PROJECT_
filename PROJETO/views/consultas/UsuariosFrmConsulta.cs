using PROJETO.models.bases;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROJETO.controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJETO.views.consultas
{
    public partial class UsuariosFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        UsuariosController usuariosController;
        UsuariosFrmCadastro usuariosFrmCadastro;
        Usuarios oUsuario;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }


        public UsuariosFrmConsulta()
        {
            InitializeComponent();
            usuariosController = new UsuariosController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                usuariosFrmCadastro = (UsuariosFrmCadastro)obj;
            }
        }
        public override void ConhecaObj(object obj)
        {
            oUsuario = (Usuarios)obj;
        }

        protected override void Incluir()
        {
            base.Incluir();
            usuariosController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idFunc = ObterIdSelecionado();
            if (idFunc > 0)
            {
                Usuarios Usuario = usuariosController.BuscarUsuarioPorId(idFunc);
                if (Usuario != null)
                {
                    usuariosController.Alterar(Usuario);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idFunc = ObterIdSelecionado();
            if (idFunc > 0)
            {
                Usuarios Usuario = usuariosController.BuscarUsuarioPorId(idFunc);
                if (Usuario != null)
                {
                    usuariosController.Excluir(Usuario);
                    CarregaLV();
                }
            }
        }

        public override void Visualizar()
        {
            if (btnSair.Text == "Selecionar")
            {
                btnSair.PerformClick();
            }
            else if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                Usuarios Usuario = selectedItem.Tag as Usuarios;
                if (Usuario != null)
                {
                    usuariosController.Visualizar(Usuario);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Usuarios> dados = usuariosController.ListarUsuarios(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<Usuarios> dados)
        {
            listView1.Items.Clear();

            foreach (var Usuario in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(Usuario.ID));
                item.SubItems.Add(Usuario.Nome);
                item.SubItems.Add(Usuario.Sexo == "M" ? "Masculino" : Usuario.Sexo == "F" ? "Feminino" : Usuario.Sexo);
                item.SubItems.Add(string.IsNullOrWhiteSpace(Usuario.RG) ? "Não Cadastrado" : Operacao.FormatarDocumento(Usuario.RG));
                item.SubItems.Add(string.IsNullOrWhiteSpace(Usuario.CPF) ? "Não Cadastrado" : Operacao.FormatarDocumento(Usuario.CPF));
                item.SubItems.Add(Usuario.Cargo.Cargo);
                item.SubItems.Add(Usuario.Apelido);
                item.SubItems.Add(Usuario.DataNascimento.ToString());
                item.SubItems.Add(Usuario.Email);
                item.SubItems.Add(Operacao.FormatarTelefone(string.IsNullOrEmpty(Usuario.Telefone) ? "Não Cadastrado" : Operacao.FormatarTelefone(Usuario.Telefone)));
                item.SubItems.Add(Operacao.FormatarTelefone(string.IsNullOrEmpty(Usuario.Celular) ? "Não Cadastrado" : Operacao.FormatarTelefone(Usuario.Celular)));
                item.SubItems.Add(Operacao.FormatarCep(Usuario.CEP));
                item.SubItems.Add(Usuario.Cidade.Cidade);
                item.SubItems.Add(Usuario.Bairro);
                item.SubItems.Add(Usuario.Endereco);
                item.SubItems.Add(Usuario.Complemento);
                item.SubItems.Add(Usuario.Numero.ToString());
                item.SubItems.Add(Usuario.DataCriacao.ToString());
                item.SubItems.Add(Usuario.DataUltimaAlteracao.ToString());
                item.SubItems.Add(Usuario.StatusUsuario == "I" ? "Inativo" : Usuario.StatusUsuario == "A" ? "Ativo" : Usuario.StatusUsuario);

                item.Tag = Usuario;
                listView1.Items.Add(item);
            }
        }

        private int ObterIdSelecionado()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                return int.Parse(listView1.SelectedItems[0].Text);
            }
            return 0;
        }

        protected override void Sair()
        {
            if (btnSair.Text == "Sair")
            {
                base.Sair();
            }
            else if (btnSair.Text == "Selecionar")
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    IdSelecionado = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    NomeSelecionado = listView1.SelectedItems[0].SubItems[1].Text;
                }
                this.Close();
            }
        }
        protected override void Pesquisar()
        {
                var resultados = usuariosController.Pesquisar(txtPesquisar.Text, oStatus);
                PreencherListView(resultados);
         
        }
    }
}
