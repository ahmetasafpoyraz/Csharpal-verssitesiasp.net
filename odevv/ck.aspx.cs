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
    public partial class ck : System.Web.UI.Page
    {
        OleDbCommand cmd;
        OleDbConnection con;
        DataSet ds = new DataSet();
        OleDbDataAdapter adp;
        public StringBuilder tablo2 = new StringBuilder();
        private int id = 0;
        private void dznlegtr()
        {
            object uye = Session["duyuru"];
            if (uye != null)
            {

                tbbaslik.Text = tbicerik.Text = "";
                cbyayinlansin.Checked = false;
                btndznl.Visible = true;
                bbtn.Visible = false;
                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                lbl4.Visible = true;
                tbbaslik.Visible = true;
                tbicerik.Visible = true;
                cbyayinlansin.Visible = true;
                bittar.Visible = true;
                bastar.Visible = true;

                id = int.Parse(uye.ToString());
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                cmd = new OleDbCommand("SELECT * FROM duyuru where id=" + id + " ", con);
                con.Open();
                OleDbDataReader ole = cmd.ExecuteReader();
                while (ole.Read())
                {
                    tbbaslik.Text = ole.GetValue(1).ToString();
                    tbicerik.Text = ole.GetValue(2).ToString();
                    bastar.SelectedDate = DateTime.Parse(ole.GetValue(3).ToString());
                    bittar.SelectedDate = DateTime.Parse(ole.GetValue(4).ToString());

                    if (ole.GetValue(5).ToString() == "Evet")
                    {
                        cbyayinlansin.Checked = true;
                    }
                    else
                    {
                        cbyayinlansin.Checked = false;
                    }
                   

                }
                con.Close();
                btndznl.Visible = true;
            }
        }

        private void tablodoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            adp = new OleDbDataAdapter("SELECT * FROM duyuru", con);
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM duyuru ", con);
            ds.Clear();
            adp.Fill(ds, "du");
            tablo2.Clear();
            foreach (DataRow d in ds.Tables["du"].Rows)
            {

                tablo2.Append("<tr>");
                tablo2.Append("<td>" + d["baslik"] + "</td>");
                tablo2.Append("<td>" + d["duyuruicerik"] + "</td>");
                tablo2.Append("<td>" + d["duyurubastar"] + "</td>");
                tablo2.Append("<td>" + d["duyurubittar"] + "</td>");
                tablo2.Append("<td>" + d["yayindrm"] + "</td>");
                tablo2.Append("<td><a href='idczc.aspx?duyuru=" + d["id"] + "'>Düzenle</a></td>");
                tablo2.Append("<td><a onclick='return condel()' href='sil.aspx?duyuru=" + d["id"] + "'>Sil</a></td>");
                tablo2.Append("</tr>");

            }

            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["yenimi"] = "false";
                btndznl.Visible = false;
                bbtn.Visible = true;
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                lbl4.Visible = false;
                tbbaslik.Visible = false;
                tbicerik.Visible = false;
                cbyayinlansin.Visible = false;
                bittar.Visible = false;
                bastar.Visible = false;
                if (Session["duyuru"]!= null)
                {
                    dznlegtr();
                }
            }
           


            tablodoldur();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["yenimi"] = "true";
            btnkyt.Visible = true;
            tbbaslik.Text = tbicerik.Text = "";
            cbyayinlansin.Checked = false;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            tbbaslik.Visible = true;
            tbicerik.Visible = true;
            cbyayinlansin.Visible = true;
            bittar.Visible = true;
            bastar.Visible = true;
            bbtn.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            con.Open();
            cmd = new OleDbCommand("insert into duyuru(baslik,duyuruicerik,duyurubastar,duyurubittar,yayindrm)Values(@baslik,@duyuruicerik,@duyurubastar,@duyurubittar,@yayindrm)", con);
            if (Session["yenimi"].ToString() == "true")
            {

                cmd.Parameters.AddWithValue("@baslik", tbbaslik.Text);
                cmd.Parameters.AddWithValue("@duyuruicerik", tbicerik.Text);
                cmd.Parameters.AddWithValue("@duyurubastar", bastar.SelectedDate.ToString());
                cmd.Parameters.AddWithValue("@duyurubittar", bittar.SelectedDate.ToString());
                if (cbyayinlansin.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@yayindrm", "Evet");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@yayindrm", "Hayıt");
                }

                cmd.ExecuteNonQuery();
                con.Close();
                tablodoldur();
                tbbaslik.Text = tbicerik.Text = "";
                cbyayinlansin.Checked = false;
                Session["yenimi"] = "false";

            }

            btndznl.Visible = false;
            bbtn.Visible = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            tbbaslik.Visible = false;
            tbicerik.Visible = false;
            cbyayinlansin.Visible = false;
            bittar.Visible = false;
            bastar.Visible = false;
            btnkyt.Visible = false;
           


        }

        protected void btndznl_Click(object sender, EventArgs e)
        {
            dznl();
        }

        void dznl()
        {
            object uye = Session["duyuru"];
            id = int.Parse(uye.ToString());
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));

            con.Open();
            cmd = new OleDbCommand("UPDATE duyuru SET baslik=@1,duyuruicerik=@2,duyurubastar=@3,duyurubittar=@4,yayindrm=@5 WHERE id=" + id + "", con);
            cmd.Parameters.AddWithValue("@1", tbbaslik.Text);
            cmd.Parameters.AddWithValue("@2", tbicerik.Text);
            cmd.Parameters.AddWithValue("@3", bastar.SelectedDate.ToString());
            cmd.Parameters.AddWithValue("@4", bittar.SelectedDate.ToString());


            if (cbyayinlansin.Checked == true)
            {
                cmd.Parameters.AddWithValue("@5", "Evet");
            }
            else
            {
                cmd.Parameters.AddWithValue("@5", "Hayıt");
            }


            cmd.ExecuteNonQuery();
            con.Close();

            tablodoldur();


            btndznl.Visible = false;
            bbtn.Visible = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            tbbaslik.Visible = false;
            tbicerik.Visible = false;
            cbyayinlansin.Visible = false;
            bittar.Visible = false;
            bastar.Visible = false;
        }
    }
}