<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MaisVendido.aspx.cs" Inherits="Administrativo_Relatorios_MaisVendido"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Mais vendido
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                        <h2>Digite a data do Relatório:</h2>
                        </td>
                        <td>
                            <asp:Label ID="lbldata" runat="server" AssociatedControlID="txtdata" Text="Data" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtdata" MaxLength="10" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%--<asp:Button runat="server" Text="Pesquisar" ID="btnPesquisar" OnCommand="ChamarListagem" />--%>
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
                                        Valor
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("NomeProduto")%>
                            </td>
                            <td>
                                <%#Eval("QuantidadeVendida")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </asp:View>
        </asp:MultiView>
        </asp:content>
