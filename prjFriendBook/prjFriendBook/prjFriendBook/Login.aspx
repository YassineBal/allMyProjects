<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="prjFriendBook.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
          .body {
        background-image: url('images/couple.jpg');
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
           .btnlog {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 140px;
            height: 50px;
            background-color: #F08080;
            color: white;
            font-size: 25px;
            border-radius: 5px;
            margin-top: 20px;
            /*position: absolute;*/
            right: 719px;
            top: 430px;
        }
           </style>
    <title></title>
     <link href="css/Style.css" rel="stylesheet"  type="text/css"/>
</head>
<body class="body" style="width: 1710px">
    <div class="login">
        <form id="form1" runat="server" class="form">
            <div class="header">
                <div class="subtitle">FRIENDBOOK</div>
            </div>
            <div class="container">
            <div class="auto-style4">
                <asp:Label ID="lblEtudiant" runat="server" Text="Pseudo : " CssClass="label" Font-Bold="False" Font-Size="Larger" Font-Strikeout="False" ></asp:Label><br />
                <asp:TextBox ID="txtPseudo" CssClass="txt" runat="server"></asp:TextBox>
                </div>
                <br /><br />
            <div class="auto-style4">
                <asp:Label ID="lblPassword" runat="server" CssClass="label" Text="Label" Font-Size="Larger" >Mot de passe : </asp:Label><br />
                <asp:TextBox ID="txtMotdepasse"  CssClass="txt" runat="server" TextMode="Password"></asp:TextBox>
            </div>
                <div>
                    <asp:Button ID="btnLogin" CssClass="btnlog" runat="server" Text="Connexion" Font-Bold="True" OnClick="btnLogin_Click" />
                 </div>

                 <div class="btnLink">
                     <asp:LinkButton ID="btnInscrire" runat="server" class="btn" Font-Bold="True" ForeColor="Black" OnClick="btnInscrire_Click" >Premiere fois ? Inscrivez vous</asp:LinkButton>
                 </div>
                <div>
                    <asp:Label ID="lblErreur" Font-Bold="true" ForeColor="blue" runat="server"></asp:Label>
                </div>
             </div>
        </form>
    </div>
</body>
</html>

