using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class comment
    {
        public void addComment(int prodid, int userid,string tittle,string message, int vote)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            COMM_COMMENT newcomment = new COMM_COMMENT();

            newcomment.COMM_ProdID = prodid;
            newcomment.COMM_UserID = userid;
            newcomment.COMM_Tittle = tittle;
            newcomment.COMM_Message = message;
            newcomment.COMM_Vote = vote;

            ctx.COMM_COMMENTs.InsertOnSubmit(newcomment);
            ctx.SubmitChanges();
        }

        public void deleteComment(int commid) 
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var comments = from c in ctx.COMM_COMMENTs
                          where c.COMM_ID == commid
                          select c;

            ctx.COMM_COMMENTs.DeleteAllOnSubmit(comments);
            ctx.SubmitChanges();

        }
    }
}