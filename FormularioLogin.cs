using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TCC
{

    public partial class FormularioLogin : Form
    {        
        
        public FormularioLogin()
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do Sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string senha = textBoxSenha.Text;

            Usuario usuario = new Usuario(login, senha);
            int logar = usuario.login();
            //textBoxLogin.Text = Usuario.senhaHash("user");

            if(logar == 1 || logar ==2)
            {
                this.Hide();
                Form1 formularioPrincipal = new Form1();
                formularioPrincipal.Closed += (s, args) => this.Close();
                formularioPrincipal.loginNivel = logar;
                formularioPrincipal.usuario = login;
                formularioPrincipal.Show();
            }
            else
            {
                labelExistente.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {      
            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
                    
        }
    }
}
