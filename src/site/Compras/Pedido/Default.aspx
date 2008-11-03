<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Compras_Pedido_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Pedidos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div>
                <asp:Repeater runat="server" ID="rpListagem">
                    <HeaderTemplate>
                        <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                            <thead>
                                <tr>
                                    <td>
                                        IDFornecedor
                                    </td>
                                    <td>
                                        Código
                                    </td>
                                    <td>
                                        Nome
                                    </td>
                                    <td>
                                        Quantidade Mínima
                                    </td>
                                    <td>
                                        Quantidade em Estoque
                                    </td>
                                    <td>
                                        Quantidade a Comprar
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
                                <%#Eval("idFornecedor")%>
                            </td>
                            <td>
                                <%#Eval("codInterno")%>
                            </td>
                            <td>
                                <%#Eval("nome")%>
                            </td>
                            <td>
                                <%#Eval("qtMinima")%>
                            </td>
                            <td>
                                <%#Eval("qtEstoque")%>
                            </td>
                            <td>
                                <%#Eval("qtCompra")%>
                            </td>
                            <td>
                               <%-- <asp:LinkButton ID="LinkButton1" runat="server" Text="E" OnCommand="MostrarFormularioEdicao"
                                    CommandArgument='<%# Eval("codInterno") %>' />--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </asp:View>
       <%-- <asp:View ID="View2" runat="server">
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtNome" Text="Nome" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNome" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtNome"
                                        Text="*" ErrorMessage="Nome obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" AssociatedControlID="txtRazaoSocial" Text="Razão Social" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRazaoSocial" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txtRazaoSocial" Text="*" ErrorMessage="Razão SOcial obrigatória" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" AssociatedControlID="txtCNPJ" Text="CNPJ" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCNPJ" MaxLength="14" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="txtCNPJ" Text="*" ErrorMessage="CNPJ obrigatório" />
                                        <svce:ValidadorCNPJ ID="ValidadorCNPJ1" runat=server ControlToValidate="txtCNPJ" Text="*" ErrorMessage="CNPJ inválido" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label7" runat="server" AssociatedControlID="txtEndereco" Text="Endereço" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Columns="22" Style="overflow-y: auto;"
                                        ID="txtEndereco" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="txtEndereco" Text="*" ErrorMessage="Endereço obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label8" runat="server" AssociatedControlID="txtTelefone" Text="Telefone" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTelefone" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="txtTelefone" Text="*" ErrorMessage="Telefone obrigatório" />
                                        <svce:ValidadorTelefone ID="ValidadorTelefone1"
                                            runat="server" ControlToValidate="txtTelefone"
                                            text="*" ErrorMessage="Formato do telefone inválido" />
                                    <div style="text-align: right;">
                                        formato: XX XXXXXXXX</div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label9" runat="server" AssociatedControlID="txtEmail" Text="E-mail" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                        ControlToValidate="txtEmail" Text="*" ErrorMessage="E-mail obrigatório" />
                                        <svce:ValidadorEmail ID="RegularExpressionValidator1"
                                            runat="server" ControlToValidate="txtEmail"  
                                            text="*" ErrorMessage="Formato do e-mail inválido" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label10" runat="server" AssociatedControlID="txtContato" Text="Contato" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtContato" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server"
                                        ControlToValidate="txtContato" Text="*" ErrorMessage="Contato obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Button OnCommand="SalvarFornecedor" ID="Button2" runat="server" Text="Salvar" />
                                    <asp:Button CausesValidation="false" ID="Button3" runat="server" Text="Cancelar"
                                        OnCommand="RetornarListagem" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:View>--%>
    </asp:MultiView>
</asp:Content>