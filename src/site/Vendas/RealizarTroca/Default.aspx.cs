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


	protected Venda VendaSelecionada
	{
		get
		{
			return (Venda)ViewState["Venda"];
		}
		set
		{
			ViewState["Venda"] = value;
		}
	}


	private RealizarTroca controle;

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
		controle = new RealizarTroca();


		if (!IsPostBack)
		{
			ManterProduto controleProdutos = new ManterProduto();
			Produtos = new List<ItemTransacao>();


			this.ddlCodigoProduto.DataSource = controleProdutos.Listar(null, null, null,null);
			this.ddlCodigoProduto.DataBind();

		}
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
		this.rpProdutos.DataSource = from p in Produtos where p.TipoItem == TipoItemTransacao.Entrada select p;
		this.rpProdutos.DataBind();
		this.rpNovosProdutos.DataSource = from p in Produtos where p.TipoItem == TipoItemTransacao.Saida select p;
		this.rpNovosProdutos.DataBind();



		if (Produtos.Count() == 0)
			pnlProdutos.Visible = false;
		else
		{
			var entrada = (from p in Produtos where p.TipoItem == TipoItemTransacao.Entrada select p).Count();
			var saida = (from p in Produtos where p.TipoItem == TipoItemTransacao.Saida select p).Count();

			if (saida == 0 || entrada == 0)
				this.btnProsseguir1.Enabled = false;
			else
				btnProsseguir1.Enabled = true;
		}

	}
	private void LimparDadosProduto()
	{
		ddlCodigoProduto.SelectedIndex = 0;
		txtQuantidade.Text = "";
	}


	protected decimal CalcularSaldo()
	{
		return (from p in Produtos select (p.TipoItem == TipoItemTransacao.Entrada ? -1 : 1) * p.PrecoTotal).Sum();
	}

	protected void IncluirProduto(object sender, CommandEventArgs e)
	{
		if (Page.IsValid)
		{

			int codigo = Int32.Parse(ddlCodigoProduto.Text);
			int quantidade = Int32.Parse(txtQuantidade.Text);

			var tipo = (TipoItemTransacao)Enum.Parse(typeof(TipoItemTransacao), rbEntradaSaida.SelectedValue);

			var itens = (from p in Produtos where p.IdProduto == codigo && tipo == p.TipoItem select p);

			if (itens.Count() > 0)
			{
				var itemExistente = itens.First();
				itemExistente.Quantidade += quantidade;
				MostrarProdutos();
				this.pnlProdutos.Visible = true;
				itemExistente.TipoItem = tipo;
				LimparDadosProduto();
			}
			else
			{


				var produto = controle.BuscarProduto(codigo);

				var sequencial = 0;

				if (produto != null)
				{
					var item = new ItemTransacao() { IdProduto = produto.CodigoInterno, Sequencial = sequencial, NomeProduto = produto.Nome, PrecoUnitario = produto.PrecoVenda, Quantidade = quantidade };
					item.TipoItem = tipo;
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
		
	}



	public void ValidarNumeroNotaFiscal(object sender, ServerValidateEventArgs e)
	{
		int numeroNota = Int32.Parse((string)e.Value);
		var venda = controle.CarregarVenda(numeroNota);

		if (venda == null)
			e.IsValid = false;
		else
			this.VendaSelecionada = venda;
	}

	protected void IniciarTroca(object sender, CommandEventArgs e)
	{
		if (IsValid)
		{
			mv.ActiveViewIndex = 0;
		}
	}
}
