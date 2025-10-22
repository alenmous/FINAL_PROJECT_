using PROJETO.models.bases;
using System;

namespace PROJETO.models
{
    public class Cargos : Pai
    {
        public string StatusCargo { get; set; }
        public string Cargo { get; set; }

        public Cargos() : base() { }

        public Cargos(int id, string statusCargo, string cargo, DateTime dataCriacao, DateTime dataUltAlteracao)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            StatusCargo = statusCargo;
            Cargo = cargo;
        }
    }
}
