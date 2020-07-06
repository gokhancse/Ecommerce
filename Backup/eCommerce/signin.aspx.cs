using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppliactionLayer;
using DataLayer;
using System.Collections;


namespace eCommerce
{
     
    public partial class signin : System.Web.UI.Page
    {
        public Hashtable kelime;
        public SiteDil s = new SiteDil();

        user userObj = new user();
        basket basketObj = new basket();
        DataLayer.USER_USER usr = new DataLayer.USER_USER();
        protected void Page_Load(object sender, EventArgs e)
        {
            kelime = s.KelimeleriGetir();
            Label1.Text = kelime["25"].ToString();
            Label2.Text = kelime["26"].ToString();
            Button2.Text = kelime["38"].ToString();
            Button1.Text = kelime["6"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int check = userObj.userLoginCheck(txtUsername.Text, txtPassword.Text);
            Session["userid"] = check;
            bool admin = userObj.IsAdmin(Convert.ToInt32(Session["userid"]));
            if (admin == true) 
            {

                Response.Redirect("Admin.aspx");
                return;
            }

            //  check = userObj.userLoginCheck(txtUsername.Text, txtPassword.Text);

             if (check > 0)
             {
             //    int oldID =Convert.ToInt32(Session["userid"]);


              //   Session["userid"] = check;
                 Session["enterance"] = "true";

   
              /*  if (oldID != 0)
                 {
                     usr = userObj.GetUserByID(oldID);
                     basketObj.ChangeBasketID(oldID, check);
                   //  userObj.DeleteUser(oldID);
                 }*/

                 Response.Redirect("Default.aspx");
             }

             else
             {
                // lblMessage.Visible = true;
        
                 
                 
                //lblMessage.Text = "* Hatalı kullanıcı adı yada şifre girdiniz"; 
             }
        
        }

     

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }
    }
}