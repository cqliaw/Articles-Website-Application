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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showContent.Value = "false";
            }

            if (HttpContext.Current.Application["AccessToken"] != null)
            {
                showContent.Value = "true";
            }
            RDSContext rdsContext = RDSContext.Create();
            string displayContent;
            int index = 1;
            rdsContext.news.ToList().ForEach(n =>
            {
                displayContent = NewsViewHelpers.GetNewsView(n.NewsTitle, n.NewsVisibleDetails, n.NewsHiddenDetails, n.ImageUrl, index);
                Content.Controls.Add(new Literal
                { Text = displayContent }
                );
                index = index + 1;
            });
        }
    }
}
