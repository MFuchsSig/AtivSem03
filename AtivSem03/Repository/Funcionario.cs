using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace AtivSem03.Repository
{
    public class Funcionario
    {
        public static void save(Models.Funcionario funcionario)
        {

            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "insert into Funcionario(CodigoDepartamento, PrimeiroNome, DataNascimento, CPF, RG, Endereço, CEP, Cidade, Funcao, Salario) values(@CodigoDepartamento, @PrimeiroNome,@DataNascimento, @CPF, @RG, @Endereço, @CEP, @Cidade,@Funcao, @Salario);";
                    cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", System.Data.SqlDbType.Int)).Value = funcionario.CodigoDepartamento;
                    cmd.Parameters.Add(new SqlParameter("@PrimeiroNome", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.PrimeiroNome;
                    cmd.Parameters.Add(new SqlParameter("@DataNascimento", System.Data.SqlDbType.Date)).Value = funcionario.DataNascimento;
                    cmd.Parameters.Add(new SqlParameter("@CPF", System.Data.SqlDbType.Int)).Value = funcionario.CPF;
                    cmd.Parameters.Add(new SqlParameter("@RG", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.RG;
                    cmd.Parameters.Add(new SqlParameter("@Endereço", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.Endereco;
                    cmd.Parameters.Add(new SqlParameter("@CEP", System.Data.SqlDbType.Int)).Value = funcionario.CEP;
                    cmd.Parameters.Add(new SqlParameter("@Cidade", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.Cidade;
                    cmd.Parameters.Add(new SqlParameter("@Funcao", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.Funcao;
                    cmd.Parameters.Add(new SqlParameter("@Salario", System.Data.SqlDbType.VarChar)).Value = funcionario.Salario = funcionario.Salario;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Models.Funcionario> getAll()
        {

            List<Models.Funcionario> funcionarios = new List<Models.Funcionario>();

            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "select Codigo, CodigoDepartamento, PrimeiroNome,DataNascimento, CPF, RG, Endereço, CEP, Cidade,Funcao, Salario from Funcionario;";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Models.Funcionario funcionario = new Models.Funcionario();
                        funcionario.Id = (int)dr["Codigo"];
                        funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                        funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                        funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                        funcionario.CPF = (int)dr["CPF"];
                        funcionario.RG = (string)dr["RG"];
                        funcionario.Endereco = (string)dr["Endereço"];
                        funcionario.CEP = (int)dr["CEP"];
                        funcionario.Cidade = (string)dr["Cidade"];
                        funcionario.Funcao = (string)dr["Funcao"];
                        funcionario.Salario = (decimal)dr["Salario"];
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public static Models.Funcionario getById(int codigo)
        {
            Models.Funcionario funcionario = new Models.Funcionario();

            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "select Codigo, CodigoDepartamento, PrimeiroNome, DataNascimento, CPF, RG, Endereço, CEP, Cidade, Funcao, Salario from Funcionario where Codigo = @Codigo";
                    cmd.Parameters.Add(new SqlParameter("@codigo", System.Data.SqlDbType.Int)).Value = codigo;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        funcionario.Id = (int)dr["Codigo"];
                        funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                        funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                        funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                        funcionario.CPF = (int)dr["CPF"];
                        funcionario.RG = (string)dr["RG"];
                        funcionario.Endereco = (string)dr["Endereço"];
                        funcionario.CEP = (int)dr["CEP"];
                        funcionario.Cidade = (string)dr["Cidade"];
                        funcionario.Funcao = (string)dr["Funcao"];
                        funcionario.Salario = (decimal)dr["Salario"];
                    }
                }
            }
            return funcionario;
        }

        public static void deleteById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "delete from Funcionario where Codigo = @codigo";
                    cmd.Parameters.Add(new SqlParameter("@codigo", System.Data.SqlDbType.Int)).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void update(Models.Funcionario funcionario)
        {
            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "update Funcionario set CodigoDepartamento = @CodigoDepartamento, PrimeiroNome = @PrimeiroNome,DataNascimento = @DataNascimento, CPF = @CPF, RG = @RG, Endereço = @Endereco, CEP = @CEP, Cidade = @Cidade,Funcao = @Funcao, Salario = @Salario from Funcionario where Codigo = @Codigo";
                    cmd.Parameters.Add(new SqlParameter("@Codigo", System.Data.SqlDbType.Int)).Value = funcionario.Id;
                    cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", System.Data.SqlDbType.Int)).Value = funcionario.CodigoDepartamento;
                    cmd.Parameters.Add(new SqlParameter("@PrimeiroNome", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.PrimeiroNome;
                    cmd.Parameters.Add(new SqlParameter("@DataNascimento", System.Data.SqlDbType.Date)).Value = funcionario.DataNascimento;
                    cmd.Parameters.Add(new SqlParameter("@CPF", System.Data.SqlDbType.Int)).Value = funcionario.CPF;
                    cmd.Parameters.Add(new SqlParameter("@RG", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.RG;
                    cmd.Parameters.Add(new SqlParameter("@Endereco", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.Endereco;
                    cmd.Parameters.Add(new SqlParameter("@CEP", System.Data.SqlDbType.Int)).Value = funcionario.CEP;
                    cmd.Parameters.Add(new SqlParameter("@Cidade", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.Cidade;
                    cmd.Parameters.Add(new SqlParameter("@Funcao", System.Data.SqlDbType.VarChar, 100)).Value = funcionario.Funcao;
                    cmd.Parameters.Add(new SqlParameter("@Salario", System.Data.SqlDbType.VarChar)).Value = funcionario.Salario = funcionario.Salario;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

