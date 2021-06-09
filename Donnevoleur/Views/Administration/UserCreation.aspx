<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCreation.aspx.cs" Inherits="Donnevoleur.Views.Administration.UserCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Centrale béton</title>
</head>
<body>
    <asp:Label ID="DynButton" ForeColor="red" runat="server" />
    <asp:Label ID="DynButton2" ForeColor="red" runat="server" />
<form id="form3" runat="server">
      <h3>Création d'utilisateur </h3>
      <table>
          <tr><td>Nom d'utilisateur</td>
          <td><asp:TextBox ID="UserName" runat="server" /></td></tr>
          <tr><td>Mot de passe</td>
          <td><asp:TextBox ID="Password" runat="server" /></td></tr>
      </table>
      <asp:Button ID="Submit2" OnClick="CreateUser_Click" Text="Create" runat="server" />
    </form>
      <p>
                <asp:Label ID="Msg" ForeColor="red" runat="server" />
                <asp:Label ID="Msg1" ForeColor="red" runat="server" />
    </p>
</body>
</html>
