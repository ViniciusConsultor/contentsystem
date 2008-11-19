<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Compras_Comprar_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Comprar
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">

    <asp:MultiView runat="server" ID="mvCompras" ActiveViewIndex="0">
        <asp:View ID="ViewListagem" runat="server">
            <div>
            <table>
                <tr>
                    <td>
                    <h2>Lista de Pedidos:</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblProduto" runat="server" AssociatedControlID="txtProduto" Text="Código do Produto" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtProduto" MaxLength="20" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPeriodo" runat="server" AssociatedControlID="txtdata" Text="Data do pedido" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtdata" MaxLength="10" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
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
                                        Número
                                    </td>
                                    <td>
                                        Funcionário
                                    </td>
                                    <td>
                                        Tipo
                                    </td>
                                    <td>
                                        Data do Pedido
                                    </td>
                                    <td>
                                        Valor Total
                                    </td>
                                    <td>
                                        Status
                                    </td>
                                    <td>
                                        Fornecedor
                                    </td>
                                    <td>
                                        Quantidade
                                    </td>
                                    <td>
                                        Preço Unitario
                                    </td>
                                    <td>
                                        Produto
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
                                <%#Eval("IdTransacao")%>
                            </td>
                            <td>
                                <%#Eval("nomeFU")%>
                            </td>
                            <td>
                                <%#Eval("tpTransacao")%>
                            </td>
                            <td>
                                <%#Eval("DataTransacao", "{0:d}")%>
                            </td>
                            <td>
                                <%#Eval("ValorTotal", "{0:C}")%>
                            </td>
                            <td>
                                <%#Eval("desPro")%>
                            </td>
                            <td>
                                <%#Eval("nomeF")%>
                            </td>
                            <td>
                                <%#Eval("qt")%>
                            </td>
                            <td>
                                <%#Eval("pu", "{0:C}")%>
                            </td>
                            <td>
                                <%#Eval("nomeP")%>
                            </td>
                            <td>
                               <asp:LinkButton ID="Selecionar" runat="server" Text="E" OnCommand="SelecionarPedido"
                                    CommandArgument='<%# Eval("IdTransacao") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </asp:View>
       <%--<asp:View ID="ViewCadastro" runat="server">
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
                </tr>
            </table>
        </asp:View>--%>
        	<asp:View ID="vmCompraRealidade" runat="server">
			<h3 style="text-align:center;">
				Compra realizada com sucesso!</h3>
			<div style="text-align:center;">
			
		
				<a href="Default.aspx">Listar pedidos</a>
			</div>
		</asp:View>
    </asp:MultiView>
</asp:Content>