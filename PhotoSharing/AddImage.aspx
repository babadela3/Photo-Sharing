<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImage.aspx.cs" Inherits="PhotoSharing.AddImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/styles/addImage.css" rel="stylesheet" type="text/css" />
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
                <div id="divProfileButton">
                    <input id="profileButton" type="button" value="Edit Profile" />
                </div>
                <div id="divProfileDetails">
                    <div id="divProfilePhotos">
                        <label id="profilePhotos">45 photos</label>
                    </div>
                    <div id="divProfileAlbums">
                        <label id="profileAlbums">3 albums</label>
                    </div>
                    <div id="divProfileComments">
                        <label id="profileComments">106 comments</label>
                    </div>
                </div>
                <div id="divProfileEmail">
                    <asp:Label id="profileEmail"  runat="server"/>
                </div>
            </div>
        </div>

        <div id="divMenu">
            <div id="divEmpty">
            </div>
            <div id="divMenuEdit">
                <div id="divEditTitle">
                    <label id="editTitle">Add Photo</label>
                </div>
                <div id="divEditInfo">
                    <label id="editInfo">Share your photos with other people.</label>
                </div>
                <div id="divEditEmailLabel">
                    <label id="editEmailLabel">Name</label>
                </div>
                <div id="divEditEmailText">
                    <asp:TextBox ID="editEmailText" runat="server" />
                </div>
                <div id="divEditNameLabel">
                    <label id="editNameLabel">Upload</label>
                </div>
                <div id="divEditNameText">
                    <asp:FileUpload id="editNameText" runat="server" />
                </div>
                <div id="divEditCityLabel">
                    <label id="editCityLabel">Description</label>
                </div>
                <div id="divEditCityText">
                    <asp:TextBox ID="editCityText" runat="server" />
                </div>
                <div id="divEditLocationLabel">
                    <label id="editLocationLabel">Location</label>
                </div>
                <div id="divEditLocationText">
                    <asp:TextBox ID="editLocationText" runat="server" />
                </div>
                <div id="divEditCategoryLabel">
                    <label id="editCategoryLabel">Category</label>
                </div>
                <div id="divEditCategoryText">
                    <asp:TextBox ID="editCategoryText" runat="server" />
                </div>
                <div id="divEditAlbumLabel">
                    <label id="editAlbumLabel">Album</label>
                </div>
                <div id="divEditAlbumText">
                    <asp:DropDownList id="editAlbumText"
                        AutoPostBack="True"
                        runat="server">
                   </asp:DropDownList>
                </div>
                <div id="divButtonEdit">
                    <asp:Button ID="buttonEdit" Text="Save" OnClick="Save" runat="server"/>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
