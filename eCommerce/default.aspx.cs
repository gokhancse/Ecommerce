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
    public partial class _default1 : System.Web.UI.Page
    {
        product prodObj = new product();
        picture picObj = new picture();
        basket basketObj = new basket();
        user userObj = new user();

        public Hashtable kelime;
        public SiteDil s = new SiteDil();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            kelime = s.KelimeleriGetir();
            //Son eklenen ürünleri ekleme
            var lastadded = prodObj.getLastAddedProducts();

            var lastproducts = from l in lastadded
                               select new
                               {
                                   PIC_PictureURL = picObj.getFirstPicture(l.PROD_ID),
                                   PIC_ProdID = l.PROD_ID,
                                   PIC_ProdPrice = l.PROD_Price,
                                   PIC_ProdName = l.PROD_Name,
                                   PIC_ProdOldPrice = l.PROD_OldPrice,
                                   PIC_ProdInformation = l.PROD_Information
                               };
            ListViewLastProducts.DataSource = lastproducts;
            ListViewLastProducts.DataBind();





            
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
                    string msg =kelime["42"].ToString();

                    Response.Write("<script>alert('" +msg+"');</script>");
  
                }
            }
            else if (e.CommandName == "ProductDetail")
            {
                Session["prod_ID"] = e.CommandArgument.ToString();
                Response.Redirect("productDetail.aspx");



            }

        }

        }


    }
