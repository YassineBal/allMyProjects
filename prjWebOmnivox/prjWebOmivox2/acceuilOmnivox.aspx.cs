using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace prjWebCsAdoNet
{
    public partial class acceuilOmnivox : System.Web.UI.Page
    {
        //variable global a la page
        static Int32 refM;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                refM = Convert.ToInt32(Session["userId"]);
                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDBh;Integrated Security=True");
                mycon.Open();
                string sql = "SELECT RefMembre,Nom FROM Membres WHERE RefMembre =" + refM;
                SqlCommand mycmd = new SqlCommand(sql, mycon);
                SqlDataReader myrder = mycmd.ExecuteReader();
                if (myrder.Read())
                {
                    lblMessage.Text = "Bienvenue " + myrder["Nom"].ToString();
                }
                myrder.Close();

                //recuperation des messages recus par Memmbre courant
                sql = "SELECT Messages.RefMessage,Messages.Titre,Membres.Nom,Messages.Nouveau FROM Messages, Membres WHERE Membres.RefMembre = Messages.Envoyeur AND Receveur = " + refM;
                SqlCommand mycmd2 = new SqlCommand(sql, mycon);
                SqlDataReader rdrMsg = mycmd2.ExecuteReader();
                Int16 nbMsg = 0;
                while (rdrMsg.Read() == true)
                {
                    nbMsg++;
                    Int32 refMsg = Convert.ToInt32(rdrMsg["RefMessage"].ToString());
                    //creation dynamique du tableau
                    TableRow uneLigne = new TableRow();
                    TableCell uneCell = new TableCell();
                    uneCell.Text = rdrMsg["Titre"].ToString();
                    uneLigne.Cells.Add(uneCell);
                    uneCell = new TableCell();
                    uneCell.Text = rdrMsg["Nom"].ToString();
                    uneLigne.Cells.Add(uneCell);
                    uneCell = new TableCell();
                    uneCell.Text = "<a href='lireMessage.aspx?refM=" + refMsg + "' >Lire</a>  <a href='effacerMessage.aspx?refM=" + refMsg + "' >Effacer</a>";
                    uneLigne.Cells.Add(uneCell);
                    //verifier si le message est nouveau et changer la couleur de la ligne par consequence
                    if (rdrMsg["Nouveau"].ToString() == "True")
                    {
                        uneLigne.BackColor = System.Drawing.Color.Yellow;
                    }
                    tabMessages.Rows.Add(uneLigne);

                }
                rdrMsg.Close();
                lblMessage.Text += "<br />Vous avez " + nbMsg + " Messages";
                mycon.Close();
            }

        }

        protected void btnRediger_Click(object sender, EventArgs e)
        {
            Server.Transfer("ecrireMessage.aspx");
        }
    }
}