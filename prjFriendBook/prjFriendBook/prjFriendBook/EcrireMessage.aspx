<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EcrireMessage.aspx.cs" Inherits="prjFriendBook.EcrireMessage" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        table{
            width:500px;
            margin:auto;
            font-weight:bold;
            border-radius:15px;
            background-color:darkgray;
            padding:2px;
        }
          .body {
        background-image: url('images/blan-noir.jpg');
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

    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div>
            
            <hr style="width:600px;" />
            <table>
<tr>
    <td>Destinataire :</td>

    <td>
        <asp:DropDownList ID="cboDestinataires" runat="server" Font-Bold="true" Width="300px"></asp:DropDownList>
    </td>
</tr>
    <td> Contenue Message :</td>

    <td>
        <asp:TextBox ID="TxtMessage" runat="server" Font-Bold="True" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox></td>
</tr>
<tr>
    <td colspan="2">
        <asp:Label ID="LblErreur" runat="server" Text="Label" Width="100%" ForeColor="Red" Font-Bold="True"></asp:Label> </td>

   
</tr>
                <tr>
    <td> 
        <asp:Button ID="btnEnvoyer" runat="server" Font-Bold="True" OnClick="btnEnvoyer_Click1" Text="Envoyer" />
                    </td>

    <td>
        <td> <asp:Button ID="btnEffacer" runat="server" Text="Effacer" Width="100px" Font-Bold="True" OnClick="btnEffacer_Click" /></td>
</tr>





            </table>
        </div>
    </form>
</body>
</html>

