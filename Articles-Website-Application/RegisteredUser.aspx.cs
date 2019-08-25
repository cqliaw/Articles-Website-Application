using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Articles_Website_Application
{
    public partial class RegisteredUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Application["AccessToken"] != null)
            {
                List<UserType> userList = new List<UserType>();
                List<string> emailList = new List<string>();

                string access_key = "AKIAJ5D7L2Y3C7DWLEKQ";
                string secret_key = "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";

                BasicAWSCredentials basicAWSCredentials = new BasicAWSCredentials(access_key, secret_key);

                AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(basicAWSCredentials);

                if (HttpContext.Current.Application["AccessToken"] != null)
                {
                    ListUsersRequest listUserRequest = new ListUsersRequest
                    {
                        UserPoolId = ConfigurationManager.AppSettings["USERPOOL_ID"],
                        AttributesToGet = new List<string> { "email" },

                    };

                    ListUsersResponse response = provider.ListUsers(listUserRequest);

                    userList.AddRange(response.Users);

                    foreach(UserType u in userList)
                    {
                        //emailList.Add(u.Attributes);
                    }

                    GV1.DataSource = emailList;
                    GV1.DataBind();
                }
            }
        }
    }
}