<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHistory.aspx.cs" Inherits="Donnevoleur.Views.Administration.UserHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:BulletedList ID="BulletedList1" runat="server">
            </asp:BulletedList>
            <asp:Label ID="Msg" ForeColor="Red" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
