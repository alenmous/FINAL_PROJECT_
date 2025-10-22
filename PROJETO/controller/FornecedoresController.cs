
using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PROJETO.controller
{
    public class FornecedoresController
    {
        private FornecedoresDAO fornecedoresDAO = new FornecedoresDAO();

        public string AdicionarFornecedor(Fornecedores fornecedor)
        {
            return fornecedoresDAO.AdicionarFornecedor(fornecedor);
        }

        public string AtualizarFornecedor(Fornecedores fornecedor)
        {
            return fornecedoresDAO.AtualizarFornecedor(fornecedor);
        }

        public bool ExcluirFornecedor(int fornecedorId)
        {
            return fornecedoresDAO.ExcluirFornecedor(fornecedorId);
        }
        public string BuscarFornecedorPorDocumento(string nome)
        {
            return fornecedoresDAO.BuscarFornecedorPorCPFouCNPJ(nome);
        }
        public Fornecedores BuscarFornecedorPorDocumento2(string nome)
        {
            return fornecedoresDAO.BuscarFornRGCpf(nome);
        }
        public string BuscarFornecedorPorRG(string nome)
        {
            return fornecedoresDAO.BuscarFornecedorPorRG(nome);
        }
        public Fornecedores BuscarFornecedorPorNome(string nome)
        {
            return fornecedoresDAO.BuscarFornecedorPorNome(nome);
        }
        public Fornecedores BuscarFornecedorPorId(int id)
        {
            return fornecedoresDAO.BuscarFornecedorPorId(id);
        }

        public List<Fornecedores> ListarFornecedores(string status)
        {
            return fornecedoresDAO.ListarFornecedores(status);
        }
        public List<Fornecedores> Pesquisar(string filtro, string status)
        {
            return fornecedoresDAO.Pesquisar(filtro, status);
        }

        public void Incluir()
        {
            FornecedoresFrmCadastro frm = new FornecedoresFrmCadastro();
            frm.Text = "Incluir Fornecedor";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }

        public void Alterar(Fornecedores fornecedor)
        {
            if (fornecedor != null)
            {
                FornecedoresFrmCadastro frm = new FornecedoresFrmCadastro();
                frm.ConhecaObj(fornecedor);
                frm.Text = "Alterar Fornecedor";
                frm.btnSalvar.Text = "Alterar";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Fornecedores fornecedor)
        {
            if (fornecedor != null)
            {
                FornecedoresFrmCadastro frm = new FornecedoresFrmCadastro();
                frm.ConhecaObj(fornecedor);
                frm.Text = "Excluir Fornecedor";
                frm.btnSalvar.Text = "Excluir";
                if (fornecedor.TipoFornecedor == "F")
                {
                    frm.rbPessoaFisica.Checked = true;
                }
                else
                {
                    frm.rbPessoaJuridica.Checked = true;
                }
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(Fornecedores fornecedor)
        {
            if (fornecedor != null)
            {
                FornecedoresFrmCadastro frm = new FornecedoresFrmCadastro();
                frm.ConhecaObj(fornecedor);
                frm.Text = "Consultar Fornecedor";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
    }
}
