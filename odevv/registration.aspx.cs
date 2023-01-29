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
    public partial class registration : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("databaase.mdb"));
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (tbadi.Text != "" && tbsadi.Text != "" && tbadres.Text != "" && tbdt.Text != "" && drpdvn.Text != "" && tbmail.Text != "" && tbsifre.Text != "" && tbcep.Text != "" && tbil.Text != "" && tbilce.Text != "" && tbpk.Text != "")
            {
                
                    con.Open();
                    cmd = new OleDbCommand("insert into musteribilgileri(adi,sadi,dt,cinsiyet,email,sifre,telno,il,ilce,postakodu,ackadres,yetki) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", con);
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
                    cmd.Parameters.AddWithValue("@12", "user");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    Response.Write("<script>alert('Kaydınız Başarıyla Berçekleşti Şimdi Giriş Yapınız .');window.location='login.aspx';</script>");
                   

                }
                else
                {
                    Response.Write("<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUN.');</script>");
                }
            
           
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string navigateURL = "bilgimetni.aspx";
            string target = "_blank";
            string windowProperties = "status=yes, menubar=yes, toolbar=yes";
            string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
        }
    }
}