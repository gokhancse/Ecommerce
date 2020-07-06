using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppliactionLayer;

namespace eCommerce
{
    public partial class productbrands : System.Web.UI.Page
    {
        category catObj = new category();
        product prodObj = new product();
        picture picObj = new picture();
        basket basketObj = new basket();
        manufacturer manObj = new manufacturer();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["MAN_ID"]);
            string manname = manObj.getManNameByID(id);
            Lbltitle.Text = manname;

            var products = prodObj.getProductByManufacturerID(id);

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

            ListViewBrands.DataSource = prods;
            ListViewBrands.DataBind();
        
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