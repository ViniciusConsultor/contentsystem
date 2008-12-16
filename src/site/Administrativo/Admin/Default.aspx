<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrativo_Admin_Default" %>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="Server">
    Manter forma de pagamento
</asp:Content>
<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View runat="server" ID="vwFormulario">
            <table>
                <tr>
                    <td>
                       <asp:Label ID="lblFormapagamento" runat="server" Text="Forma de pagamento" /> 
                    </td>
                    <td>
                        <asp:TextBox ID="txtFormapagamento" runat="server" MaxLength="20" />
                        <asp:RequiredFieldValidator ID="rfvdescricao" runat="server" Text="preencha a descrição" ControlToValidate="txtFormapagamento" ValidationGroup="cadastra" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCadastra" Text="Cadastrar" runat="server" OnCommand="Cadastra" ValidationGroup="cadastra" />
                    </td>
                </tr>
                <tr>
                  <asp:Repeater runat="server" ID="rpListagem">
                    <HeaderTemplate>
                        <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                            <thead>
                                <tr>
                                    <td>
                                        Código
                                    </td>
                                    <td>
                                        Descrição
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("ID")%>
                            </td>
                            <td>
                                <%#Eval("Descricao")%>
                            </td>
                            <td>
                               <asp:LinkButton OnClientClick="return confirm('Tem certeza que deseja excluir este funcionário?');" ID="btnRemover" runat="server" OnCommand="ExcluirPagamento"
                                CommandArgument='<%# Eval("ID") %>' CssClass="btnExcluir" Width="16" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                
                </tr>
            </table>
        </asp:View>
        
        <asp:View runat="server" ID="vwLista">
        </asp:View>
    </asp:MultiView>
</asp:Content>

