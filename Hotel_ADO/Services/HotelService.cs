using Hotel_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ADO.Services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\Hotel_ADO\BancoDeDados\hotel.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Models.Hotel hotel)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Hotel1 (Nome, IdEndereco, DataCadastro, Valor)" +
                    "values (@Nome, @IdEndereco, @DataCadastro, @Valor)";

                SqlCommand comandInsert = new SqlCommand(strInsert, conn);

                comandInsert.Parameters.Add(new SqlParameter("@Nome", hotel.Nome));
                comandInsert.Parameters.Add(new SqlParameter("@IdEndereco", hotel.Endereco));
                comandInsert.Parameters.Add(new SqlParameter("@DataCadastro", hotel.DataCadastro));
                comandInsert.Parameters.Add(new SqlParameter("@Valor", hotel.Valor));

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

        

        public List<Models.Hotel> FindAll()
        {
            List<Models.Hotel> hoteis = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Nome, IdEndereco, DataCadastro, Valor from Hotel");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Models.Hotel hotel = new();

                hotel.Id = (int)dr["Id"];
                hotel.Nome = (string)dr["Nome"];
                hotel.Endereco = (Endereco)dr["IdEndereco"];
                hotel.DataCadastro = (DateTime)dr["DataCadastro"];
                hotel.Valor = (decimal)dr["Valor"];

                hoteis.Add(hotel);
            }

            return hoteis;
        }
    }
}
