using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.consultas
{
    public partial class ClientesFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        ClientesFrmCadastro clientesFrmCadastros;
        Clientes oCliente;
        ClientesController clientesController;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        private string status = "A";

        public ClientesFrmConsulta()
        {
            InitializeComponent();
            clientesController = new ClientesController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                clientesFrmCadastros = (ClientesFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            oCliente = (Clientes)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            clientesController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idCliente = ObterIdSelecionado();
            if (idCliente > 0)
            {
                Clientes cliente = clientesController.BuscarClientePorId(idCliente);
                if (cliente != null)
                {
                    clientesController.Alterar(cliente);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idCliente = ObterIdSelecionado();
            if (idCliente > 0)
            {
                Clientes cliente = clientesController.BuscarClientePorId(idCliente);
                if (cliente != null)
                {
                    clientesController.Excluir(cliente);
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
                Clientes cliente = selectedItem.Tag as Clientes;
                if (cliente != null)
                {
                    clientesController.Visualizar(cliente);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Clientes> dados = clientesController.ListarClientes(status);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<Clientes> dados)
        {
            listView1.Items.Clear();

            foreach (var cliente in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(cliente.ID));
                item.SubItems.Add(cliente.Nome);
                string sexo = string.IsNullOrEmpty(cliente.Sexo) ? "Não Cadastrado" : cliente.Sexo == "M" ? "Masculino" : cliente.Sexo == "F" ? "Feminino" : cliente.Sexo;
                item.SubItems.Add(sexo);
                item.SubItems.Add(string.IsNullOrWhiteSpace(cliente.RG) ? "Não Cadastrado" : Operacao.FormatarDocumento(cliente.RG));
                item.SubItems.Add(string.IsNullOrWhiteSpace(cliente.CPF) ? "Não Cadastrado" : Operacao.FormatarDocumento(cliente.CPF));
                item.SubItems.Add(cliente.DataNasc.ToString());
                item.SubItems.Add(cliente.Email);
                string telefone = string.IsNullOrEmpty(cliente.Telefone) ? "Não Cadastrado" : Operacao.FormatarTelefone(cliente.Telefone);
                item.SubItems.Add(telefone);
                string celular = string.IsNullOrEmpty(cliente.Celular) ? "Não Cadastrado" : Operacao.FormatarTelefone(cliente.Celular);
                item.SubItems.Add(celular);
                item.SubItems.Add(Operacao.FormatarCep(cliente.CEP));
                item.SubItems.Add(cliente.Cidade.Cidade);
                item.SubItems.Add(cliente.Bairro);
                string endereco = string.IsNullOrWhiteSpace(cliente.Endereco) ? "Não Cadastrado" : cliente.Endereco;
                item.SubItems.Add(endereco);
                string complemento = string.IsNullOrWhiteSpace(cliente.Complemento) ? "Não Cadastrado" : cliente.Complemento;
                item.SubItems.Add(complemento);
                int? numeroBanco = cliente.Numero; // Supondo que cliente.Numero é um int?
                string numero = numeroBanco.HasValue ? numeroBanco.Value.ToString() : "Não Cadastrado";
                item.SubItems.Add(numero);
                item.SubItems.Add(cliente.DataCriacao.ToString());
                item.SubItems.Add(cliente.DataUltimaAlteracao.ToString());
                string statusCliente = cliente.StatusCliente == "I" ? "Inativo" : cliente.StatusCliente == "A" ? "Ativo" : cliente.StatusCliente;
                item.SubItems.Add(statusCliente);
                item.SubItems.Add(cliente.CondicaoPagamento.Condicao);
                string tipoCliente = cliente.TipoCliente == "O" ? "Pessoa Física" : cliente.TipoCliente == "F" ? "Pessoa Física" : cliente.TipoCliente == "J" ? "Pessoa Jurídica" : cliente.TipoCliente;
                item.SubItems.Add(tipoCliente);
                item.Tag = cliente;
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
            var resultados = clientesController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);
        }

    }
}
