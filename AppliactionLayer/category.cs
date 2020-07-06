using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace AppliactionLayer
{
    public class category
    {
        public void addCategory(string name, int parentCatID, string icon)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            CAT_CATEGORY newCategory = new DataLayer.CAT_CATEGORY();

            newCategory.CAT_Name = name;
            newCategory.CAT_ParentCatID = parentCatID;
            newCategory.CAT_Icon = icon;

            ctx.CAT_CATEGORies.InsertOnSubmit(newCategory);
            ctx.SubmitChanges();
        }

        public void editCategory(int catid, string name, int parentCatID, string icon)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var categories = from c in ctx.CAT_CATEGORies
                             where c.CAT_ID == catid
                             select c;

            if (categories.Count() < 1) return;

            var editCategory = categories.SingleOrDefault();

            editCategory.CAT_Name = name;
            editCategory.CAT_ParentCatID = parentCatID;
            editCategory.CAT_Icon = icon;

            ctx.SubmitChanges();
        }

        public void deleteCategory(int catid)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var subcategories = from c in ctx.CAT_CATEGORies
                                where c.CAT_ParentCatID == catid
                                select c;

            ctx.CAT_CATEGORies.DeleteAllOnSubmit(subcategories);
            ctx.SubmitChanges();

            var categories = from c in ctx.CAT_CATEGORies
                             where c.CAT_ID == catid
                             select c;

            ctx.CAT_CATEGORies.DeleteAllOnSubmit(categories);
            ctx.SubmitChanges();
        }

        public List<CAT_CATEGORY> searchCategory(int catid, string name, int parentCatID, string icon)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var categories = from c in ctx.CAT_CATEGORies
                             where c.CAT_ID == (catid == null ? c.CAT_ID : catid)
                             && c.CAT_Name == (name == null ? c.CAT_Name : name)
                             && c.CAT_ParentCatID == (parentCatID == null ? c.CAT_ParentCatID : parentCatID)
                             && c.CAT_Icon == (icon == null ? c.CAT_Icon : icon)
                             select c;

            return categories.ToList();
        }

        public List<CAT_CATEGORY> getAllCategories()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var categories = from c in ctx.CAT_CATEGORies
                             where c.CAT_ParentCatID == null
                             select c;

            return categories.ToList();
        }

        public List<string> GetAllSubCategories()
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var subCategories = from c in ctx.CAT_CATEGORies
                                where c.CAT_ParentCatID != null
                                select c.CAT_Name;

            return subCategories.ToList();
        }

        public List<string> GetSubCategories(string categoryName)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();

            var categoryID = from c in ctx.CAT_CATEGORies
                                where c.CAT_Name == categoryName
                                select c.CAT_ID;



            var cID = categoryID.SingleOrDefault();

            var subCategories = from c in ctx.CAT_CATEGORies
                                where c.CAT_ParentCatID == cID
                                select c.CAT_Name;

            return subCategories.ToList();




        }

        public string getCategoryNameByCategoryID(int categoryID, string dil)
        {
            eCommerceDataClassesDataContext ctx = new eCommerceDataClassesDataContext();
            var categoryName="";

            if (dil == "TR")
            {
                categoryName = (from c in ctx.CAT_CATEGORies
                                    where c.CAT_ID == categoryID
                                    select c.CAT_Name).SingleOrDefault();
            }
            else if (dil == "ENG")
            {
                categoryName = (from c in ctx.CAT_CATEGORies
                                    where c.CAT_ID == categoryID
                                    select c.CAT_Name_ENG).SingleOrDefault();
            }

            return categoryName;

        }

    }
}