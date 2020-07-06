using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class manufacturer
    {
        public void addManufacturer(string name, string pictureURL, string starttime, string endtime)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            MAN_MANUFACTURER newMan = new DataLayer.MAN_MANUFACTURER();
            IFormatProvider culture = new System.Globalization.CultureInfo("tr-TR", true);

            newMan.MAN_Name = name;
            newMan.MAN_Picture = pictureURL;
            newMan.MAN_StartTime = DateTime.Parse(endtime, culture);
            newMan.MAN_EndTime = DateTime.Parse(endtime, culture);

            ctx.MAN_MANUFACTURERs.InsertOnSubmit(newMan);
            ctx.SubmitChanges();
        }

        public void editManufacturer(int manid, string name, string pictureURL)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var manufacturers = from c in ctx.MAN_MANUFACTURERs
                                where c.MAN_ID == manid
                                select c;

            if (manufacturers.Count() < 1) return;

            var editMan = manufacturers.SingleOrDefault();
            editMan.MAN_Name = name;
            editMan.MAN_Picture = pictureURL;

            ctx.SubmitChanges();
        }

        public void deleteManufacturer(int manid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var manufacturers = from c in ctx.MAN_MANUFACTURERs
                                where c.MAN_ID == manid
                                select c;

            ctx.MAN_MANUFACTURERs.DeleteAllOnSubmit(manufacturers);
            ctx.SubmitChanges();
        }

        public List<MAN_MANUFACTURER> searchManufacturer(int manid, string name, string pictureURL)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var manufacturers = from c in ctx.MAN_MANUFACTURERs
                                where c.MAN_ID == (manid == null ? c.MAN_ID : manid)
                                && c.MAN_Name.Contains(name == null ? c.MAN_Name : name)
                                && c.MAN_Picture == (pictureURL == null ? c.MAN_Picture : pictureURL)
                                select c;


            return manufacturers.ToList();
        }

        public List<MAN_MANUFACTURER> getActiveManufacturer()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var manufacturers = from c in ctx.MAN_MANUFACTURERs
                                where c.MAN_StartTime <= DateTime.Now
                                && c.MAN_EndTime >= DateTime.Now
                                select c;

            return manufacturers.ToList();
        }

        public List<MAN_MANUFACTURER> getAllManufacturer()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var manufacturers = from c in ctx.MAN_MANUFACTURERs
                                select c;

            return manufacturers.ToList();

        }

        public string getManNameByID(int manID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var man = (from c in ctx.MAN_MANUFACTURERs
                      where c.MAN_ID == manID
                      select c.MAN_Name).SingleOrDefault();
            return man;
        }
        

    }
}