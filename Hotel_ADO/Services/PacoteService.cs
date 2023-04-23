using Hotel_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class PacoteService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\Hotel_ADO\BancoDeDados\hotel.mdf";
        readonly SqlConnection conn;

        public PacoteService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Pacote pacote)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Pacote (IdHotel, IdPassagem, DataCadastro, Valor, IdCliente)" +
                    "values (@IdHotel, @IdPassagem, @DataCadastro, @Valor, @IdCliente)";

                SqlCommand comandInsert = new SqlCommand(strInsert, conn);

                comandInsert.Parameters.Add(new SqlParameter("@IdHotel", pacote.Hotel));
                comandInsert.Parameters.Add(new SqlParameter("@IdPassagem", pacote.Passagem));
                comandInsert.Parameters.Add(new SqlParameter("@DataCadastro", pacote.DataCadastro));
                comandInsert.Parameters.Add(new SqlParameter("@Valor", pacote.Valor));
                comandInsert.Parameters.Add(new SqlParameter("@IdCliente", pacote.Cliente));

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



        public List<Pacote> FindAll()
        {
            List<Pacote> pacotes = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Nome, IdEndereco, DataCadastro, Valor from Hotel");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Pacote pacote = new();

                pacote.Id = (int)dr["Id"];
                pacote.Hotel = (Hotel_ADO.Models.Hotel)dr["IdHotel"];
                pacote.Passagem = (Passagem)dr["IdPassagem"];
                pacote.DataCadastro = (DateTime)dr["DataCadastro"];
                pacote.Valor = (decimal)dr["Valor"];
                pacote.Cliente = (Cliente)dr["IdCliente"];

                pacotes.Add(pacote);
            }

            return pacotes;
        }
    }
}
