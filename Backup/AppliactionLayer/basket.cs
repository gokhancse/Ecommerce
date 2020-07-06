using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.Collections;


namespace AppliactionLayer
{
    public class basket
    {
        product prodObj = new product();
        public void addBasket(int userid, int prodid, int unit)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            BASKT_BASKET newBasket = new DataLayer.BASKT_BASKET();

            newBasket.BASKT_UserID = userid;
            newBasket.BASKT_ProdID = prodid;
            newBasket.BASKT_Unit = unit;

            ctx.BASKT_BASKETs.InsertOnSubmit(newBasket);
            ctx.SubmitChanges();
        }

        public void editBasket(int basketID, int userid, int prodid, int unit)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var baskets = from c in ctx.BASKT_BASKETs
                          where c.BASKT_ID == basketID
                          select c;

            if (baskets.Count() < 1) return;

            var editBasket = baskets.SingleOrDefault();
            editBasket.BASKT_UserID = userid;
            editBasket.BASKT_ProdID = prodid;
            editBasket.BASKT_Unit = unit;

            ctx.SubmitChanges();
        }

        public void deleteBasket(int basketID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var baskets = from c in ctx.BASKT_BASKETs
                          where c.BASKT_ID == basketID
                          select c;

            ctx.BASKT_BASKETs.DeleteAllOnSubmit(baskets);
            ctx.SubmitChanges();
        }

        //public List<BASKT_BASKET>searchBasket(String basketID, String userid, String prodid, String unit)
        //{
        //    eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

        //    var baskets = from c in ctx.BASKT_BASKETs
        //                  where c.BASKT_ID == (basketID == null ? c.BASKT_ID : int.Parse(basketID.ToString()))
        //                  && c.BASKT_UserID == (userid == null ? c.BASKT_UserID : int.Parse(userid.ToString()))
        //                  && c.BASKT_ProdID == (prodid == null ? c.BASKT_ProdID : int.Parse(prodid.ToString()))
        //                  && c.BASKT_Unit == (unit == null ? c.BASKT_Unit : int.Parse(unit.ToString()))
        //                  select c;

        //    return baskets.ToList();
        //}

        public List<BASKT_BASKET> getBasket(int userid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var baskets = from c in ctx.BASKT_BASKETs
                          where c.BASKT_UserID == userid
                          select c;

            return baskets.ToList();
        }

        public void emtpyBasket(int userid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var basketItems = from c in ctx.BASKT_BASKETs
                              where c.BASKT_UserID == userid
                              select c;

            ctx.BASKT_BASKETs.DeleteAllOnSubmit(basketItems);
            ctx.SubmitChanges();
        }

        public int  getBasketCount(int userID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var total= 0;
            var count = from c in ctx.BASKT_BASKETs
                        where c.BASKT_UserID == userID
                        group c by c.BASKT_UserID into a
                       select new {total_unit = a.Sum(p=>p.BASKT_Unit)};

            foreach (var item in count)
            {
                total += item.total_unit;
                
            }

            return total;
        }

        public double getBasketTotalPrice(int userID )
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var productCount = from p in ctx.BASKT_BASKETs
                               where p.BASKT_UserID == userID
                               group p by p.BASKT_ProdID into a
                               select new { a.Key, total_unit = a.Sum(p => p.BASKT_Unit) };

            var prdcnt = from p in ctx.PROD_PRODUCTs
                         from c in productCount
                         where c.Key == p.PROD_ID
                         select new {total = c.total_unit * p.PROD_Price };
            double ttl = 0;
            foreach (var item in prdcnt)
            {
                ttl += item.total;
            }
            return ttl;

         

            
        }
        public bool checkBasket(int userID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var basket = from c in ctx.BASKT_BASKETs
                         where c.BASKT_UserID == userID
                         select c;

            if (basket.Count() > 0)
                return true;
            else 
                return false;
        }

        public void ChangeBasketID(int oldID ,int newID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var basket = from c in ctx.BASKT_BASKETs
                         where c.BASKT_UserID == oldID
                         select c;

            foreach (var item in basket)
            {
                item.BASKT_UserID = newID;
            }

            ctx.SubmitChanges();

        }
    }
}