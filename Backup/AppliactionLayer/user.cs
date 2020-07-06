using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class user
    {
        public int getUserAddress(int userid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var userAdress = from c in ctx.ADDR_ADDRESSes
                             where c.ADDR_UserID == userid
                             select c;

            if (userAdress.Count() > 0) return userAdress.ToList()[0].ADDR_ID;
            else return -1;
        }

        public bool InsertUser(string email ,string password,string name ,string surname,string phone,string gsm,int town)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            USER_USER user = new USER_USER();

            user.USER_Email = email;
            user.USER_Password = password;
            user.USER_Name = name;
            user.USER_Surname = surname;
            user.USER_Phone = phone;
            user.USER_GSM = gsm;
            user.USER_Status = 1;
            user.USER_TYPE = 1;
            user.USER_Town = town;

            ctx.USER_USERs.InsertOnSubmit(user);
            ctx.SubmitChanges();

            return true;

           

        }
        
        public int GetUserIDbyMail(string mail)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var ID = (from c in ctx.USER_USERs
                     where c.USER_Email == mail
                     select c.USER_ID).SingleOrDefault();


            return ID;
        }

        public int userLoginCheck(string email ,string password)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var user = from c in ctx.USER_USERs
                       where c.USER_Email == email && c.USER_Password == password
                        select c;
            if (user.Count() < 1) return -1;

            return user.ToList()[0].USER_ID;
        }

        public USER_USER GetUserByID(int userID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var user = (from c in ctx.USER_USERs
                       where c.USER_ID == userID
                       select c).SingleOrDefault();

            return user;
        }

        public bool EditUser(int userID,string userName ,string userSurname ,string userMail ,string GSM)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var user = (from c in ctx.USER_USERs
                       where c.USER_ID == userID
                       select c).SingleOrDefault();

            user.USER_Name = userName;
            user.USER_Surname = userSurname;
            user.USER_Email = userMail;
            user.USER_GSM = GSM;

            ctx.SubmitChanges();
            return true;
            


        }
        
        public bool EditUserPassword(int userID,string password)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var user = (from c in ctx.USER_USERs
                       where c.USER_ID == userID
                       select c).SingleOrDefault();

            user.USER_Password = password;
            ctx.SubmitChanges();
            return true;
        }

        public int GetUserIDByUserName(string name)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var userID = (from c in ctx.USER_USERs
                          where c.USER_Name == name
                          select c.USER_ID).SingleOrDefault();

            return userID;

        }

        public bool DeleteUser(int userID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            DataLayer.USER_USER usr = new DataLayer.USER_USER();
            var user = from c in ctx.USER_USERs
                       where c.USER_ID == userID
                       select c;
            usr = user.SingleOrDefault();
            ctx.USER_USERs.DeleteOnSubmit(usr);
            ctx.SubmitChanges();
            return true;

        }

        public bool IsAdmin(int userID)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var user = from c in ctx.USER_USERs
                       where c.USER_ID == userID
                       where c.USER_TYPE == 2
                       select c;
            if (user.Count() > 0) return true;
            return false;

        }


    }
}