'-<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Donnevoleur.login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
      <title></title>
</head>
    <body>
        <form id="form1" runat="server">
            <h3>Login Page</h3>
            <table><tr><td>UserName:</td>
                      <td><asp:TextBox ID="UserName" runat="server" /></td>
                      <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                      ControlToValidate="UserName"
                                                      Display="Dynamic"
                                                      ErrorMessage="Cannot be empty."
                                                      runat="server" />
                    </td>
                    </tr>
                    <tr><td>Password:</td>
                        <td><asp:TextBox ID="UserPass" TextMode="Password" runat="server" /></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                        ControlToValidate="UserPass"
                                                        ErrorMessage="Cannot be empty."
                                                        runat="server" />
                    </td>
                    </tr>
                    <tr><td>Remember me?</td>
                    <td><asp:CheckBox ID="chkboxPersist" runat="server" /></td>
                    </tr>
            </table>
                <asp:Button ID="Submit1" OnClick="Login_Click" Text="Log In" runat="server" />
            <!--
            <asp:SqlDataSource ID="Test" runat="server" DataSourceMode="DataReader" ConnectionString="Server=localhost;Database=centrale_beton;User Id =root; password=;" 
                SelectCommand="select Login from utilisateurs">
            </asp:SqlDataSource>
            
            <asp:ListView ID="UserListView" runat="server" DataSourceID="Test" DataKeyNames="IdUser">
               
            </asp:ListView>
            -->
            <p>
                <asp:Label ID="Msg" ForeColor="red" runat="server" />
            </p>
        </form>
    </body>
</html>
