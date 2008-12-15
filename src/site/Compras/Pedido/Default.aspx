<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Compras_Pedido_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Pedidos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View ID="ViewListagem" runat="server">
            <div>
                <h3><asp:Label ID="lblAbaixoestoque" Text="Listar produtos abaixo do estoque:" runat="server" /></h3>
                <asp:Repeater runat="server" ID="rpListagem">
                    <HeaderTemplate>
                        <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                            <thead>
                                <tr>
                                    <td>
                                        Fornecedor
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
                               <asp:LinkButton ID="Selecionar" runat="server" CssClass="btnPreview" Width="16"  OnCommand="SelecionarProduto"
                                    CommandArgument='<%# Eval("codInterno") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
         <h3>produtos em estoque:</h3>
            <asp:Repeater runat="server" ID="rpEstoque">
                <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" class="tabela">
                    <thead>
                        <tr>
                            <td>
                                Nome Fornecedor
                            </td>
                            <td>
                                Código do Produto
                            </td>
                            <td>
                                Nome do produto
                            </td>
                            <td>
                                Quantidade Mínima
                            </td>
                            <td>
                                Quantidade Estoque
                            </td>
                            <td>
                                Preço de Venda
                            </td>
                        </tr>
                    </thead>
                <tbody>
                </HeaderTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
                <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("NFornecedor")%>
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
                        <%#Eval("Preco", "{0:C}")%>
                    </td>
                </tr>
                </ItemTemplate>
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
                                    <asp:Label ID="lblFornecedor" runat="server" AssociatedControlID="ddlIDFornecedor" Text="Fornecedor" />
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlIDFornecedor" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCodInterno" runat="server" AssociatedControlID="txtcodInterno" Text="Código Interno" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtcodInterno" MaxLength="50" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome" Text="Nome" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNome" MaxLength="14" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblQuantidade" runat="server" AssociatedControlID="txtQuantidade" Text="Quantidade" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtQuantidade" MaxLength="14" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Button OnCommand="SalvarPedido" ID="btnsalvar" runat="server" Text="Salvar" />
                                    <asp:Button CausesValidation="false" ID="btnCancelar" runat="server" Text="Cancelar"
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
        </asp:View>
    </asp:MultiView>
</asp:Content>