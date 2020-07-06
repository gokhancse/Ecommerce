using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class address
    {
        public int addAddress(string aliasname, int userid, int townid, string address, string name, string surname, string phone, string gsm)
        {
            try{
                    eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
                    DataLayer.ADDR_ADDRESS newAdres = new DataLayer.ADDR_ADDRESS();

                        newAdres.ADDR_Alias = aliasname;
                        newAdres.ADDR_TownID = townid;
                        newAdres.ADDR_UserID = userid;
                        newAdres.ADDR_Address1 = address;
                        newAdres.ADDR_Name = name;
                        newAdres.ADDR_Surname = surname;
                        newAdres.ADDR_Phone = phone;
                        newAdres.ADDR_GSM = gsm;

                        ctx.ADDR_ADDRESSes.InsertOnSubmit(newAdres);
                        ctx.SubmitChanges();
                        
                
                        return newAdres.ADDR_ID;
            }
            catch(Exception e) {
                throw e;
            }
  
        }

        public ADDR_ADDRESS GetUserAddressByUserID(int userID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var address = (from c in ctx.ADDR_ADDRESSes
                          where c.ADDR_UserID == userID
                           select c).SingleOrDefault(); 
            
            
            return address;

        }

        public bool EditAddress(int addressID,string aliasname, int userid, int townid, string addresss, string name, string surname, string phone, string gsm)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var address = (from c in ctx.ADDR_ADDRESSes
                          where c.ADDR_ID == addressID
                          select c).SingleOrDefault();

            address.ADDR_Alias = aliasname;
            address.ADDR_GSM = gsm;
            address.ADDR_UserID = userid;
            address.ADDR_TownID = townid;
            address.ADDR_Address1 = addresss;
            address.ADDR_Name = name;
            address.ADDR_Surname = surname;
            address.ADDR_GSM = gsm;
            address.ADDR_Phone = phone;

            ctx.SubmitChanges();


            return true;
        }

        public int GetAdressIDbyAddress(string address)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var ID = (from c in ctx.ADDR_ADDRESSes
                     where c.ADDR_Address1 == address
                     select c.ADDR_ID).SingleOrDefault();

            return ID;

        }

        public int GetAddressTownIDbyAddressID(int addressID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var townID = (from c in ctx.ADDR_ADDRESSes
                          where c.ADDR_ID == addressID
                          select c.ADDR_TownID).SingleOrDefault();

            return townID;
        }
    }
}