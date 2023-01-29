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
    public partial class duzenle : System.Web.UI.Page
    {

        private int id = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["musteri"]==null)
            {
                Response.Redirect("admin.aspx");
            }
            id = int.Parse(Request.QueryString["musteri"].ToString());
            if (!IsPostBack)
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));

                string sorgu = "select * from musteribilgileri where id=" + id + "";

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
                    if (ko.GetValue(12).ToString()=="admin")
                    {
                        chbadmn.Checked = true;
                    }
                    else
                    {
                        chbadmn.Checked = false;
                    }
                    


                }
                con.Close();
            }


        }

        protected void btndznle_Click(object sender, EventArgs e)
        {


            duuzenle();


        }

        void duuzenle()
        {
            id = int.Parse(Request.QueryString["musteri"].ToString());
            if (tbadi.Text != "" && tbsadi.Text != "" && tbadres.Text != "" && tbdt.Text != "" && drpdvn.Text != "" && tbmail.Text != "" && tbsifre.Text != "" && tbcep.Text != "" && tbil.Text != "" && tbilce.Text != "" && tbpk.Text != "")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                con.Open();

                OleDbCommand cmd = new OleDbCommand("UPDATE musteribilgileri SET adi=@1,sadi=@2,dt=@3,cinsiyet=@4,email=@5,sifre=@6,telno=@7,il=@8,ilce=@9,postakodu=@10,ackadres=@11,yetki=@12  WHERE id=" + id + "", con);


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
                if (chbadmn.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@12", "admin");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@12", "user");
                }



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("uyeler.aspx");

            }
            else
            {
                Response.Write("<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ.');</script>");
            }
        }


    }
}