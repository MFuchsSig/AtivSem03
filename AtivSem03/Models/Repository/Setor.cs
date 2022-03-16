using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtivSem03.Models.Repository
{
    public class Setor
    {
        public static void save(Models.Setor setor)
        {
            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "Insert into Setor(Nome,Rg,Sexo) values (@Nome,@Rg,@Sexo)";
                    cmd.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 100)).Value = setor.Nome;
                    cmd.Parameters.Add(new SqlParameter("@Rg", System.Data.SqlDbType.VarChar, 18)).Value = setor.Rg;
                    cmd.Parameters.Add(new SqlParameter("@Sexo", System.Data.SqlDbType.VarChar, 20)).Value = setor.Sexo;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Models.Setor> getAll()
        {
            List<Models.Setor> setor = new List<Models.Setor>();

            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "select Codigo, Nome,Rg,Sexo from setor";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Models.Setor setor = new Models.Setor();
                        setorId = (int)dr["Codigo"];
                        setor.Nome = (string)dr["Nome"];
                        setor.Rg = (string)dr["Rg"];
                        setor.Sexo = (string)dr["Sexo"];
                        setor.Add(setor);
                    }
                }
            }
            return setor;
        }

        public static Models.Setor getById(int id)
        {
            Models.Setor setor = new Models.Departamento();

            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "select codigo, nome,rg,sexo from setor where codigo = @codigo";
                    cmd.Parameters.Add(new SqlParameter("@codigo", System.Data.SqlDbType.Int)).Value = id;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        setor.Id = (int)dr["Codigo"];
                        setor.Nome = (string)dr["Nome"];
                        setor.Rg = (string)dr["Rg"];
                        setor.Sexo = (string)dr["Sexo"];
                    }
                }
            }
            return setor;
        }

        public static void deleteById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "delete from Setor where codigo = @codigo";
                    cmd.Parameters.Add(new SqlParameter("@codigo", System.Data.SqlDbType.Int)).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void update(Models.Setor setor)
        {
            using (SqlConnection conexaoSQL = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexaoSQL.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexaoSQL;
                    cmd.CommandText = "update Setor set Nome = @Nome ,Rg = @Rg,Sexo = @Sexo where Codigo = @Codigo";
                    cmd.Parameters.Add(new SqlParameter("@Codigo", System.Data.SqlDbType.Int)).Value = setor.Id;
                    cmd.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 100)).Value = setor.Nome;
                    cmd.Parameters.Add(new SqlParameter("@Rg", System.Data.SqlDbType.VarChar, 18)).Value = setor.Rg;
                    cmd.Parameters.Add(new SqlParameter("@Sexo", System.Data.SqlDbType.VarChar, 20)).Value = setor.Sexo;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

