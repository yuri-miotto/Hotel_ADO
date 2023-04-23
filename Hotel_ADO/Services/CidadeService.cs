using Hotel_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class CidadeService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\Hotel_ADO\BancoDeDados\hotel.mdf";
        readonly SqlConnection conn;

        public CidadeService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Cidade cidade)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Cidade (Descricao, DataCadastro)" +
                    "values (@Descricao, @DataCadastro)";

                SqlCommand comandInsert = new SqlCommand(strInsert, conn);

                comandInsert.Parameters.Add(new SqlParameter("@Descricao", cidade.Descricao));
                comandInsert.Parameters.Add(new SqlParameter("@DataCadastro", cidade.DataCadastro));

                comandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public List<Cidade> FindAll()
        {
            List<Cidade> cidades = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Descricao, DataCadastro from Cidade");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Cidade cidade = new();

                cidade.Id = (int)dr["Id"];
                cidade.Descricao = (string)dr["Descricao"];
                cidade.DataCadastro = (DateTime)dr["DataCadastro"];

                cidades.Add(cidade);
            }

            return cidades;
        }
    }
}
