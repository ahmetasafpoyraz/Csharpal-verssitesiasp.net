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
    public partial class productdetails : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbCommand cmd2;
        public int id, tf = 0;
        public static string adi, aciklama, resim, fiyati, uidd, uid, st;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                    cmd = new OleDbCommand("SELECT * FROM urun where id= " + id + "", con);
                    con.Open();
                    OleDbDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        uid = rdr.GetValue(0).ToString();
                        adi = rdr.GetValue(1).ToString();
                        aciklama = rdr.GetValue(2).ToString();
                        fiyati = rdr.GetValue(5).ToString();
                        resim = rdr.GetValue(7).ToString();
                        st = rdr.GetValue(8).ToString();
                        break;
                    }
                    con.Close();
                    
                    if (Session["id"] != null)
                    {
                        int id2 = int.Parse(Request.QueryString["id"]);
                        cmd2 = new OleDbCommand("SELECT * FROM sepet where (musteriid=" + Session["id"] + "and urunid= " + id2 + ")", con);
                        con.Open();
                        OleDbDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            uidd = rdr2.GetValue(2).ToString();
                            break;
                        }
                        con.Close();
                    }
                }
            }
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            
         if (Session["adi"] != null)
            {
                if (tbmik.Text != "")
                {
                    if (uid==uidd)
                    {
                            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                            con.Open();
                            cmd = new OleDbCommand(" update sepet set miktar=miktar+" + tbmik.Text + " where (musteriid=" + Session["id"] + " and urunid="+uidd+")", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('ÜRÜNÜNÜZ BAŞARI İLgfdfgfdgfdgE SEPETE EKLENMİŞTİR.');window.location='sepet.aspx';</script>");
                           
                    }
                    else
                    {
                    con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                    cmd = new OleDbCommand(" insert into sepet (musteriid,urunid,miktar,tarih) values (@1,@2,@3,@4) ", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@1", Session["id"]);
                    cmd.Parameters.AddWithValue("@2", uid);
                    cmd.Parameters.AddWithValue("@3", tbmik.Text);
                    cmd.Parameters.AddWithValue("@4", DateTime.Now.ToShortDateString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('ÜRÜNÜNÜZ BAŞARI İLE SEPETE EKLENMİŞTİR.');window.location='sepet.aspx';</script>");
                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('LÜTFEN MİKTAR GİRİNİZ.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('LÜTFEN ÖNCE GİRİŞ YAPINIZ VEYA ÜYE OLUNUZ.');</script>");
            }
        }
        
    }
}