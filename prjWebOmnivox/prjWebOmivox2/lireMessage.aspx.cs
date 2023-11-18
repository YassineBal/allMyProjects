using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace prjWebCsAdoNet
{
    public partial class lireMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblMessage.Text = Request.QueryString["idMsg"];


            if (IsPostBack == false)
            {
                Int32 refMsg = Convert.ToInt32(Request.QueryString["idMsg"].ToString());  //une autre methode de recuperation de donnes au lieu de variable de session 

                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDBh;Integrated Security=True";
                mycon.Open();
                string sql = "SELECT * FROM Messages WHERE RefMessage =" + refMsg;


                SqlCommand mycmd = new SqlCommand(sql, mycon);
                SqlDataReader myrder = mycmd.ExecuteReader();
                if (myrder.Read())
                {
                    lblTitre.Text = myrder["Titre"].ToString();
                    lblDate.Text = myrder["DateCreation"].ToString();
                    // info += "De : " + myrder["Nom"].ToString() + " <br />";
                    lblMessage.Text = myrder["Message"].ToString();

                }
                myrder.Close();

                sql = "UPDATE Messages SET (Nouveau='False') WHERE RefMessage =" + refMsg;
                SqlCommand cmd = new SqlCommand(sql, mycon);
                cmd.ExecuteNonQuery();

                mycon.Close();

            }




        }
    }
}