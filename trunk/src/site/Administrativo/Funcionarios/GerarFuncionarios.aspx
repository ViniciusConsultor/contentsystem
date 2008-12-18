<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GerarFuncionarios.aspx.cs" Inherits="Administrativo_Funcionarios_GerarFuncionarios" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Produto mais vendido</title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
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
                                <td>Perfil</td>
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
                        
                            <%# TraduzirPerfil((SVCE.Modelo.Dados.Perfil)  Eval("Perfil")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        <div>
		<a href="javascript:;" onclick="window.print();">
		    Imprimir
		</a>
        </div>
        </div>
        </form>
        </body>
        </html>
        