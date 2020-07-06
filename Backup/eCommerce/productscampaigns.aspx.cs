using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppliactionLayer;
namespace eCommerce
{
    public partial class productscampaigns : System.Web.UI.Page
    {
        basket basketObj = new basket();
        protected void Page_Load(object sender, EventArgs e)
        {
            category catObj = new category();
            product prodObj = new product();
            picture picObj = new picture();

            var products = prodObj.getAllCampaignPorducts();

            var prods = from p in products
                        select new 
                        {
                            PIC_PictureURL = picObj.getFirstPicture(p.PROD_ID),
                            PIC_ProdID = p.PROD_ID,
                            PIC_ProdPrice = p.PROD_Price,
                            PIC_ProdName = p.PROD_Name,
                            PIC_ProdOldPrice = p.PROD_OldPrice,
                            PIC_ProdInformation = p.PROD_Information
                        };

            ListViewCampaignProducts.DataSource = prods;
            ListViewCampaignProducts.DataBind();
        }

        protected void ProductItemCommand(Object source, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ProductSale")
            {
                Session["prod_ID"] = e.CommandArgument.ToString();
                basketObj.addBasket(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["prod_ID"]), 1);
            }
            else if (e.CommandName == "ProductDetail")
            {
                Session["prod_ID"] = e.CommandArgument.ToString();
                Response.Redirect("productDetail.aspx");

            }

        }
     
    }
}