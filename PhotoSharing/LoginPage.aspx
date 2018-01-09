<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PhotoSharing.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/styles/loginPage.css" rel="stylesheet" type="text/css" />
    <title></title>          
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBarMenu">

            <div id="divLogo">

                <asp:ImageButton  ID="logoImg" runat="server" ImageAlign="Bottom" ImageUrl="images/camera.png" OnClick="TransferDefault"/>

            </div>

            <div id="divSearch">

                <asp:TextBox ID="searchBar" placeholder="Search..." runat="server" OnTextChanged="Search"  />
                
                <asp:RadioButtonList ID="RadioButton1"  runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value ="1">Caregory</asp:ListItem>
                    <asp:ListItem Value ="2">Location</asp:ListItem>
                    <asp:ListItem Value ="3">Description</asp:ListItem>
                </asp:RadioButtonList>

            </div>

            <div id="divAutentification">

                <asp:LinkButton Id="signUp" runat="server" Font-Underline="False" OnClick="TransferSignUp">Sign Up</asp:LinkButton>                

                <label id="line">|</label>

                <asp:LinkButton Id="logIn" runat="server" Font-Underline="False">Log In</asp:LinkButton>

            </div>

        </div>

        <div id="divMenu">
    <div id="divEmpty">
    </div>
    <div id="divMenuLogin">
        <div id="divLoginTitle">
            <label id="loginTitle">Photo Sharing</label>
        </div>
        <div id="divLoginInfo">
            <label id="loginInfo">If you have an account with us, please log in.</label>
        </div>
        <div id="divLoginEmailLabel">
            <label id="loginEmailLabel">Email</label>
        </div>
        <div id="divLoginEmailText">
            <asp:TextBox ID="loginEmailText" runat="server" />
        </div>
        <div id="divloginPasswordLabel">
            <label id="loginPasswordLabel">Password</label>
        </div>
        <div id="divloginPasswordText">
            <asp:TextBox ID="loginPasswordText" TextMode="password" runat="server" />
        </div>
        <div id="divButtonLogin">
            <asp:Button ID="buttonLogin" Text="Login" OnClick="Login" runat="server"/>
        </div>
    </div>
</div>
    </form>
   
</body>
</html>
