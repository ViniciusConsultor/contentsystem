<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Administrativo_Relatorios_Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="Server">
    Relatórios
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="Server">
    <div>
        <ul>
            <li>
                <asp:HyperLink ID="rltMaisVendido" runat="server" NavigateUrl="~/Administrativo/Relatorios/MaisVendido.aspx" Text="Relatório por produto mais vendido." Target="_blank" />  
            </li>
            <li>
                <asp:HyperLink ID="rltPorVenda" runat="server" NavigateUrl="~/Administrativo/Relatorios/SemEstoque.aspx" Text="Relatório produto em falta no Estoque." Target="_blank" />
            </li>
            <li>
                <asp:HyperLink ID="rltMelhorVenda" runat="server" NavigateUrl="~/Administrativo/Relatorios/VolumeVendas.aspx" Text="Relatório por volume de venda." Target="_blank" />
            </li>
        </ul>
    </div>
        
</asp:Content>
