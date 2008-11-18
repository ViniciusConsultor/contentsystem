using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using SVCE.Modelo.Dados;
using SVCE.Controle.CasosDeUso;

public partial class Vendas_RealizarTroca_Default : System.Web.UI.Page
{


	private RealizarVenda controle;

	public List<ItemTransacao> Produtos
	{
		get
		{
			return (List<ItemTransacao>)ViewState["Produtos"];
		}
		set { ViewState["Produtos"] = value; }
	}


	protected void Page_Load(object sender, EventArgs e)
	{
		controle = new RealizarVenda();


		if (!IsPostBack)
			Produtos = new List<ItemTransacao>();
	}

	protected void ProsseguirParaFormasPagamento(object sender, CommandEventArgs e)
	{
		mv.ActiveViewIndex = 1;
		rblFormasPagamento.DataSource = controle.ListarFormasPagamento();
		rblFormasPagamento.DataBind();
	}
	protected void SalvarVenda(object sender, CommandEventArgs e)
	{


		Venda venda = new Venda();
		venda.IdResponsavel = Int32.Parse(User.Identity.Name);
		venda.IdFormaPagamento = Int32.Parse(rblFormasPagamento.SelectedValue);
		venda.Itens = new List<ItemTransacao>();
		foreach (var p in Produtos)
			venda.Itens.Add(p);
		venda.ValorTotal = venda.CalcularValorTotal();

		controle.RegistrarVenda(venda);
		lbNotaFiscal.OnClientClick = "window.open('notafiscal.aspx?v=" + venda.IdTransacao + "');";

		mv.ActiveViewIndex = 2;
	}

	private void MostrarProdutos()
	{
		this.rpProdutos.DataSource = Produtos;
		this.rpProdutos.DataBind();
	}
	private void LimparDadosProduto()
	{
		txtCodigoProduto.Text = txtQuantidade.Text = "";
	}

	protected void IncluirProduto(object sender, CommandEventArgs e)
	{
		if (Page.IsValid)
		{

			int codigo = Int32.Parse(txtCodigoProduto.Text);
			int quantidade = Int32.Parse(txtQuantidade.Text);


			var itens = (from p in Produtos where p.IdProduto == codigo select p);

			if (itens.Count() > 0)
			{
				var itemExistente = itens.First();
				itemExistente.Quantidade += quantidade;
				MostrarProdutos();
				this.pnlProdutos.Visible = true;
				LimparDadosProduto();
			}
			else
			{


				var produto = controle.BuscarProduto(codigo);

				var sequencial = 0;

				if (produto != null)
				{
					var item = new ItemTransacao() { IdProduto = produto.CodigoInterno, Sequencial = sequencial, NomeProduto = produto.Nome, PrecoUnitario = produto.PrecoVenda, Quantidade = quantidade };
					Produtos.Add(item);
					MostrarProdutos();
					this.pnlProdutos.Visible = true;
					LimparDadosProduto();
				}
				else
					Page.ClientScript.RegisterClientScriptBlock(GetType(), "Produto", "alert('Produto não encontrado!');", true);
			}
		}
	}
	protected void ExcluirProduto(object sender, CommandEventArgs e)
	{
		int codigo = Int32.Parse((string)e.CommandArgument);
		var item = (from p in Produtos where p.IdProduto == codigo select p).First();

		Produtos.Remove(item);

		MostrarProdutos();
		if (Produtos.Count() == 0)
			pnlProdutos.Visible = false;
	}

	protected void IniciarTroca(object sender, CommandEventArgs e)
	{
		mv.ActiveViewIndex = 0;
	}
}
