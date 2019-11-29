using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TCC
{
    class Usuario
    {
        private string usuario;
        private string email;
        private string senha;
        private int nivel;
        private string proximoUsuario;

        public void cadastrarUsuario()
        {

        }
        public void deletarUsuario()
        {

        }
        public void editarUsuario()
        {

        }
        public bool usuarioExistente()
        {
            return false;
        }
        public bool emailExistente()
        {
            return false;
        }

        public Usuario(string login, string senha)
        {
            setUsuario(login);
            setSenha(senhaHash(senha));
        }
        public int login()
        {
            AcessoBancodeDados login = new AcessoBancodeDados();
            return login.LoginUsuario(getUsuario(),getSenha());
        }
        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }
        public void setNivel(int nivel)
        {
            this.nivel = nivel;
        }
        
        public string getUsuario()
        {
            return this.usuario;
        }

        private string getSenha()
        {
            return this.senha;
        }
        public string getEmail()
        {
            return this.email;
        }

        public int getNivel()
        {
            return this.nivel;
        }

        public static string senhaHash(string senha)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(senha));
            return byteArrayToString(hashedDataBytes);
        }

        public static string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }

        public void setProximoUsuario()
        {
            this.proximoUsuario = AcessoBancodeDados.proximoUsuario();
        }
        public string getProximoUsuario()
        {
            return this.proximoUsuario;
        }
    }

}
