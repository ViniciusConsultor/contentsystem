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


			this.ddlMotivoTroca.DataSource = controle.ListarMotivosTroca();
			this.ddlMotivoTroca.DataBind();

		}
	}

	protected void ProsseguirParaFormasPagamento(object sender, CommandEventArgs e)
	{
		mv.ActiveViewIndex = 1;
        decimal sl = Convert.ToDecimal(Session["saldo"]);
        if (sl > 0)
        {
            rblFormasPagamento.DataSource = controle.ListarFormasPagamento();
            rblFormasPagamento.DataBind();
        }
        else if (sl == 0)
        {
            rblFormasPagamento.Visible = false;
            lblformapagamento.Visible = false;
        }
	}
	protected void SalvarVenda(object sender, CommandEventArgs e)
	{

		Troca troca = new Troca();
		troca.IdResponsavel = Int32.Parse(User.Identity.Name);
		troca.IdTransacaoPai = this.VendaSelecionada.IdTransacao;
        if (lblformapagamento.Visible == true)
            troca.IdFormaPagamento = Int32.Parse(rblFormasPagamento.SelectedValue);
        else
            troca.IdFormaPagamento = 1;

		troca.Itens = new List<ItemTransacao>();
		foreach (var p in Produtos)
			troca.Itens.Add(p);
		troca.ValorTotal = CalcularSaldo();

		controle.RegistrarTroca(troca);
		lbNotaFiscal.OnClientClick = "window.open('../realizarvenda/notafiscal.aspx?v=" + troca.IdTransacao + "');";

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

			if (saida == 0 || entrada == 0 || CalcularSaldo() < 0)
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

            if (tipo == TipoItemTransacao.Entrada)
            {
                if (ValidaTroca(codigo))
                {
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
                    // do teste do produto
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "Produto", "alert('Não faz parte da nota fiscal indicada!');", true);
                }
            }
                // else do tipo
            else
            {
                if (ValidaEstoque(codigo, quantidade))
                {
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
                else
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "Produto", "alert('Produto não contém no estoque!');", true);
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

    public bool ValidaTroca(int id)
    {
        bool validProduto = true;
        List<ItemTransacao> it = new List<ItemTransacao>();
        it = VendaSelecionada.Itens;
        foreach (ItemTransacao i in it)
        {
            if (i.IdProduto == id)
            {
                validProduto = true;
                return true;
            }
            else
                validProduto = false;
            
        }

        return validProduto;
    }

    public bool ValidaEstoque(int id, int qt)
    {
        bool validProduto = true;
        RealizarVenda controle = new RealizarVenda();
        List<Estoque> es = new List<Estoque>();
        es =controle.ConsultarEstoque().ToList<Estoque>();
        foreach (Estoque e in es)
        {
            if (e.codInterno == id)
            {
                if (e.qtEstoque >= qt)
                {
                    validProduto = true;
                    return true;
                }
                else
                {
                    validProduto = false;
                    return false;
                }
            }
        }


        return validProduto;
    }
}
