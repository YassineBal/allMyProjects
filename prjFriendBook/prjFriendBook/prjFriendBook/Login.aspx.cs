using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblErreur.Visible = false;
            }






        }

        protected void btnInscrire_Click(object sender, EventArgs e)
        {
            Server.Transfer("Inscription.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //recuperer le pseudo  et le mot de passe \
            string pseudo = txtPseudo.Text.Trim();
            string mdp = txtMotdepasse.Text.Trim();
            //connecter BD
            Int32 refm = Convert.ToInt32(Session["userID"]);
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
            mycon.Open();

            string req = "SELECT RefMembre FROM Membres ";
            req += "WHERE Pseudo ='" + pseudo + "'AND Motdepasse = '" + mdp + "'";
            SqlCommand mycmd = new SqlCommand(req, mycon);
            SqlDataReader myreader = mycmd.ExecuteReader();



            //verifier  si membre existe

            if (myreader.Read() == false)
            {
                mycon.Close();
                lblErreur.Text = "numero ou mot de passe invalide ! essayez de nouveau";

                lblErreur.Visible = true;

            }
            else
            {
                //Sauvegarder le refMembre dans une variable globale de session
                Session["userID"] = myreader["RefMembre"];
                mycon.Close();
                Server.Transfer("Acceuil.aspx");


            }

        }
    }
}