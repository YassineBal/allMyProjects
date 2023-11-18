using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class EcrireMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Int32 refsm = Convert.ToInt32(Session["selectuserID"]);
                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
                mycon.Open();
                string sql = "SELECT RefMembre,Pseudo FROM Membres WHERE RefMembre =" + refsm;
                SqlCommand mycmd = new SqlCommand(sql, mycon);
                SqlDataReader myreader = mycmd.ExecuteReader();
                while (myreader.Read())
                {
                    string tmp = myreader["Pseudo"].ToString();
                    ListItem elm = new ListItem();
                    elm.Text = tmp;
                    elm.Value = myreader["RefMembre"].ToString();
                    cboDestinataires.Items.Add(elm);
                }
                myreader.Close();
                mycon.Close();
                LblErreur.Visible = false;
            }
        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {

        }

        protected void btnEffacer_Click(object sender, EventArgs e)
        {
            LblErreur.Text = TxtMessage.Text = "";
            TxtMessage.Focus();
        }

        protected void btnEnvoyer_Click1(object sender, EventArgs e)
        {
            Int32 refEnv = Convert.ToInt32(Session["userID"]);
            Int32 refDest = Convert.ToInt32(cboDestinataires.SelectedItem.Value);
            string mess = TxtMessage.Text.Trim();
            if (mess.Length == 0)
            {
                LblErreur.Visible = true;
                LblErreur.Text = " Veuillez ecrire un message ";
                TxtMessage.Focus();
            }
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cfabi\\Desktop\\2022\\Automne\\prjFriendBook\\prjFriendBook\\App_Data\\FriendBook.accdb;Persist Security Info=True";
            mycon.Open();
            string sql = "INSERT INTO Messages(Message,Envoyeur,Receveur) " + "VALUES(@parmess,@parrefEnv,@parrefDest)";
            SqlCommand mycmd = new SqlCommand(sql, mycon);
            mycmd.Parameters.AddWithValue("parmess", mess);
            mycmd.Parameters.AddWithValue("parrefEnv", refEnv);
            mycmd.Parameters.AddWithValue("parrefDest", refDest);
            mycmd.ExecuteNonQuery();
            mycon.Close();

            Server.Transfer("Messagerie.aspx");

        }
    }
}