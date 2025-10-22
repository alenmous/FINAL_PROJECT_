using PROJETO.data;
using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PROJETO.controller;
using PROJETO.models;

namespace PROJETO.dao
{
    internal class UsuariosDAO
    {

    private Banco banco = new Banco();
    private Operacao operacao = new Operacao();
    private CargosController cargosController = new CargosController();
    private CidadesController cidadesController = new CidadesController();

    public string AdicionarUsuario(Usuarios user)
    {
        try
        {
            string sql = "INSERT INTO tb_usuarios (status_usuario, nome, apelido, sexo, rg, cpf, email, senha, telefone, celular, cep, endereco, numero, complemento, bairro, id_cargo, id_cidade, data_nasc, data_criacao, data_ult_alteracao, data_demissao) " +
                         "VALUES (@StatusUsuario, @Nome, @Apelido, @Sexo, @RG, @CPF, @Email, @Senha, @Telefone, @Celular, @CEP, @Endereco, @Numero, @Complemento, @Bairro, @IdCargo, @IdCidade, @DataNasc, @DataCriacao, @DataUltimaAlteracao,@data_demissao)";
            SqlParameter[] parametros =
            {
                    new SqlParameter("@StatusUsuario", user.StatusUsuario),
                    new SqlParameter("@Nome", user.Nome),
                    new SqlParameter("@Apelido", user.Apelido),
                    new SqlParameter("@Sexo", user.Sexo),
                    new SqlParameter("@RG", user.RG),
                    new SqlParameter("@CPF", user.CPF),
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@Senha", user.Senha),
                    new SqlParameter("@Telefone", user.Telefone),
                    new SqlParameter("@Celular", user.Celular),
                    new SqlParameter("@CEP", user.CEP),
                    new SqlParameter("@Endereco", user.Endereco),
                    new SqlParameter("@Numero", user.Numero),
                    new SqlParameter("@Complemento", user.Complemento),
                    new SqlParameter("@Bairro", user.Bairro),
                    new SqlParameter("@IdCargo", user.Cargo.ID),
                    new SqlParameter("@IdCidade", user.Cidade.ID),
                    new SqlParameter("@DataNasc", user.DataNascimento),
                    new SqlParameter("@DataCriacao", user.DataCriacao),
                    new SqlParameter("@DataUltimaAlteracao", user.DataUltimaAlteracao),
                    new SqlParameter("@data_demissao", user.Demissao)
                };
            banco.ExecutarComando(sql, parametros);
            return "OK";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

        public string AtualizarUsuarioComSenha(Usuarios user)
        {
            try
            {
                string sql = "UPDATE tb_usuarios SET status_usuario = @StatusUsuario, nome = @Nome, apelido = @Apelido, " +
                             "sexo = @Sexo, rg = @RG, cpf = @CPF, email = @Email, senha = @Senha, telefone = @Telefone, celular = @Celular, cep = @CEP, " +
                             "endereco = @Endereco, numero = @Numero, complemento = @Complemento, bairro = @Bairro, id_cargo = @IdCargo, " +
                             "id_cidade = @IdCidade, data_nasc = @DataNasc, data_ult_alteracao = @DataUltimaAlteracao, data_demissao = @data_demissao " +
                             "WHERE id_usuario = @Id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@StatusUsuario", user.StatusUsuario),
                    new SqlParameter("@Nome", user.Nome),
                    new SqlParameter("@Apelido", user.Apelido),
                    new SqlParameter("@Sexo", user.Sexo),
                    new SqlParameter("@RG", user.RG),
                    new SqlParameter("@CPF", user.CPF),
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@Senha", user.Senha),
                    new SqlParameter("@Telefone", user.Telefone),
                    new SqlParameter("@Celular", user.Celular),
                    new SqlParameter("@CEP", user.CEP),
                    new SqlParameter("@Endereco", user.Endereco),
                    new SqlParameter("@Numero", user.Numero),
                    new SqlParameter("@Complemento", user.Complemento),
                    new SqlParameter("@Bairro", user.Bairro),
                    new SqlParameter("@IdCargo", user.Cargo.ID),
                    new SqlParameter("@IdCidade", user.Cidade.ID),
                    new SqlParameter("@DataNasc", user.DataNascimento),
                    new SqlParameter("@DataUltimaAlteracao", user.DataUltimaAlteracao),
                    new SqlParameter("@data_demissao", user.Demissao ?? (object)DBNull.Value), // Nome correto do parâmetro
                    new SqlParameter("@Id", user.ID)
                };

                banco.ExecutarComando(sql, parametros);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public Usuarios AtualizarSenha(Usuarios user)
    {
        try
        {
            string sql = "UPDATE tb_usuarios SET data_ult_alteracao = @DataUltimaAlteracao, senha = @Senha WHERE id_usuario = @Id";
            SqlParameter[] parametros =
            {
                    new SqlParameter("@Senha", user.Senha),
                    new SqlParameter("@DataUltimaAlteracao", user.DataUltimaAlteracao),
                    new SqlParameter("@Id", user.ID)
                };
            banco.ExecutarComando(sql, parametros);
            return user;
        }
        catch (Exception)
        {
            return new Usuarios();
        }
    }
        public string AtualizarUsuarioSemSenha(Usuarios user)
        {
            try
            {
                string sql = "UPDATE tb_usuarios SET status_usuario = @StatusUsuario, nome = @Nome, apelido = @Apelido, " +
                             "sexo = @Sexo, rg = @RG, cpf = @CPF, email = @Email, telefone = @Telefone, celular = @Celular, cep = @CEP, " +
                             "endereco = @Endereco, numero = @Numero, complemento = @Complemento, bairro = @Bairro, id_cargo = @IdCargo, " +
                             "id_cidade = @IdCidade, data_nasc = @DataNasc, data_ult_alteracao = @DataUltimaAlteracao, data_demissao = @data_demissao " +
                             "WHERE id_usuario = @Id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@StatusUsuario", user.StatusUsuario),
                    new SqlParameter("@Nome", user.Nome),
                    new SqlParameter("@Apelido", user.Apelido),
                    new SqlParameter("@Sexo", user.Sexo),
                    new SqlParameter("@RG", user.RG),
                    new SqlParameter("@CPF", user.CPF),
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@Telefone", user.Telefone),
                    new SqlParameter("@Celular", user.Celular),
                    new SqlParameter("@CEP", user.CEP),
                    new SqlParameter("@Endereco", user.Endereco),
                    new SqlParameter("@Numero", user.Numero),
                    new SqlParameter("@Complemento", user.Complemento),
                    new SqlParameter("@Bairro", user.Bairro),
                    new SqlParameter("@IdCargo", user.Cargo.ID),
                    new SqlParameter("@IdCidade", user.Cidade.ID),
                    new SqlParameter("@DataNasc", user.DataNascimento),
                    new SqlParameter("@DataUltimaAlteracao", user.DataUltimaAlteracao),
                    new SqlParameter("@data_demissao", user.Demissao ?? (object)DBNull.Value), // Corrigido para corresponder à query
                    new SqlParameter("@Id", user.ID)
                };

                banco.ExecutarComando(sql, parametros);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public bool ExcluirUsuario(int userId)
    {
        try
        {
            string sql = "DELETE FROM tb_usuarios WHERE id_usuario = @Id";
            SqlParameter parametro = new SqlParameter("@Id", userId);
            banco.ExecutarComando(sql, new[] { parametro });
            return true;
        }
        catch (Exception ex)
        {
            operacao.HandleException("Erro ao excluir funcionário", ex);
            return false;
        }
    }

    public Usuarios BuscarUsuarioPorId(int id)
    {
        try
        {
            string query = "SELECT * FROM tb_usuarios WHERE id_usuario = @Id";
            SqlParameter parametro = new SqlParameter("@Id", id);
            DataTable dataTable = banco.ExecutarConsulta(query, new[] { parametro });

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return CreateUsuarioFromDataRow(row);
            }

            return null;
        }
        catch (Exception ex)
        {
            operacao.HandleException("Erro ao buscar funcionário por ID", ex);
            return null;
        }
    }

    public List<Usuarios> ListarUsuarios(string status)
    {
        try
        {
            string sql = "SELECT * FROM tb_usuarios";
            List<SqlParameter> parametros = new List<SqlParameter>();

            // Verifica se o parâmetro de status foi fornecido e adiciona a cláusula WHERE, se necessário
            if (!string.IsNullOrEmpty(status))
            {
                sql += " WHERE status_usuario = @Status";
                parametros.Add(new SqlParameter("@Status", status));
            }

            DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());
            return CreateUsuariosListFromDataTable(dataTable);
        }
        catch (Exception ex)
        {
            operacao.HandleException("Erro ao listar funcionários", ex);
            return new List<Usuarios>();
        }
    }


    private Usuarios CreateUsuarioFromDataRow(DataRow row)
    {
        return new Usuarios
        {
            ID = Convert.ToInt32(row["id_usuario"]),
            StatusUsuario = row["status_usuario"].ToString(),
            Nome = row["nome"].ToString(),
            Apelido = row["apelido"].ToString(),
            Sexo = row["sexo"].ToString(),
            RG = row["rg"].ToString(),
            CPF = row["cpf"].ToString(),
            Email = row["email"].ToString(),
            Senha = row["senha"].ToString(),
            Telefone = row["telefone"].ToString(),
            Celular = row["celular"].ToString(),
            CEP = row["cep"].ToString(),
            Endereco = row["endereco"].ToString(),
            Numero = Convert.ToInt32(row["numero"]),
            Complemento = row["complemento"].ToString(),
            Bairro = row["bairro"].ToString(),
            Cargo = cargosController.BuscarCargoPorId(Convert.ToInt32(row["id_cargo"])),
            Cidade = cidadesController.BuscarCidadePorId(Convert.ToInt32(row["id_cidade"])),
            DataNascimento = Convert.ToDateTime(row["data_nasc"]),
            DataCriacao = Convert.ToDateTime(row["data_criacao"]),
            DataUltimaAlteracao = Convert.ToDateTime(row["data_ult_alteracao"]),
            Demissao = row["data_demissao"] != DBNull.Value ? Convert.ToDateTime(row["data_demissao"]) : new DateTime(2001, 1, 1)
        };
    }

    private List<Usuarios> CreateUsuariosListFromDataTable(DataTable dataTable)
    {
        List<Usuarios> usuarios = new List<Usuarios>();
        foreach (DataRow row in dataTable.Rows)
        {
            usuarios.Add(CreateUsuarioFromDataRow(row));
        }
        return usuarios;
    }
 

    public Usuarios ValidarLogin(string emailOuApelido, string senha)
    {
        try
        {
            if (string.IsNullOrEmpty(emailOuApelido) || string.IsNullOrEmpty(senha))
            {
                return null;
            }

            string sql = "SELECT * FROM tb_usuarios WHERE (email = @EmailOuApelido OR apelido = @EmailOuApelido) AND senha = @Senha";
            SqlParameter[] parametros =
            {
                new SqlParameter("@EmailOuApelido", emailOuApelido),
                    new SqlParameter("@Senha", senha)
                };

            DataTable dataTable = banco.ExecutarConsulta(sql, parametros);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return CreateUsuarioFromDataRow(row);
            }

            return null;
        }
        catch (Exception ex)
        {
            operacao.HandleException("Erro ao validar login", ex);
            return null;
        }
    }

        public List<Usuarios> Pesquisar(string filtro, string status)
        {
            try
            {
                string query = @"SELECT * FROM tb_usuarios 
                         WHERE (nome LIKE @Filtro OR cpf LIKE @Filtro OR rg LIKE @Filtro OR apelido LIKE @Filtro OR email LIKE @Filtro OR telefone LIKE @Filtro OR celular LIKE @Filtro) 
                         AND status_usuario = @Status";

                SqlParameter[] parametros = {
                    new SqlParameter("@Filtro", "%" + filtro + "%"),
                    new SqlParameter("@Status", status)
                    };

                DataTable dataTable = banco.ExecutarConsulta(query, parametros);

                List<Usuarios> listaUsuarios = new List<Usuarios>();
                foreach (DataRow row in dataTable.Rows)
                {
                    listaUsuarios.Add(CreateUsuarioFromDataRow(row));
                }

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                operacao.HandleException("Erro ao pesquisar usuário", ex);
                return new List<Usuarios>();
            }
        }

        public string CriptografarDadosSHA256(string dados)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dados));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public Usuarios BuscarPorEmailOuApelido(string func)
    {
        try
        {
            string sql = "SELECT * FROM tb_usuarios WHERE email = @emailOuApelido OR apelido = @emailOuApelido";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                    new SqlParameter("@emailOuApelido", func)
                };

            DataTable dataTable = banco.ExecutarConsulta(sql, parametros.ToArray());

            // Verifica se a consulta retornou algum resultado
            if (dataTable.Rows.Count > 0)
            {
                // Cria um objeto Usuarios a partir da primeira linha da DataTable
                return CreateUsuarioFromDataRow(dataTable.Rows[0]);
            }
            else
            {
                return null; // Retorna null se nenhum resultado for encontrado
            }
        }
        catch (Exception ex)
        {
            operacao.HandleException("Erro ao buscar funcionário por email ou apelido", ex);
            return null;
        }
    }


}
}

