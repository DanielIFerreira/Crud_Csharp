using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelss;
using DAL;

namespace GUI
{
    public partial class frmCadastroProdutoss : Form
    {
        public frmCadastroProdutoss()
        {
            InitializeComponent();
        }

        private void bntInserir_Click(object sender, EventArgs e)
        {
            //Instanciar o objeto tipo produto com os daods da tela

            Produto produto = new Produto();
            produto.Descricao = txtDescricao.Text;
            produto.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);
            produto.PesoKG = Convert.ToDecimal(txtPesdoKG.Text);

            // Instanciar um obejto da DAL e chamar o méotodo de inserção
            ProdutoDAL produtoDAL = new ProdutoDAL();
            produtoDAL.InserirProdutos(produto);

            MessageBox.Show("Produto inserido com sucesso!");
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.Codigo = Convert.ToInt32(txtCodigo.Text);
            produto.Descricao = txtDescricao.Text;
            produto.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);
            produto.PesoKG = Convert.ToDecimal(txtPesdoKG.Text);

            ProdutoDAL produtoDAL = new ProdutoDAL();

            produtoDAL.AtualizarProduto(produto);

            MessageBox.Show("Produto atualizado com sucesso!");
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.Codigo = Convert.ToInt32(txtCodigo.Text);
          //  produto.Descricao = txtValorUnitario.Text;
           // produto.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);
           // produto.PesoKG = Convert.ToDecimal(txtPesdoKG.Text);

            ProdutoDAL produtoDAL = new ProdutoDAL();
            produtoDAL.DeletarProduto(produto);

            MessageBox.Show("Produto deleato com sucesso!");
        }
    }
}
