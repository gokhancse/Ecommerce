using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AppliactionLayer.user user = new AppliactionLayer.user();
            DataLayer.USER_USER newUser = new DataLayer.USER_USER();
           
            int ID = Convert.ToInt32(Session["userid"]);
            newUser =   user.GetUserByID(ID);
            if (newUser.USER_TYPE != 2 ) 
            {
                Response.Redirect("default.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteProduct.aspx");
        }

       
    }
}