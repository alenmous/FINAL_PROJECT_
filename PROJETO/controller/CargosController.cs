using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System.Collections.Generic;


namespace PROJETO.controller
{
    public class CargosController
    {
        private CargosDAO cargosDAO = new CargosDAO();

        public string AdicionarCargo(Cargos cargo)
        {
            return cargosDAO.AdicionarCargo(cargo);
        }

        public string AtualizarCargo(Cargos cargo)
        {
            return cargosDAO.AtualizarCargo(cargo);
        }

        public bool ExcluirCargo(int cargoId)
        {
            return cargosDAO.ExcluirCargo(cargoId);
        }

        public Cargos BuscarCargoPorId(int id)
        {
            return cargosDAO.BuscarCargoPorId(id);
        }

        public List<Cargos> ListarCargos(string status)
        {
            return cargosDAO.ListarCargos(status);
        }

        public void Incluir()
        {
            CargosFrmCadastro frm = new CargosFrmCadastro();
            frm.Text = "Incluir Cargo";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }

        public void Alterar(Cargos cargo)
        {
            if (cargo != null)
            {
                CargosFrmCadastro frm = new CargosFrmCadastro();
                frm.ConhecaObj(cargo);
                frm.Text = "Alterar Cargo";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Cargos cargo)
        {
            if (cargo != null)
            {
                CargosFrmCadastro frm = new CargosFrmCadastro();
                frm.ConhecaObj(cargo);
                frm.Text = "Excluir Cargo";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(Cargos cargo)
        {
            if (cargo != null)
            {
                CargosFrmCadastro frm = new CargosFrmCadastro();
                frm.ConhecaObj(cargo);
                frm.Text = "Consultar Cargo";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
        public List<Cargos> Pesquisar(string filtro, string status)
        {
            return cargosDAO.Pesquisar(filtro, status);
        }
    }
}
