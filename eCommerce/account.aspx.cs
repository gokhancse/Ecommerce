using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppliactionLayer;
using System.Collections;
using DataLayer;

namespace eCommerce
{
    public partial class account : System.Web.UI.Page
    {
        public Hashtable kelime;
        public SiteDil s = new SiteDil();

        user userObj = new user();
        DataLayer.USER_USER usr = new DataLayer.USER_USER();
        protected void Page_Load(object sender, EventArgs e)
        {
            kelime = s.KelimeleriGetir();

                Label1.Text = kelime["6"].ToString();
                Label2.Text = kelime["25"].ToString(); ;
                Label3.Text = kelime["26"].ToString();
                Button2.Text = kelime["38"].ToString();
                Button1.Text = kelime["6"].ToString();
             
         
            if (Session["userid"] == null)  
            {
               
                PnlMember.Visible = true;
                PanelUpdate.Visible = false;

            }

            else if (userObj.GetUserByID(Convert.ToInt32(Session["userid"])).USER_Email != "")
            {
               
             
                PnlMember.Visible = false;
                PanelUpdate.Visible = true;
            }

      
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int check = userObj.userLoginCheck(txtUsername.Text, txtPassword.Text);

            if (check > 0)
            {

                Session["userid"] = check;
                Response.Redirect("Default.aspx");
            }

            else
            {
                lblLoginMessage.Visible = true;
                lblLoginMessage.Text = "* Hatalı kullanıcı adı yada şifre girdiniz";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

       
     

     
    }
}