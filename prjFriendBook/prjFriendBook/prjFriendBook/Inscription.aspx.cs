using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void BtnRecommencer_Click(object sender, EventArgs e)
        {

            TxtNom.Text = "";
            TxtPrenom.Text = "";
            TxtPseudo.Text = "";
            TxtAnneeN.Text = "";

            TxtEmail.Text = "";
            TxtMotdepasse.Text = "";
            TxtMotdepasse2.Text = "";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)

            {
                RemplirGenre();
                RemplirBody();
                RemplirEthnie();
                RemplirReligion();


            }
        }


        private void RemplirGenre()
        {
            //Remplissage du combo box des genres 
            ListItem elem1 = new ListItem();
            cboGenre.Items.Add(new ListItem("Selectionnez"));
            elem1.Text = "Homme";

            cboGenre.Items.Add(elem1);

            ListItem elem2 = new ListItem("Femme");
            cboGenre.Items.Add(elem2);

        }
        private void RemplirBody()
        {
            //Remplissage du combo box pour le body
            ListItem elem1 = new ListItem();
            cboBody.Items.Add(new ListItem("Selectionnez"));
            elem1.Text = "Athletique";

            cboBody.Items.Add(elem1);

            ListItem elem2 = new ListItem("Moyen");
            cboBody.Items.Add(elem2);

            ListItem elem3 = new ListItem("courbé");
            cboBody.Items.Add(elem3);

            ListItem elem4 = new ListItem("grande taille");
            cboBody.Items.Add(elem4);

            ListItem elem5 = new ListItem("mince");
            cboBody.Items.Add(elem5);



        }
        private void RemplirEthnie()
        {
            //Remplissage du combo box pour le body
            ListItem elem1 = new ListItem();
            cboBody.Items.Add(new ListItem("Selectionnez"));
            elem1.Text = "noir";

            cboEthnie.Items.Add(elem1);

            ListItem elem2 = new ListItem("caucasien");
            cboEthnie.Items.Add(elem2);

            ListItem elem3 = new ListItem("Sud Asiatique");
            cboEthnie.Items.Add(elem3);

            ListItem elem4 = new ListItem("Europeen");
            cboEthnie.Items.Add(elem4);

            ListItem elem5 = new ListItem("metis");
            cboEthnie.Items.Add(elem5);


            ListItem elem6 = new ListItem("latino");
            cboEthnie.Items.Add(elem6);



        }
        private void RemplirReligion()
        {
            //Remplissage du combo box pour le body
            ListItem elem1 = new ListItem();
            cboReligion.Items.Add(new ListItem("Selectionnez"));
            elem1.Text = "Musulman";

            cboReligion.Items.Add(elem1);

            ListItem elem2 = new ListItem("chretien");
            cboReligion.Items.Add(elem2);

            ListItem elem4 = new ListItem("athe");
            cboReligion.Items.Add(elem4);





        }


        protected void BtnNext_Click(object sender, EventArgs e)
        {
            //recuperation des valeeurs 
            string nom = TxtNom.Text.Trim();
            string prenom = TxtPrenom.Text.Trim();
            string pseudo = TxtPseudo.Text.Trim();
            string genre = cboGenre.SelectedItem.Text.Trim();
            Int16 AnneeN = Convert.ToInt16(TxtAnneeN.Text);
            string eml = TxtEmail.Text.Trim();
            string mdp = TxtMotdepasse.Text;
            string description = TxtDescription.Text;
            string bodytype = cboBody.SelectedItem.Text;
            string ethnie = cboEthnie.SelectedItem.Text;
            string religion = cboReligion.SelectedItem.Text;
            //connection a la BD
            Int32 refm = Convert.ToInt32(Session["userID"]);
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
            mycon.Open();
            //verification si le client  est membre
            string req = "SELECT RefMembre FROM Membres ";
            req += "WHERE Email ='" + eml + "'";
            SqlCommand mycmd1 = new SqlCommand(req, mycon);
            SqlDataReader myreader1 = mycmd1.ExecuteReader();

            if (myreader1.Read()) //deja membre
            {
                myreader1.Close();
                mycon.Close();
                lblmessage.Text = "Vous etes deja membre !";
            }
            else
            {
                myreader1.Close();
                //Creation de la requete
                req = "INSERT INTO Membres(Nom,Prenom,Pseudo,AnneeN,Genre,Email,Motdepasse,Description,Bodytype,Ethnie,Religion) ";
                req += "VALUES('" + nom + "','" + prenom + "','" + pseudo + "','" + AnneeN + "','" + genre + "','" + eml + "','" + mdp + "','" + description + "','" + bodytype + "','" + ethnie + "','" + religion + "')";
                SqlCommand Command = new SqlCommand(req, mycon);
                Command.ExecuteNonQuery();
                mycon.Close();
                Server.Transfer("Login.aspx");


            }




        }

        protected void TxtAnneeN_TextChanged(object sender, EventArgs e)
        {

        }

    }
}