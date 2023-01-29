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

    public partial class urunler : System.Web.UI.Page
    {
        OleDbConnection con;
        DataSet ds = new DataSet();
        OleDbDataAdapter adp;
        OleDbCommand cmd;
        public StringBuilder tablo1 = new StringBuilder();
        private int id = 0;
        public string a = "";

        private void drpdvn()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            adp = new OleDbDataAdapter("SELECT * FROM kategori", con);

            DataSet ds2 = new DataSet();
            ds2.Clear();
            adp.Fill(ds2, "drp");
            tbkat.DataSource = ds2.Tables[0];
            tbkat.DataTextField = "adi";
            tbkat.DataValueField = "id";
            tbkat.DataBind();
            drpkt.DataSource = ds2.Tables[0];
            drpkt.DataTextField = "adi";
            drpkt.DataValueField = "id";
            drpkt.DataBind();

        }


        private void doldur()
        {
            if (Session["urun"] != null)
            {

                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                lbl4.Visible = true;
                lbl5.Visible = true;
                lbl6.Visible = true;
                tbaciklama.Visible = true;
                tbadi.Visible = true;
                tbalis.Visible = true;
                tbkat.Visible = true;
                tbmik.Visible = true;
                tbsat.Visible = true;
                btnyni.Visible = false;
                btnkytt.Visible = false;
                btndznl.Visible = true;
                flup.Visible = true;
                lbl.Visible = true;
                btnynktgr.Visible = false;
                drpdvnst.Visible = true;
                llbb.Visible = true;
                object urun = Session["urun"].ToString();
                id = int.Parse(urun.ToString());
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                cmd = new OleDbCommand("SELECT * FROM urun where id=" + id + " ", con);
                con.Open();
                OleDbDataReader ole = cmd.ExecuteReader();
                while (ole.Read())
                {
                    tbadi.Text = ole.GetValue(1).ToString();
                    tbaciklama.Text = ole.GetValue(2).ToString();
                    tbmik.Text = ole.GetValue(3).ToString();
                    tbalis.Text = ole.GetValue(4).ToString();
                    tbsat.Text = ole.GetValue(5).ToString();
                    tbkat.SelectedValue = ole.GetValue(6).ToString();
                    a = ole.GetValue(7).ToString();
                    drpdvnst.SelectedValue = ole.GetValue(8).ToString();

                }
                con.Close();
            }
        }

        private void tablogtr()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            string search = Request.QueryString["s"], sorgu = "SELECT * FROM urun";
            if (search != null)
            {
                sorgu += " WHERE adi LIKE '%" + search + "%'";
            }
            adp = new OleDbDataAdapter(sorgu, con);


            tablo1.Clear();
            ds.Clear();
            adp.Fill(ds, "ur");
            foreach (DataRow d in ds.Tables["ur"].Rows)
            {
                tablo1.Append("<tr>");
                tablo1.Append("<td>" + d["adi"] + "</td>");
                tablo1.Append("<td>" + d["aciklama"] + "</td>");
                tablo1.Append("<td>" + d["miktar"] + "</td>");
                tablo1.Append("<td>" + d["alisfiyati"] + "</td>");
                tablo1.Append("<td>" + d["satisfiyati"] + "</td>");
                tablo1.Append("<td><a href='idczc.aspx?urun=" + d["id"] + "'>Düzenle</a></td>");
                tablo1.Append("<td><a onclick='return condel()' href='sil.aspx?urun=" + d["id"] + "'>Sil</a></td>");
                tablo1.Append("</tr>");


            }
        }

        public void CleartextBoxes(Control parent)
        {

            foreach (Control x in parent.Controls)
            {
                if ((x.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(x)).Text = "";
                }

                if (x.HasControls())
                {
                    CleartextBoxes(x);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["yenimii"] = "false";
                btndznl.Visible = false;
                btnyni.Visible = true;
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                lbl4.Visible = false;
                lbl5.Visible = false;
                lbl6.Visible = false;
                tbaciklama.Visible = false;
                tbadi.Visible = false;
                tbalis.Visible = false;
                tbkat.Visible = false;
                tbmik.Visible = false;
                tbsat.Visible = false;
                btnkytt.Visible = false;
                flup.Visible = false;
                lbl.Visible = false;
                btnkategri.Visible = false;
                tbkategri.Visible = false;
                drpdvnst.Visible = false;
                llbb.Visible = false;
              
                if (Session["urun"] != null)
                {
                    doldur();
                }
                drpdvn();
            }


            tablogtr();
        }

        protected void btnkytt_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            cmd = new OleDbCommand("insert into urun (adi,aciklama,miktar,alisfiyati,satisfiyati,kategorid,rsm,satisturu)Values(@adi,@aciklama,@miktar,@alisfiyati,@satisfiyati,@kategori,@rsm,@satisturu)", con);
            if (Session["yenimii"].ToString() == "true")
            {
                cmd.Parameters.AddWithValue("@adi", tbadi.Text);
                cmd.Parameters.AddWithValue("@aciklama", tbaciklama.Text);
                cmd.Parameters.AddWithValue("@miktar", tbmik.Text);
                cmd.Parameters.AddWithValue("@alisfiyati", tbalis.Text);
                cmd.Parameters.AddWithValue("@satisfiyati", tbsat.Text);
                cmd.Parameters.AddWithValue("@kategorid", tbkat.Text);
                cmd.Parameters.AddWithValue("@rsm", flup.FileName);
                cmd.Parameters.AddWithValue("@satisturu",drpdvnst.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                string img = Server.MapPath("/images/");
                flup.SaveAs(img + flup.FileName);
                tablogtr();
            }
            CleartextBoxes(this);
            btndznl.Visible = false;
            btnyni.Visible = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            tbaciklama.Visible = false;
            tbadi.Visible = false;
            tbalis.Visible = false;
            tbkat.Visible = false;
            tbmik.Visible = false;
            tbsat.Visible = false;
            btnkytt.Visible = false;
            flup.Visible = false;
            lbl.Visible = false;
            drpdvnst.Visible = false;
            llbb.Visible = false;
            btnynktgr.Visible = true;
        }

        protected void btnyni_Click(object sender, EventArgs e)
        {
            Session["yenimii"] = "true";
            lbl.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = true;
            tbaciklama.Visible = true;
            tbadi.Visible = true;
            tbalis.Visible = true;
            tbkat.Visible = true;
            tbmik.Visible = true;
            tbsat.Visible = true;
            btnyni.Visible = false;
            btnkytt.Visible = true;
            btnynktgr.Visible = false;
            flup.Visible = true;
            drpdvnst.Visible = true;
            llbb.Visible = true;
        }

        protected void btndznl_Click(object sender, EventArgs e)
        {
            int idd = 0;
            object urun = Session["urun"];
            idd = int.Parse(urun.ToString());

            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            cmd = new OleDbCommand("update urun set adi=@adi,aciklama=@aciklama,miktar=@miktar,alisfiyati=@alisfiyati,satisfiyati=@satisfiyati,kategorid=@kategori,rsm=@rsm,satisturu=@satisturu where id=" + idd + " ", con);


            cmd.Parameters.AddWithValue("@adi", tbadi.Text);
            cmd.Parameters.AddWithValue("@aciklama", tbaciklama.Text);
            cmd.Parameters.AddWithValue("@miktar", tbmik.Text);
            cmd.Parameters.AddWithValue("@alisfiyati", tbalis.Text);
            cmd.Parameters.AddWithValue("@satisfiyati", tbsat.Text);
            cmd.Parameters.AddWithValue("@kategorid", tbkat.Text);
            cmd.Parameters.AddWithValue("@rsm", flup.FileName);
            cmd.Parameters.AddWithValue("@satisturu", drpdvnst.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            if (flup.HasFile)
            {
                 string img = Server.MapPath("/images/");
            flup.SaveAs(img + flup.FileName);
            tablogtr();
            }
           
            /* resim sorgusunu unutmaaa
             sor değişmek istermisiniz
             */
            CleartextBoxes(this);
            btndznl.Visible = false;
            btnyni.Visible = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            tbaciklama.Visible = false;
            tbadi.Visible = false;
            tbalis.Visible = false;
            tbkat.Visible = false;
            tbmik.Visible = false;
            tbsat.Visible = false;
            btnkytt.Visible = false;
            flup.Visible = false;
            lbl.Visible = false;
            drpdvnst.Visible = false;
            llbb.Visible = false;
            btnynktgr.Visible = true;
        }

        protected void btnynktgr_Click(object sender, EventArgs e)
        {
            Session["yenimii"] = "true";
            btnkategri.Visible = true;
            tbkategri.Visible = true;
            btnynktgr.Visible = false;
            btnyni.Visible = false;
        }

        protected void btnkategri_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("insert into kategori (adi)Values(@adi)", con);
            if (Session["yenimii"].ToString() == "true")
            {
                cmd.Parameters.AddWithValue("@adi", tbkategri.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                drpdvn();
            }
            btnkategri.Visible = false;
            tbkategri.Visible = false;
            btnynktgr.Visible = true;
            btnyni.Visible = true;
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("DELETE  FROM kategori where id=" + drpkt.Text + "", con);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('KATEGORİ SİLİNDİ');</script>");
            con.Close();
            drpdvn();
        }




    }
}