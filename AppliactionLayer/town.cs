using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class town
    {
        public List<DataLayer.TOWN_TOWN> getTowns(int cityid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var towns = from c in ctx.TOWN_TOWNs
                        where c.TOWN_CityID == cityid
                        select c;

            return towns.ToList();

        }

        public bool InsertTown(int cityID,string townname)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            TOWN_TOWN town = new TOWN_TOWN();

            var twn = from c in ctx.TOWN_TOWNs
                      where c.TOWN_Name == townname
                      select c;

            if (twn.Count() > 0) return false;

            town.TOWN_CityID = cityID;
            town.TOWN_Name = townname;

            ctx.TOWN_TOWNs.InsertOnSubmit(town);
            ctx.SubmitChanges();

            return true;
            

        }

        public int GetTownIDbyName(string townname)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

                var town = (from c in ctx.TOWN_TOWNs
                           where c.TOWN_Name == townname
                           select c.TOWN_ID).SingleOrDefault();

                return town;

            }

        public bool EditTown(int townID,string townName,int townCityID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var town = (from c in ctx.TOWN_TOWNs
                       where c.TOWN_ID == townID
                       select c).SingleOrDefault();

            town.TOWN_CityID = townCityID;
            town.TOWN_Name = townName;

            ctx.SubmitChanges();

            return true;


        }

        public string getTownNameByTownID(int townID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var townname = (from c in ctx.TOWN_TOWNs
                            where c.TOWN_ID == townID
                            select c.TOWN_Name).SingleOrDefault();

            return townname;


        }
        
    }
}