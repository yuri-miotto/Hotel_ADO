using Hotel_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class ClienteService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\Hotel_ADO\BancoDeDados\hotel.mdf";
        readonly SqlConnection conn;

        public ClienteService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Cliente cliente)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Cliente (Nome, Telefone, IdEndereco, DataCadastro)" +
                    "values (@Nome, @Telefone, @IdEndereco, @DataCadastro)";

                SqlCommand comandInsert = new SqlCommand(strInsert, conn);

                comandInsert.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
                comandInsert.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));
                comandInsert.Parameters.Add(new SqlParameter("@IdEndereco", cliente.Endereco));
                comandInsert.Parameters.Add(new SqlParameter("@DataCadastro", cliente.DataCadastro));

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

        public List<Cliente> FindAll()
        {
            List<Cliente> clientes = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Nome, Telefone, IdEndereco, DataCadastro from Cliente");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Cliente cliente = new();

                cliente.Id = (int)dr["Id"];
                cliente.Nome = (string)dr["Nome"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Endereco = new Endereco();
                cliente.DataCadastro = (DateTime)dr["DataCadastro"];

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
