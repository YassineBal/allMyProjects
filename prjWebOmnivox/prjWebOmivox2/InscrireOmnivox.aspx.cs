using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace prjWebOmivox2
{
    public partial class InscrireOmnivox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInscrire_Click(object sender, EventArgs e)
        {

            // recuperer les valeurs entrees

            string eml, num;
            num=txtNumero.Text.Trim();
            eml=txtEmail.Text.Trim();
            Int32 anNais = Convert.ToDateTime(dateNaissance.Text).Year;

            SqlConnection mycon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDBh;Integrated Security=True");
            mycon.Open();

            //creer une requete de recherche 
            string sql = "SELECT RefEtudiant,Nom  FROM Etudiants WHERE Numero ='" + num + "' AND AnneeNaissance =" +anNais;
            sql += " AND Email ='" + eml + "'";

            SqlCommand mycmd = new SqlCommand(sql,mycon);
            SqlDataReader myrder = mycmd.ExecuteReader();

            if (myrder.Read()==true) //si etudiants trouvee
            {
                string nom = myrder["Nom"].ToString();
                myrder.Close();
                string sql2 = "select RefMembre from Membres where Numero ='" + num + "'";
                SqlCommand mycmd2=new SqlCommand(sql2,mycon);
                SqlDataReader myreader = mycmd2.ExecuteReader();
                if (myreader.HasRows)
                {
                    lblErreur.Text = "ATTENTION VOUS ETES DEJA MEMBRE,CONTACTER L'ADMINISTRATION !";
                    myreader.Close();
                }
                else //user est etudiant mais il n'est pas membre donc il faut l'ajouter comme membre
                {
                    myreader.Close();
                    string mdp = txtMot2Passe.Text.Trim();
                    sql = "INSERT INTO Membres (Numero,Nom,Mot2Passe,Status) Values ('" + num + "','" + nom + "','" + mdp + "','actif')";
                    SqlCommand mycmd3 = new SqlCommand(sql, mycon);
                    mycmd3.ExecuteNonQuery();
                    mycon.Close();
                    //appres inscription, redirriger le user a lapage login;
                    Response.Redirect("indexOmnivox.aspx");  //on peut faire aussi Server.Transfer;  Mais lui il arrete tout l'execution qui vient appree


                }
                
            }
            else  //
            {
                      //si on veut faire server transfer on met le close de conn et  reader a l'interieur 

                lblErreur.Text = "Ce site est SEULEMENT pour les ETUDIANTS";
            }
            mycon.Close();
        }
    }
}