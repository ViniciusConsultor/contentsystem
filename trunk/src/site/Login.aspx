<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SVCE</title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="pageBody">
    
    
		<h1>Login</h1>
        <asp:Panel runat="server" DefaultButton="btnEnviar">
    
        <table align=center>
            <tr>
                <td align="right">
                    <asp:Label runat="server" AssociatedControlID="txtLogin" Text="Usuário" />
                </td>
                <td align="right">
                    <asp:TextBox runat="server" MaxLength="50" Width="200px" ID="txtLogin" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLogin" Text="*" ErrorMessage="Usuário obrigatório" />
                </td>
            </tr>
            
            
             <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtSenha"  Text="Senha" />
                </td>
                <td align="right">
                    <asp:TextBox runat="server" MaxLength="50" TextMode=Password Width="200px" ID="txtSenha" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat=server ControlToValidate="txtSenha" Text="*" ErrorMessage="Senha obrigatória" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="right" style="padding-right:15px;">
                
                    <asp:Button OnCommand="Logar" Text="Entrar" ID="btnEnviar" runat="server" />
                </td>
            </tr>
        </table>
        
        
        <asp:ValidationSummary runat="server" ID="vs" />
        </asp:Panel>
        
        
    </div>
    </form>
</body>
</html>
