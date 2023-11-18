<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceuil.aspx.cs" Inherits="prjFriendBook.Acceuil" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
          .body {
        background-image: url('images/acc1.jpg');
        background-repeat: no-repeat;
        background-attachment: fixed;
        width: 100%;
         background-size:     cover; 
        height: 890px;
        margin-top: 0px;
        margin-bottom: 0px;
        margin-right: 0px;
        float: right;
         overflow-x: hidden;
        }
        .auto-style2 {
            text-align: left;
        }
          .pub{
            background-color:white;
        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
      <center><h1> <asp:Label ID="lblAcceuil" runat="server" Text="Label" ForeColor="#FF3300"></asp:Label></h1></center>
        <hr />
          <marquee class="pub">
       Trouvez l'amour,l'amitie en un clic sur FriendBook le meilleur pour vous. Appelez ou envoyez un sms  au XXX-XXX-XXX si vous avez des suggestions pour nous aider a ameliorer votre experience</marquee>
    </marquee>
        <h2 class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Que recherchez Vous ?"></asp:Label>
        </h2>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Bodytype"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p class="auto-style2">
            <asp:DropDownList ID="cboType" runat="server" OnSelectedIndexChanged="cboType_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p class="auto-style2">
            &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Religion"></asp:Label>
&nbsp;
        </p>
        <p class="auto-style2">
            <asp:DropDownList ID="cboReligion" runat="server">
            </asp:DropDownList>
        </p>
        <p class="auto-style2">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Ethnie"></asp:Label>
        </p>
        <p class="auto-style2">
            <asp:DropDownList ID="cboEthnie" runat="server">
            </asp:DropDownList>
        </p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:Button ID="BtnRechercher" runat="server" BackColor="#999999" Font-Bold="True" Height="40px" OnClick="BtnRechercher_Click" Text="Rechercher" Width="150px" />
        </p>
        <p class="auto-style2">
            &nbsp;</p>
        <h3>
            Veuillez choisir une personne pour plus de détails
        </h3>
          <asp:Table ID="TabMembres" runat="server" BackColor="red" BorderStyle="Solid" GridLines="Horizontal" Width="500px" Font-Bold="True">
                <asp:TableRow runat="server" BackColor="#53D5FF" ForeColor="blue">
                    <asp:TableCell runat="server">Pseudo</asp:TableCell>
                    <asp:TableCell runat="server">Genre</asp:TableCell>
                    <asp:TableCell runat="server">Action</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        <p class="auto-style2">
            
        </p>

    </form>
</body>
</html>
