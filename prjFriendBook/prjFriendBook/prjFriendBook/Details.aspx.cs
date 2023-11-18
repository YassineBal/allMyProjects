using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Int32 refMSg = Convert.ToInt32(Request.QueryString["refm"].ToString());
            Int32 refsm = Convert.ToInt32(Session["selectuserID"]);
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
            mycon.Open();

            string req = "SELECT * FROM Membres ";
            req += "WHERE RefMembre =" + refsm;
            SqlCommand mycmd = new SqlCommand(req, mycon);
            SqlDataReader myreader = mycmd.ExecuteReader();
            if (myreader.Read())
            {
                LblDetails.Text = "Pseudo : " + myreader["Pseudo"].ToString() + "<br />";
                LblDetails.Text += "Annee de Naissance : " + myreader["AnneeN"].ToString() + "<br />";
                LblDetails.Text += "Bodytype : " + myreader["Bodytype"].ToString() + "<br />";
                LblDetails.Text += "Religion : " + myreader["religion"].ToString() + "<br />";
                LblDetails.Text += "Ethnie : " + myreader["Ethnie"].ToString() + "<br />";

                LblDetails.Text += " Description : " + myreader["Description"].ToString() + "<br />";

            }
        }

        protected void BtnContacter_Click(object sender, EventArgs e)
        {
            Server.Transfer("EcrireMessage.aspx");
        }
    }
}