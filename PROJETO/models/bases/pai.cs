using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models.bases
{
    public class Pai
    {
        protected int _id = 0;
        protected DateTime _data_criacao;
        protected DateTime _data_ult_alteracao;

        public Pai()
        {
            _id = 0;
            _data_criacao = DateTime.Now;
            _data_ult_alteracao = DateTime.Now;
        }

        public Pai(int id)
        {
            this._id = id;
        }
        public Pai(DateTime dataCriacao)
        {
            this._data_criacao = dataCriacao;
        }
        public Pai(int id, DateTime dataCriacao)
        {
            this._id = id;
            this._data_criacao = dataCriacao;
        }

        public Pai(int id, DateTime dataCriacao, DateTime dataUltAlteracao)
        {
            this._id = id;
            this._data_criacao = dataCriacao;
            this._data_ult_alteracao = dataUltAlteracao;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }
        public DateTime DataUltimaAlteracao
        {
            get => _data_ult_alteracao;
            set => _data_ult_alteracao = value;
        }
        public DateTime DataCriacao
        {
            get => _data_criacao;
            set => _data_criacao = value;
        }

    }
}
