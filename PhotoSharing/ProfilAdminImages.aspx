<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilAdminImages.aspx.cs" Inherits="PhotoSharing.ProfilAdminImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/styles/profileAdmin.css" rel="stylesheet" type="text/css" />
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

                <asp:LinkButton Id="profile" runat="server" Font-Underline="False" OnClick="TransferProfile">Profile</asp:LinkButton>                

                <label id="line">|</label>

                <asp:LinkButton Id="logOut" runat="server" Font-Underline="False" OnClick="TransferLogIn">Log Out</asp:LinkButton>

            </div>

        </div>
        <div id="divProfile">
            <div id="divProfilePicture">
                <asp:Image id="ImageProfile" runat="server" class="roundedcorners"/>
            </div>
            <div id="divProfileInfo">
                <div id="divProfileName">
                    <asp:Label id="profileName" runat="server"/>
                </div>
            </div>
        </div>
        <div id="divOptions">
            <div class="options">
                <asp:LinkButton Id="optionPhotos" runat="server" Font-Underline="False" OnClick="SeePhotos">Comments</asp:LinkButton>
            </div>
            <div class="options">
                <label id="optionAlbums">Photos</label>
            </div>
        </div>
        
    
        <div id="divMenu">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>

    </form>
</body>
</html>
