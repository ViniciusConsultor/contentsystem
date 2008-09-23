<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Administrativo_Funcionarios_Default" Title="Untitled Page" %>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="Server">
    Manter Funcionários
</asp:Content>
<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="Server">
    <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
        <asp:View runat="server" ID="vwLista">
            <div>
                <asp:Button ID="Button1" runat="server" OnCommand="MostrarFormularioInclusao" Text="Incluir Funcionário" />
            </div>
            <asp:Repeater runat="server" ID="rpFuncionarios">
                <HeaderTemplate>
                    <table width="100%">
                        <thead>
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
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </asp:View>
        <asp:View runat="server" ID="vwFormulario">
            <div>
                <asp:Button runat="server" OnCommand="RetornarListagem" Text="Voltar" />
            </div>
            <table>
            <tr>
            
                <td colspan="2">Dados Pessoais</td>
            </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" AssociatedControlID="txtMatricula" Text="Matrícula" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMatricula" Enabled=false />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtNome" Text="Nome" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome"  />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtCPF" Text="CPF" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCPF"  />
                    </td>
                </tr>
                <tr>
                
                    <td colspan="2">Dados de Acesso</td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtLogin" Text="Login" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLogin"  />
                    </td>
                </tr>
                
                
                 <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" AssociatedControlID="txtSenha" Text="Senha" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode=Password ID="txtSenha"  />
                    </td>
                </tr>
                
                <tr>
                    <td>
                    
                        <asp:Label runat=server  AssociatedControlID="rbPerfil" Text="Perfil" />
                    </td>
                    <td>
                    
                    
                        <asp:RadioButtonList RepeatColumns="2" RepeatDirection=Horizontal runat=server ID="rbPerfil">
                            <asp:ListItem Text="CONTROLE TOTAL" Value="Master" />
                            <asp:ListItem Text="SETOR ADMINISTRATIVO" Value="Administrativo" />
                            <asp:ListItem Text="SETOR DE COMPRAS" Value="Compras" />
                            <asp:ListItem Text="VENDEDORES" Value="Vendas" />
                        </asp:RadioButtonList>
                    
                    </td>
                </tr>
                
                
                 <tr>
                    <td>
                    
                        <asp:Label ID="Label5" runat=server  AssociatedControlID="rvStatus" Text="Status" />
                    </td>
                    <td>
                    
                    
                        <asp:RadioButtonList RepeatColumns="2" RepeatDirection=Horizontal runat=server ID="rvStatus">
                            <asp:ListItem Text="ATIVO" Value="Ativo" />
                            <asp:ListItem Text="INATIVO" Value="Inativo" />
                        </asp:RadioButtonList>
                    
                    </td>
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                    <td align=right>
                        <asp:Button runat=server ID="btnSalvar" Text="Salvar" OnCommand="SalvarFuncionario" />
                    </td>
                </tr>
                
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
