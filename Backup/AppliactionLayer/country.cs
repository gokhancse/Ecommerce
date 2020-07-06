using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class country
    {
        public List<CNTR_COUNTRY> getCountries()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            return ctx.CNTR_COUNTRies.ToList();
        }
        
        public bool InsertCountry(string countryName)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            CNTR_COUNTRY country = new CNTR_COUNTRY();

            var cnt = from c in ctx.CNTR_COUNTRies
                      where c.CNTR_Name == countryName
                      select c;

            if (cnt.Count() > 0) return false;

            country.CNTR_Name = countryName;
            ctx.CNTR_COUNTRies.InsertOnSubmit(country);
            ctx.SubmitChanges();
            return true;
           
        }
         
        public bool EditCountry(int countryID,string countryName)
        {

            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var country = (from c in ctx.CNTR_COUNTRies
                          where c.CNTR_ID == countryID
                          select c).SingleOrDefault();

            country.CNTR_Name = countryName;

            ctx.SubmitChanges();

            return true;
        }

        public int GetCountryIDbyName(string countryName)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var ID = (from c in ctx.CNTR_COUNTRies
                     where c.CNTR_Name == countryName
                     select c.CNTR_ID).SingleOrDefault();

            return ID;
        }

        public int GetCountryIDByCityID(int cityID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var countryID = (from c in ctx.CITY_CITies
                             where c.CITY_ID == cityID
                             select c.CITY_CountryID).SingleOrDefault();

            return countryID;

        }

        public string GetCountryNameByCountryID(int countryID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var countryname = (from c in ctx.CNTR_COUNTRies
                               where c.CNTR_ID == countryID
                               select c.CNTR_Name).SingleOrDefault();

            return countryname;

        }
    }
}