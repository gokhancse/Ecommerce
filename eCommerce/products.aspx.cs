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
    public partial class products : System.Web.UI.Page
    {

        public Hashtable kelime;
        public SiteDil s = new SiteDil();


        category catObj = new category();
        product prodObj = new product();
        picture picObj = new picture();
        basket basketObj = new basket();
       
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ListViewProducts.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            kelime = s.KelimeleriGetir();
           
           var products = prodObj.getAllProducts();
            var prod = from p in products
                       select new
                       {
                           PIC_PictureURL = picObj.getFirstPicture(p.PROD_ID),
                           PIC_ProdID = p.PROD_ID,
                           PIC_ProdPrice = p.PROD_Price,
                           PIC_ProdName = p.PROD_Name,
                           PIC_ProdOldPrice = p.PROD_OldPrice,
                           PIC_ProdInformation = p.PROD_Information

                       };


            ListViewProducts.DataSource = prod.ToList() ;
            ListViewProducts.DataBind();
        }


        protected void ProductItemCommand(Object source, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ProductSale")
            {
                if (Session["userid"] != null)
                {
                    Session["prod_ID"] = e.CommandArgument.ToString();
                    basketObj.addBasket(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["prod_ID"]), 1);
                }
                else
                {
                    string msg = kelime["42"].ToString();

                    Response.Write("<script>alert('" + msg + "');</script>");

                }


            }
            if (e.CommandName == "ProductDetail")
            {
                Session["prod_ID"] = e.CommandArgument.ToString();
                Response.Redirect("productDetail.aspx");

            }if (e.CommandName == "ProductDetailImage")
            {
                Session["prod_ID"] = e.CommandArgument.ToString();
                Response.Redirect("productDetail.aspx");

            }
        }
    }
}