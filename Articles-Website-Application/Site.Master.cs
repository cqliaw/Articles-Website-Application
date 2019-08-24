using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Articles_Website_Application
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Application["AccessToken"] != null)
            {
                HtmlAnchor loginAnchor = (HtmlAnchor)(Page.Master.FindControl("LoginLink"));
                //HtmlAnchor welcomeMessage = (HtmlAnchor)(Page.Master.FindControl("Welcome"));
                //HtmlAnchor signup = (HtmlAnchor)(Page.Master.FindControl("SignUp"));
                if (loginAnchor != null)
                {
                    loginAnchor.InnerText = "LogOut";
                    //signup.Style.Add("display", "none");
                    //welcomeMessage.Style.Add("display", "block");
                    //welcomeMessage.Style.Add("disabled", "true");
                    //welcomeMessage.Style.Add("pointer-events", "none");
                }
               
            }
        }
    }
}