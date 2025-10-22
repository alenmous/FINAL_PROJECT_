using PROJETO.controller;
using PROJETO.controller.compraevenda;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.models.compraevenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.compraevenda
{
    public partial class ComprasFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        ComprasFrmCadastro comprasFrmCadastro;
        ComprasController comprasController;
        Compra aCompra;

        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        public ComprasFrmConsulta()
        {
            InitializeComponent();
            comprasController = new ComprasController();
            Operacao.DisableCopyPaste(this);
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                comprasFrmCadastro = (ComprasFrmCadastro)obj;
            }
        }
        public override void ConhecaObj(object obj)
        {
            aCompra = (Compra)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            comprasController.Incluir();
            CarregaLV();
        }
        protected override void Excluir()
        {
            int Numero = ObterIdSelecionado(0); // Obtém o número
            int Modelo = ObterIdSelecionado(1); // Obtém o modelo
            int Serie = ObterIdSelecionado(2); // Obtém a série
            int Fornecedor = ObterIdSelecionado(3); // Obtém o ID do fornecedor

            // Verifica se o ID do fornecedor é maior que 0
            if (Fornecedor > 0)
            {
                // Busca a compra com base nos IDs obtidos
                Compra compra = comprasController.BuscarCompraPorChave(Numero, Modelo, Serie, Fornecedor);

                // Verifica se a compra foi encontrada
                if (compra != null)
                {
                    ContasPagarController aCTLConta = new ContasPagarController();
                    var result = aCTLConta.VerificarExistenciaDeCompra(compra.NumNFC, compra.ModeloNFC, compra.SerieNFC, compra.Fornecedor.ID);
                    if (!result)
                    {
                        comprasController.CancelarNota(compra);
                        CarregaLV();
                    }
                    else
                    {
                        MessageBox.Show("Impossivel cancelar nota, pois a mesma já possui baixa");
                    }

                }
            }
        }
        private int ObterIdSelecionado(int posicao)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                return int.Parse(listView1.SelectedItems[0].SubItems[posicao].Text);
            }
            return 0;
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
                Compra compra = selectedItem.Tag as Compra;
                if (compra != null)
                {
                    comprasController.Visualizar(compra);
                    CarregaLV();
                }
            }
        }
        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Compra> dados = comprasController.ListarCompras(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<Compra> dados)
        {
            listView1.Items.Clear();

            foreach (var compra in dados)
            {
                ListViewItem item = new ListViewItem(compra.NumNFC.ToString());
                item.SubItems.Add(compra.ModeloNFC.ToString());
                item.SubItems.Add(compra.SerieNFC.ToString());
                item.SubItems.Add(compra.Fornecedor.ID.ToString());
                item.SubItems.Add(compra.Fornecedor.NomeFantasia);
                item.SubItems.Add(compra.Condicao.Condicao);
                item.SubItems.Add(compra.ValorTotal.ToString("C"));
                item.SubItems.Add(compra.ValorFrete.ToString("C"));
                item.SubItems.Add(compra.ValorSeguro.ToString("C"));
                item.SubItems.Add(compra.ValorOutrasDespesas.ToString("C"));
                item.SubItems.Add(compra.DataChegada.ToString());
                item.SubItems.Add(compra.DataEmissao.ToString());
                item.SubItems.Add(compra.DataCancelamento == DateTime.MinValue ? "Não Cancelada" : compra.DataCancelamento.ToString()); // Verifica se a data de cancelamento é MinValue
                item.SubItems.Add(compra.DataCriacao.ToString());
                item.SubItems.Add(compra.StatusCompra.ToString());
                item.Tag = compra;
                listView1.Items.Add(item);
            }
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
            var resultados = comprasController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);
        }

    }
}
