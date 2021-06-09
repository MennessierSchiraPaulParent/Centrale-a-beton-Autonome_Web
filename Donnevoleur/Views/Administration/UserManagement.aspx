<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Donnevoleur.Views.Administration.WebForm1" %>

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
        <div>
        </div>
                <asp:ListBox ID="UserList" runat="server" Height="540px" Width="204px"></asp:ListBox>
            <p>
                <asp:Button OnClick="Validate_click" ID="Validate" runat="server" Text="Select" />
            </p>
        </form>
</body>
</html>
