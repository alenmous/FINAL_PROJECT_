using PROJETO.models.bases;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PROJETO.Models;
using PROJETO.models.compraevenda;

namespace PROJETO.views
{
    public partial class principalFrm : Form
    {
        private Dictionary<string, EventHandler> menuActions = new Dictionary<string, EventHandler>();

        // Modelos
        private Interfaces aInter;
        private Cargos oCargo;
        private Paises oPais;
        private Estados oEstado;
        private Cidades aCidade;
        private Usuarios oUsuario;
        private CondicaoPagamento aCondicao;
        private FormaPagamento aFormaPagamento;
        private Clientes oCliente;
        private Clientes oFornecedor;
        private Marca aMarca;
        private Categoria aCategoria;
        private Produto oProduto;
        private ProdutosFornecedor oProdutoFornecedor;
        private Compra aCompra;
        private ContasPagar aContasPagar;
        private Venda aVenda;
        private ContasReceber aContaReceber;

        private MenuManager menuManager;

        public principalFrm()
        {
            InitializeComponent();
            InicializarModelos();
            InicializarMenu();
        }

        private void InicializarModelos()
        {
            aInter = new Interfaces();
            oCargo = new Cargos();
            oPais = new Paises();
            oEstado = new Estados();
            aCidade = new Cidades();
            oUsuario = new Usuarios();
            aCondicao = new CondicaoPagamento();
            aFormaPagamento = new FormaPagamento();
            oCliente = new Clientes();
            aMarca = new Marca();
            aCategoria = new Categoria();
            oProduto = new Produto();
            oProdutoFornecedor = new ProdutosFornecedor();
            aCompra = new Compra();
            aContasPagar = new ContasPagar();
            aVenda = new Venda();
            aContaReceber = new ContasReceber();
        }

        private void InicializarMenu()
        {
            // Inicializa o MenuManager passando o MenuStrip e o PanelMenu
            menuManager = new MenuManager(menuStrip1, panelMenu);

            // Define as ações dos botões diretamente no MenuManager
            menuActions["Cargos"] = stripConCargos_Click;
            menuActions["Países"] = stripConPaises_Click;
            menuActions["Estados"] = stripConEstados_Click;
            menuActions["Cidades"] = stripConCidades_Click;
            menuActions["Usuarios"] = stripConUsuarios_Click;
            menuActions["Condição de Pagamento"] = stripFinCondicao_Click;
            menuActions["Forma de Pagamento"] = stripFinForma_Click;
            menuActions["Clientes"] = stripConClientes_Click;
            menuActions["Fornecedores"] = stripConFonecedores_Click;
            menuActions["Marcas"] = stripAlmMarca_Click;
            menuActions["Categorias"] = stripAlmCategoria_Click;
            menuActions["Produtos"] = stripAlmProduto_Click;
           // menuActions["Produto -> Fornecedor"] = stripAlmVinculo_Click;
            menuActions["Compras"] = stripAlmCompra_Click;
            menuActions["Contas a Pagar"] = stripFinContaPg_Click;
            menuActions["Contas a Receber"] = stripFinContaReceber_Click;
            menuActions["Vendas"] = stripAlmVenda_Click;
            menuManager.DefinirAcoesDosBotoes(menuActions);
        }

        // Ações dos botões
        private void stripConCargos_Click(object sender, EventArgs e) => aInter.consultaCargos(oCargo);
        private void stripConPaises_Click(object sender, EventArgs e) => aInter.consultaPaises(oPais);
        private void stripConEstados_Click(object sender, EventArgs e) => aInter.consultaEstados(oEstado);
        private void stripConCidades_Click(object sender, EventArgs e) => aInter.consultaCidades(aCidade);
        private void stripConUsuarios_Click(object sender, EventArgs e) => aInter.consultaUsuarios(oUsuario);
        private void stripFinCondicao_Click(object sender, EventArgs e) => aInter.consultaCondicaoPagamento(aCondicao);
        private void stripFinForma_Click(object sender, EventArgs e) => aInter.consultaFormaPagamento(aFormaPagamento);
        private void stripConClientes_Click(object sender, EventArgs e) => aInter.consultaClientes(oCliente);
        private void stripConFonecedores_Click(object sender, EventArgs e) => aInter.consultaFornecedores(oFornecedor);
        private void stripAlmMarca_Click(object sender, EventArgs e) => aInter.consultaMarcas(aMarca);
        private void stripAlmCategoria_Click(object sender, EventArgs e) => aInter.consultaCategorias(aCategoria);
        private void stripAlmProduto_Click(object sender, EventArgs e) => aInter.consultaProdutos(oProduto);
        private void stripAlmVinculo_Click(object sender, EventArgs e) => aInter.consultaProdutosFornecedor(oProdutoFornecedor);
        private void stripAlmCompra_Click(object sender, EventArgs e) => aInter.consultaCompras(aCompra);
        private void stripFinContaPg_Click(object sender, EventArgs e) => aInter.consultaContasPagar(aContasPagar);
        private void stripFinContaReceber_Click(object sender, EventArgs e) => aInter.consultaContasReceber(aContaReceber);
        private void stripAlmVenda_Click(object sender, EventArgs e) => aInter.consultaVenda(aVenda);


        private void principalFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ttSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza de que deseja sair desta sessão?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
