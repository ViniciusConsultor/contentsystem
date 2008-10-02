<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Compras_Fornecedores_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" Runat="Server">
Manter Fornecedores
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" Runat="Server">




    <asp:MultiView runat=server ID="mv" ActiveViewIndex="0">
    
        <asp:View runat=server>
        
            <div>
                <table>
                
                    <tr>
                        <td>
                            <asp:Label runat=server AssociatedControlID="txtFiltroNome" Text="Nome" />
                        </td>
                        <td>
                            <asp:TextBox runat=server ID="txtFiltroNome" MaxLength="50" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat=server AssociatedControlID="txtFiltroRazaoSocial" Text="Nome" />
                        </td>
                        <td>
                            <asp:TextBox runat=server ID="txtFiltroRazaoSocial" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat=server AssociatedControlID="txtCNPJ" Text="Nome" />
                        </td>
                        <td>
                            <asp:TextBox runat=server ID="txtCNPJ" MaxLength="19" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                        &nbsp;
                        </td>
                        <td>
                        
                            <asp:Button runat=server Text="Pesquisar" ID="btnPesquisar" />
                        </td>
                    </tr>
                    
                    
                </table>
            
            </div>
        
        </asp:View>
    </asp:MultiView>



</asp:Content>

