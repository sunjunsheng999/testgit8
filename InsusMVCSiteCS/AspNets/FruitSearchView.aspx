<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FruitSearchView.aspx.cs" Inherits="Insus.NET.AspNets.FruitSearchView" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, 
    Culture=neutral, PublicKeyToken=89845dcd8080cc91" 
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                Category Name: <asp:TextBox ID="TextBoxCategroyName" runat="server"></asp:TextBox>
                Kind Name: <asp:TextBox ID="TextBoxKindName" runat="server"></asp:TextBox>
                Fruit Name: <asp:TextBox ID="TextBoxFruitName" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonSR" runat="server" Text="Search & Report" OnClick="ButtonSR_Click" /><br />                
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"></rsweb:ReportViewer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
