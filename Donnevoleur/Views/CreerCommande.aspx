﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerCommande.aspx.cs" Inherits="Donnevoleur.creerCommande" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
</head>
  <body>
    <form id="form2" runat="server">
      <h3>Création de commande </h3>
      <table>
          <tr><td>Quantitée</td>
              <!--Faire ne sorte de ne pouvoir rentrer que des nombres  -->
          <td><asp:TextBox ID="Quantity" runat="server" /></td></tr>
      </table>
      <asp:Button ID="Submit2" OnClick="CommandCreate_Click" Text="Create" runat="server" />
    </form>
      <p>
                <asp:Label ID="Msg" ForeColor="red" runat="server" />
          
            </p>
</body>
</html>
