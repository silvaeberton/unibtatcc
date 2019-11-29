using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TCC
{      
    public partial class Form1 : Form
    {
        private bool encostou;
        private bool menuExpandido;
        private int opcaoMenu;
        private int opcaoExpandida;
        public int loginNivel;
        public string usuario;
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwand, int wmsg, int wparam,int lparam);

        private void botaoMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
                paineldropPedidos.Size = paineldropPedidos.MinimumSize;
                paineldropClientes.Size = paineldropClientes.MinimumSize;
                paineldropProdutos.Size = paineldropProdutos.MinimumSize;
                paineldropRelatorios.Size = paineldropRelatorios.MinimumSize;
                paineldropConfiguracoes.Size = paineldropConfiguracoes.MinimumSize;
                encostou = true;
            }
            else
            {
                MenuVertical.Width = 250;
                //encostou = true;
            }
            menuExpandido = !menuExpandido;
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do Sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }           
        }

        private void botaoMazimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            botaoMazimizar.Visible = false;
            botaoRestaurar.Visible = true;
        }

        private void botaoRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            botaoMazimizar.Visible = true;
            botaoRestaurar.Visible = false;
        }

        private void botaoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,0xf012,0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (encostou && opcaoMenu != 0 && menuExpandido)
            {
                switch (opcaoMenu)
                {
                     case 1:
                        paineldropPedidos.Height += 10;
                        if (paineldropPedidos.Size == paineldropPedidos.MaximumSize)
                        {
                            timer1.Stop();
                            encostou = false;
                            escondeMenus();
                            painelPedidos.Visible = true;
                        }
                        opcaoExpandida = 1;
                        break;
                    case 2:                     
                        paineldropClientes.Height += 10;
                        if (paineldropClientes.Size == paineldropClientes.MaximumSize)
                        {
                            timer1.Stop();
                            encostou = false;
                            escondeMenus();
                            painelClientes.Visible = true;
                        }
                        opcaoExpandida = 2;
                        break;
                    case 3:
                        paineldropProdutos.Height += 10;
                        if (paineldropProdutos.Size == paineldropProdutos.MaximumSize)
                        {
                            timer1.Stop();
                            encostou = false;
                            escondeMenus();
                            painelProdutos.Visible = true;
                        }
                        opcaoExpandida = 3;
                        break;
                    case 4:
                        paineldropRelatorios.Height += 10;
                        if (paineldropRelatorios.Size == paineldropRelatorios.MaximumSize)
                        {
                            timer1.Stop();
                            encostou = false;
                            escondeMenus();
                            painelRelatorios.Visible = true;
                        }
                        opcaoExpandida = 4;
                        break;
                    case 5:
                        paineldropConfiguracoes.Height += 10;
                        if (paineldropConfiguracoes.Size == paineldropConfiguracoes.MaximumSize)
                        {
                            timer1.Stop();
                            encostou = false;
                        }
                        opcaoExpandida = 5;
                        break;                    
                };             
            }
            else
            {
                if(opcaoMenu == opcaoExpandida)
                {
                    switch (opcaoMenu)
                    {
                        case 1:
                            paineldropPedidos.Height -= 10;
                            if (paineldropPedidos.Size == paineldropPedidos.MinimumSize)
                            {
                                timer1.Stop();
                                encostou = true;
                                escondeMenus();
                                painelPedidos.Visible = true;
                            }
                            break;
                        case 2:
                            paineldropClientes.Height -= 10;
                            if (paineldropClientes.Size == paineldropClientes.MinimumSize)
                            {
                                timer1.Stop();
                                encostou = true;
                                escondeMenus();
                                painelClientes.Visible = true;
                            }
                            break;
                        case 3:
                            paineldropProdutos.Height -= 10;
                            if (paineldropProdutos.Size == paineldropProdutos.MinimumSize)
                            {
                                timer1.Stop();
                                encostou = true;
                                escondeMenus();
                                painelProdutos.Visible = true;
                            }
                            break;
                        case 4:
                            paineldropRelatorios.Height -= 10;
                            if (paineldropRelatorios.Size == paineldropRelatorios.MinimumSize)
                            {
                                timer1.Stop();
                                encostou = true;
                                escondeMenus();
                                painelRelatorios.Visible = true;
                            }
                            break;
                        case 5:
                            paineldropConfiguracoes.Height -= 10;
                            if (paineldropConfiguracoes.Size == paineldropConfiguracoes.MinimumSize)
                            {
                                timer1.Stop();
                                encostou = true;
                            }
                            break;
                    };
                }                               
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if(loginNivel == 1)
            {
                this.Enabled = true;
                encostou = true;
                menuExpandido = true;
                opcaoMenu = 0;
                opcaoExpandida = 0;
                escondeMenus();
                painelVender.Visible = true;
                paineldropConfiguracoes.Enabled = false;
                paineldropClientes.Enabled = false;
                paineldropPedidos.Enabled = false;
                paineldropProdutos.Enabled = false;
                paineldropRelatorios.Enabled = false;

                DateTime dateAndTime = DateTime.Now;
                DateTime date = dateAndTime.Date;
                labelDataAtual.Text = date.ToString("dd/MM/yyyy");
            }  
            if(loginNivel == 2)
            {
                this.Enabled = true;
                encostou = true;
                menuExpandido = true;
                opcaoMenu = 0;
                opcaoExpandida = 0;
                escondeMenus();
                painelVender.Visible = true;
                paineldropConfiguracoes.Enabled = true;
                paineldropClientes.Enabled = true;
                paineldropPedidos.Enabled = true;
                paineldropProdutos.Enabled = true;
                paineldropRelatorios.Enabled = true;

                DateTime dateAndTime = DateTime.Now;
                DateTime date = dateAndTime.Date;
                labelDataAtual.Text = date.ToString("dd/MM/yyyy");
            }
            botaoUsuario.Text = usuario;
        }

        private void botaoVender_Click(object sender, EventArgs e)
        {            
            opcaoMenu = 0;
            timer1.Start();
            if(encostou)
            {
                escondeMenus();
                painelVender.Visible = true;
            }
        }

        private void botaoClientes_Click(object sender, EventArgs e)
        {
            
            if (menuExpandido)
            {                
                timer1.Start();                                
            }
            if (encostou)
            {
                escondeMenus();
                painelClientes.Visible = true;
            }
            opcaoMenu = 2;

        }

        private void botaoProdutos_Click(object sender, EventArgs e)
        {
            
            if (menuExpandido)
            {
                timer1.Start();                
            }
            opcaoMenu = 3;
            if (encostou)
            {
                escondeMenus();                
                painelProdutos.Visible = true;
            }

            listViewUltimosProdutos.Items.Clear();
            AcessoBancoProdutos produtos = new AcessoBancoProdutos();
            DataTable tabelaProdutos = produtos.ListaProdutos();

            

            
            if (tabelaProdutos.Rows.Count > 9)
            {
                  
                for (int i = 0; i < 10; i++)
                {
                    String ID_produto = tabelaProdutos.Rows[i]["ID_produto"].ToString();
                    String produto = tabelaProdutos.Rows[i]["produto"].ToString();
                    String quantidade = tabelaProdutos.Rows[i]["quantidade"].ToString();
                    String valor = tabelaProdutos.Rows[i]["valor"].ToString();
                    String marca = tabelaProdutos.Rows[i]["marca"].ToString();

                    var item1 = new ListViewItem(new[] { ID_produto, produto, quantidade, valor, marca });
                    listViewUltimosProdutos.Items.Add(item1);
                }
                
            }
            else
            {
                
                for (int i = 0; i < tabelaProdutos.Rows.Count; i++)
                {


                    String ID_produto = tabelaProdutos.Rows[i]["ID_produto"].ToString();
                    String produto = tabelaProdutos.Rows[i]["produto"].ToString();                    
                    String valor = tabelaProdutos.Rows[i]["valor"].ToString();
                    String marca = tabelaProdutos.Rows[i]["marca"].ToString();

                    var item1 = new ListViewItem(new[] { ID_produto, produto, valor, marca });
                    listViewUltimosProdutos.Items.Add(item1);
                }                

            }
        }

        private void botaoRelatorios_Click(object sender, EventArgs e)
        {            
            if (menuExpandido)
            {
                timer1.Start();
            }
            opcaoMenu = 4;
            if (encostou)
            {
                escondeMenus();
                painelRelatorios.Visible = true;
            }
        }

        private void botaoPedidos_Click(object sender, EventArgs e)
        {
            
            if (menuExpandido)
            {
                timer1.Start();
            }
            opcaoMenu = 1;
            if (encostou)
            {
                escondeMenus();
                painelPedidos.Visible = true;
            }
        }

        private void botaoConfiguracoes_Click(object sender, EventArgs e)
        {            
            if (encostou)
            {
                escondeMenus();
                painelConfiguracoes.Visible = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            AcessoBancoProdutos produtosBanco = new AcessoBancoProdutos();
            DataTable tabelaProdutos = new DataTable();
            

        }

        public void escondeMenus()
        {
            painelAdicionarProduto.Visible = false;
            painelRelatoriosPedidos.Visible = false;
            painelRelatoriosProdutos.Visible = false;
            painelRelatoriosCliente.Visible = false;
            painelProdutos.Visible = false;
            painelDeletarProdutos.Visible = false;
            painelEditarProdutos.Visible = false;
            painelClientes.Visible = false;
            painelEditarCliente.Visible = false;
            painelDeletarCliente.Visible = false;
            painelCadastrarCliente.Visible = false;
            painelPedidosFinalizados.Visible = false;
            painelPedidosPendentes.Visible = false;            
            painelPedidos.Visible = false;
            painelVender.Visible = false;
            painelConfiguracoes.Visible = false;
            painelRelatorios.Visible = false;
        }

        private void botaoPedidosCancelados_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelPedidosCancelados.Visible = true;
        }

        private void botaoPedidosPendentes_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelPedidosPendentes.Visible = true;
        }

        private void botaoPedidosFinalizados_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelPedidosFinalizados.Visible = true;
        }

        private void botaoDeletarCliente_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelDeletarCliente.Visible = true;
        }

        private void botaoEditarCliente_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelEditarCliente.Visible = true;
        }

        private void botaoAdicionarCliente_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelCadastrarCliente.Visible = true;
        }

        private void botaoAdicionarProdutos_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelAdicionarProduto.Visible = true;
            textBox5.Text = "";            
            textBox6.Text = "";           
            textBoxProximoProduto.Text = "";
            textBoxProximoProduto.Text = AcessoBancoProdutos.proximoProduto();
            comboBox1.Items.Add("Apple");
            comboBox1.Items.Add("Samsung");
            comboBox1.Items.Add("Intel");
            comboBox1.Items.Add("Dell");
            comboBox1.Items.Add("Lenovo");
            comboBox1.SelectedIndex = 0;        
        }

        private void botaoEditarProdutos_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelEditarProdutos.Visible = true;
            textBox14.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;            
            comboBox2.Enabled = false;
        }

        private void botaoDeletarProdutos_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelDeletarProdutos.Visible = true;
        }

        private void botaoRelatoriosCliente_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelRelatoriosCliente.Visible = true;
        }

        private void botaoRelatoriosProdutos_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelRelatoriosProdutos.Visible = true;
        }

        private void botaoRelatoriosPedidos_Click(object sender, EventArgs e)
        {
            escondeMenus();
            painelRelatoriosPedidos.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("001", 0);
            item.SubItems.Add("Placa de Video");
            item.SubItems.Add("10");
            item.SubItems.Add("100");
            item.SubItems.Add("1000");

            listViewUltimosProdutos.Items.Add(item);
        }

        private void botaoPedidosFinalizados_Click_1(object sender, EventArgs e)
        {
            escondeMenus();
            painelPedidosFinalizados.Visible = true;
        }

        private void botaoPedidosPendentes_Click_1(object sender, EventArgs e)
        {
            escondeMenus();
            painelPedidosPendentes.Visible = true;
        }

        private void botaoPedidosCancelados_Click_1(object sender, EventArgs e)
        {
            escondeMenus();
            painelPedidosCancelados.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deletar Produto:","Deletar Produto",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MessageBox.Show("Apagado");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void botaoUsuario_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fazer Logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FormularioLogin formularioLogin = new FormularioLogin();
                formularioLogin.Closed += (s, args) => this.Close();
                formularioLogin.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {          
            string produtoNome = textBox5.Text;
            string produtoValor = textBox6.Text;            
            string produtoMarca = comboBox1.SelectedItem.ToString();
            string produtoDescricao = textBox13.Text;

            if (String.IsNullOrEmpty(produtoDescricao))
            {
                MessageBox.Show("Descrição inválida");
            }
            else
            {
                AcessoBancoProdutos produto = new AcessoBancoProdutos();
                produto.CadastraProduto(produtoNome,produtoValor, produtoDescricao, produtoMarca);

                if (produto.VerificaProdutoCadastrado(produtoDescricao, produtoMarca))
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }
            }           

            textBox5.Text = "";             
            textBox6.Text = "";            
            textBoxProximoProduto.Text = "";
            textBox13.Text = "";
            comboBox1.SelectedIndex = 0;
            textBoxProximoProduto.Text = AcessoBancoProdutos.proximoProduto();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AcessoBancoProdutos produto = new AcessoBancoProdutos();

            if(textBox16.Text.Length >= 1)
            {
                if (produto.VerificaProdutoDeletado(textBox16.Text))
                {
                    produto.DeletaProduto(textBox16.Text);
                    if (!produto.VerificaProdutoDeletado(textBox16.Text))
                    {
                        MessageBox.Show("Produto Deletado");
                    }
                }
                else
                {
                    MessageBox.Show("Produto não cadastrado");
                }
            }
            else
            {
                MessageBox.Show("Por favor preencha o produto");
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            AcessoBancoProdutos produtos = new AcessoBancoProdutos();
            
            if (produtos.VerificaProdutoDeletado(textBox20.Text))
            {
                textBox14.Enabled = true;
                textBox19.Enabled = true;
                textBox18.Enabled = true;                
                comboBox2.Enabled = true;
                textBox20.Enabled = false;
                button8.Enabled = true;

                DataRow coluna = produtos.ConsultaProduto(textBox20.Text);
                textBox18.Text = coluna[1].ToString();
                textBox19.Text = coluna[4].ToString();
                textBox14.Text = coluna[2].ToString();
                comboBox2.Items.Add("Apple");
                comboBox2.Items.Add("Samsung");
                comboBox2.Items.Add("Intel");
                comboBox2.Items.Add("Dell");
                comboBox2.Items.Add("Lenovo");
                comboBox2.SelectedItem = coluna[3].ToString();

            }
            else
            {
                MessageBox.Show("Produto Não Encontrado");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox14.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            comboBox2.Enabled = false;
            textBox20.Enabled = true;
            button8.Enabled = false;

            textBox14.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            for(int i=0; i < comboBox2.Items.Count; i++)
            {
                comboBox2.Items.RemoveAt(i);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            AcessoBancoProdutos produtos = new AcessoBancoProdutos();
            String codigo = textBox20.Text;
            String produto = textBox19.Text;
            String valor = textBox18.Text;
            String descricao = textBox14.Text;
            String marca = comboBox2.SelectedItem.ToString();

            produtos.EditaProduto(codigo, produto, valor, descricao, marca);

            MessageBox.Show("Produto Salvo");
            textBox14.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            comboBox2.Enabled = false;
            textBox20.Enabled = true;
            button8.Enabled = false;

            textBox14.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                comboBox2.Items.RemoveAt(i);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AcessoBancoProdutos produtos = new AcessoBancoProdutos();

            if (produtos.VerificaProdutoDeletado(textBox3.Text))
            {
                DataRow coluna = produtos.ConsultaProduto(textBox3.Text);

                textBox8.Text = coluna[1].ToString();
                textBox4.Text = coluna[4].ToString();
                

            }
            else
            {
                MessageBox.Show("Produto Não Encontrado");
            }
        }
    }
}
