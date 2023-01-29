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
    public partial class Homepage : System.Web.UI.MasterPage
    {
        public string user;
        public int p = 0;
        OleDbConnection con;
        OleDbDataAdapter adp;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            object uye = Session["adi"];
            if (uye != null)
            {
                user = uye.ToString();
            }
            if (!IsPostBack)
            {
                
            if (Session["id"] != null)
            {
                adp = new OleDbDataAdapter("SELECT * FROM sepet where musteriid=" + Session["id"] + "", con);
                adp.Fill(ds, "sp");
                p= ds.Tables["sp"].Rows.Count;
            }
            }
        }
    }
}