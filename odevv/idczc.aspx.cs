using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace odevv
{
    public partial class idczc : System.Web.UI.Page
    {
        private int id = 0, id2 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["duyuru"]!=null)
            {
                id = int.Parse(Request.QueryString["duyuru"].ToString());
                Session.Add("duyuru", id.ToString());
                Response.Redirect("ck.aspx");
            }

            if (Request.QueryString["urun"]!=null)
            {
                id2 = int.Parse(Request.QueryString["urun"].ToString());
                Session.Add("urun", id2.ToString());
                Response.Redirect("urunler.aspx");
            }
           
        }
    }
}