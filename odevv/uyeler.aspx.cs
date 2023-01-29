using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace odevv
{
    public partial class uyeler : System.Web.UI.Page
    {

        OleDbConnection con;
        DataSet ds = new DataSet();
        OleDbDataAdapter adp;
        public StringBuilder tablo = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {


            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            string search = Request.QueryString["s"], sorgu = "SELECT * FROM musteribilgileri ";
            if (search != null)
            {
                sorgu += " WHERE email LIKE '%" + search + "%'";
            }
            adp = new OleDbDataAdapter(sorgu, con);


            tablo.Clear();
            ds.Clear();
            adp.Fill(ds, "ur");
            foreach (DataRow d in ds.Tables["ur"].Rows)
            {
                tablo.Append("<tr>");
                tablo.Append("<td>" + d["adi"] + "</td>");
                tablo.Append("<td>" + d["sadi"] + "</td>");
                tablo.Append("<td>" + d["telno"] + "</td>");
                tablo.Append("<td>" + d["email"] + "</td>");
                tablo.Append("<td>" + d["il"] + "</td>");
                tablo.Append("<td>" + d["ilce"] + "</td>");
                tablo.Append("<td>" + d["ackadres"] + "</td>");
                tablo.Append("<td>" + d["yetki"] + "</td>");
                tablo.Append("<td><a href='duzenle.aspx?musteri=" + d["id"] + "'>Düzenle</a></td>");
                tablo.Append("<td><a onclick='return condel()' href='sil.aspx?musteri=" + d["id"] + "'>Sil</a></td>");
                tablo.Append("</tr>");


            }
           













            //con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            //adp = new OleDbDataAdapter("SELECT * FROM musteribilgileri", con);
            //adp.Fill(ds, "mb");
            //foreach (DataRow d in ds.Tables["mb"].Rows)
            //{
            //    tablo.Append("<tr>");
            //    tablo.Append("<td>" + d["adi"] + "</td>");
            //    tablo.Append("<td>" + d["sadi"] + "</td>");
            //    tablo.Append("<td>" + d["telno"] + "</td>");
            //    tablo.Append("<td>" + d["il"] + "</td>");
            //    tablo.Append("<td>" + d["ilce"] + "</td>");
            //    tablo.Append("<td>" + d["ackadres"] + "</td>");
            //    tablo.Append("<td>" + d["yetki"] + "</td>");
            //    tablo.Append("<td><a href='duzenle.aspx?musteri=" + d["id"] + "'>Düzenle</a></td>");
            //    tablo.Append("<td><a onclick='return condel()' href='sil.aspx?musteri=" + d["id"] + "'>Sil</a></td>");
            //    tablo.Append("</tr>");
            //}

        }
    }
}