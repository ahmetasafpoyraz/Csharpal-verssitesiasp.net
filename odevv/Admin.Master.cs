using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace odevv
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public string user;
        public int j = 0;
        OleDbConnection con;
        DataSet ds = new DataSet();
        OleDbDataAdapter adp;
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("login.aspx");
            }
            object uye = Session["adi"];
            if (uye != null)
            {
                user = uye.ToString();
            }

            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            OleDbCommand cmd1 = new OleDbCommand("SELECT * FROM siparisdrm ", con);
            adp = new OleDbDataAdapter("SELECT * FROM siparisdrm", con);
            OleDbDataReader rdr = cmd1.ExecuteReader();
            adp.Fill(ds, "drm");
            while (rdr.Read())
            {
                foreach (DataRow d in ds.Tables["drm"].Rows)
                {


                    if (rdr["sipdurum"].ToString() == "yeni")
                    {
                        j++;
                        break;
                    }
                }
               
            }
            con.Close();
        }
    }
}