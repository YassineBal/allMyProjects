using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFriendBook
{
    public partial class SupprimerMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 refMsg = Convert.ToInt32(Request.QueryString["refm"].ToString());
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendBook;Integrated Security=True";
                mycon.Open();
            string req = "DELETE FROM Messages WHERE Messages.refMessage=" + refMsg;
            SqlCommand mycmd = new SqlCommand(req, mycon);
            mycmd.ExecuteNonQuery();
            mycon.Close();
            Server.Transfer("Messagerie.aspx");
        }
    }
}