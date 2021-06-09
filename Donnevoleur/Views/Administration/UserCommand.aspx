<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCommand.aspx.cs" Inherits="Donnevoleur.Views.Administration.UserCommand" %>

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
        
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="Validate" runat="server" Text="Delete" OnClick="Validate_click" />
    </form>
</body>
</html>
