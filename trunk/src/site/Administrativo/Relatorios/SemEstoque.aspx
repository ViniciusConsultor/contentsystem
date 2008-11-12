<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SemEstoque.aspx.cs" Inherits="Administrativo_Relatorios_SemEstoque" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    <h2>Produtos Sem Estoque </h2>
    
    <asp:Repeater   runat="server" ID="rpItens">
    <HeaderTemplate>
    
    <table class="tabela" cellspacing=0 cellpadding=0>
		<thead>
		<tr>
			<td>
				ID do Produto
			</td>
			<td>
			   Nome do Produto
			</td>
			<td>
			    Quantidade Mínima
			</td>
			<td>
			    Quantidade Disponível
			</td>
			<td>
			    Nome do Fornecedor
			</td>
		</tr>
		</thead>
		<tbody>
		</HeaderTemplate>
		
		<ItemTemplate>
		
		
		<tr>
			<td>
				<%# Eval("IdProduto")%>
			</td>
			<td>
				<%# Eval("NomeProduto")%>
			</td>
			<td>
				<%# Eval("QuantidadeMinima")%>
			</td>
			<td>
				<%# Eval("QuantidadeDisponivel")%>
			</td>
			<td>
				<%# Eval("NomeFornecedor")%>
			</td>
		</tr>
		</ItemTemplate>
		<FooterTemplate>
		</tbody>
    </table>
    </FooterTemplate>
    </asp:Repeater>
    
    
    <div>
		<a href="javascript:;" onclick="window.print();">
		    Imprimir
		</a>
    </div>
    </div>
    </form>
</body>
</html>
