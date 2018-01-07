<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="PhotoSharing.UpdateUser" %>

<!DOCTYPE html>

<script runat="server">
 private void On_Click(Object source, EventArgs e) {
    try {
        SqlDataSource1.Update();
    }
    catch (Exception except) {
        // Handle the Exception.
    }

        Label2.Text="The record was updated successfully!";

 }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True"
          UpdateCommand="UPDATE Users SET Name=@Name,City=@City WHERE Email=@Email">
          <UpdateParameters>
              <asp:ControlParameter Name="Name" ControlId="TextBox1" PropertyName="Text" />
              <asp:ControlParameter Name="City" ControlId="TextBox2" PropertyName="Text" />
              <asp:ControlParameter Name="Email" ControlId="TextBox3" PropertyName="Text" />
          </UpdateParameters>
      </asp:SqlDataSource>



      <br />
      <asp:TextBox id="TextBox1" runat="server" Text="Enter name."/>
      <asp:TextBox id="TextBox2" runat="server" Text="Enter city."/>
      <asp:TextBox id="TextBox3" runat="server" Text="Enter mail."/>
      <asp:Button id="Submit" runat="server" Text="Submit" OnClick="On_Click" />

      <br /><asp:Label id="Label2" runat="server" Text="" />

    </form>
  </body>
</html>
