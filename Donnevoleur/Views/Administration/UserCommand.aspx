﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCommand.aspx.cs" Inherits="Donnevoleur.Views.Administration.UserCommand" %>

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
        <asp:TextBox ID="Oui" runat="server"></asp:TextBox>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="Validate" runat="server" Text="Button" OnClick="Validate_click" />
    </form>
</body>
</html>