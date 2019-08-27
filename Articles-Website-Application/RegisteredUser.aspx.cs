using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Runtime;
using Articles_Website_Application.Helpers;
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
                List<AttributeType> attributeList = new List<AttributeType>();


                string accessKey = RDSContext.Create().awsCredentials.FirstOrDefault().AccessKey;
                string secretKey = RDSContext.Create().awsCredentials.FirstOrDefault().SecretKey;


                BasicAWSCredentials basicAWSCredentials = new BasicAWSCredentials(accessKey, secretKey);

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

                    foreach (UserType u in userList)
                    {
                        attributeList.AddRange(u.Attributes);
                    }
                    
                    GV1.DataSource = attributeList.Select(t => t.Value);
                    GV1.DataBind();
                    GV1.HeaderRow.Cells[0].Text = "Email List";
                }
            }
        }
    }
}