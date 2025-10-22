using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller
{
    public class ProdutosController
    {
        private ProdutosDAO produtosDAO = new ProdutosDAO();


        public bool AdicionarProduto(Produto produto)
        {
            return produtosDAO.AdicionarProduto(produto);
        }

        public bool AtualizarEstoque(Produto produto)
        {
            return produtosDAO.AtualizarProdutoEstoque(produto);
        }
        public string AtualizarProduto(Produto produto)
        {
            return produtosDAO.AtualizarProduto(produto);
        }

        public bool ExcluirProduto(int idProduto)
        {
            return produtosDAO.ExcluirProduto(idProduto);
        }

        public List<Produto> ListarProdutos(string status)
        {
            return produtosDAO.ListarProdutos(status);
        }

        public Produto BuscarProdutoPorId(int idProduto)
        {
            return produtosDAO.BuscarProdutoPorId(idProduto);

        }
        public List<Produto> ListarProdutoPorIDProduto(int id)
        {
            return produtosDAO.ListarProdutoPorIDProduto(id);
        }

        public bool AtivarOuDesativarProduto(Produto produto)
        {
            return produtosDAO.AtivarOuDesativarProdutos(produto);
        }
        public List<Produto> Pesquisar(string filtro, string status)
        {
            return produtosDAO.Pesquisar(filtro, status);
        }
        public void Incluir()
        {
            ProdutosFrmCadastro frm = new ProdutosFrmCadastro();
            frm.Text = "Incluir Produto";
            frm.ShowDialog();
        }

        public void Alterar(Produto produto)
        {
            if (produto != null)
            {
                ProdutosFrmCadastro frm = new ProdutosFrmCadastro();
                frm.ConhecaObj(produto);
                frm.Text = "Alterar Produto";
                frm.btnSalvar.Text = "Alterar";
                frm.btnDesativar.Visible = true;
                if (produto.Status == "A")
                {
                    frm.btnDesativar.Text = "Desativar";
                }
                else
                {
                    frm.btnDesativar.Text = "Ativar";
                }
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Produto produto)
        {
            if (produto != null)
            {
                ProdutosFrmCadastro frm = new ProdutosFrmCadastro();
                frm.ConhecaObj(produto);
                frm.Text = "Excluir Produto";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }
        public void Visualizar(Produto produto)
        {
            if (produto != null)
            {
                ProdutosFrmCadastro frm = new ProdutosFrmCadastro();
                frm.ConhecaObj(produto);
                frm.Text = "Consultar Produto";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
    }
}
