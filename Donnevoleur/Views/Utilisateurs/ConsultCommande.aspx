<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultCommande.aspx.cs" Inherits="Donnevoleur.Views.ConsultCommande" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Centrale béton</title>
</head>
<body>
    <asp:Label ID="DynButton" ForeColor="red" runat="server" />
     <asp:Label ID="DynButton2" ForeColor="red" runat="server" />
    <form id="form1" runat="server">
        <asp:ListBox ID="CheckBoxList2" Rows="25" Width="200px" SelectionMode="Single"  runat="server"></asp:ListBox>
        <asp:Button ID="Validate" runat="server" Text="Download BarCode" OnClick="Validate_click" />
        <asp:Label ID="Msg" ForeColor ="PaleVioletRed" runat ="server"></asp:Label>
    </form>
</body>
</html>
