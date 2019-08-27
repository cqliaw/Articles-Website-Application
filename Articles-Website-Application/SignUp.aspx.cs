using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Articles_Website_Application
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public async Task<bool> SignUpUser()
        {
            AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials());

            SignUpRequest signUpRequest = new SignUpRequest
            {
                ClientId = ConfigurationManager.AppSettings["CLIENT_ID"],
                Username = emailInput.Value,
                Password = passwordInput.Value
            };



            AttributeType emailAttr = new AttributeType
            {
                Name = "email",
                Value = emailInput.Value
            };
            signUpRequest.UserAttributes.Add(emailAttr);

            AttributeType givenNameAttr = new AttributeType
            {
                Name = "given_name",
                Value = firstNameInput.Value
            };
            signUpRequest.UserAttributes.Add(givenNameAttr);

            AttributeType familyNameAttr = new AttributeType
            {
                Name = "family_name",
                Value = lastNameInput.Value
            };
            signUpRequest.UserAttributes.Add(familyNameAttr);

            try
            {
                SignUpResponse result = await provider.SignUpAsync(signUpRequest);
                return true;
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
                var script = string.Format("alert({0});", message);

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", script, true);
                return false;
            }
        }

        protected async void signUpButton_Click(object sender, EventArgs e)
        {
            bool signedUp = await SignUpUser();
            if (signedUp)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('The new user has been registered! \\nPlease check your email to verify your account!');window.location.href='Login.aspx';", true);
            }
        }
    }
}