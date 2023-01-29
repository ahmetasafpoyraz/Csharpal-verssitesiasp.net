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
    public partial class admin : System.Web.UI.Page
    {
        public static int u, x, i, j, k, y, t, p, m, h, n, ip;
        OleDbConnection con;
        DataSet ds = new DataSet();
        OleDbDataAdapter adp;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               u=x= n = i = j = k = y = t = p = m = h = ip = 0;

            }
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            adp = new OleDbDataAdapter("SELECT * FROM musteribilgileri", con);
            adp.Fill(ds, "mb");
            i = ds.Tables["mb"].Rows.Count;



            adp = new OleDbDataAdapter("SELECT * FROM urun", con);
            adp.Fill(ds, "ur");
            j = ds.Tables["ur"].Rows.Count;

            adp = new OleDbDataAdapter("SELECT * FROM  duyuru", con);
            adp.Fill(ds, "du");
            k = ds.Tables["du"].Rows.Count;

            adp = new OleDbDataAdapter("SELECT * FROM  siparisdrm ", con);
            adp.Fill(ds, "dr");
            m = ds.Tables["dr"].Rows.Count;


            con.Open();
            OleDbCommand cmd1 = new OleDbCommand("SELECT * FROM siparisdrm ", con);
            adp = new OleDbDataAdapter("SELECT * FROM siparisdrm", con);
            OleDbDataReader rdr = cmd1.ExecuteReader();
            adp.Fill(ds, "drm");
            while (rdr.Read())
            {
                foreach (DataRow d in ds.Tables["drm"].Rows)
                {


                    if (rdr["sipdurum"].ToString() == "paketlendi")
                    {
                        p++;
                        break;
                    }

                }
                foreach (DataRow d in ds.Tables["drm"].Rows)
                {
                    if (rdr["sipdurum"].ToString() == "yolda")
                    {
                        y++;
                        break;
                    }
                }
                foreach (DataRow d in ds.Tables["drm"].Rows)
                {
                    if (rdr["sipdurum"].ToString() == "tamamlandı")
                    {
                        t++;
                        break;
                    }

                }
                foreach (DataRow d in ds.Tables["drm"].Rows)
                {
                    if (rdr["sipdurum"].ToString() == "hazırlanıyor")
                    {
                        h++;
                        break;
                    }

                }
                foreach (DataRow d in ds.Tables["drm"].Rows)
                {
                    if (rdr["sipdurum"].ToString() == "yeni")
                    {
                        n++;
                        break;
                    }
                    Session.Add("bldrm", n);
                }
            }

            con.Close();




            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
            adp = new OleDbDataAdapter("SELECT * FROM ziyaretci ", con);
            ds = new DataSet();
            adp.Fill(ds, "zyrt");

            adp = new OleDbDataAdapter("SELECT * FROM ziyaretci ", con);
            ds = new DataSet();
            adp.Fill(ds, "zyrt");
            ip = ds.Tables["zyrt"].Rows.Count;
            //ds.Tables[0].Rows[i]["ip"]
            //for (int q = 0; q < ds.Tables[0].Rows.Count; q++)
            //{
               
                
            //    for (int b = 1; b < ds.Tables["zyrt"].Rows.Count; b++)
            //    {
            //        if (ds.Tables["zyrt"].Rows[q]["ip"].ToString()==ds.Tables["zyrt"].Rows[b]["ip"].ToString())
            //        {
            //            u++;
            //        }
            //        else
            //        {
            //            x++;
            //        }
            //    }
            //}
            //ip = x - u; ;



        }
    }
}