using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class Acceuil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Int32 refm = Convert.ToInt32(Session["userID"]);
                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
                mycon.Open();

                string req = "SELECT RefMembre,Prenom FROM Membres ";
                req += "WHERE RefMembre =" + refm;
                SqlCommand mycmd = new SqlCommand(req, mycon);
                SqlDataReader myreader = mycmd.ExecuteReader();
                if (myreader.Read())
                {
                    lblAcceuil.Text = "Bienvenue " + myreader["Prenom"].ToString();
                }
                myreader.Close();
                remplircbotype();
                remplircboReligion();
                remplircboEthnie();

                TabMembres.Visible = false;

            }
        }
        private void remplircboEthnie()
        {
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cfabi\\Desktop\\2022\\Automne\\prjFriendBook\\prjFriendBook\\App_Data\\FriendBook.accdb;Persist Security Info=True";
            mycon.Open();
            string req1 = "SELECT  DISTINCT Ethnie FROM Membres ";

            SqlCommand mycmd1 = new SqlCommand(req1, mycon);
            SqlDataReader myreader1 = mycmd1.ExecuteReader();
            while (myreader1.Read())
            {
                cboEthnie.Items.Add(myreader1["Ethnie"].ToString());

            }
        }
        private void remplircboReligion()
        {
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cfabi\\Desktop\\2022\\Automne\\prjFriendBook\\prjFriendBook\\App_Data\\FriendBook.accdb;Persist Security Info=True";
            mycon.Open();
            string req1 = "SELECT  DISTINCT Religion  FROM Membres ";

            SqlCommand mycmd1 = new SqlCommand(req1, mycon);
            SqlDataReader myreader1 = mycmd1.ExecuteReader();
            while (myreader1.Read())
            {



                cboReligion.Items.Add(myreader1["Religion"].ToString());



            }
        }
        private void remplircbotype()
        {
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cfabi\\Desktop\\2022\\Automne\\prjFriendBook\\prjFriendBook\\App_Data\\FriendBook.accdb;Persist Security Info=True";
            mycon.Open();
            string req1 = "SELECT DISTINCT Bodytype FROM Membres ";

            SqlCommand mycmd1 = new SqlCommand(req1, mycon);
            SqlDataReader myreader1 = mycmd1.ExecuteReader();
            while (myreader1.Read())
            {



                cboType.Items.Add(myreader1["Bodytype"].ToString());




            }

        }
        protected void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void BtnRechercher_Click(object sender, EventArgs e)
        {
            string bodytype = cboType.SelectedItem.Text;
            string ethnie = cboEthnie.SelectedItem.Text;
            string religion = cboReligion.SelectedItem.Text;
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cfabi\\Desktop\\2022\\Automne\\prjFriendBook\\prjFriendBook\\App_Data\\FriendBook.accdb;Persist Security Info=True";
            mycon.Open();

            string req = "SELECT *  FROM Membres WHERE Ethnie = '" + ethnie + "' AND Religion ='" + religion + "' AND Bodytype ='" + bodytype + "'";
            SqlCommand mycmd = new SqlCommand(req, mycon);
            SqlDataReader myreader = mycmd.ExecuteReader();


            while (myreader.Read())
            {
                Int32 refM = Convert.ToInt32(myreader["RefMembre"].ToString());
                TableRow uneLigne = new TableRow();
                TableCell uneCell = new TableCell();
                uneCell.Text = myreader["Pseudo"].ToString();
                uneLigne.Cells.Add(uneCell);
                uneCell = new TableCell();
                uneCell.Text = myreader["Genre"].ToString();
                uneLigne.Cells.Add(uneCell);
                uneCell = new TableCell();
                uneCell.Text = " <a href = 'Details.aspx?refm='" + refM + "'>Details</a>";
                uneLigne.Cells.Add(uneCell);
                TabMembres.Rows.Add(uneLigne);
                TabMembres.Visible = true;
                Session["selectuserID"] = myreader["RefMembre"];
            }





            mycon.Close();




        }

        protected void cboRecherche_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}