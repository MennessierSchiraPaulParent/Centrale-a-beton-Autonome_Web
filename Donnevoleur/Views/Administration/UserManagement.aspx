<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Donnevoleur.Views.Administration.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
        <div>
        </div>
                <asp:Label ID="Msg" ForeColor="red" runat="server" />
                <asp:ListBox ID="UserList" runat="server"></asp:ListBox>
            <p>
                <asp:Button OnClick="Validate_click" ID="Validate" runat="server" Text="Button" />
            </p>
        </form>
</body>
</html>
