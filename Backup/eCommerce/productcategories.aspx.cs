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
    public partial class productcategories : System.Web.UI.Page
    {
        category catObj = new category();
        product prodObj = new product();
        picture picObj = new picture();
        basket basketObj = new basket();
        public SiteDil s = new SiteDil();
        public Hashtable kelime = new Hashtable();
  

        protected void Page_Load(object sender, EventArgs e)
        {

          kelime = s.KelimeleriGetir();

          int id = Convert.ToInt32(Request.QueryString["CAT_ID"]);
          string categoryname = catObj.getCategoryNameByCategoryID(id, Session["Dil"].ToString());
          Lbltitle.Text = categoryname;

          var products =  prodObj.getProdbyCat(id);

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
          ListViewCategories.DataSource = prod;
          ListViewCategories.DataBind();

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