using PROJETO.data;
using PROJETO.models.bases;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJETO.dao;
using System.Drawing;
using PROJETO.views.cadastros;

namespace PROJETO.controller
{
    public class ClientesController
    {
        private ClientesDAO clientesDAO = new ClientesDAO();

        public string AdicionarCliente(Clientes cliente)
        {
            return clientesDAO.AdicionarCliente(cliente);
        }

        public string AtualizarCliente(Clientes cliente)
        {
            return clientesDAO.AtualizarCliente(cliente);
        }

        public bool ExcluirCliente(int clienteId)
        {
            return clientesDAO.ExcluirCliente(clienteId);
        }
        public Clientes BuscarClientePorDocumento2(string nome)
        {
            return clientesDAO.BuscarClientePorCPFouCNPJ2(nome);
        }
        public Clientes BuscarClientePorId(int id)
        {
            return clientesDAO.BuscarClientePorId(id);
        }
        public string BuscarClientePorDocumento(string nome)
        {
            return clientesDAO.BuscarClientePorCPFouCNPJ(nome);
        }

        public string BuscarClientePorRG(string nome)
        {
            return clientesDAO.BuscarClientePorRG(nome);
        }

        public List<Clientes> ListarClientes(string status)
        {
            return clientesDAO.ListarClientes(status);
        }
        public List<Clientes> Pesquisar(string filtro, string status)
        {
            return clientesDAO.Pesquisar(filtro, status);
        }

        public void Incluir()
        {
            ClientesFrmCadastro frm = new ClientesFrmCadastro();
            frm.Text = "Incluir Cliente";
            frm.cmbStatus.Text = "ATIVO";
           // frm.VerCampos(false);
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }

        public void Alterar(Clientes cliente)
        {
            if (cliente != null)
            {
                ClientesFrmCadastro frm = new ClientesFrmCadastro();
                frm.ConhecaObj(cliente);
                frm.Text = "Alterar Cliente";
                frm.btnSalvar.Text = "Alterar";
                frm.rbPessoaFisica.Enabled = false;
                frm.rbPessoaJuridica.Enabled = false;
                if(cliente.TipoCliente == "F")
                {
                    frm.rbPessoaFisica.Checked = true;
                }
                else
                {
                    frm.rbPessoaJuridica.Checked = true;
                }
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Clientes cliente)
        {
            if (cliente != null)
            {
                ClientesFrmCadastro frm = new ClientesFrmCadastro();
                frm.ConhecaObj(cliente);
                frm.Text = "Excluir Cliente";
                frm.btnSalvar.Text = "Excluir";
                frm.rbPessoaFisica.Enabled = false;
                frm.rbPessoaJuridica.Enabled = false;
                if (cliente.TipoCliente == "F")
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

        public void Visualizar(Clientes cliente)
        {
            if (cliente != null)
            {
                ClientesFrmCadastro frm = new ClientesFrmCadastro();
                frm.ConhecaObj(cliente);
                frm.Text = "Consultar Cliente";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.rbPessoaFisica.Enabled = false;
                frm.rbPessoaJuridica.Enabled = false;
                frm.ShowDialog();
            }
        }
    }
}
