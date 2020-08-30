using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelss;
using System.Data.SqlClient;

namespace DAL
{
    public class ProdutoDAL
    {
        //atributo privado de uma classe serve pra colocar os dados de conexão do servido
        private string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDSistemaAula_3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Criar um método para insersão no banco de dados
        public void InserirProdutos(Produto produto)
        {
            //Criar a conexão
            SqlConnection conn = new SqlConnection(connetionString);

            //Abrir a conexão
            conn.Open();

            //Criar a sintaxe para inserir o produto
            string sql = "INSERT INTO Produtoss VALUES (@desc, @unit, @peso)";

            //Criar um objeto do tipó command sql
            SqlCommand cmd = new SqlCommand(sql, conn);

            //Trocar os parametros do comando
            cmd.Parameters.AddWithValue("@desc", produto.Descricao);
            cmd.Parameters.AddWithValue("@unit", produto.ValorUnitario);
            cmd.Parameters.AddWithValue("@peso", produto.PesoKG);
            //Mandar executar o comando no servidor
            cmd.ExecuteNonQuery();


            //Fechar a conexão do banco
            conn.Close();

        }

        public void AtualizarProduto(Produto produto)
        {
            SqlConnection conn = new SqlConnection(connetionString);

            conn.Open();

            string sql = "UPDATE Produtoss SET Descricao = @desc, ValorUnitario = @unit, PesoKG = @peso WHERE Codigo = @cod";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@desc", produto.Descricao);
            cmd.Parameters.AddWithValue("@unit", produto.ValorUnitario);
            cmd.Parameters.AddWithValue("@peso", produto.PesoKG);
            cmd.Parameters.AddWithValue("@cod", produto.Codigo);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void DeletarProduto(Produto produto)
        {
            SqlConnection conn = new SqlConnection(connetionString);

            conn.Open();

            string sql = "DELETE FROM Produtoss  WHERE Codigo = @cod";
            SqlCommand cmd = new SqlCommand(sql, conn);

           
            cmd.Parameters.AddWithValue("@cod", produto.Codigo);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
