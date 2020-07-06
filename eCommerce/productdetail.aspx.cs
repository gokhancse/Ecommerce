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
    public partial class productdetail : System.Web.UI.Page
    {
        public Hashtable kelime;
        public SiteDil s = new SiteDil();

        product prodObj = new product();
        manufacturer manObj = new manufacturer();
        PROD_PRODUCT product = new PROD_PRODUCT();
        picture picObj = new picture();
        basket basketObj = new basket();
        protected void Page_Load(object sender, EventArgs e)
        {
                 product = prodObj.getProductById(Convert.ToInt32(Session["prod_ID"]));
                 string pictureURL = picObj.getPictureUrlByProductId(Convert.ToInt32(Session["prod_ID"]));
                 //string brandname = manObj.getManNameByID(product.PROD_ManID);
            
            
                kelime = s.KelimeleriGetir();
                Label1.Text = kelime["34"].ToString();
                Label2.Text = kelime["35"].ToString();
                Label4.Text = kelime["36"].ToString();
                Label5.Text = kelime["37"].ToString();
            if(Session["Dil"] == "Tr" || Session["Dil"]==null)
            {
               
                lblName.Text = product.PROD_Name_tr;
                Lblinfo.Text = product.PROD_Information_tr;
                LblPrice.Text = Convert.ToString(product.PROD_Price);
                Image1.ImageUrl = pictureURL;
                LblStockinfo.Text = product.PROD_StockCount.ToString();
            }
            if (Session["Dil"] == "ENG")
            {
                lblName.Text = product.PROD_Name;
                Lblinfo.Text = product.PROD_Information;
                LblPrice.Text = Convert.ToString(product.PROD_Price);
                Image1.ImageUrl = pictureURL;
                LblStockinfo.Text = product.PROD_StockCount.ToString();
 
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                lblwarning.Text = kelime["42"].ToString();
            }
            else 
            {
                basketObj.addBasket(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["prod_ID"]), 1);
            }
           
          
        }
    }
}