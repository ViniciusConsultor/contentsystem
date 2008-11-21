<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotaFiscal.aspx.cs" Inherits="Vendas_RealizarVenda_NotaFiscal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    
    
    
    
    <h1>Nota Fiscal</h1>
    
    <h3>Dados da Operação</h3>
    
    
    <asp:Repeater  runat=server ID="rpHeader">
    
		<ItemTemplate>
		
		
		
		
    
    <table>
    
		<tr>
			<td>
				N&ordm;
			</td>
			<td>
				<%#Eval("NUMERO_NOTA_FISCAL") %>
			</td>
		</tr>
		<tr>
			<td>
			Data
			</td>
			<td>
				<%# Eval("DATA_TRANSACAO", "{0:d}") %>
			</td>
		</tr>
		<tr>
		
			<td>Forma de Pagamento</td>
			<td>
				<%# Eval("FORMA_PAGAMENTO") %>
			</td>
		</tr>
		<tr>
		
			<td>Valor Total</td>
			<td>
			
				<%# Eval("valor_total", "{0:C}") %>
			</td>
		</tr>
    
    </table>
    
    
    </ItemTemplate>
    
    </asp:Repeater>
    
    <h3>Itens</h3>
    
    <asp:Repeater   runat=server ID="rpItens">
    <HeaderTemplate>
    
    
    <table class="tabela" cellspacing=0 cellpadding=0>
		<thead>
		<tr>
			<td>
			
				Qtde
			</td>
			<td>Produto</td>
			<td>Valor Unit.</td>
			<td>Valor Total</td>
			<td>Tipo</td>
		</tr>
		</thead>
		<tbody>
		</HeaderTemplate>
		
		<ItemTemplate>
		
		
		<tr>
		
	
			<td>
			
				<%# Eval("Quantidade") %>
			
			</td>
			<td>
			
				<%# Eval("Nome") %>
			
			</td>
			<td>
			
				<%# Eval("Preco_Unitario", "{0:C}")%>
			
			</td>
			
			<td>
			
				<%# Eval("Valor_Total", "{0:C}") %>
			
			</td>
			<td>
				<%# Eval("DIRECAO")%>
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
