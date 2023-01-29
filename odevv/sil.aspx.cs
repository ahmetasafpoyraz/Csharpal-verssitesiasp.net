using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace odevv
{
    public partial class sil : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        private int id = 0, id2 = 0, id3 = 0, id4 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["musteri"]!=null)
            {
                id = int.Parse(Request.QueryString["musteri"].ToString());

                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                con.Open();
                cmd = new OleDbCommand("DELETE  FROM musteribilgileri where id=" + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("uyeler.aspx");
            }
            
            else if (Request.QueryString["duyuru"]!=null)
            {
                id2 = int.Parse(Request.QueryString["duyuru"]);
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                con.Open();
                cmd = new OleDbCommand("DELETE  FROM duyuru where id=" + id2 + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("ck.aspx");
            }

            else if (Request.QueryString["urun"] != null)
            {
                id3 = int.Parse(Request.QueryString["urun"]);
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                con.Open();
                cmd = new OleDbCommand("DELETE  FROM urun where id=" + id3 + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("urunler.aspx");
            }
            else if (Request.QueryString["spt"] != null)
            {
                id4 = int.Parse(Request.QueryString["spt"]);
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                con.Open();
                cmd = new OleDbCommand("DELETE  FROM sepet where id=" + id4 + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("sepet.aspx");
            }
        }
    }
}