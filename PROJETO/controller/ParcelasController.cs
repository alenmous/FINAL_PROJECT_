using PROJETO.dao;
using PROJETO.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller
{
    public class ParcelasController
    {
        private Parcela Parcelas = new Parcela();
        private ParcelasDAO parcelasDAO = new ParcelasDAO();

        public string AdicionarParcela(Parcela parcela)
        {
            return parcelasDAO.AdicionarParcela(parcela);
        }

        public bool AtualizarParcela(Parcela parcela)
        {
            return parcelasDAO.AtualizarParcela(parcela);
        }

        public bool ExcluirParcela(int idCondicao, int numParcela, int idForma)
        {
            return parcelasDAO.ExcluirParcela(idCondicao, numParcela, idForma);
        }

        public List<Parcela> ListarParcelas()
        {
            return parcelasDAO.ListarParcelas();
        }
        public Parcela BuscarParcelaPorId(int idCondicao, int numParcela, int idForma)
        {
            return parcelasDAO.BuscarParcelaPorId(idCondicao, numParcela, idForma);
        }
        public bool SalvarParcelas(Parcela parcelas)
        {
            Parcelas = parcelas;
            return parcelasDAO.SalvarParcelas(parcelas);
        }
        public List<Parcela> BuscarParcelasPorIDCondicao(int idCondicao)
        {
            return parcelasDAO.BuscarParcelasPorIDCondicao(idCondicao);
        }



    }
}
