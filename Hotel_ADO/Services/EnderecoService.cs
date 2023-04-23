using Hotel_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class EnderecoService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\Hotel_ADO\BancoDeDados\hotel.mdf";
        readonly SqlConnection conn;

        public EnderecoService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Endereco endereco)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro)" +
                    "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade, @DataCadastro)";

                SqlCommand comandInsert = new SqlCommand(strInsert, conn);

                comandInsert.Parameters.Add(new SqlParameter("@Logradouro", endereco.Logradouro));
                comandInsert.Parameters.Add(new SqlParameter("@Numero", endereco.Numero));
                comandInsert.Parameters.Add(new SqlParameter("@Bairro", endereco.Bairro));
                comandInsert.Parameters.Add(new SqlParameter("@CEP", endereco.CEP));
                comandInsert.Parameters.Add(new SqlParameter("@Complemento", endereco.Complemento));
                comandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCidade(endereco)));
                comandInsert.Parameters.Add(new SqlParameter("@DataCadastro", endereco.DataCadastro));

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

        private int InsertCidade(Endereco endereco)
        {
            string strInsert = "insert into Cidade (Descricao, DataCadastro) values (@Descricao, @DataCadastro); select cast(scope_identity() as int)";
            SqlCommand comandInsert = new SqlCommand(strInsert, conn);
            comandInsert.Parameters.Add(new SqlParameter("@Descricao", endereco.Cidade.Descricao));
            comandInsert.Parameters.Add(new SqlParameter("@DataCadastro", endereco.Cidade.DataCadastro));

            return (int)comandInsert.ExecuteScalar();
        }

        public List<Endereco> FindAll()
        {
            List<Endereco> enderecos = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro from Endereco");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Endereco endereco = new();

                endereco.Id = (int)dr["Id"];
                endereco.Logradouro = (string)dr["Logradouro"];
                endereco.Numero = (int)dr["Numero"];
                endereco.Bairro = (string)dr["Bairro"];
                endereco.CEP = (string)dr["CEP"];
                endereco.Complemento = (string)dr["Complemento"];
                endereco.Cidade = new Cidade() { Id = (int)dr["IdCidade"], Descricao = (string)dr["Descricao"], DataCadastro = (DateTime)dr["DataCadastro"]  };
                endereco.DataCadastro = (DateTime)dr["DataCadastro"];

                enderecos.Add(endereco);
            }

            return enderecos;
        }
    }
}
