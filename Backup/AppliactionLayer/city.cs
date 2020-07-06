using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class city
    {
        public List<CITY_CITY> getCities(int countryid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var cities = from c in ctx.CITY_CITies
                         where c.CITY_CountryID == countryid
                         select c;

            return cities.ToList();
        }

        public bool InsertCity(int countryID ,string cityName)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            CITY_CITY city = new CITY_CITY();

            var cty = from c in ctx.CITY_CITies
                      where c.CITY_Name == cityName
                      select c;

            if (cty.Count() > 0) return false;

            city.CITY_CountryID = countryID;
            city.CITY_Name = cityName;
            ctx.CITY_CITies.InsertOnSubmit(city);
            ctx.SubmitChanges();

            return true;
        }

        public int GetCityIDbyName(string cityname)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

          

                var city = (from c in ctx.CITY_CITies
                            where c.CITY_Name == cityname
                            select c.CITY_ID).SingleOrDefault();

                return city;
            
        }

        public bool EditCity(int cityID,string cityName,int countryID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var city = (from c in ctx.CITY_CITies
                       where c.CITY_ID == cityID
                       select c).SingleOrDefault();
            
            city.CITY_Name = cityName;
            city.CITY_CountryID = countryID;

            ctx.SubmitChanges();

            return true;



        }

        public int GetCityIDbyTownID(int townID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var cityID = (from c in ctx.TOWN_TOWNs
                         where c.TOWN_ID == townID
                         select c.TOWN_CityID).SingleOrDefault();

            return cityID;
        }

        public string GetCityNameByCityID(int cityID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var cityname = (from c in ctx.CITY_CITies
                           where c.CITY_ID == cityID
                           select c.CITY_Name).SingleOrDefault();

            return cityname;


        }
    }
}