using PROJETO.dao;
using PROJETO.DAO;
using PROJETO.models;
using PROJETO.Models;
using PROJETO.views.cadastros;
using PROJETO.views.consultas;
using System;
using System.Collections.Generic;

namespace PROJETO.controller
{
    internal class ProdutoFornecedorController
    {
        private ProdutoFornecedorDAO produtosFornecedoresDAO = new ProdutoFornecedorDAO();

        public string AdicionarProdutoFornecedor(ProdutosFornecedor produtoFornecedor)
        {
            return produtosFornecedoresDAO.AdicionarProdutoFornecedor(produtoFornecedor);
        }

        public string AtualizarProdutoFornecedor(ProdutosFornecedor produtoFornecedor)
        {
            return produtosFornecedoresDAO.AtualizarProdutoFornecedor(produtoFornecedor);
        }

        public bool ExcluirProdutoFornecedor(int produtoFornecedorId)
        {
            return produtosFornecedoresDAO.ExcluirProdutoFornecedor(produtoFornecedorId);
        }

        public ProdutosFornecedor BuscarProdutoFornecedorPorId(int id)
        {
            return produtosFornecedoresDAO.BuscarProdutoFornecedorPorId(id);
        }

        public List<ProdutosFornecedor> ListarProdutosFornecedores(string status)
        {
            return produtosFornecedoresDAO.ListarProdutosFornecedores(status);
        }
        public List<ProdutosFornecedor> ListarProdutosFornecedoresPorFornecedor(string status, string fornecedor)
        {
            return produtosFornecedoresDAO.ListarProdutosFornecedoresPorFornecedor(status, fornecedor);
        }

        public List<ProdutosFornecedor> Pesquisar(string filtro, string status)
        {
            return produtosFornecedoresDAO.Pesquisar(filtro, status);
        }
        public List<ProdutosFornecedor> PesquisarPorFornecedor(string filtro, string status, string fornecedor)
        {
            return produtosFornecedoresDAO.Pesquisar(filtro, status, fornecedor);
        }

        public ProdutosFornecedor Carregar(int Id)
        {
            ProdutosFornecedor produtoFornecedor = produtosFornecedoresDAO.BuscarProdutoFornecedorPorId(Id);
            return produtoFornecedor;
        }

        public void Incluir()
        {
            ProdutosFornecedoresFrmCadastro frm = new ProdutosFornecedoresFrmCadastro();
            frm.Text = "Incluir Produto Fornecedor";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }

        public void Alterar(ProdutosFornecedor produtoFornecedor)
        {
            if (produtoFornecedor != null)
            {
                ProdutosFornecedoresFrmCadastro frm = new ProdutosFornecedoresFrmCadastro();
                frm.ConhecaObj(produtoFornecedor);
                frm.Text = "Alterar Produto Fornecedor";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(ProdutosFornecedor produtoFornecedor)
        {
            if (produtoFornecedor != null)
            {
                ProdutosFornecedoresFrmCadastro frm = new ProdutosFornecedoresFrmCadastro();
                frm.ConhecaObj(produtoFornecedor);
                frm.Text = "Excluir Produto Fornecedor";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(ProdutosFornecedor produtoFornecedor)
        {
            if (produtoFornecedor != null)
            {
                ProdutosFornecedoresFrmCadastro frm = new ProdutosFornecedoresFrmCadastro();
                frm.ConhecaObj(produtoFornecedor);
                frm.Text = "Consultar Produto Fornecedor";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
    }
}
