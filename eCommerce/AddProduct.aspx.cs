using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class AddProduct : System.Web.UI.Page
    {
        AppliactionLayer.product prodObj = new AppliactionLayer.product();
        AppliactionLayer.picture picObj = new AppliactionLayer.picture();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
         int prodID =  prodObj.addProduct(1, 1, txtProductName.Text, Convert.ToDouble (txtPrice.Text),Convert.ToDouble( txtOldPrice.Text), txtshortdesc.Text, txtdescripton.Text);
         string Filename = "~/images/" + FileUpload1.FileName;
         picObj.AddPicture(prodID, Filename , 1);
         FileUpload1.SaveAs(Server.MapPath("~/images/") + FileUpload1.FileName);
             
        }
    }
}