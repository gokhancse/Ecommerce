using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class coupon
    {
        public void addCoupon(int userid, int categoryid, string pass, double value, int status)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            COUP_COUPON newCoupon = new DataLayer.COUP_COUPON();

            newCoupon.COUP_UserID = userid;
            newCoupon.COUP_CategoryID = categoryid;
            newCoupon.COUP_Pass = pass;
            newCoupon.COUP_Value = value;
            newCoupon.COUP_Status = status;

            ctx.COUP_COUPONs.InsertOnSubmit(newCoupon);
            ctx.SubmitChanges();
        }

        public void editCoupon(int couponid, int userid, int categoryid, string pass, double value, int status)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var coupons = from c in ctx.COUP_COUPONs
                          where c.COUP_ID == couponid
                          select c;

            if (coupons.Count() < 1) return;

            var editCoupon = coupons.SingleOrDefault();

            editCoupon.COUP_UserID = userid;
            editCoupon.COUP_CategoryID = categoryid;
            editCoupon.COUP_Pass = pass;
            editCoupon.COUP_Value = value;
            editCoupon.COUP_Status = status;

            ctx.SubmitChanges();
        }

        public void deleteCoupon(int couponid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var coupons = from c in ctx.COUP_COUPONs
                          where c.COUP_ID == couponid
                          select c;

            ctx.COUP_COUPONs.DeleteAllOnSubmit(coupons);
            ctx.SubmitChanges();
        }

        public List<COUP_COUPON> searchCoupon(int couponid, int userid, int categoryid, string pass, double value, int status)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var coupons = from c in ctx.COUP_COUPONs
                          where c.COUP_ID == (couponid == null ? c.COUP_ID : couponid)
                          && c.COUP_UserID == (userid == null ? c.COUP_UserID : userid)
                          && c.COUP_CategoryID == (categoryid == null ? c.COUP_CategoryID : categoryid)
                          && c.COUP_Pass == (pass == null ? c.COUP_Pass : pass)
                          && c.COUP_Value == (value == null ? c.COUP_Value : value)
                          && c.COUP_Status == (status == null ? c.COUP_Status : status)
                          select c;

            return coupons.ToList();
        }

    }
}