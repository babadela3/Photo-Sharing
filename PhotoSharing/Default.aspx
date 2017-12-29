<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoSharing.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/styles/firstPage.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBarMenu">

            <div id="divLogo">

                <asp:ImageButton  ID="logoImg" runat="server" ImageAlign="Bottom" ImageUrl="images/camera.png" />                

            </div>

            <div id="divSearch">

                <input id="searchBar" type="text" placeholder="Search..." />

            </div>

            <div id="divAutentification">

                <asp:LinkButton Id="signUp" runat="server" Font-Underline="False" OnClick="TransferSignUp">Sign Up</asp:LinkButton>                

                <label id="line">|</label>

                <asp:LinkButton Id="logIn" runat="server" Font-Underline="False" OnClick="TransferLogIn">Log In</asp:LinkButton>

            </div>

        </div>
    <div id="divMenu">
        <div class="divImg">
            <img class="imgPresentation" src="images/image.jpg" />
            <div class="description">
                <label>Descriere</label>
            </div>
        </div>
        <div class="divImg">
            <img class="imgPresentation" src="images/image.jpg" />
            <div class="description">
                <label>Descriere</label>
            </div>
        </div>
        <div class="divImg">
            <img class="imgPresentation" src="images/image.jpg" />
            <div class="description">
                <label>Descriere</label>
            </div>
        </div>
        <div class="divImg">
            <img class="imgPresentation" src="images/image.jpg" />
            <div class="description">
                <label>Descriere</label>
            </div>
        </div>
        <div class="divImg">
            <img class="imgPresentation" src="images/image.jpg" />
            <div class="description">
                <label>Descriere</label>
            </div>
        </div>
        <div class="divImg">
            <img class="imgPresentation" src="images/image.jpg" />
            <div class="description">
                <label>Descriere</label>
            </div>
        </div>
                

    </div>
    </form>
</body>
</html>
