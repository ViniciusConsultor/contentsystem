<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VolumeVendas.aspx.cs" Inherits="Administrativo_Relatorios_VolumeVendas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Produto mais vendido</title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                        <h2>Digite a data do Relatório:</h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldata" runat="server" AssociatedControlID="txtdi" Text="Data Inicial" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtdi" MaxLength="10" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldf" runat="server" AssociatedControlID="txtdf" Text="Data Final" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtdf" MaxLength="10" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Label ID="lblPeriodo" runat="server" AssociatedControlID="rdbPeriodo" Text="Período" />
                        </td>
                        <td>
                        <asp:RadioButtonList runat="server" ID="rdbPeriodo">
                        <asp:ListItem Text="Diário" Value="D" />
                        <asp:ListItem Text="Mensal" Value="M" />
                        <asp:ListItem Text="Anual" Value="A" />
                        </asp:RadioButtonList>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Pesquisar" ID="btnPesquisar" OnCommand="Pesquisar" />
                        </td>
                    </tr>
                </table>
                <asp:Repeater runat="server" ID="rpListagem">
                    <HeaderTemplate>
                        <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                            <thead>
                                <tr>
                                    <td>
                                        Data
                                    </td>
                                    <td>
                                        Quantidade
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("data")%>
                            </td>
                            <td>
                                <%#Eval("VolumeVendas")%>
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
        </form>
    </body>
</html>