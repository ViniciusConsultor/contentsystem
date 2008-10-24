<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Compras_Fornecedores_Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Manter Fornecedores
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mvprodutos" ActiveViewIndex="0">
        <asp:View ID="ViewListagem" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblCodInterno" runat="server" AssociatedControlID="txtCodInterno" Text="Código Interno" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCodInterno" MaxLength="20" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCodExterno" runat="server" AssociatedControlID="txtCodExterno"
                                Text="Código Externo" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCodExterno" MaxLength="20" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome" Text="Nome" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNome" MaxLength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Pesquisar" ID="btnPesquisar" OnCommand="ChamarListagem" />
                            <asp:Button runat="server" Text="Novo Produto" ID="btnNovo" OnCommand="MostrarFormularioInclusao" />
                        </td>
                    </tr>
                </table>
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
                                    <td>
                                        Status
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
                                <%#Eval("PrecoVenda")%>
                            </td>
                            <td>
                                <%#Eval("QuantidadeMinima")%>
                            </td>
                            <td>
                                <%#Eval("Status")%>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="E" OnCommand="MostrarFormularioEdicao"
                                    CommandArgument='<%# Eval("CodigoInterno") %>' />
                                <asp:LinkButton OnClientClick="return confirm('Tem certeza que deseja excluir este fornecedor?');"
                                    ID="LinkButton2" runat="server" Text="X" OnCommand="ExcluirFornecedor" CommandArgument='<%# Eval("IdFornecedor") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </asp:View>
        <asp:View ID="ViewCadastro" runat="server">
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCadastroInterno" runat="server" AssociatedControlID="txtCadastrointerno" Text="Código Interno" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCadastrointerno" MaxLength="20" />
                                    <asp:RequiredFieldValidator ID="rfvCodInterno" Display="Dynamic" runat="server" ControlToValidate="txtCadastrointerno"
                                        Text="*" ErrorMessage="Código Interno obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCadastroExterno" runat="server" AssociatedControlID="txtCadastroExterno" Text="Código Externo" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCadastroExterno" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCodExterno" runat="server"
                                        ControlToValidate="txtCadastroExterno" Text="*" ErrorMessage="Código Externo obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCadastroID" runat="server" AssociatedControlID="txtCadastroID" Text="ID Fornecedor" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCadastroID" MaxLength="10" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDFornecedor" runat="server"
                                        ControlToValidate="txtCadastroID" Text="*" ErrorMessage="ID Fornecedor obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblCadastroNome" runat="server" AssociatedControlID="CadastroNome" Text="Nome" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCadastroNome" MaxLength="30" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvNome" runat="server"
                                        ControlToValidate="txtCadastroNome" Text="*" ErrorMessage="Nome obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblPrecoVenda" runat="server" AssociatedControlID="txtPrecoVenda" Text="Preço Venda" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPrecoVenda" MaxLength="20" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="txtPrecoVenda" Text="*" ErrorMessage="Preço venda obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblCadastroQuantidade" runat="server" AssociatedControlID="txtCadastroQuantidade" Text="Quantidade Mínima" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="CadastroQuantidade" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                        ControlToValidate="txtCadastroQuantidade" Text="*" ErrorMessage="Quantidade Mínima obrigatório" />
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
                                    <asp:Button OnCommand="SalvarProduto" ID="btnSalvar" runat="server" Text="Salvar" />
                                    <asp:Button CausesValidation="false" ID="btnCancelar" runat="server" Text="Cancelar"
                                        OnCommand="RetornarListagem" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
