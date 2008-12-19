<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Compras_Fornecedores_Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src="../../lib/prototype-1.6.0.3.js"></script>
<script src="../../lib/scriptaculous-1.8.1/scriptaculous.js"></script>

<script type="text/javascript">
function formataCNPJ(event)
{
var tecla = null;
    if(navigator.appName.indexOf('Internet Explorer')>0)
        tecla = event.keyCode;
    else
        tecla = event.which;
        
        //alert(tecla);
        if(tecla < 47 || tecla > 57)
        {
            if(tecla == 8 )
                return true;
            else if(tecla == 0)
                return true;
            else
                return false;
        }
        else
            return true;
}


function formataTEL(event)
{
    var tecla = null;
    if(navigator.appName.indexOf('Internet Explorer')>0)
        tecla = event.keyCode;
    else
        tecla = event.which;
        
        //alert(tecla);
        if(tecla < 48 || tecla > 57)
        {
            if(tecla == 8 )
                return true;
            else if(tecla == 0)
                return true;
            else if(tecla == 32)
                return true;
            else
                return false;
        }
        else
            return true;
         
}   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Manter Fornecedores
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtFiltroNome" Text="Nome" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFiltroNome" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFiltroRazaoSocial"
                                Text="Razão Social" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFiltroRazaoSocial" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtFiltroCNPJ" Text="CNPJ" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFiltroCNPJ" MaxLength="19" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Pesquisar" ID="btnPesquisar" OnCommand="ChamarListagem" />
                            <asp:Button runat="server" Text="Novo Fornecedor" ID="Button1" OnCommand="MostrarFormularioInclusao" />
                        </td>
                    </tr>
                </table>
                <asp:Repeater runat="server" ID="rpListagem">
                    <HeaderTemplate>
                        <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                            <thead>
                                <tr>
                                    <td>
                                        ID
                                    </td>
                                    <td>
                                        Nome
                                    </td>
                                    <td>
                                        Razão Social
                                    </td>
                                    <td>
                                        CNPJ
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
                                <%#Eval("IdFornecedor") %>
                            </td>
                            <td>
                                <%#Eval("Nome") %>
                            </td>
                            <td>
                                <%#Eval("RazaoSocial") %>
                            </td>
                            <td>
                                <%#Eval("CNPJ") %>
                            </td>
                            <td align="center" width="65">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="MostrarFormularioEdicao"
                                    CommandArgument='<%# Eval("IdFornecedor") %>' CssClass="btnPreview" Width="16"   />
                                <asp:LinkButton OnClientClick="return confirm('Tem certeza que deseja excluir este fornecedor?');"
                                    ID="LinkButton2" runat="server" CssClass="btnExcluir" Width="16"   OnCommand="ExcluirFornecedor" CommandArgument='<%# Eval("IdFornecedor") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        <div>
        <asp:HyperLink runat="server" NavigateUrl="~/Compras/Fornecedores/GerarFornecedores.aspx" Text="Gerar Relátorios" />
		<a href="javascript:;" onclick="window.print();">
		    Imprimir
		</a>
        </div>
        </asp:View>
        <asp:View runat="server">
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtNome" Text="Nome" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNome" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtNome"
                                        Text="*" ErrorMessage="Nome obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtRazaoSocial" Text="Razão Social" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRazaoSocial" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtRazaoSocial" Text="*" ErrorMessage="Razão SOcial obrigatória" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtCNPJ" Text="CNPJ" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCNPJ" MaxLength="14" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txtCNPJ" Text="*" ErrorMessage="CNPJ obrigatório" />
                                        <svce:ValidadorCNPJ runat=server ControlToValidate="txtCNPJ" Text="*" ErrorMessage="CNPJ inválido" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label5" runat="server" AssociatedControlID="txtEndereco" Text="Endereço" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Columns="22" Style="overflow-y:auto;"
                                        ID="txtEndereco" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="txtEndereco" Text="*" ErrorMessage="Endereço obrigatório" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label6" runat="server" AssociatedControlID="txtTelefone" Text="Telefone" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTelefone" MaxLength="11" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="txtTelefone" Text="*" ErrorMessage="Telefone obrigatório" />
                                        <svce:ValidadorTelefone
                                            runat="server" ControlToValidate="txtTelefone"
                                            text="*" ErrorMessage="Formato do telefone inválido" />
                                    <div style="text-align: right;">
                                        formato: XX XXXXXXXX</div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label7" runat="server" AssociatedControlID="txtEmail" Text="E-mail" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="txtEmail" Text="*" ErrorMessage="E-mail obrigatório" />
                                        <svce:ValidadorEmail ID="RegularExpressionValidator1"
                                            runat="server" ControlToValidate="txtEmail"  
                                            text="*" ErrorMessage="Formato do e-mail inválido" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label8" runat="server" AssociatedControlID="txtContato" Text="Contato" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtContato" MaxLength="50" />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
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
        </asp:View>
    </asp:MultiView>
</asp:Content>
