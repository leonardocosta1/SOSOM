using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSOM.CAMADAS.DAL
{
    public class cliente
    {
        private string strCon = Conexao.getConexao();
        public List<MODEL.cliente> select()
        {
            List<MODEL.cliente> lstCliente = new List<MODEL.cliente>();
            SqlConnection Conexao = new SqlConnection(strCon);
            string sql = "select * from cliente";
            SqlCommand cmd = new SqlCommand(sql, Conexao);
            try
            {
                Conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.cliente cliente = new MODEL.cliente();
                    cliente.id = Convert.ToInt32(dados[0].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.endereco = dados["endereco"].ToString();
                    cliente.telefone = dados["telefone"].ToString();
                    lstCliente.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execução do comando select de clientes...");
            }
            return lstCliente;
        }

        public MODEL.cliente SelectByID(int id)
        {
            MODEL.cliente cliente = new MODEL.cliente();
            SqlConnection Conexao = new SqlConnection(strCon);
            string sql = "select * from clientes WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, Conexao);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                Conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader();
                if (dados.Read())
                {
                    cliente.id = Convert.ToInt32(dados[0].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.endereco = dados["endereco"].ToString();
                    cliente.telefone = dados["telefone"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execução do comando select de clientes por id");
            }
            finally
            {
                Conexao.Close();
            }
            return cliente;
        }

        public void Insert(MODEL.cliente cliente)
        {
            SqlConnection Conexao = new SqlConnection(strCon);
            string sql = "Insert into cliente values(@nome, @endereco, @telefone)";
            SqlCommand cmd = new SqlCommand(sql, Conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            try
            {
                Conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro inserção de clientes...");
            }
            finally
            {
                Conexao.Close();
            }
        }

        public void Update(MODEL.cliente cliente)
        {
            SqlConnection Conexao = new SqlConnection(strCon);
            string sql = "Update cliente SET nome=@nome, endereco=@endereco, telefone=@telefone WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, Conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            try
            {
                Conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro atualização de clientes...");
            }
            finally
            {
                Conexao.Close();
            }
        }

        public void Delete(int id)
        {
            SqlConnection Conexao = new SqlConnection(strCon);
            string sql = "Delete from cliente WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, Conexao);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                Conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro remoção  de cliente...");
            }
            finally
            {
                Conexao.Close();
            }
        }
    }
}
