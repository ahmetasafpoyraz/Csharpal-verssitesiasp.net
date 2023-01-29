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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngrs_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));

            string sorgu = "select * from musteribilgileri where email=@email and sifre=@sifre";

            OleDbCommand cmd = new OleDbCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@email", tbmail.Text);
            cmd.Parameters.AddWithValue("@sifre", tbsf.Text);
            con.Open();
            OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if (rdr["yetki"].ToString() == "admin")
                {
                    Session.Add("adi", rdr["adi"].ToString() + " " + rdr["sadi"].ToString());
                    Session.Add("admin", 1);
                    Session.Add("id", rdr["id"].ToString());
                }
                else
                {
                    Session.Add("adi", rdr["adi"].ToString() + " " + rdr["sadi"].ToString());
                    Session.Add("id", rdr["id"].ToString());
                }

                Response.Redirect("products.aspx");
            }
            else
            {
                Response.Write("<script>alert('MAİL ADRESİ VEYA ŞİFRE HATALI');</script>");
            }

            con.Close();

        }
    }
}