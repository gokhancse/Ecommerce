using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppliactionLayer;
using System.Collections;
using DataLayer;

namespace eCommerce
{
    public partial class signup : System.Web.UI.Page
    {
        user userObj = new user();
        city cityObj = new city();
        country countryObj = new country();
        town townObj = new town();
        address addrObj = new address();
        basket basketObj = new basket();
        public Hashtable kelime;
        public SiteDil s = new SiteDil();
        protected void Page_Load(object sender, EventArgs e)
        {
                kelime = s.KelimeleriGetir();
                Label7.Text = kelime["10"].ToString();
                Label9.Text = kelime["31"].ToString();
                Label6.Text = kelime["29"].ToString();
                Label1.Text = kelime["20"].ToString();
                Label2.Text = kelime["21"].ToString();
                Label14.Text = kelime["22"].ToString();
                Label4.Text = kelime["27"].ToString();
                Label5.Text = kelime["28"].ToString();
                Label3.Text = kelime["26"].ToString();
                Label8.Text = kelime["30"].ToString();
                Label10.Text = kelime["32"].ToString();
                Label11.Text = kelime["39"].ToString();
                Label12.Text = kelime["19"].ToString();
                Label13.Text = kelime["33"].ToString();
                Button1.Text = kelime["24"].ToString();
                RequiredFieldValidator1.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator2.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator3.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator4.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator5.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator6.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator7.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator8.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator9.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator10.ErrorMessage = kelime["48"].ToString();
                RequiredFieldValidator11.ErrorMessage = kelime["48"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtPasswordRetype.Text)
            {
                int oldID = Convert.ToInt32(Session["userid"]);
                countryObj.InsertCountry(txtCountry.Text);
                int countryID = countryObj.GetCountryIDbyName(txtCountry.Text);

                cityObj.InsertCity(countryID, txtCity.Text);
                int cityID = cityObj.GetCityIDbyName(txtCity.Text);

                townObj.InsertTown(cityID, txtTown.Text);

                int townID = townObj.GetTownIDbyName(txtTown.Text);

                userObj.InsertUser(txtEmail.Text, txtPassword.Text, txtName.Text, txtSurname.Text, txtPhone.Text, txtGSM.Text, townID);

                int userID = userObj.GetUserIDbyMail(txtEmail.Text);
                addrObj.addAddress(txtAddress.Text, userID, townID, txtAddress.Text, txtName.Text, txtSurname.Text, txtPhone.Text, txtGSM.Text);

                Session["userid"] = userID;
                if (oldID != 0)
                {
                    int newID = userID;
                    basketObj.ChangeBasketID(oldID, newID);
                    //    userObj.DeleteUser(oldID);
                }

                Lblregistration.Text = kelime["40"].ToString();
                Lblregistration.Visible = true;
            }
            else {

                Lblregistration.Text = kelime["41"].ToString();
                Lblregistration.Visible = true;
            }
           
        
        }
    }
}