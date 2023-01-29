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
    public partial class hasabim : System.Web.UI.Page
    {
        private void doldur()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));

            string sorgu = "select * from musteribilgileri where id=" + Session["id"] + "";

            OleDbCommand cmd = new OleDbCommand(sorgu, con);
            con.Open();
            OleDbDataReader ko = cmd.ExecuteReader();
            while (ko.Read())
            {
                tbadi.Text = ko.GetValue(1).ToString();
                tbsadi.Text = ko.GetValue(2).ToString();
                tbdt.Text = ko.GetValue(3).ToString();
                drpdvn.Text = ko.GetValue(4).ToString();
                tbmail.Text = ko.GetValue(5).ToString();
                tbsifre.Text = ko.GetValue(6).ToString();
                tbcep.Text = ko.GetValue(7).ToString();
                tbil.Text = ko.GetValue(8).ToString();
                tbilce.Text = ko.GetValue(9).ToString();
                tbpk.Text = ko.GetValue(10).ToString();
                tbadres.Text = ko.GetValue(11).ToString();
                tbsifretk.Text = ko.GetValue(6).ToString();
            }
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adi"]==null)
            {
                Response.Redirect("product.aspx");
            }
            tbadi.Enabled = false;
            tbadres.Enabled = false;
            tbcep.Enabled = false;
            tbdt.Enabled = false;
            tbil.Enabled = false;
            tbilce.Enabled = false;
            tbmail.Enabled = false;
            tbpk.Enabled = false;
            tbsadi.Enabled = false;
            tbsifre.Enabled = false;
            drpdvn.Enabled = false;
            btnkyt.Visible = false;
            tbsifretk.Enabled = false;

            if (!IsPostBack)
            {
                doldur();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (tbadi.Text != "" && tbsadi.Text != "" && tbadres.Text != "" && tbdt.Text != "" && drpdvn.Text != "" && tbmail.Text != "" && tbsifre.Text != "" && tbcep.Text != "" && tbil.Text != "" && tbilce.Text != "" && tbpk.Text != "")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                con.Open();

                OleDbCommand cmd = new OleDbCommand("UPDATE musteribilgileri SET adi=@1,sadi=@2,dt=@3,cinsiyet=@4,email=@5,sifre=@6,telno=@7,il=@8,ilce=@9,postakodu=@10,ackadres=@11 WHERE id=" + Session["id"] + "", con);


                cmd.Parameters.AddWithValue("@1", tbadi.Text);
                cmd.Parameters.AddWithValue("@2", tbsadi.Text);
                cmd.Parameters.AddWithValue("@3", tbdt.Text);
                cmd.Parameters.AddWithValue("@4", drpdvn.Text);
                cmd.Parameters.AddWithValue("@5", tbmail.Text);
                cmd.Parameters.AddWithValue("@6", tbsifre.Text);
                cmd.Parameters.AddWithValue("@7", tbcep.Text);
                cmd.Parameters.AddWithValue("@8", tbil.Text);
                cmd.Parameters.AddWithValue("@9", tbilce.Text);
                cmd.Parameters.AddWithValue("@10", tbpk.Text);
                cmd.Parameters.AddWithValue("@11", tbadres.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                btndz.Visible = true;
                Response.Write("<script>alert('DÜZENLEMENİZ BAŞARI İLE KAYIDEDİMİŞTİR');</script>");
                doldur();
            }
            else
            {
                Response.Write("<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ.');</script>");
            }

        }

        protected void btndz_Click(object sender, EventArgs e)
        {
            btndz.Visible = false;
            tbadi.Enabled = true;
            tbadres.Enabled = true;
            tbcep.Enabled = true;
            tbdt.Enabled = true;
            tbil.Enabled = true;
            tbilce.Enabled = true;
            tbmail.Enabled = true;
            tbpk.Enabled = true;
            tbsadi.Enabled = true;
            tbsifre.Enabled = true;
            drpdvn.Enabled = true;
            btnkyt.Visible = true;
            tbsifretk.Enabled = true;
        }
    }
}