using PROJETO.views.cadastros;
using PROJETO.views.compraevenda;
using PROJETO.views.consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.models.bases
{
    public class Interfaces
    {

        // Forms de cadastro
        CargosFrmCadastro cargosFrmCadastro;
        PaisesFrmCadastro paisesFrmCadastro;
        EstadosFrmCadastro estadosFrmCadastro;
        CidadesFrmCadastro cidadesFrmCadastro;
        UsuariosFrmCadastro usuariosFrmCadastro;
        CondicaoPagamentoFrmCadastro condicaoPagamentoFrmCadastro;
        FormaPagamentoFrmCadastro formaPagamentoFrmCadastro;
        ClientesFrmCadastro clientesFrmCadastro;
        FornecedoresFrmCadastro fornecedoresFrmCadastro;
        MarcasFrmCadastro marcasFrmCadastro;
        CategoriasFrmCadastro categoriasFrmCadastro;
        ProdutosFrmCadastro produtosFrmCadastro;
        ProdutosFornecedoresFrmCadastro produtosFornecedoresFrmCadastro;
        ComprasFrmCadastro comprasFrmCadastro;
        ContasPagarFrmCadastro contasPagarFrmCadastro;
        VendaFrmCadastro vendaFrmCadastro;
        ContasReceberFrmCadastro contasReceberFrmCadastro;

        // Forms de consulta
        CargosFrmConsulta cargosFrmConsulta;
        PaisesFrmConsulta paisesFrmConsulta;
        EstadosFrmConsulta estadosFrmConsulta;
        CidadesFrmConsulta cidadesFrmConsulta;
        UsuariosFrmConsulta usuariosFrmConsulta;
        CondicaoPagamentoFrmConsulta condicaoPagamentoFrmConsulta;
        FormaPagamentoFrmConsulta formaPagamentoFrmConsulta;
        ClientesFrmConsulta clientesFrmConsulta;
        FornecedoresFrmConsulta fornecedoresFrmConsulta;
        MarcasFrmConsulta marcasFrmConsulta;
        CategoriasFrmConsulta categoriasFrmConsulta;
        ProdutosFrmConsulta produtosFrmConsulta;
        ProdutosFornecedoresFrmConsulta produtosFornecedoresFrmConsulta;
        ComprasFrmConsulta comprasFrmConsulta;
        ContasPagarFrmConsulta contasPagarFrmConsulta;
        VendaFrmConsulta vendaFrmConsulta;
        ContasReceberFrmConsulta contasReceberFrmConsulta;

        public Interfaces()
        {
            cargosFrmCadastro = new CargosFrmCadastro();
            paisesFrmCadastro = new PaisesFrmCadastro();
            estadosFrmCadastro = new EstadosFrmCadastro();
            cidadesFrmCadastro = new CidadesFrmCadastro();
            usuariosFrmCadastro = new UsuariosFrmCadastro();
            condicaoPagamentoFrmCadastro = new CondicaoPagamentoFrmCadastro();
            formaPagamentoFrmCadastro = new FormaPagamentoFrmCadastro();
            clientesFrmCadastro = new ClientesFrmCadastro();
            fornecedoresFrmCadastro = new FornecedoresFrmCadastro();
            marcasFrmCadastro = new MarcasFrmCadastro();
            categoriasFrmCadastro = new CategoriasFrmCadastro();
            produtosFrmCadastro = new ProdutosFrmCadastro();
            produtosFornecedoresFrmCadastro = new ProdutosFornecedoresFrmCadastro();
            comprasFrmCadastro = new ComprasFrmCadastro();
            contasPagarFrmCadastro = new ContasPagarFrmCadastro();
            vendaFrmCadastro = new VendaFrmCadastro();
            contasReceberFrmCadastro = new ContasReceberFrmCadastro();


            cargosFrmConsulta = new CargosFrmConsulta();
            paisesFrmConsulta = new PaisesFrmConsulta();
            estadosFrmConsulta = new EstadosFrmConsulta();
            cidadesFrmConsulta = new CidadesFrmConsulta();
            usuariosFrmConsulta = new UsuariosFrmConsulta();
            condicaoPagamentoFrmConsulta = new CondicaoPagamentoFrmConsulta();
            formaPagamentoFrmConsulta = new FormaPagamentoFrmConsulta();
            clientesFrmConsulta = new ClientesFrmConsulta();
            fornecedoresFrmConsulta = new FornecedoresFrmConsulta();
            marcasFrmConsulta = new MarcasFrmConsulta();
            categoriasFrmConsulta = new CategoriasFrmConsulta();
            produtosFrmConsulta = new ProdutosFrmConsulta();
            produtosFornecedoresFrmConsulta = new ProdutosFornecedoresFrmConsulta();
            comprasFrmConsulta = new ComprasFrmConsulta();
            contasPagarFrmConsulta = new ContasPagarFrmConsulta();
            vendaFrmConsulta = new VendaFrmConsulta();
            contasReceberFrmConsulta = new ContasReceberFrmConsulta();


        }

        public void consultaCargos(object obj)
        {
            cargosFrmConsulta.ConhecaObj(obj);
            cargosFrmConsulta.ShowDialog();
        }
        public void consultaPaises(object obj)
        {
            paisesFrmConsulta.ConhecaObj(obj);
            paisesFrmConsulta.ShowDialog();
        }
        public void consultaEstados(object obj)
        {
            estadosFrmConsulta.ConhecaObj(obj);
            estadosFrmConsulta.ShowDialog();
        }
        public void consultaCidades(object obj)
        {
            cidadesFrmConsulta.ConhecaObj(obj);
            cidadesFrmConsulta.ShowDialog();
        }
        public void consultaUsuarios(object obj)
        {
            usuariosFrmConsulta.ConhecaObj(obj);
            usuariosFrmConsulta.ShowDialog();
        }

        public void consultaFormaPagamento(object obj)
        {
            formaPagamentoFrmConsulta.ConhecaObj(obj);
            formaPagamentoFrmConsulta.ShowDialog();
        }

        public void consultaCondicaoPagamento(object obj)
        {
            condicaoPagamentoFrmConsulta.ConhecaObj(obj);
            condicaoPagamentoFrmConsulta.ShowDialog();
        }

        public void consultaClientes(object obj)
        {
            clientesFrmConsulta.ConhecaObj(obj);
            clientesFrmConsulta.ShowDialog();
        }
        public void consultaFornecedores(object obj)
        {
            fornecedoresFrmConsulta.ConhecaObj(obj);
            fornecedoresFrmConsulta.ShowDialog();
        }
        public void consultaMarcas(object obj)
        {
            marcasFrmConsulta.ConhecaObj(obj);
            marcasFrmConsulta.ShowDialog();
        }
        public void consultaCategorias(object obj)
        {
            categoriasFrmConsulta.ConhecaObj(obj);
            categoriasFrmConsulta.ShowDialog();
        }
        public void consultaProdutos(object obj)
        {
            produtosFrmConsulta.ConhecaObj(obj);

            produtosFrmConsulta.ShowDialog();
        }
        public void consultaProdutosFornecedor(object obj)
        {
            produtosFornecedoresFrmConsulta.ConhecaObj(obj);
            produtosFornecedoresFrmConsulta.ShowDialog();
        }
        public void consultaCompras(object obj)
        {
            comprasFrmConsulta.ConhecaObj(obj);
            comprasFrmConsulta.ShowDialog();
        }
        public void consultaContasPagar(object obj)
        {
            contasPagarFrmConsulta.ConhecaObj(obj);
            contasPagarFrmConsulta.ShowDialog();
        }
        public void consultaVenda(object obj)
        {
            vendaFrmConsulta.ConhecaObj(obj);
            vendaFrmConsulta.ShowDialog();
        }
        public void consultaContasReceber(object obj)
        {
            contasReceberFrmConsulta.ConhecaObj(obj);
            contasReceberFrmConsulta.ShowDialog();
        }
    }
}
