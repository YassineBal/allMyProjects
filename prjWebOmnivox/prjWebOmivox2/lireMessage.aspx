<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lireMessage.aspx.cs" Inherits="prjWebOmivox2.lireMessage" %>


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
        table{
            width:500px;
            font-weight:bold;
            margin:auto;
            border-radius:10px;
            border:2px solid;
            background-color:antiquewhite;
            color:brown;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>OMNIVOX-TECCART-MIO</h1>
            <hr />
            <table style="width: 100%;">
                <tr>
                    <td>Titre </td>
                    <td>
                        <asp:Label ID="lblTitre" runat="server" Text=""></asp:Label>

                    </td>
                    
                </tr>
                <tr>
                    <td>Date </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>

                    </td>
                    
                </tr>
                <tr>
                    <td>Message </td>
                    <td>
                         <asp:Label ID="lblMessage" runat="server" CssClass="hiphop" ></asp:Label>
                    </td>
                    
                </tr>
                
            </table>

        </div>
        <center>
       
            </center>
    </form>
</body>
</html>

