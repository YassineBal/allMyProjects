using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class Messagerie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                Int32 refm = Convert.ToInt32(Session["userID"]);
                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
                mycon.Open();

                string sql = "SELECT RefMembre,Nom from Membres where RefMembre =" + refm;
                SqlCommand mycmd = new SqlCommand(sql, mycon);
                SqlDataReader myrder = mycmd.ExecuteReader();
                if (myrder.Read())
                {
                    lblMessage.Text = "Bienvenue " + myrder["Nom"].ToString();
                }
                myrder.Close();
                sql = "SELECT Messages.RefMessage,Membres.Nom from Messages, Membres where Membres.RefMembre = Messages.Envoyeur AND Receveur = " + refm;
                SqlCommand mycmd2 = new SqlCommand(sql, mycon);
                SqlDataReader rdrMsg = mycmd2.ExecuteReader();
                Int16 nbMsg = 0;
                while (rdrMsg.Read())

                {
                    nbMsg++;
                    Int32 refMsg = Convert.ToInt32(rdrMsg["RefMessage"].ToString());

                    TableRow uneLigne = new TableRow();
                    TableCell uneCell = new TableCell();
                    uneCell = new TableCell();
                    uneCell.Text = rdrMsg["Nom"].ToString();
                    uneLigne.Cells.Add(uneCell);
                    uneCell = new TableCell();
                    uneCell.Text = "<a href='LireMessage.aspx?refm='" + refMsg + "'>Lire</a>  <a href='SupprimerMessage.aspx?refm='" + refMsg + "'> Effacer</a> ";
                    uneLigne.Cells.Add(uneCell);


                    TableEtudiants.Rows.Add(uneLigne);

                }
                rdrMsg.Close();
            }
        }

        protected void btnRediger_Click(object sender, EventArgs e)
        {
            Server.Transfer("EcrireMessage.aspx");
        }
    }
}