<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertImage.aspx.cs" Inherits="PhotoSharing.InsertImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload id="FileUpload1" runat="server" />
        <asp:Button runat="server" id="ButtonInsert" text="Button Insert" onclick="ButtonInsert_Click" />
        <br /><br />
        <asp:Label runat="server" id="LabelError" text="" />
    </form>
</body>
</html>
