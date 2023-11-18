<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="prjFriendBook.Details" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style ="background-color:antiquewhite">
    
    <form id="form1" runat="server">
        <div>
             <center>
        <asp:Label ID="LblDetails" runat="server"  CssClass="hiphop" Font-Bold="True"></asp:Label>
            </center>
        </div>
        <div>
        <center>
        <asp:Button ID="BtnContacter" runat="server" Text="Contacter" Font-Bold="True" Height="30px" OnClick="BtnContacter_Click" />
            </center>
            </div>
    </form>
</body>
</html>
