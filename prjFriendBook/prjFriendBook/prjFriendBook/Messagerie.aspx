<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messagerie.aspx.cs" Inherits="prjFriendBook.Messagerie" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">Votre messagerie FriendBook</h1>

            <hr />
            <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            <div class="auto-style1">
            <asp:Table ID="TableEtudiants" runat="server" BackColor="yellow" BorderStyle="Solid" GridLines="Horizontal" Width="500px" Font-Bold="True">
                <asp:TableRow runat="server" BackColor="#53D5FF" ForeColor="White">
                    
                    <asp:TableCell runat="server">Envoyeur</asp:TableCell>
                    <asp:TableCell runat="server">Action</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
            <br />
            <asp:Button ID="btnRediger" runat="server" Text="Rediger nouveau message" Font-Bold="True" OnClick="btnRediger_Click" />
            <center />
        </div>
    </form>
</body>
</html>

