<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="Vendas_RealizarVenda_Default" Title="Untitled Page" %>
<asp:Content ContentPlaceHolderID=head runat=server>

<script src="../../lib/prototype-1.6.0.3.js"></script>
<script src="../../lib/scriptaculous-1.8.1/scriptaculous.js"></script>

<script type="text/javascript">


window.onload = function()
{
	new Ajax.Autocompleter('<%=txtCodigoProduto.ClientID %>', "autocomplete", '<%=ResolveUrl("~/Compras/Produtos/AutoComplete.aspx") %>',
	{
		paramName:'filtro'
		,indicator: 'indicator'
	}); 
}

</script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
	Realizar Venda
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
	<asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
		<asp:View runat="server">
			<asp:Panel runat="server" DefaultButton="btnIncluirProduto">
				<asp:ValidationSummary runat="server" ID="vs" />
				<table>
					<tr>
						<td>
							<asp:Label runat="server" AssociatedControlID="txtCodigoProduto" Text="Código do Produto" />
						</td>
						<td>
							<asp:TextBox runat="server" MaxLength="10" ID="txtCodigoProduto" /><asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtCodigoProduto"
								Text="*" ErrorMessage="Código do produto obrigatório" />
							<asp:RegularExpressionValidator runat="server" ControlToValidate="txtCodigoProduto"
								ValidationExpression="^\d+$" Text="*" ErrorMessage="Código de Produto inválido" />
								
								<div style="display:none;" id="indicator">carregando...</div>
								<div class="autocomplete" id="autocomplete">
								
									<h1>Autocomplete</h1>
								</div>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label1" runat="server" AssociatedControlID="txtQuantidade" Text="Quantidade" />
						</td>
						<td>
							<asp:TextBox runat="server" MaxLength="5" Columns="5" ID="txtQuantidade" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
								ControlToValidate="txtQuantidade" Text="*" ErrorMessage="Quantidade obrigatória" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtQuantidade"
								ValidationExpression="^\d+$" Text="*" ErrorMessage="Quantidade inválida" />
						</td>
					</tr>
					<tr>
						<td>
							&nbsp;
						</td>
						<td align="right">
							<asp:Button runat="server" Text="Incluir" OnCommand="IncluirProduto" ID="btnIncluirProduto" />
						</td>
					</tr>
				</table>
				
				
				
				
				
			</asp:Panel>
			<asp:Panel runat="server" ID="pnlProdutos" Visible="false">
				<asp:Repeater runat="server" ID="rpProdutos">
					<HeaderTemplate>
						<table cellspacing=0 cellpadding=0 class="tabela">
							<thead>
								<tr>
									<td>
										Código
									</td>
									<td>
										Produto
									</td>
									<td>
										Quantidade
									</td>
									<td>Preço Unit.</td>
									<td>Preço Total</td>
									<td>
										&nbsp;
									</td>
								</tr>
							</thead>
							<tbody>
					</HeaderTemplate>
					<FooterTemplate>
						</tbody> </table></FooterTemplate>
					<ItemTemplate>
						<tr>
							<td>
								<%# Eval("IdProduto") %>
							</td>
							<td>
								<%# Eval("NomeProduto") %>
							</td>
							<td align=right>
								<%# Eval("Quantidade") %>
							</td>
							<td align=right><%# Eval("PrecoUnitario", "{0:C}") %></td>
							<td align=right><%# Eval("PrecoTotal", "{0:C}") %></td>
							<td>
							
								<asp:LinkButton runat=server Text="Excluir" CommandArgument='<%# Eval("IdProduto") %>' CommandName="Excluir" OnCommand="ExcluirProduto" />
							
							
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
				<div>
					<asp:Button runat="server" ID="btnProsseguir1" CausesValidation="false" OnCommand="ProsseguirParaFormasPagamento"
						Text="Prosseguir" />
				</div>
			</asp:Panel>
		</asp:View>
		<asp:View runat="server">
			<p>
				Selecione a forma de pagamento</p>
			<asp:RadioButtonList runat="server" ID="rblFormasPagamento" DataTextField="Descricao"
				DataValueField="ID" RepeatDirection="Horizontal" RepeatColumns="1" />
			<div>
				<asp:RequiredFieldValidator runat="server" Text="Selecione a forma de pagamento"
					ControlToValidate="rblFormasPagamento" />
			</div>
			<div>
				<asp:Button runat="server" ID="btnProsseguir2" OnCommand="SalvarVenda" Text="Prosseguir" />
			</div>
		</asp:View>
		<asp:View runat="server">
			<h3 style="text-align:center;">
				Venda realizada com sucesso!</h3>
			<div style="text-align:center;">
				<a href="Default.aspx">Nova Venda</a>
			</div>
		</asp:View>
	</asp:MultiView>
</asp:Content>
