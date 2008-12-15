<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrativo_Admin_Default" %>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="Server">
    Admin
</asp:Content>
<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View runat="server" ID="vwLista">
            <table>
                <tr>
                    <td>
                       <%-- <asp:Label ID="lbldescricao" --%>
                    </td>
                </tr>
            </table>
        </asp:View>
        
        <asp:View runat="server" ID="vwFormulario">

        </asp:View>
    </asp:MultiView>
</asp:Content>

