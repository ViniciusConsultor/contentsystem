<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Administrativo_Funcionarios_Default" Title="Untitled Page" %>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="Server">
    Manter Funcionários
</asp:Content>
<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View runat="server" ID="vwLista">
            <div>
                <asp:Button CausesValidation="false" ID="Button1" runat="server" OnCommand="MostrarFormularioInclusao"
                    Text="Incluir Funcionário" />
            </div>
            <asp:Repeater runat="server" ID="rpFuncionarios">
                <HeaderTemplate>
                    <table class="tabela" cellspacing="0" cellpadding="0" width="100%">
                        <thead>
                            <tr>
                                <td>
                                    Matrícula
                                </td>
                                <td>
                                    Nome
                                </td>
                                <td>
                                    CPF
                                </td>
                                <td>
                                    Login
                                </td>
                                <td>
                                    Data Adm.
                                </td>
                                <td>
                                    Salário
                                </td>
                                <td>
                                    &#160;
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Matricula") %>
                        </td>
                        <td>
                            <%#Eval("Nome") %>
                        </td>
                        <td>
                            <%#Eval("CPF") %>
                        </td>
                        <td>
                            <%#Eval("Login") %>
                        </td>
                        <td>
                            <%#Eval("DataAdmissao", "{0:d}") %>
                        </td>
                        <td>
                            <%#Eval("Salario", "{0:C}") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="E" OnCommand="MostrarFormularioEdicao"
                                CommandArgument='<%# Eval("Matricula") %>' />
                            <asp:LinkButton OnClientClick="return confirm('Tem certeza que deseja excluir este funcionário?');" ID="LinkButton2" runat="server" Text="X" OnCommand="ExcluirFuncionario"
                                CommandArgument='<%# Eval("Matricula") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </asp:View>
        <asp:View runat="server" ID="vwFormulario">
        
        
        
        
            <table>
                <tr>
                    <td>
                     <table>
                <tr>
                    <td colspan="2">
                        <h3>
                            Dados Pessoais
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" AssociatedControlID="txtMatricula" Text="Matrícula" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMatricula" Enabled="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtNome" Text="Nome" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome" MaxLength="50" />
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" Text="*" ControlToValidate="txtNome"
                            ErrorMessage="Nome obrigatório" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtCPF" Text="CPF" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCPF" MaxLength="11" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            Text="*" ControlToValidate="txtCPF" ErrorMessage="CPF obrigatório" />
                        <svce:ValidadorCPF runat="server" ControlToValidate="txtCPF" Text="*" ErrorMessage="CPF inválido" />
                    </td>
                </tr>
                <tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="txtSalario" Text="Salário" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtSalario" MaxLength="15" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                Text="*" ControlToValidate="txtSalario" ErrorMessage="Salário obrigatório" />
                            <svce:ValidadorDinheiro runat="server" ControlToValidate="txtSalario" Text="*" ErrorMessage="Salário inválido!" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="txtDataAdmissao" Text="Data Admissão" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDataAdmissao" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                Text="*" ControlToValidate="txtDataAdmissao" ErrorMessage="Data de Admissão obrigatória" />
                            <svce:ValidadorData runat="server" ControlToValidate="txtDataAdmissao" Text="*" ErrorMessage="Data de admissão inválida!" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h3>
                                Dados de Acesso
                            </h3>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtLogin" Text="Login" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLogin" MaxLength="50" />
                            <asp:RequiredFieldValidator ID="rqLogin" runat="server" Display="Dynamic" Text="*"
                                ControlToValidate="txtLogin" ErrorMessage="Login obrigatório" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSenha" runat="server" AssociatedControlID="txtSenha" Text="Senha" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="Password" MaxLength="50" ID="txtSenha" />
                            <asp:RequiredFieldValidator ID="rqSenha" runat="server" Display="Dynamic" Text="*"
                                ControlToValidate="txtSenha" ErrorMessage="Senha obrigatória" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="rbPerfil" Text="Perfil" />
                        </td>
                        <td>
                            <asp:RadioButtonList RepeatColumns="1" RepeatDirection="Horizontal" runat="server"
                                ID="rbPerfil">
                                <asp:ListItem Text="CONTROLE TOTAL" Value="Master" />
                                <asp:ListItem Text="SETOR ADMINISTRATIVO" Value="Administrativo" />
                                <asp:ListItem Text="SETOR DE COMPRAS" Value="Compras" />
                                <asp:ListItem Text="VENDEDORES" Value="Vendas" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                Text="*" ControlToValidate="rbPerfil" ErrorMessage="Perfil obrigatório" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnCommand="SalvarFuncionario" />
                            <asp:Button ID="Button2" CausesValidation="false" runat="server" OnCommand="RetornarListagem"
                    Text="Cancelar" />
                        </td>
                    </tr>
            </table>
                    
                    </td>
                    <td valign=top>
                    
                    <asp:ValidationSummary runat="server" />
                    
                    </td>
                </tr>
            </table>
        
        
          
            
           
        </asp:View>
    </asp:MultiView>
</asp:Content>
