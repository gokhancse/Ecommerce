using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class picture
    {
        public List<PIC_PRODUCTPICTURE> getPictures(int productid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var pictures = from c in ctx.PIC_PRODUCTPICTUREs
                           where c.PIC_ProdID == productid
                           select c;

            return pictures.ToList();
        }

        public string getFirstPicture(int productid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var pictures = from c in ctx.PIC_PRODUCTPICTUREs
                           where c.PIC_ProdID == productid
                           select c;

            if (pictures.Count() < 1) return "";

            return pictures.ToList()[0].PIC_PictureURL;
        }

        public string getPictureUrlByProductId(int prodid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var url = (from c in ctx.PIC_PRODUCTPICTUREs
                       where c.PIC_ProdID == prodid
                       select c.PIC_PictureURL).SingleOrDefault();

            return url;

        }

        public void AddPicture(int prodID ,string picUrl , int picorder) 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            PIC_PRODUCTPICTURE picentity = new PIC_PRODUCTPICTURE();

            picentity.PIC_ProdID = prodID;
            picentity.PIC_PictureURL = picUrl;
            picentity.PIC_Order = picorder;

            ctx.PIC_PRODUCTPICTUREs.InsertOnSubmit(picentity);
            ctx.SubmitChanges();

        }

        public void EditPicture(int prodID, string picUrl, int picorder)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var prod = (from c in ctx.PIC_PRODUCTPICTUREs
                        where c.PIC_ProdID == prodID
                        select c).SingleOrDefault();

            prod.PIC_PictureURL = picUrl;
            prod.PIC_Order = picorder;

            ctx.SubmitChanges();

        }

        public void DeletePicture(int prodID) 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var pic = (from c in ctx.PIC_PRODUCTPICTUREs
                      where c.PIC_ProdID == prodID
                      select c).SingleOrDefault();

            ctx.PIC_PRODUCTPICTUREs.DeleteOnSubmit(pic);
            ctx.SubmitChanges();
        }
    }
}