using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
namespace AppliactionLayer
{
    public class order
    {
      /*  public void giveOrder(int userID ,int adressıd)
        {

        }*/

   /*     public void acceptBasket(int userid)
        {
            var basketItems = new basket().getBasket(userid);

            if (basketItems.Count() > 0)
            {
                eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
                ORDER_ORDER newOrder = new DataLayer.ORDER_ORDER();

                newOrder.ORDER_UserID = userid;
                newOrder.ORDER_AddressID = new user().getUserAddress(userid);
                newOrder.ORDER_TotalPrice = 0;
                ctx.ORDER_ORDERs.InsertOnSubmit(newOrder);
                ctx.SubmitChanges();

                foreach (var item in basketItems)
                {
                    DETOR_ORDERDETAIL detailOrder = new DETOR_ORDERDETAIL();
                    detailOrder.DETOR_OrderID = newOrder.ORDER_ID;
                    detailOrder.DETOR_ProductID = item.BASKT_ProdID;
                    detailOrder.DETOR_Unit = item.BASKT_Unit;
                    newOrder.ORDER_TotalPrice += item.PROD_PRODUCT.PROD_Price;
                    ctx.DETOR_ORDERDETAILs.InsertOnSubmit(detailOrder);
                    ctx.SubmitChanges();
                }

                new basket().emtpyBasket(userid);
            }
        }

        public ORDER_ORDER getOrder(int userid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var orders = from c in ctx.ORDER_ORDERs
                         where c.ORDER_UserID == userid
                         select c;

            if (orders.Count() > 0)
                return orders.ToList()[0];
            else return null;
        }*/
    }
}
