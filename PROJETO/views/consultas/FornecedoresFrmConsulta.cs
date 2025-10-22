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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJETO.views.consultas
{
    public partial class FornecedoresFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        FornecedoresFrmCadastro fornecedoresFrmCadastro;
        Fornecedores oFornecedor;
        FornecedoresController fornecedoresController;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public FornecedoresFrmConsulta()
        {
            InitializeComponent();
            fornecedoresController = new FornecedoresController();
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                fornecedoresFrmCadastro = (FornecedoresFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            oFornecedor = (Fornecedores)obj;
        }

        protected override void Incluir()
        {
            base.Incluir();
            fornecedoresController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idFornecedor = ObterIdSelecionado();
            if (idFornecedor > 0)
            {
                Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorId(idFornecedor);
                if (fornecedor != null)
                {
                    fornecedoresController.Alterar(fornecedor);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idFornecedor = ObterIdSelecionado();
            if (idFornecedor > 0)
            {
                Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorId(idFornecedor);
                if (fornecedor != null)
                {
                    fornecedoresController.Excluir(fornecedor);
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
                Fornecedores fornecedor = selectedItem.Tag as Fornecedores;
                if (fornecedor != null)
                {
                    fornecedoresController.Visualizar(fornecedor);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Fornecedores> dados = fornecedoresController.ListarFornecedores(oStatus);
            PreencherListView(dados);
        }

        private void PreencherListView(IEnumerable<Fornecedores> dados)
        {
            listView1.Items.Clear();

            foreach (var fornecedor in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(fornecedor.ID));

                string nomeFantasia = string.IsNullOrWhiteSpace(fornecedor.NomeFantasia) ? "Não Cadastrado" : fornecedor.NomeFantasia;
                item.SubItems.Add(nomeFantasia);

                string razaoSocial = string.IsNullOrWhiteSpace(fornecedor.RazaoSocial) ? "Não Cadastrado" : fornecedor.RazaoSocial;
                item.SubItems.Add(razaoSocial);

                string inscricaoEstadual = string.IsNullOrWhiteSpace(fornecedor.InscricaoEstadual) ? "Não Cadastrado" : Operacao.FormatarDocumento(fornecedor.InscricaoEstadual);
                item.SubItems.Add(inscricaoEstadual);

                string inscricaoMunicipal = string.IsNullOrWhiteSpace(fornecedor.InscricaoMunicipal) ? "Não Cadastrado" : Operacao.FormatarDocumento(fornecedor.InscricaoMunicipal);
                item.SubItems.Add(inscricaoMunicipal);

                string cnpj = string.IsNullOrWhiteSpace(fornecedor.CNPJ) ? "Não Cadastrado" : Operacao.FormatarDocumento(fornecedor.CNPJ);
                item.SubItems.Add(cnpj);

                string rg = string.IsNullOrWhiteSpace(fornecedor.RG) ? "Não Cadastrado" : Operacao.FormatarDocumento(fornecedor.RG);
                item.SubItems.Add(rg);

                item.SubItems.Add(fornecedor.Email);

                string telefone = string.IsNullOrEmpty(fornecedor.Telefone) ? "Não Cadastrado" : Operacao.FormatarTelefone(fornecedor.Telefone);
                item.SubItems.Add(telefone);

                string celular = string.IsNullOrEmpty(fornecedor.Celular) ? "Não Cadastrado" : Operacao.FormatarTelefone(fornecedor.Celular);
                item.SubItems.Add(celular);

                item.SubItems.Add(Operacao.FormatarCep(fornecedor.CEP));
                item.SubItems.Add(fornecedor.Cidade.Cidade);
                item.SubItems.Add(fornecedor.Bairro);

                string endereco = string.IsNullOrWhiteSpace(fornecedor.Endereco) ? "Não Cadastrado" : fornecedor.Endereco;
                item.SubItems.Add(endereco);

                string complemento = string.IsNullOrWhiteSpace(fornecedor.Complemento) ? "Não Cadastrado" : fornecedor.Complemento;
                item.SubItems.Add(complemento);

                int? numeroBanco = fornecedor.Numero; // Supondo que fornecedor.Numero é um int?
                string numero = numeroBanco.HasValue ? numeroBanco.Value.ToString() : "Não Cadastrado";

                item.SubItems.Add(numero);

                item.SubItems.Add(fornecedor.DataFundacao.ToString());
                item.SubItems.Add(fornecedor.DataCriacao.ToString());
                item.SubItems.Add(fornecedor.DataUltimaAlteracao.ToString());

                string statusFornecedor = fornecedor.StatusFornecedor == "I" ? "Inativo" : fornecedor.StatusFornecedor == "A" ? "Ativo" : fornecedor.StatusFornecedor;
                item.SubItems.Add(statusFornecedor);

                item.SubItems.Add(fornecedor.CondicaoPagamento.Condicao);

                string tipoFornecedor = fornecedor.TipoFornecedor == "O" ? "Pessoa Física" : fornecedor.TipoFornecedor == "F" ? "Pessoa Física" : fornecedor.TipoFornecedor == "J" ? "Pessoa Jurídica" : fornecedor.TipoFornecedor;
                item.SubItems.Add(tipoFornecedor);

                item.Tag = fornecedor;
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
            var resultados = fornecedoresController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);
        }

    }
}
