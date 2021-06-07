<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdministration.aspx.cs" Inherits="Donnevoleur.Views.Administration.UserAdministration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:Label ID="DynButton" ForeColor="red" runat="server" />
    <asp:Label ID="DynButton2" ForeColor="red" runat="server" />
    <form id="form1" runat="server">
        <asp:Label ID="Msg" ForeColor="red" runat="server" />
        <div>
        </div>
        <asp:Button ID="CommandesEnCours" runat="server" OnClick="Button1_Click" Text="Commandes en cours" />
        <p>
        <asp:Button ID="CommandsHistory" runat="server" OnClick="Button2_Click" Text="Historique des commandes" />
        </p>
        <asp:Button ID="DeleteUser" runat="server" OnClick="Button3_Click" Text="Supprimer Utilisateur" />
    </form>
</body>
</html>
