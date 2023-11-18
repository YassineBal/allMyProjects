using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;  //sql server sqlclient  //oledb access   

namespace prjWebOmivox2
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //recuperer numero et mot2passe
            string numETud=txtNumero.Text.Trim();
            string motpasse = txtMot2passe.Text.Trim();


            //connexion a la base de donnee

            SqlConnection mycon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDBh;Integrated Security=True");
            mycon.Open();

            //la requete de recherche de membre avec le numero et mot de passe entree

            string sql = "SELECT RefMembre,Nom from Membres where Numero='" + numETud + "' AND Mot2Passe='" + motpasse + "'";

            SqlCommand mycmd = new SqlCommand(sql,mycon);
            SqlDataReader myRder = mycmd.ExecuteReader();

            //verifier si membre a ete trouvee
            if(myRder.Read()==true)   //.true on peut l'enlever  //. hasrows pour juste tester si ya de ligne dans my reader mais on ne pourra pas recuperer ces donnees

            {
                //sauvegarder RefMembre et nom dans des variable global (de session )
                Session["MembreID"] = myRder["RefMembre"];
                Session["NomMembre"] = myRder["Nom"];


                myRder.Close();
                mycon.Close();
                //rediriger vers la page d'accueil 

                Server.Transfer("AcceuilOmnivox.aspx");


            }
            else   //si reder est vide ou membre n'existe pas 
             {
                myRder.Close();
                mycon.Close();

                lblErreur.Text = "Numero ou Motdepasse Incorrect essayer de nouveau ";
            }
        }

        protected void btnInscrire_Click(object sender, EventArgs e)
        {
            Response.Redirect("InscrireOmnivox.aspx");   //une autre manier poour ouvrire une page apartire d'une autre
        }
    }
}