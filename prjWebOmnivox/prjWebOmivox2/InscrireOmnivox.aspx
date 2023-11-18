<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscrireOmnivox.aspx.cs" Inherits="prjWebOmivox2.InscrireOmnivox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Premier Utilisation</title>

   <style type="text/css">
       body{
           background-color:powderblue;
           font-weight:bold;
       }
       table{
           background-color:aquamarine;
           font-weight:bold;
           color:black;
           border-radius:10px;
           width:400px;
           margin:auto;
           
       }
       h1{
           text-align:center;

       }
       .boite{
           width:200px;
           color:orangered;
           font-weight:bold;
           border-radius:5px;

       }
       .bouton{
           width:150px;
           color:orangered;
           background-color:black;
           border-radius:5px;
       }
   </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>OMNIVOX-INSCRIPTION MEMBRE</h1>
            <hr  style="width:800px" />
            <table>
                <tr>
                    <td>Numero Etudiant</td>
                    <td>
                        <asp:TextBox ID="txtNumero" CssClass="boite" runat="server"></asp:TextBox>

                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqNumero" Text="*" runat="server" ErrorMessage="Numero requis !" ControlToValidate="txtNumero" ForeColor="Red"></asp:RequiredFieldValidator></td>

                </tr>
                <tr>
                    <td>Nom </td>
                    <td><asp:TextBox ID="txtNom" CssClass="boite" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="reqNom" Text="*" runat="server" ErrorMessage="Nom requis !" ControlToValidate="txtNom" ForeColor="Red"></asp:RequiredFieldValidator></td>

                </tr>
                <tr>
                    <td>Date Naissance</td>
                    <td><asp:TextBox ID="dateNaissance" CssClass="boite" runat="server" TextMode="Date"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="reqDateNaissance" Text="*" runat="server" ErrorMessage="Date Naissance Requise !" ControlToValidate="dateNaissance" ForeColor="Red"></asp:RequiredFieldValidator></td>

                </tr>
                <tr>
                    <td>Email</td>
                    <td><asp:TextBox ID="txtEmail" CssClass="boite" runat="server" TextMode="Email"></asp:TextBox></td>
                    <td>
                         <asp:RegularExpressionValidator ID="reqExEmail" Text="*" runat="server" ErrorMessage="Email invalide" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="reqEmail" Text="*" runat="server" ErrorMessage="Adresse email requise !" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator></td>

                </tr>
                <tr>
                    <td>Mot de Passe</td>
                    <td><asp:TextBox ID="txtMot2Passe" CssClass="boite" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="reqMot2Passe" Text="*" runat="server" ErrorMessage="MotDePasse requis !" ControlToValidate="txtMot2Passe" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                    </td>

                </tr>
                <tr>
                    <td>Confirmer Mot de Passe</td>
                    <td><asp:TextBox ID="txtMot2Passe2" CssClass="boite" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td>
                        <asp:CompareValidator ID="cmpMot2Passe" runat="server" ErrorMessage="MotDePasse nom Identique" ForeColor="Red" Text="*" ControlToCompare="txtMot2Passe" ControlToValidate="txtMot2Passe2"></asp:CompareValidator></td>
                    <asp:RequiredFieldValidator ID="reqMot2Passe2" Text="*" runat="server" ErrorMessage="MotDePasse requis !" ControlToValidate="txtMot2Passe2" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                 <tr>
                    <td>&nbsp</td>
                    <td>&nbsp</td>       <!--&nbsp pour laisser un espace en html-->
                    <td>&nbsp</td>

                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnInscrire" CssClass="bouton" runat="server" Text="Inscrire"  OnClick="btnInscrire_Click" /></td>     <!--OnClientClick c'est pour gerer si on execute cote client ou cote serveur si on met true donc il va executer cote serveur si on met return false il va blocker l'execution dans le serveur-->
                    <td><asp:Button ID="btnRecommencer" runat="server" CssClass="bouton" Text="Recommencer" /></td>
                    <td></td>

                </tr>
               
                <tr>
                    <td colspan="3"><asp:Label ID="lblErreur" runat="server" Text="" Font-Bold="True" ForeColor="Red" Height="100%"></asp:Label></td>
                </tr>
                 <tr>
                    
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1"  ForeColor="Red" Font-Bold="true" runat="server" />
                    </td>
                    

                </tr>


            </table>
        </div>
    </form>
</body>
</html>
