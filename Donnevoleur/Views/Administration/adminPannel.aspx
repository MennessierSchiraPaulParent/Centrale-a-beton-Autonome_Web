<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPannel.aspx.cs" Inherits="Donnevoleur.Views.adminPannel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:Label ID="DynButton" ForeColor="red" runat="server" />
     <section id="menuBout" style="margin : 50px auto 20px 40%">
        <p>
            <a href="../Administration/UserCreation.aspx">
                <input type="button"  value="Création d'utilisateurs" />
            </a>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <a href="../Administration/UserManagement.aspx">
                <input type="button" value="Gestion Utilisateurs" />
            </a>
        </p>
        <p style="margin : 50px auto 370px auto">
    </p>
    </section>
</body>
</html>
