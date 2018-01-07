<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="PhotoSharing.EditProfile" %>

<!DOCTYPE html>

<script runat="server">
    private void Save(Object source, EventArgs e) {
        try {
            SqlDataSource1.Update();
            Session["email"] = editEmailText.Text;
            Server.Transfer("Profile.aspx");
        }
        catch (Exception except) {
            // Handle the Exception.
            Session["email"] = editEmailText.Text;
            Server.Transfer("Profile.aspx");
        }        
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/styles/editProfile.css" rel="stylesheet" type="text/css" />
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
                    <label id="editTitle">Edit Profile</label>
                </div>
                <div id="divEditInfo">
                    <label id="editInfo">Help us to have your updated information.</label>
                </div>
                <div id="divEditEmailLabel">
                    <label id="editEmailLabel">Email</label>
                </div>
                <div id="divEditEmailText">
                    <asp:TextBox ID="editEmailText" ReadOnly="true" runat="server" />
                </div>
                <div id="divEditNameLabel">
                    <label id="editNameLabel">Name</label>
                </div>
                <div id="divEditNameText">
                    <asp:TextBox ID="editNameText" runat="server" />
                </div>
                <div id="divEditCityLabel">
                    <label id="editCityLabel">City</label>
                </div>
                <div id="divEditCityText">
                    <asp:TextBox ID="editCityText" runat="server" />
                </div>
                <div id="divButtonEdit">
                    <asp:Button ID="buttonEdit" Text="Save" OnClick="Save" runat="server"/>
                </div>

            </div>
        </div>

        <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True"
          UpdateCommand="UPDATE Users SET Name=@Name,City=@City WHERE Email=@Email">
          <UpdateParameters>
              <asp:ControlParameter Name="Name" ControlId="editNameText" PropertyName="Text" />
              <asp:ControlParameter Name="City" ControlId="editCityText" PropertyName="Text" />
              <asp:ControlParameter Name="Email" ControlId="editEmailText" PropertyName="Text" />
          </UpdateParameters>
      </asp:SqlDataSource>
    </form>
</body>
</html>
