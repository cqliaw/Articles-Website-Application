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
            HtmlAnchor logOutAnchor = (HtmlAnchor)Page.Master.FindControl("LogOutAnchor");
            HtmlAnchor loginAnchor = (HtmlAnchor)Page.Master.FindControl("LoginAnchor");
            HtmlAnchor signUpAchor = (HtmlAnchor)Page.Master.FindControl("SignUpAnchor");
            HtmlAnchor registeredAnchor = (HtmlAnchor)Page.Master.FindControl("RegisteredAnchor");

            if (HttpContext.Current.Application["AccessToken"] != null)
            {

                loginAnchor.Style.Add("display", "none");
                logOutAnchor.Style.Add("display", "block");
                signUpAchor.Style.Add("display", "none");
                registeredAnchor.Style.Add("display", "block");
            }
            else
            {
                loginAnchor.Style.Add("display", "block");
                logOutAnchor.Style.Add("display", "none");
                signUpAchor.Style.Add("display", "block");
                registeredAnchor.Style.Add("display", "none");
            }
        }
    }
}