<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeePhotoComment.aspx.cs" Inherits="PhotoSharing.SeePhotoComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/styles/seePhotoComment.css" rel="stylesheet" type="text/css" />
</head>
<body>
   
    <form id="form1" runat="server">
        <div id="divMenu">
            <div id="divEmpty">
                <asp:Image id="Image" runat="server" />
            </div>
            <div id="divMenuLogin" >
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
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    
                    </asp:PlaceHolder>
                
            </div>
            <div id="header-content">
                        <asp:TextBox ID="commentText" placeholder="Write a comment..." runat="server" OnTextChanged="AddComment" />
                    </div>
            
        </div>
    </form>
</body>
</html>
