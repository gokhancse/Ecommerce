using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Collections;
using DataLayer;


namespace eCommerce
{
    public partial class contact : System.Web.UI.Page
    {


        public Hashtable kelime;
        public SiteDil s = new SiteDil();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            kelime = s.KelimeleriGetir();
            Label7.Text = kelime["10"].ToString();
            Label9.Text = kelime["19"].ToString();
            Label6.Text = kelime["11"].ToString();
            Label1.Text = kelime["20"].ToString();
            Label2.Text = kelime["21"].ToString(); ;
            Label3.Text = kelime["22"].ToString(); ;
            Label4.Text = kelime["19"].ToString(); ;
            Label5.Text = kelime["23"].ToString(); ;
            btnMessage.Text = kelime["24"].ToString();
            RequiredFieldValidator2.ErrorMessage = kelime["48"].ToString();
            RequiredFieldValidator3.ErrorMessage = kelime["48"].ToString();
            RequiredFieldValidator4.ErrorMessage = kelime["48"].ToString();
            RequiredFieldValidator5.ErrorMessage = kelime["48"].ToString();
            RequiredFieldValidator6.ErrorMessage = kelime["48"].ToString();

        }

        protected void btnMessage_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('"+kelime["49"].ToString()+"');</script>");
           
        }
    }
}