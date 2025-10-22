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
using System.Windows.Forms;
using PROJETO.controller;

namespace PROJETO.dao
{
    public class ParcelasDAO
    {
        private Banco banco = new Banco();
        private Operacao operacao = new Operacao();
        CondicaoPagamentoController condicaoPagamentoController;
        FormaPagamentoController formaPagamentoController;

        public ParcelasDAO()
        {
            condicaoPagamentoController = new CondicaoPagamentoController();
            formaPagamentoController = new FormaPagamentoController();
        }
        public bool SalvarParcelas(Parcela Obj)
        {
            try
            {
                string Sql = @"insert into tb_parcelas (id_condicao, num_parcela, id_forma, dias_totais, porcentagem,
                    data_criacao, data_ult_alteracao) values (@id_condicao, @num_parcela, @id_forma, @dias_totais,
                        @porcentagem, @data_criacao, @data_ult_alteracao)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@id_condicao", Obj.ID),
                    new SqlParameter("@num_parcela", Obj.NumParcela),
                    new SqlParameter("@id_forma", Obj.Forma.ID),
                    new SqlParameter("@dias_totais", Obj.DiasTotais),
                    new SqlParameter("@porcentagem", Obj.Porcentagem),
                    new SqlParameter("@data_criacao", Obj.DataCriacao),
                    new SqlParameter("@data_ult_alteracao", Obj.DataUltimaAlteracao)
                };

                // Aqui, em vez de usar ConexaoBanco.Open() e ConexaoBanco.Close(), você pode usar os métodos da classe Banco
                banco.ExecutarComando(Sql, parametros);

                return true;
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Aconteceu o Erro: " + Erro);
                return false;
            }
        }

        public string AdicionarParcela(Parcela parcela)
        {
            try
            {
                string sql = "INSERT INTO tb_parcelas (id_condicao, num_parcela, id_forma, dias_totais, porcentagem, data_criacao, data_ult_alteracao) " +
                             "VALUES (@IdCondicao, @NumParcela, @IdForma, @DiasTotais, @Porcentagem, @DataCriacao, @DataUltimaAlteracao)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@IdCondicao", parcela.Condicao.ID),
                    new SqlParameter("@NumParcela", parcela.NumParcela),
                    new SqlParameter("@IdForma", parcela.Forma.ID),
                    new SqlParameter("@DiasTotais", parcela.DiasTotais),
                    new SqlParameter("@Porcentagem", parcela.Porcentagem),
                    new SqlParameter("@DataCriacao", parcela.DataCriacao),
                    new SqlParameter("@DataUltimaAlteracao", parcela.DataUltimaAlteracao)
                };
                banco.ExecutarComando(sql, parametros);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool AtualizarParcela(Parcela parcela)
        {
            try
            {
                string sql = "UPDATE tb_parcelas SET dias_totais = @DiasTotais, porcentagem = @Porcentagem, " +
                             "data_ult_alteracao = @DataUltimaAlteracao WHERE id_condicao = @IdCondicao AND num_parcela = @NumParcela AND id_forma = @IdForma";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@DiasTotais", parcela.DiasTotais),
                    new SqlParameter("@Porcentagem", parcela.Porcentagem),
                    new SqlParameter("@DataUltimaAlteracao", parcela.DataUltimaAlteracao),
                    new SqlParameter("@IdCondicao", parcela.Condicao.ID),
                    new SqlParameter("@NumParcela", parcela.NumParcela),
                    new SqlParameter("@IdForma", parcela.Forma.ID)
                };
                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExcluirParcela(int idCondicao, int numParcela, int idForma)
        {
            try
            {
                string sql = "DELETE FROM tb_parcelas WHERE id_condicao = @IdCondicao AND num_parcela = @NumParcela AND id_forma = @IdForma";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@IdCondicao", idCondicao),
                    new SqlParameter("@NumParcela", numParcela),
                    new SqlParameter("@IdForma", idForma)
                };
                banco.ExecutarComando(sql, parametros);

                return true;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao excluir parcela", ex);
                return false;
            }
        }

        public List<Parcela> ListarParcelas()
        {
            try
            {
                string sql = "SELECT * FROM tb_parcelas";
                DataTable dataTable = banco.ExecutarConsulta(sql, null);
                return CreateParcelasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao listar parcelas", ex);
                return new List<Parcela>();
            }
        }
        private Parcela CreateParcelaFromDataRow(DataRow row)
        {

            CondicaoPagamento condicao = condicaoPagamentoController.BuscarCondicaoPagamentoPorId(Convert.ToInt32(row["id_condicao"]));
            FormaPagamento forma = formaPagamentoController.BuscarFormaPagamentoPorId(Convert.ToInt32(row["id_forma"]));

            return new Parcela
            {
                Condicao = condicao,
                NumParcela = Convert.ToInt32(row["num_parcela"]),
                Forma = forma,
                DiasTotais = Convert.ToInt32(row["dias_totais"]),
                Porcentagem = Convert.ToDecimal(row["porcentagem"]),
                DataCriacao = Convert.ToDateTime(row["data_criacao"]),
                DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"])
            };
        }
        public Parcela BuscarParcelaPorId(int idCondicao, int numParcela, int idForma)
        {
            try
            {
                string query = "SELECT * FROM tb_parcelas WHERE id_condicao = @IdCondicao AND num_parcela = @NumParcela AND id_forma = @IdForma";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@IdCondicao", idCondicao),
                    new SqlParameter("@NumParcela", numParcela),
                    new SqlParameter("@IdForma", idForma)
                };
                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return CreateParcelaFromDataRow(row);
                }

                return null;
            }
            catch (Exception ex)
            {
                // Trate exceções
                operacao.HandleException("Erro ao buscar parcela por ID", ex);
                return null;
            }
        }

        private List<Parcela> CreateParcelasListFromDataTable(DataTable dataTable)
        {
            List<Parcela> parcelas = new List<Parcela>();
            // Para cada linha no DataTable, crie um objeto Parcela e adicione à lista de parcelas
            foreach (DataRow row in dataTable.Rows)
            {
                parcelas.Add(CreateParcelaFromDataRow(row));
            }
            return parcelas;
        }
        public List<Parcela> BuscarParcelasPorIDCondicao(int idCondicao)
        {
            try
            {
                string query = "SELECT * FROM tb_parcelas WHERE id_condicao = @IdCondicao";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@IdCondicao", idCondicao)
                };
                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                return CreateParcelasListFromDataTable(dataTable);
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao buscar parcelas por ID de condição", ex);
                return new List<Parcela>();
            }
        }

    }
}
