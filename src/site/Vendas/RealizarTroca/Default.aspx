<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="Vendas_RealizarTroca_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

	<script src="../../lib/prototype-1.6.0.3.js"></script>

	<script src="../../lib/scriptaculous-1.8.1/scriptaculous.js"></script>

	<script type="text/javascript">


//window.onload = function()
//{
//	new Ajax.Autocompleter('<%=ddlCodigoProduto.ClientID %>', "autocomplete", '<%=ResolveUrl("~/Compras/Produtos/AutoComplete.aspx") %>',
//	{
//		paramName:'filtro'
//		,delay: 1.0
//		,indicator: 'idicator'
//	}); 
//}

	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
	Realizar Troca
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
	<asp:MultiView ID="mv" runat="server" ActiveViewIndex="3">
		<asp:View ID="View1" runat="server">
			<asp:Panel ID="Panel1" runat="server" DefaultButton="btnIncluirProduto">
				<asp:ValidationSummary runat="server" ID="vs" />
				<table>
					<tr>
						<td>
							<asp:Label ID="Label1" runat="server" AssociatedControlID="ddlCodigoProduto" Text="Produto" />
						</td>
						<td>
							
							
								<asp:DropDownList runat=server AppendDataBoundItems=true ID="ddlCodigoProduto" DataValueField="CodigoInterno" DataTextField="Nome">
								<asp:ListItem Text="" Value="" />
								</asp:DropDownList>
							<asp:RequiredFieldValidator
								ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="ddlCodigoProduto"
								Text="*" ErrorMessage="Produto obrigatório" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ddlCodigoProduto"
								ValidationExpression="^\d+$" Text="*" ErrorMessage="Código de Produto inválido" />
							<div style="display: none;" id="indicator">
								carregando...</div>
							
							
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label2" runat="server" AssociatedControlID="txtQuantidade" Text="Quantidade" />
						</td>
						<td>
							<asp:TextBox runat="server" MaxLength="5" Columns="5" ID="txtQuantidade" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
								ControlToValidate="txtQuantidade" Text="*" ErrorMessage="Quantidade obrigatória" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuantidade"
								ValidationExpression="^\d+$" Text="*" ErrorMessage="Quantidade inválida" />
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label runat="server" AssociatedControlID="rbEntradaSaida">Tipo</asp:Label>
						</td>
						<td>
							<asp:RadioButtonList RepeatDirection="Horizontal" runat="server" ID="rbEntradaSaida">
								<asp:ListItem Selected="True" Text="Entrada" Value="Entrada" />
								<asp:ListItem Text="Saída" Value="Saida" />
							</asp:RadioButtonList>
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
				<h3>
					Produtos devolvidos</h3>
				<asp:Repeater runat="server" ID="rpProdutos">
					<HeaderTemplate>
						<table cellspacing="0" cellpadding="0" class="tabela">
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
									<td>
										Preço Unit.
									</td>
									<td>
										Preço Total
									</td>
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
							<td align="right">
								<%# Eval("Quantidade") %>
							</td>
							<td align="right">
								<%# Eval("PrecoUnitario", "{0:C}") %>
							</td>
							<td align="right">
								<%# Eval("PrecoTotal", "{0:C}") %>
							</td>
							<td>
								<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btnPreview" Width="16" CommandArgument='<%# Eval("IdProduto") %>'
									CommandName="Excluir" OnCommand="ExcluirProduto" />
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
				<h3>
					Produtos retirados</h3>
				<asp:Repeater runat="server" ID="rpNovosProdutos">
					<HeaderTemplate>
						<table cellspacing="0" cellpadding="0" class="tabela">
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
									<td>
										Preço Unit.
									</td>
									<td>
										Preço Total
									</td>
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
							<td align="right">
								<%# Eval("Quantidade") %>
							</td>
							<td align="right">
								<%# Eval("PrecoUnitario", "{0:C}") %>
							</td>
							<td align="right">
								<%# Eval("PrecoTotal", "{0:C}") %>
							</td>
							<td>
								<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btnExcluir" Width="16" CommandArgument='<%# Eval("IdProduto") %>'
									CommandName="Excluir" OnCommand="ExcluirProduto" />
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
				
				
				
				<div>
				
					 <% var saldo = CalcularSaldo();

			   if (saldo < 0)
				   Response.Write(string.Format("Valor restante: {0:C}", -saldo));
			   else
				   Response.Write(string.Format("Valor a ser pago pelo cliente: {0:C}", saldo));		 	
			
					 			 			 			 	 %>
				
				</div>
				
				
				<div>
					<asp:Button runat="server" ID="btnProsseguir1" CausesValidation="false" OnCommand="ProsseguirParaFormasPagamento"
						Text="Prosseguir" />
				</div>
			</asp:Panel>
		</asp:View>
		<asp:View ID="View2" runat="server">
		
		
			<asp:ValidationSummary runat=server />
		
		
			<p>
				<asp:Label runat=server Text="Motivo da Troca" AssociatedControlID="ddlMotivoTroca" /><br />
				<asp:DropDownList runat=server ID="ddlMotivoTroca" DataValueField="IdMotivoTroca" DataTextField="Descricao" AppendDataBoundItems=true>
					<asp:ListItem Text="" Value="" />
				</asp:DropDownList>
				<asp:RequiredFieldValidator runat=server ControlToValidate="ddlMotivoTroca" ErrorMessage="Selecione um motivo para a troca" Text="*" />
			</p>
		
		
			<p>Valor Total a Pagar:
			
				<%=string.Format( "{0:C}", CalcularSaldo()) %>
			</p>
		
			<p>
				Selecione a forma de pagamento
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Selecione a forma de pagamento" Text="*"
					ControlToValidate="rblFormasPagamento" />
			
				</p>
			<asp:RadioButtonList runat="server" ID="rblFormasPagamento" DataTextField="Descricao"
				DataValueField="ID" RepeatDirection="Horizontal" RepeatColumns="1" />
			<div>
				<asp:Button runat="server" ID="btnProsseguir2" OnCommand="SalvarVenda" Text="Prosseguir" />
			</div>
		</asp:View>
		<asp:View ID="View3" runat="server">
			<h3 style="text-align: center;">
				Venda realizada com sucesso!</h3>
			<div style="text-align: center;">
				<asp:LinkButton runat="server" ID="lbNotaFiscal" Text="Imprimir Cupom Fiscal" /><br />
				<a href="Default.aspx">Nova Venda</a>
			</div>
		</asp:View>
		<asp:View runat="server">
			<asp:ValidationSummary runat="server" />
			<table>
				<tr>
					<td>
						<asp:Label runat="server" AssociatedControlID="txtNumeroNota" Text="Número da nota fiscal" />
					</td>
					<td>
						<asp:TextBox runat="server" MaxLength="5" ID="txtNumeroNota" />
						<asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumeroNota" Text="*"
							ErrorMessage="Número da nota fiscal obrigatório" />
						<asp:RegularExpressionValidator runat="server" ControlToValidate="txtNumeroNota"
							Text="*" ErrorMessage="Número da nota fiscal inválido" ValidationExpression="^\d+$" />
						<asp:CustomValidator runat="server" ControlToValidate="txtNumeroNota" OnServerValidate="ValidarNumeroNotaFiscal"
							Text="*" ErrorMessage="Nota fiscal não encontrada" />
					</td>
				</tr>
			</table>
			<div>
				<asp:Button runat="server" Text="Prosseguir" OnCommand="IniciarTroca" />
			</div>
		</asp:View>
	</asp:MultiView>
</asp:Content>
