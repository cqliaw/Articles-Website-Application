using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
namespace Articles_Website_Application
{
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string accessToken = await AuthorizeUser();

                if(accessToken != null)
                {
                    HttpContext.Current.Application["AccessToken"] = accessToken;

                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
                var script = string.Format("alert({0});", message);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", script, true);
            }
        }

        public async Task<String> AuthorizeUser()
        {
            try
            {
                AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials());
                CognitoUserPool userPool = new CognitoUserPool(ConfigurationManager.AppSettings["USERPOOL_ID"],
                ConfigurationManager.AppSettings["CLIENT_ID"], provider);

                CognitoUser cognitoUser = new CognitoUser(inputEmail.Value, ConfigurationManager.AppSettings["CLIENT_ID"], userPool, provider);

                InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
                {
                    Password = inputPassword.Value
                };

                AuthFlowResponse authFlowResponse = await cognitoUser.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);

                if (authFlowResponse.AuthenticationResult != null)
                {
                    return authFlowResponse.AuthenticationResult.AccessToken;
                }
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
                var script = string.Format("alert({0});", message);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message + "');", true);
            }
            return null;
        }
    }
}