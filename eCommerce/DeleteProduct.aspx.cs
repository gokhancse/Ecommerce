using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        AppliactionLayer.product product = new AppliactionLayer.product();
        AppliactionLayer.picture picture = new AppliactionLayer.picture();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = product.getAllProducts();
                DropDownList1.DataTextField = "PROD_Name";
                DropDownList1.DataValueField = "PROD_ID";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

          
            int prodID =int.Parse( DropDownList1.SelectedValue);
            picture.DeletePicture(prodID);
             product.deleteProduct(prodID);
             DropDownList1.DataSource = product.getAllProducts();
             DropDownList1.DataTextField = "PROD_Name";
             DropDownList1.DataValueField = "PROD_ID";
             DropDownList1.DataBind();
        }

      
          
        
    }
}