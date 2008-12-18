<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GerarProdutos.aspx.cs" Inherits="Compras_Produtos_GerarProdutos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Repeater runat="server" ID="rpListagem">
                    <HeaderTemplate>
                        <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                            <thead>
                                <tr>
                                    <td>
                                        Código Interno
                                    </td>
                                    <td>
                                        Código Externo
                                    </td>
                                    <td>
                                        IDFornecedor
                                    </td>
                                    <td>
                                        Nome
                                    </td>
                                    <td>
                                        Preço Venda
                                    </td>
                                    <td>
                                        Quantidade Mínima
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("CodigoInterno")%>
                            </td>
                            <td>
                                <%#Eval("CodigoExterno")%>
                            </td>
                            <td>
                                <%#Eval("IdFornecedor")%>
                            </td>
                            <td>
                                <%#Eval("Nome")%>
                            </td>
                            <td>
                                <%#Eval("PrecoVenda", "{0:C}")%>
                            </td>
                            <td>
                                <%#Eval("QuantidadeMinima")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        <div>
		<a href="javascript:;" onclick="window.print();">
		    Imprimir
		</a>
        </div>
    </div>
    </form>
</body>
</html>
