<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="command.aspx.cs" Inherits="Donnevoleur.command" %>
<!DOCTYPE html>
<html 
    xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Centrale à béton</title>

</head>
<body>
    <asp:Label ID="DynButton" ForeColor="red" runat="server" />
    <section id="menuBout" style="margin : 50px auto 20px 40%">
        <p>
            <a href="CreerCommande.aspx">
                <input type="button"  value="Creation d'une commande" />
            </a>
        </p>
        <p>
            <a href="ConsultCommande.aspx">
                <input type="button" value="Consultation des commandes" />
            </a>
        </p>
        <p>
            <a href="HistoryCommand.aspx">
                <input type="button" value="Historique des commandes" />
            </a>
        </p>
        
        <p style="margin : 50px auto 370px auto">
    </p>
    </section>
</body>
</html>
