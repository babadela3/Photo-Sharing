<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PhotoSharing.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/styles/logInPage.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBarMenu">

            <div id="divLogo">

                <asp:ImageButton  ID="logoImg" runat="server" ImageAlign="Bottom" ImageUrl="images/camera.png" OnClick="TransferDefault"/>

            </div>

            <div id="divSearch">

                <input id="searchBar" type="text" placeholder="Search..." />

            </div>

            <div id="divAutentification">

                <asp:LinkButton Id="signUp" runat="server" Font-Underline="False" OnClick="TransferSignUp">Sign Up</asp:LinkButton>                

                <label id="line">|</label>

                <asp:LinkButton Id="logIn" runat="server" Font-Underline="False">Log In</asp:LinkButton>

            </div>

        </div>
    </form>
</body>
</html>
