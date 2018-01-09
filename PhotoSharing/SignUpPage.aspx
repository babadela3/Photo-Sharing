<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="PhotoSharing.SignUpPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/styles/signUpPage.css" rel="stylesheet" type="text/css" />
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

                <asp:LinkButton Id="signUp" runat="server" Font-Underline="False">Sign Up</asp:LinkButton>

                <label id="line">|</label>

                <asp:LinkButton Id="logIn" runat="server" Font-Underline="False" OnClick="TransferLogIn">Log In</asp:LinkButton>

            </div>

        </div>
            <div id="divMenu">
                <div id="divEmpty">
                </div>
                <div id="divMenuCreate">
                    <div id="divCreateTitle">
                        <label id="createTitle">Create Account</label>
                    </div>
                    <div id="divCreateInfo">
                        <label id="createInfo">Use site name to keep in touch with best photos and amazing landscapes</label>
                    </div>
                    <div id="divCreateEmailLabel">
                        <label id="createEmailLabel">Email</label>
                    </div>
                    <div id="divCreateEmailText">
                        <asp:TextBox ID="createEmailText" runat="server" />
                    </div>
                    <div id="divCreatePasswordLabel">
                        <label id="createPasswordLabel">Password</label>
                    </div>
                    <div id="divCreatePasswordText">
                        <asp:TextBox ID="createPasswordText" TextMode="password" runat="server" />
                    </div>
                    <div id="divCreateNameLabel">
                        <label id="createNameLabel">Name</label>
                    </div>
                    <div id="divCreateNameText">
                        <asp:TextBox ID="createNameText" runat="server" />
                    </div>
                    <div id="divCreateCityLabel">
                        <label id="createCityLabel">City</label>
                    </div>
                    <div id="divCreateCityText">
                        <asp:TextBox ID="createCityText" runat="server" />
                    </div>
                    <div id="divButtonCreate">
                        <asp:Button ID="buttonCreate" Text="Create Account" runat="server" OnClick="CreateAccount"/>
                    </div>
                </div>
            </div>
        </form>
</body>
</html>

