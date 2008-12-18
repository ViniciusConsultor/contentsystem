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
using SVCE.Controle.CasosDeUso;
using System.Collections.Generic;
using SVCE.Modelo.Dados;

public partial class Vendas_RealizarVenda_Default : System.Web.UI.Page
{

	private RealizarVenda controle;
    List<Estoque> ddl = new List<Estoque>();

	public List<ItemTransacao> Produtos
	{
		get
		{
			return (List<ItemTransacao>)ViewState["Produtos"];
		}
		set { ViewState["Produtos"] = value; }
	}

    //public List<Estoque> ddl
    //{
    //    get
    //    {
    //        return (List<Estoque>)ViewState["ddl"];
    //    }
    //    set
    //    {
    //        ViewState["ddl"] = value;
    //    }
    //}


	protected void Page_Load(object sender, EventArgs e)
	{
		controle = new RealizarVenda();


        if (!IsPostBack)
        {
            Produtos = new List<ItemTransacao>();
            PopularProdutos();
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
		venda.IdResponsavel = Int32.Parse( User.Identity.Name);
		venda.IdFormaPagamento = Int32.Parse(rblFormasPagamento.SelectedValue);
		venda.Itens = new List<ItemTransacao>();
		foreach (var p in Produtos)
			venda.Itens.Add(p);
		venda.ValorTotal = venda.CalcularValorTotal();

		controle.RegistrarVenda(venda);
		lbNotaFiscal.OnClientClick = "window.open('notafiscal.aspx?v=" + venda.IdTransacao + "');";

		mv.ActiveViewIndex = 2;
	}
    private void PopularProdutos()
    {
        //ManterProduto p = new ManterProduto();
        List<Estoque> le = new List<Estoque>();
        le = controle.ConsultarEstoque().ToList<Estoque>();
        foreach (Estoque e in le)
        {
            if (e.qtEstoque > 0)
            {
                ddl.Add(e);
            }
        }
        txtCodigoProduto.DataSource = ddl;
        txtCodigoProduto.DataBind();
    }
	private void MostrarProdutos()
	{
		this.rpProdutos.DataSource = Produtos;
		this.rpProdutos.DataBind();
	}
	private void LimparDadosProduto()
	{
		txtQuantidade.Text = "";
        //ddlCodProduto.SelectedIndex = 0;
        
	}

	protected void IncluirProduto(object sender, CommandEventArgs e)
	{
        if (Page.IsValid)
        {

            //int codigo = Int32.Parse(txtCodigoProduto.Text);
            int codigo =Convert.ToInt32(txtCodigoProduto.SelectedValue);
            int quantidade = Int32.Parse(txtQuantidade.Text);
            List<Estoque> le = new List<Estoque>();
            le = controle.ConsultarEstoque().ToList<Estoque>();
            if (ddl.Count == 0)
            {
                foreach (Estoque et in le)
                {
                    if (et.qtEstoque > 0)
                    {
                        ddl.Add(et);
                    }
                }
            }

            foreach (Estoque es in ddl)
            {
                if (es.codInterno == codigo)
                {
                    if (es.qtEstoque >= quantidade)
                    {
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
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "Produto", "alert('quantidade inferior!');", true);
                    }
                }
            }

        }
	}
	protected void ExcluirProduto(object sender, CommandEventArgs e)
	{
		int codigo = Int32.Parse( (string) e.CommandArgument);
		var item = (from p in Produtos where p.IdProduto == codigo select p).First();

		Produtos.Remove(item);

		MostrarProdutos();
		if (Produtos.Count() == 0)
			pnlProdutos.Visible = false;
	}

	
}
