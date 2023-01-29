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
    public partial class sepet : System.Web.UI.Page
    {
        public int t = 0, total = 0;
        public string c, idd, uid, adi, fiyati, resim, aciklama, st;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbCommand cmd;
        public StringBuilder spt = new StringBuilder();
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                c = Session["id"].ToString();
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                adp = new OleDbDataAdapter("SELECT * FROM  sepet where musteriid=" + c + "", con);
                ds = new DataSet();
                ds.Clear();
                adp.Fill(ds, "sp");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cmd = new OleDbCommand("SELECT * FROM  urun where id=" + ds.Tables[0].Rows[i]["urunid"] + "", con);
                    con.Open();
                    OleDbDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        uid = rdr.GetValue(0).ToString();
                        adi = rdr.GetValue(1).ToString();
                        aciklama = rdr.GetValue(2).ToString();
                        fiyati = rdr.GetValue(5).ToString();
                        resim = rdr.GetValue(7).ToString();
                        st= rdr.GetValue(8).ToString();
                        break;
                    }
                    con.Close();
                    int tfiyat = int.Parse(fiyati) * int.Parse(ds.Tables[0].Rows[i]["miktar"].ToString());



                    spt.Append("<div class='cart-header'>");
                    spt.Append(" <a onclick='return condel()' href='sil.aspx?spt=" + ds.Tables[0].Rows[i]["id"] + "'><div class='close1'> </div></a>");
                    spt.Append("<div class='cart-sec'>");
                    spt.Append(" <div class='cart-item cyc'>");
                    spt.Append("<img src=" + "images/" + resim + ">");
                    spt.Append("</div>");                                     
                    spt.Append("<div class='cart-item-info'>");
                    spt.Append("<h3>"+adi+"<span></h3>");
                    spt.Append(" <h4><span>TOPLAM TUTAR TL </span>"+tfiyat+"</h4>");
                    spt.Append("<p class='qty'>MİKTAR : " + ds.Tables[0].Rows[i]["miktar"] + "" + st + " </p>");
                    spt.Append("</div>");
                    spt.Append("  <div class='delivery'>");
                    spt.Append("<p> 100 TL VE ÜZERİ ALIŞVERİŞLERDE KARGO ÜCRETSİZ </p>");
                    spt.Append("<div class='clearfix'></div>");
                    spt.Append(" </div>	");
                    spt.Append(" </div>	");
                    spt.Append(" </div>	");
                    t++;
                    total = total + tfiyat;
                }
            }
            else
            {

                Response.Write("<script>alert('SEPET İŞLEMLERİ İÇİN GİRİŞ YAOINIZ VEYA ÜYE OLUN');window.location='login.aspx';</script>");

            }
        }
    }
}