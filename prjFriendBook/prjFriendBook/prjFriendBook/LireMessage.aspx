<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LireMessage.aspx.cs" Inherits="prjFriendBook.LireMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style>
        h1{
            text-align:center;

        }
        hr{
            width:440px;
        }
        .lire{
            font-weight:bold;
            background-color:beige;
            width:400px;
            height:400px;
            border-radius:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
        </div>
        <center>
        <asp:Label ID="LblMessage" runat="server"  CssClass="lire"></asp:Label>
            </center>
    </form>
</body>
</html>