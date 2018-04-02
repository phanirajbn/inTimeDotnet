using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessLayerLib;
namespace SampleWebApp
{
    public partial class Registration : System.Web.UI.Page
    {
        static RestaurantBal balComponent = new RestaurantBal();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //This is an event handler for the click event of the Button, if this button is clicked in the browser, the Application will invoke this function......
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                Restaurant hotel = new Restaurant();
                hotel.Name = txtName.Text;
                hotel.Address = txtAddress.Text;
                hotel.EmailAddress = txtEmail.Text;
                hotel.PhoneNo = long.Parse(txtPhone.Text);
                hotel.UserName = txtUserName.Text;
                hotel.Password = txtPassword.Text;
                try
                {
                    balComponent.RegisterUser(hotel);
                    Session.Add("UserInfo", hotel);//storing the logged hotel detail....
                    Session.Add("bal", balComponent);//For retaining the same component.... 
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;                    
                }
                //var ourData = Application["Hotels"] as List<RestaurantEntity>;
                //ourData.Add(hotel);
                //Application["Hotels"] = ourData;
                //var users = Application["Logins"] as Dictionary<string, string>;
                //if (users.ContainsKey(txtUserName.Text))
                //{
                //    throw new Exception("User already Exists");
                //}
                //users[txtUserName.Text] = txtPassword.Text;
                //users.Add(txtUserName.Text, txtPassword.Text);
                //It creates a new key and sets a value to that key..
                //Application["Logins"] = users;
                Response.Redirect("HomePage.aspx");
            }
        }
        //This function is called as a server side validation for UR Custom validator. This validation will be the last, all the other client side validations should be accomplished before the App hits the code...
        protected void Unnamed6_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //var users = Application["Logins"] as Dictionary<string, string>;
            //if (users.ContainsKey(args.Value))
            //{
            //    args.IsValid = false;
            //}
            args.IsValid = !balComponent.ValidateUser(txtUserName.Text, txtPassword.Text);
        }
    }
}