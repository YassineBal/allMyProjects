<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="prjFriendBook.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   
   
    <style type="text/css">
        .auto-style3 {
            height: 61px;
        }
        .corps{
            background-color:bisque;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 246px;
        }
        .auto-style7 {
            height: 61px;
            width: 246px;
        }
        .pub{
            background-color:white;
        }
    </style>
    
</head>
<body class="corps">
    <form id="form1" runat="server">
        <div>
            <img src="images/meet.png" />
            </div>
       
    <h1 class="titre">FRIENDBOOK</h1>
          <marquee class="pub">
       Trouvez l'amour,l'amitie en un clic sur FriendBook le meilleur pour vous. Appelez ou envoyez un sms  au XXX-XXX-XXX si vous avez des suggestions pour nous aider a ameliorer votre experience</marquee>
    </marquee>
    <hr />
    <h2 class="auto-style5">INSCRIPTION D&#39;UN NOUVEAU MEMBRE</h2>
     <hr />
       <table align="center" cellpadding="20" class="auto-style3">
        <tr>
            <td class="auto-style4">Votre nom :</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtNom" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNom" ErrorMessage="Votre nom est requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
            </td>
        </tr>
           <tr>
            <td class="auto-style4">Votre prenom :</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtPrenom" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPrenom" ErrorMessage="Votre prenom est requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
            </td>
        </tr>
           <tr>
            <td class="auto-style4">Votre pseudonyme :</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtPseudo" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPseudo" ErrorMessage="PSeudonyme requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Annee de naissance</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtAnneeN" runat="server" Font-Bold="True" ForeColor="Blue" TextMode="Number" Width="50px" OnTextChanged="TxtAnneeN_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqNaissance" runat="server" ControlToValidate="TxtAnneeN" ErrorMessage="annee de naissance  requise !" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rngAnnee" runat="server" ControlToValidate="TxtAnneeN" ErrorMessage="Vous devez avoir au moins 19ans pour etre membre " Font-Bold="True" ForeColor="White" MaximumValue="2003" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
            </td>
        </tr>
           <tr>
            <td class="auto-style4">Email personnel :</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtEmail" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px" ValidateRequestMode="Enabled"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Email requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regxEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Format email invalide!" Font-Bold="True" ForeColor="White" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
            <tr>
            <td class="auto-style4">Mot de passe :</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtMotdepasse" runat="server" Font-Bold="True" ForeColor="Blue" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqMotdepasse" runat="server" ControlToValidate="TxtMotdepasse" ErrorMessage="Mot de passe  requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Confirmer mot&nbsp;passe :</td>
            <td class="auto-style6">
                <asp:TextBox ID="TxtMotdepasse2" runat="server" Font-Bold="True" ForeColor="Blue" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqMotdepasse2" runat="server" ControlToValidate="TxtMotdepasse2" ErrorMessage="Confirmation du mot de passe requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpMotdepasse" runat="server" ControlToCompare="TxtMotdepasse" ControlToValidate="TxtMotdepasse2" ErrorMessage="les 2 mots de passe doivent etre identiques!" Font-Bold="True" ForeColor="White" SetFocusOnError="True">*</asp:CompareValidator>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Genre&nbsp;&nbsp;&nbsp; :</td>
            <td class="auto-style6">
                <asp:DropDownList ID="cboGenre" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style2">
                </td>
        </tr>
        
            <tr>
            <td class="auto-style4">Decrivez vous en quelques mot&nbsp; :</td>
            <td>
                <asp:TextBox ID="TxtDescription" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDescription" ErrorMessage="Votre presentation est requis!" Font-Bold="True" ForeColor="White">*</asp:RequiredFieldValidator>
            </td>
        </tr>

            <tr>
            <td class="auto-style4">Votre body type :</td>
            <td>
                <asp:DropDownList ID="cboBody" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
             <tr>
            <td class="auto-style4">Votre appartenance ethnique :</td>
            <td>
                <asp:DropDownList ID="cboEthnie" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
            <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Votre religion&nbsp;&nbsp;&nbsp; :</td>
            <td class="auto-style2">
                <asp:DropDownList ID="cboReligion" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style2">
                </td>
        </tr>
       
        <tr>
            <td class="auto-style5">
                <asp:Button ID="BtnInscription" runat="server" Font-Bold="True" Text="S'inscrire" Width="150px" OnClick="BtnNext_Click" />
            </td>
            <td id="BtnRecommencer" class="auto-style7">
                <asp:Button ID="BtnRecommencer" runat="server" Font-Bold="True" Text="Recommencer" Width="150px" OnClick="BtnRecommencer_Click" />
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="red" Width="98%"></asp:Label>
            </td>
            <td class="auto-style7"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="blue" Width="218px" />
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
       
    </form>
    </body>
</html>