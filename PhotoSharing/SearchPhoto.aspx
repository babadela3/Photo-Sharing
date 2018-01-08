<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPhoto.aspx.cs" Inherits="PhotoSharing.SearchPhoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/styles/defaultPage.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
        
    <form id="form1" runat="server">
        
        <div id="divBarMenu">

            <div id="divLogo">

                <asp:ImageButton  ID="logoImg" runat="server" ImageAlign="Bottom" ImageUrl="images/camera.png" />                

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

                <asp:LinkButton Id="profile" runat="server" Font-Underline="False" OnClick="TransferProfile">Profile</asp:LinkButton>                

                <label id="line">|</label>

                <asp:LinkButton Id="logIn" runat="server" Font-Underline="False" OnClick="TransferLogIn">Log In</asp:LinkButton>

                <asp:LinkButton Id="logOut" runat="server" Font-Underline="False" OnClick="TransferLogOut">Log Out</asp:LinkButton>

            </div>

        </div>
        <div id="divMenu">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
