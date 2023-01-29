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
    public partial class products : System.Web.UI.Page
    {
        private int id = 0;
        OleDbConnection con;
        OleDbDataAdapter adp;
        DataSet ds = new DataSet();
        public StringBuilder urun = new StringBuilder();
        public StringBuilder kategori = new StringBuilder();

        private void kategorigtr()
        {
                con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
                adp = new OleDbDataAdapter("SELECT * FROM kategori", con);

                DataSet ds1 = new DataSet();
                ds1.Clear();
                adp.Fill(ds1, "kt");
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {

                    kategori.Append("<a href='products.aspx?id=" + ds1.Tables[0].Rows[i]["id"] + "'>");
                    kategori.Append(" <div class='tab1'>");
                    kategori.Append("<ul class='place'>");
                    kategori.Append(" <li class='sort'>"+ ds1.Tables[0].Rows[i]["adi"] +"</li>");
                    kategori.Append(" <li class='by'><img src='images/do.png'></li>");
                    kategori.Append("<div class='clearfix'> </div>");
                    kategori.Append("</ul>");
                    kategori.Append(" <div class='single-bottom' style='display: none;'>");
                    kategori.Append("</div>");
                    kategori.Append("</div>");
                    kategori.Append("</a>");
                }
        }


        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
	{
		 kategorigtr();
	}

            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            string drm = Request.QueryString["id"];
            string search = Request.QueryString["ara"];
            string sorgu = "SELECT * FROM urun ";
            if (search == null && drm == null)
            {
                sorgu = "SELECT * FROM urun ";
            }
            else if (search != null)
            {
                sorgu += " WHERE adi LIKE '%" + search + "%'";

            }
            else if (drm != null)
            {
                sorgu += " WHERE kategorid LIKE '%" + drm + "%'";
            }
            adp = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            adp.Fill(ds, "ur");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                urun.Append("<a href='productdetails.aspx?id=" + ds.Tables[0].Rows[i]["id"] + "'></a> ");
                urun.Append(" <div class='product-grid love-grid'><a href='productdetails.aspx?id=" + ds.Tables[0].Rows[i]["id"] + "'>");
                urun.Append(" <div class='more-product'><span> </span></div>");
                urun.Append(" <div class='product-img b-link-stripe b-animate-go  thickbox'>");
                urun.Append(" <img src=" + "images/" + ds.Tables[0].Rows[i]["rsm"] + " height='246px' width='338px' alt=''>");
                urun.Append(" <div class='b-wrapper'>");
                urun.Append(" <h4 class='b-animate b-from-left  b-delay03'>");
                urun.Append("<asp:button class='btns'>SİPARİŞ VER</button>");
                urun.Append(" </h4>");
                urun.Append(" </div>");
                urun.Append("</div></a>");
                urun.Append(" <div class='product-info simpleCart_shelfItem'>");
                urun.Append(" <div class='product-info-cust'>");
                urun.Append(" <h4>"+ ds.Tables[0].Rows[i]["adi"]+"</h4");
                urun.Append(" <span class='item_price'>" + ds.Tables[0].Rows[i]["satisfiyati"] + " TL</span>");
                urun.Append(" </div>	");
                urun.Append("   <div class='clearfix'> </div>");
                urun.Append(" </div>");
                urun.Append("</div>");

            }
  //------------------------------------------- urun and----------------------------------------------------------///
                    //kategori.Append("<li> ");
                    //kategori.Append("<a href='default.aspx?id=" + ds.Tables[0].Rows[i]["id"] + "'>");
                    //kategori.Append("<li>" + ds.Tables[0].Rows[i]["adi"] + "</li>");
            //kategori.Append("</a> </ li > ");  <a href="single.html"></a>
            
        }

        protected void btnara_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?ara=" + tbara.Text + "");
        }
    }
}

/*
 
                             <div class="tab1">
							 <ul class="place">								
								 <li class="sort">JEANS</li>
								 <li class="by"><img src="images/do.png" alt=""></li>
									<div class="clearfix"> </div>
							  </ul>
							 <div class="single-bottom" style="display: none;">	
						     </div>
					      </div>	
 
 */
