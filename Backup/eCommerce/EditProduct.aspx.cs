using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class EditProduct : System.Web.UI.Page
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

                int ProdID = Convert.ToInt32(DropDownList1.SelectedValue);
                DataLayer.PROD_PRODUCT prod = product.getProductById(ProdID);

                txtProductName.Text = prod.PROD_Name;
                txtPrice.Text = Convert.ToString(prod.PROD_Price);
                txtOldPrice.Text = Convert.ToString(prod.PROD_OldPrice);
                txtdescripton.Text = prod.PROD_Information;
                txtshortdesc.Text = prod.PROD_ShortInformation;
            }
            }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProdID = Convert.ToInt32(DropDownList1.SelectedValue);
            DataLayer.PROD_PRODUCT prod = product.getProductById(ProdID);

            txtProductName.Text = prod.PROD_Name;
            txtPrice.Text = Convert.ToString(prod.PROD_Price);
            txtOldPrice.Text = Convert.ToString(prod.PROD_OldPrice);
            txtdescripton.Text = prod.PROD_Information;
            txtshortdesc.Text = prod.PROD_ShortInformation;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             int ProdID = Convert.ToInt32(DropDownList1.SelectedValue);
             product.editProduct(ProdID, 1, 1, txtProductName.Text, Convert.ToInt32( txtPrice.Text),Convert.ToInt32( txtOldPrice.Text), txtshortdesc.Text, txtdescripton.Text);
             //picture.EditPicture(ProdID,);          
        }
    }
}