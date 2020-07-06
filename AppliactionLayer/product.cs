using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class product
    {
        public int addProduct(int catid, int manid, string name, double price, double oldprice, string shortInfo, string info)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            DataLayer.PROD_PRODUCT newProd = new DataLayer.PROD_PRODUCT();
            newProd.PROD_CatID = catid;
            newProd.PROD_ManID = manid;
            newProd.PROD_Name = name;
            newProd.PROD_Price = price;
            newProd.PROD_OldPrice = oldprice;
            newProd.PROD_ShortInformation = shortInfo;
            newProd.PROD_Information = info;

            ctx.PROD_PRODUCTs.InsertOnSubmit(newProd);
            ctx.SubmitChanges();
            return newProd.PROD_ID;
        }

        public void editProduct(int prodid, int catid, int manid, string name, double price, double oldprice, string shortInfo, string info)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           where c.PROD_ID == prodid
                           select c;

            if (products.Count() < 1) return;

            var editProd = products.SingleOrDefault();

            editProd.PROD_CatID = catid;
            editProd.PROD_ManID = manid;
            editProd.PROD_Name = name;
            editProd.PROD_Price = price;
            editProd.PROD_OldPrice = oldprice;
            editProd.PROD_ShortInformation = shortInfo;
            editProd.PROD_Information = info;
            ctx.SubmitChanges();
        }

        public void deleteProduct(int prodid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           where c.PROD_ID == prodid
                           select c;

            if (products.Count() < 1) return;

            ctx.PROD_PRODUCTs.DeleteAllOnSubmit(products);
            ctx.SubmitChanges();
        }

        public List<PROD_PRODUCT> searchProd(string prodid, string catid, string manid,
            string name, string price, string oldprice, string shortInfo, string info)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           where c.PROD_ID == (prodid == null ? c.PROD_ID : int.Parse(prodid))
                           && c.PROD_CatID == (catid == null ? c.PROD_CatID : int.Parse(catid))
                           && c.PROD_Name == (name == null ? c.PROD_Name : name)
                           && c.PROD_Price == (price == null ? c.PROD_Price : double.Parse(price))
                           && c.PROD_OldPrice == (oldprice == null ? c.PROD_OldPrice : double.Parse(oldprice))
                           && c.PROD_ShortInformation.Contains(shortInfo == null ? c.PROD_ShortInformation : shortInfo)
                           && c.PROD_Information.Contains(info == null ? c.PROD_Information : info)
                           select c;

            return products.ToList();
        }

        public List<PROD_PRODUCT> getProdbyCat(int catid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           where c.PROD_CatID == catid
                           select c;

            return products.ToList();
        }

        public List<PROD_PRODUCT> getAllProducts()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           select c;

            return products.ToList();
        }

        public List<PROD_PRODUCT> getAllCampaignPorducts() 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           where c.PROD_Iscampaign == true
                           select c;

            return products.ToList();
            
        }

        public List<PROD_PRODUCT> getRandomProduct3() 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = from c in ctx.PROD_PRODUCTs
                           orderby ctx.GetNewId()
                           select c;

            return products.ToList();


       
        }

        public PROD_PRODUCT getRandomProduct()
         {
             eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
                var qry = from row in ctx.PROD_PRODUCTs
                select row;

                int count = qry.Count();

                int index = new Random().Next(count);

                PROD_PRODUCT prd = qry.Skip(index).FirstOrDefault();
                return prd;

         }

        public PROD_PRODUCT getRandomProduct2()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = ctx.PROD_PRODUCTs.Count();

            Random random = new Random();
            int index = random.Next(products);

            var prd = ctx.PROD_PRODUCTs.ToList()[index];

            return prd;


        }

        public List<PROD_PRODUCT> getLastAddedProducts() 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = (from c in ctx.PROD_PRODUCTs
                           orderby c.PROD_ID descending
                           select c).Take(6);

            return products.ToList();


        }

        public List<PROD_PRODUCT> getRecomendedProducts()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = (from c in ctx.PROD_PRODUCTs
                           orderby c.PROD_Like descending                           
                           select c).Take(3);

            return products.ToList();
        }

        public List<PROD_PRODUCT> getMostSaledProducts() 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = (from c in ctx.PROD_PRODUCTs
                            orderby c.PROD_SaleCount descending
                            select c).Take(5);
            
            return products.ToList();                           

        }

        public List<PROD_PRODUCT> getProductByManufacturerID(int manID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var product = from c in ctx.PROD_PRODUCTs
                          where c.PROD_ManID == manID
                          select c;
            return product.ToList();
        }

        public List<PROD_PRODUCT> getAllCampaignProducts()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var products = (from c in ctx.PROD_PRODUCTs
                           where c.PROD_Iscampaign == true
                           select c).ToList();

            return products;

        }

        public PROD_PRODUCT getProductById(int prodid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var prod = (from c in ctx.PROD_PRODUCTs
                       where c.PROD_ID == prodid
                       select c).SingleOrDefault();

            return prod;

        }

        public double getProductPriceByID(int prodID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var price = (from c in ctx.PROD_PRODUCTs
                        where c.PROD_ID == prodID
                        select c.PROD_Price).SingleOrDefault();

            return price;
        }

    }
}