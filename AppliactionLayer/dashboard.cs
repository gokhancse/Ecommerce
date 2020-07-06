using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class dashboard
    {
        public int adminLogin(string username, string password)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var users = from c in ctx.USER_USERs
                        where c.USER_Email == username
                        && c.USER_Password == password
                        && c.USER_TYPE == 99
                        select c;

            if (users.Count() < 1) return -1;

            return users.SingleOrDefault().USER_ID;
        }
    }
}