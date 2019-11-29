using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC
{
    class Produto
    {
        private string codigoProduto;
        private double valor;
        private int quantidade;
        private string descricao;
        private string marca;
        private string produto;

        public Produto(float valor, int quantidade, string descricao, string marca)
        {
            this.valor = valor;
            this.quantidade = quantidade;
            this.descricao = descricao;
            this.marca = marca;
            this.codigoProduto = AcessoBancoProdutos.proximoProduto();
        }
        public void CadastraProduto()
        {
            AcessoBancoProdutos cadastraProduto = new AcessoBancoProdutos();
            cadastraProduto.CadastraProduto(this.produto, this.valor.ToString(), this.descricao, this.marca);
        }
    }
}
