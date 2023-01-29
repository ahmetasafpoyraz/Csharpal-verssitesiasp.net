using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace odevv
{
    public class asax : System.Web.HttpApplication
    {



        DataSet ds = new DataSet();
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["online"] = 0;
            Application["toplamziyaretci"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            Application["online"] = ((int)Application["online"]) + 1;

            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=" + Server.MapPath("~/databaase.mdb"));
            baglanti.Open();
            OleDbCommand cmd1 = new OleDbCommand("SELECT COUNT(*) FROM ziyaretci WHERE ip='" + ip+"'", baglanti);
            OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM ziyaretci", baglanti);
            int rdr = (int)cmd1.ExecuteScalar();
            if (rdr == 0)
            {
                string sorgu = "insert into ziyaretci (ip,zaman) values(@ip,@zaman)";
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ip", ip);
                komut.Parameters.AddWithValue("@zaman", DateTime.Now.ToString());

                komut.ExecuteNonQuery();
            }
            baglanti.Close();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {


        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();// Application.Lock();//uyguylama kılıtlendı
            Application["online"] = (int)Application["online"] - 1;//int e cevirip bir azalttık
            Application.UnLock();//uygulama acıldı
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application.Remove("online");//ziyaretci sılındı
        }
    }
}