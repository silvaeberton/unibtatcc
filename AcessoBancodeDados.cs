using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC
{
    class AcessoBancodeDados
    {
        public int LoginUsuario(string usuario, string senhaHash)
        {

            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand("Select * from usuarios where usuario='" + usuario + "'", conexao);
            DataTable tabeladados = new DataTable();

            if(conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }            

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if(tabeladados.Rows.Count > 0)
            {
                if(tabeladados.Rows[0]["senha"].ToString() == senhaHash)
                {                    
                    if(tabeladados.Rows[0]["nivel"].ToString() == "user"){
                        conexao.Close();
                        return 1;
                    }
                    else
                    {
                        conexao.Close();
                        return 2;
                    }        
                }
                else
                {
                    conexao.Close();
                    return 0;
                }
            }
            else
            {
                conexao.Close();
                return 0;
            } 
            
        }
        public static string proximoUsuario()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"Select IDENT_CURRENT('usuarios')+1 as indice", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if(conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }            
            return tabeladados.Rows[0]["indice"].ToString();
        }
        
        public bool VerificaUsuarioExistente(string usuario)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from usuarios where usuario ='" + usuario.ToString() + "'", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            if (tabeladados.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificaEmailExistente(string email)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from usuarios where email ='" + email.ToString() + "'", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            if (tabeladados.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CadastraUsuario(string usuario, string email, string senhaHash,string nivel)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"insert into usuarios(usuario, email, senha,nivel)
            values('" + usuario.ToString() + "','" + email.ToString() + "','" + senhaHash.ToString() + "','" + nivel.ToString() + "')", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletaUsuario(string ID_usuario)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"delete from usuarios where ID_produto = " + ID_usuario, conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }

    class AcessoBancoProdutos
    {
        public void CadastraProduto(string produto, string valor, string descricao, string marca)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"insert into produtos(valor, descricao,marca,produto)
            values('" + valor.ToString() + "','"  + descricao.ToString() + "','" + marca.ToString() + "','" + produto.ToString() + "')", conexao) ;
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }            
        }

        public bool VerificaProdutoCadastrado(string produto, string marca)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from produtos where descricao ='" + produto.ToString() + "' and marca='" + marca.ToString() + "'", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            if(tabeladados.Rows.Count > 0)
            {
                return true;
            }
            else{
                return false;
            }            
        }

        public bool VerificaProdutoDeletado(string ID_produto)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from produtos where ID_produto = '" + ID_produto + "'", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            if (tabeladados.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeletaProduto(string produto)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"delete from produtos where ID_produto = " + produto , conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }            
        }

        public DataTable ListaProdutos()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from produtos", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            return tabeladados;
        }

        public DataRow ConsultaProduto(string ID_produto)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from produtos where ID_produto = '" + ID_produto +"'" , conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            return tabeladados.Rows[0];
        }

        public void EditaProduto(string codigo_produto, string produto, string valor, string descricao, string marca)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"update produtos
            set valor = '" + valor + "', descricao = '" + descricao + "',marca='" + marca + "',produto='" + produto + "' where ID_produto = " + codigo_produto, conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public static string proximoProduto()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"Select IDENT_CURRENT('produtos')+1 as indice", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            return tabeladados.Rows[0]["indice"].ToString();
        }
    }

    class AcessoBancoPedidos
    {

    }

    class AcessoBancoClientes
    {
        public void CadastraCliente(string nome, string datacadastro, string nascimento, string endereco, string cpf)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"insert into clientes(nome, datacadastro, nascimento,endereco, cpf)
            values('" + nome.ToString() + "','" + datacadastro.ToString() + "','" + nascimento.ToString() + "','" + endereco.ToString() + "','" + cpf.ToString() + "')", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        public DataTable ListaClientes()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from clientes", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            return tabeladados;
        }
        public string ConsultaCliente(int ID_cliente)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from clientes where ID_cliente = '" + ID_cliente.ToString() + "'", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            return tabeladados.Rows[0].ToString();
        }
        public void EditaCliente(string codigo_cliente, string nome, string datacadastro, string nascimento, string endereco, string cpf)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"update produtos
            set nome = '" + nome + "', datacadastro = '" + datacadastro + "', nascimento = '" + nascimento + "',endereco='" + endereco + "',cpf='" + cpf +"' where ID_produto = " + codigo_cliente, conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        public static string ProximoCliente()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"Select IDENT_CURRENT('clientes')+1 as indice", conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            return tabeladados.Rows[0]["indice"].ToString();
        }
        public void DeletaCliente(string cliente)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"delete from clientes where ID_clientes = " + cliente, conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        public bool VerificaClienteCadastrado(string cpf)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=NBDS52\EXPRESS; Initial Catalog=originaleletronicos; Integrated Security=True");
            SqlCommand comando = new SqlCommand(@"select * from clientes where cpf ='" + cpf, conexao);
            DataTable tabeladados = new DataTable();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            SqlDataReader sdr = comando.ExecuteReader();
            tabeladados.Load(sdr);
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            if (tabeladados.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
