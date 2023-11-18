using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class LireMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 refMSg = Convert.ToInt32(Request.QueryString["refm"].ToString());
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
            mycon.Open();
            string sql = "SELECT  Messages.*, Membres.Nom From Messages, Membres where  Membres.RefMembre = Messages.Envoyeur AND Messages.RefMessage " + refMSg;
            SqlCommand mycmd = new SqlCommand(sql, mycon);
            SqlDataReader myrder = mycmd.ExecuteReader();
            if (myrder.Read())
            {


                string info = "De :" + myrder["Nom"].ToString() + "<br />";
                info += "Message  :" + myrder["Message"].ToString() + "<br />";
                LblMessage.Text = info;


            }
            myrder.Close();
            mycon.Close();
        }
    }
}