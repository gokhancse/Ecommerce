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
    public partial class Site : System.Web.UI.MasterPage
    {
        category categoryObj = new category();
        product prodObj = new product();
        picture picObj = new picture();
        manufacturer manObj = new manufacturer();
        basket basketObj =  new basket();
        user userObj = new user();
        USER_USER user = new USER_USER();
        public Hashtable kelime;
        public SiteDil s = new SiteDil();

        protected void Page_Load(object sender, EventArgs e)
        {
            kelime = s.KelimeleriGetir();
            if (Session["Dil"] == "TR" || Session["Dil"] == null)
            {
                ImageButton1.ImageUrl = "images/ENG.jpg";

            }

            if (Session["Dil"] == "ENG")
            {
                ImageButton1.ImageUrl = "images/TR.jpg";
            }
            txtSearch.Text = kelime["15"].ToString();
            btnSearch.Text = kelime["15"].ToString();
      
            if (Session["enterance"] == "true") 
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
               
            }

            if (Convert.ToInt32 (Session["userid"]) > 0)
            {
                panelship.Visible = true;
                int count = basketObj.getBasketCount(Convert.ToInt32(Session["userid"]));
                LblItemCount.Text = "Sepetteki ürün adedi :" + count.ToString();

                double totalprice = basketObj.getBasketTotalPrice(Convert.ToInt32(Session["userid"]));
                LblTotalPrice.Text = totalprice.ToString() +" TL";
            }

          
            
            //Kategorileri ekleme
            ListViewCategories.DataSource = categoryObj.getAllCategories();
            ListViewCategories.DataBind();

            //Kampanyalı ürünleri ekleme
            var prods = prodObj.getAllCampaignPorducts();
           

            var products = from c in prods
                           select new
                           {
                               PIC_PictureURL = picObj.getFirstPicture(c.PROD_ID),
                               PIC_ProdID = c.PROD_ID,
                               PIC_ProdPrice = c.PROD_Price,
                               PIC_ProdName = c.PROD_Name,
                               PIC_ProdOldPrice = c.PROD_OldPrice
                           };

            ListViewCampaignProducts.DataSource = products;
            ListViewCampaignProducts.DataBind();



          


            //Markaları ekleme
            ListViewManufacturers.DataSource = manObj.getAllManufacturer();
            ListViewManufacturers.DataBind();


            //En çok satan ürünleri ekleme
            var mostsaledproducts = prodObj.getMostSaledProducts();

            var mostsaledpro = from m in mostsaledproducts
                               select new
                               {
                                   PIC_PictureURL = picObj.getFirstPicture(m.PROD_ID),
                                   PIC_ProdID = m.PROD_ID,
                                   PIC_ProdPrice = m.PROD_Price,
                                   PIC_ProdName = m.PROD_Name,
                                   PIC_ProdOldPrice = m.PROD_OldPrice,
                                   PIC_ProdInformation = m.PROD_Information
                               };

            ListViewMostSaled.DataSource = mostsaledpro;
            ListViewMostSaled.DataBind();
        
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
        /*    if (txtSearch.Text != null)
            {
                prodObj.searchProd(txtSearch.Text, txtSearch.Text, txtSearch.Text, txtSearch.Text, txtSearch.Text, txtSearch.Text, txtSearch.Text, txtSearch.Text);
            }
            else { }*/
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            AppliactionLayer.basket basketObj = new AppliactionLayer.basket();
            basketObj.emtpyBasket(Convert.ToInt32(Session["userid"]));
            Session.Abandon();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Response.Redirect("default.aspx");
            

            
    
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {

            basketObj.getBasket(Convert.ToInt32(Session["userid"]));
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


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["Dil"] == "TR" || Session["Dil"] == null)
            {
                Session["Kelimeler"] = null;
                Session["Dil"] = "ENG";
                s.KelimeleriGetir("ENG");
                Response.Redirect(Request.RawUrl);
                
 
            }
            if (Session["Dil"] == "ENG")
            {
                Session["Kelimeler"] = null;
                Session["Dil"] = "TR";
                s.KelimeleriGetir("TR");
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}