using Hotel_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class PassagemService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\Hotel_ADO\BancoDeDados\hotel.mdf";
        readonly SqlConnection conn;

        public PassagemService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Passagem passagem)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Passagem (IdOrigem, IdDestino, IdCliente, Data, Valor)" +
                    "values (@IdOrigem, @IdDestino, @IdCliente, @Data, @Valor)";

                SqlCommand comandInsert = new SqlCommand(strInsert, conn);

                comandInsert.Parameters.Add(new SqlParameter("@IdOrigem", passagem.Origem));
                comandInsert.Parameters.Add(new SqlParameter("@IdDestino", passagem.Destino));
                comandInsert.Parameters.Add(new SqlParameter("@IdCliente", passagem.Cliente));
                comandInsert.Parameters.Add(new SqlParameter("@Data", passagem.Data));
                comandInsert.Parameters.Add(new SqlParameter("@Valor", passagem.Valor));
                

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

  

        public List<Passagem> FindAll()
        {
            List<Passagem> passagens = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select IdOrigem, IdDestino, IdCliente, Data, Valor from Passagem");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Passagem passagem = new();

                passagem.Origem = (Endereco)dr["IdOrigem"];
                passagem.Destino = (Endereco)dr["IdDestino"];
                passagem.Cliente = (Cliente)dr["IdCliente"];
                passagem.Data = (DateTime)dr["Data"];
                passagem.Valor = (decimal)dr["Valor"];                

                passagens.Add(passagem);
            }

            return passagens;
        }
    }
}
