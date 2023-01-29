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
    public partial class urundurumu : System.Web.UI.Page
    {
        public string bslk;
        OleDbConnection con;
        DataSet ds = new DataSet();
        OleDbDataAdapter adp;
        public StringBuilder tablodrm = new StringBuilder();
        private void tablodldr()
        {

            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            string drm = Request.QueryString["drm"];

            string search = Request.QueryString["s"];
            string sorgu = "SELECT * FROM siparisdrm ";
            if (search != null && drm != null)
            {
                sorgu += " WHERE id LIKE '%" + search + "%' and sipdurum LIKE '%" + drm + "%'";
            }
            else if (search != null)
            {
                sorgu += " WHERE id LIKE '%" + search + "%'";
               
            }
            else if (drm != null)
            {
                sorgu += " WHERE sipdurum LIKE '%" + drm + "%'";
            }
            if (drm == "yolda")
            {
                bslk = "KARGOLANAN";
                pktl.Visible = false;
                pktll.Visible = false;
                krg.Visible = false;
                tmml.Visible = true;
            }
            else if (drm == "tamamlandı")
            {
                bslk = "TAMAMLANAN";
                pktl.Visible = false;
                pktll.Visible = false;
                krg.Visible = false;
                lb.Visible = false;
                bl.Visible = false;
                bl1.Visible = false;
                bl2.Visible = false;
                bl3.Visible = false;
                bl4.Visible = false;
                L1.Visible = false;
                L2.Visible = false;
                L3.Visible = false;
                L4.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                tmml.Visible = false;
            }
            else if (drm == "hazırlanıyor")
            {
                bslk = "HAZIRLANAN";
                pktl.Visible = false;
                pktll.Visible = true;
                krg.Visible = false;
                tmml.Visible = false;
            }
            else if (drm == "paketlendi")
            {
                bslk = "PAKETLENEN";
                pktl.Visible = false;
                pktll.Visible = false;
                krg.Visible = true;
                tmml.Visible = false;
            }
            else if (drm == "yeni")
            {
                bslk = "YENİ";
                pktl.Visible = true;
                pktll.Visible = false;
                krg.Visible = false;
                tmml.Visible = false;
            }
            adp = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            adp.Fill(ds, "ur");
            foreach (DataRow d in ds.Tables["ur"].Rows)
            {
                tablodrm.Append("<tr>");
                tablodrm.Append("<td>" + d["id"] + "</td>");
                tablodrm.Append("<td>" + d["musteriid"] + "</td>");
                tablodrm.Append("<td>" + d["sepetid"] + "</td>");
                tablodrm.Append("<td>" + d["sipadrs"] + "</td>");
                tablodrm.Append("<td>" + d["siptar"] + "</td>");
                tablodrm.Append("<td>" + d["sipdurum"] + "</td>");
                tablodrm.Append("<td><a href='SİPARİSdurumu.aspx?drm=" + d["sipdurum"] + "&id=" + d["id"] + " ' >Güncelle</a></td>");
                tablodrm.Append("</tr>");
            }
        }

        private void bilgiler()
        {
            int id = 0;
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                string sorgu = "select * from siparisdrm where id=" + id + "";

                OleDbCommand cmd = new OleDbCommand(sorgu, con);
                con.Open();
                OleDbDataReader ko = cmd.ExecuteReader();
                while (ko.Read())
                {
                    lb.Text = ko.GetValue(0).ToString();
                    L1.Text = ko.GetValue(1).ToString();
                    L2.Text = ko.GetValue(2).ToString();
                    Label2.Text = ko.GetValue(3).ToString();
                    L3.Text = ko.GetValue(4).ToString();
                    L4.Text = ko.GetValue(5).ToString();

                }
                con.Close();
            }



        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["drm"] == null)
            {
                Response.Redirect("admin.aspx");
            }
            if (!IsPostBack)
            {
                tablodldr();
            }

            bilgiler();

            // SELECT ilan.*, musteri.* FROM ilan,musteri WHERE (ilan.musteriid = musteri.id) -> 1. yol
            // 2. yol Class ile yapıldığında etkili ve kafa karıştırmaz
            // SELECT * FROM ilan
            // SELECT * FROM musteri WHERE id=@id  id-> ilan tablosundan seçilen kişinin musteriid sütunu
            // Burdan gelen verinin sütunları kontrol edilerek diğer tablodaki tüm veri seçilebilir

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            int id = 0;
          con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
                OleDbCommand cmd = new OleDbCommand("UPDATE siparisdrm SET sipdurum=@1  where id=" + id + "",con);
                cmd.Parameters.AddWithValue("@1", "hazırlanıyor");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            tablodldr();
        }

        protected void pktll_Click(object sender, EventArgs e)
        {
            int id = 0;
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
                OleDbCommand cmd = new OleDbCommand("UPDATE siparisdrm SET sipdurum=@1  where id=" + id + "", con);
                cmd.Parameters.AddWithValue("@1", "paketlendi");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            tablodldr();
        }

        protected void krg_Click(object sender, EventArgs e)
        {
            int id = 0;
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
                OleDbCommand cmd = new OleDbCommand("UPDATE siparisdrm SET sipdurum=@1  where id=" + id + "", con);
                cmd.Parameters.AddWithValue("@1", "yolda");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            tablodldr();
        }

        protected void tmml_Click(object sender, EventArgs e)
        {
            int id = 0;
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
                OleDbCommand cmd = new OleDbCommand("UPDATE siparisdrm SET sipdurum=@1  where id=" + id + "", con);
                cmd.Parameters.AddWithValue("@1", "tamamlandı");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            tablodldr();
        }
    }
}