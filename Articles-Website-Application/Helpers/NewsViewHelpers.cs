using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Articles_Website_Application.Helpers
{
    //This class is used to bind the news content retrieved from database and bind to the UI
    public class NewsViewHelpers
    {
        public static string GetNewsView(string title, string visibleMessage, string hiddenMessage, string imageUrl, int index)
        {
            StringBuilder returnString = new StringBuilder();
            if (index % 2 != 0)
            {
                returnString.Append("<div class='row content-row'>");
                returnString.Append("<div class='col-md-5 col-sm-5 col-xs-12 news-content'><div class='visiblePart'><h2>");

            }
            if (index % 2 == 0)
            {
                returnString.Append("<div class='col-md-5 col-sm-5 col-sm=offset-2 col-md-offset-2 col-xs-12 news-content'> <div class='visiblePart'> <h2>");
            }

            returnString.Append(title + "</h2>");
            returnString.Append("<div class='news-image'><img src='" + imageUrl + "'/></div>");
            returnString.Append("<h4 class='lead' style='border-bottom:1px solid light-grey'>");
            returnString.Append(visibleMessage);
            returnString.Append("</h4><p class='content-button'><a class='btn btn-primary btn-lg' runat='server' onclick='toggle(this)'>Read more &raquo;</a></p></div>");
            returnString.Append("<div class='hiddenPart'><div class='row' runat='server'>");
            returnString.Append("<div class='col-md-12'><p>" + hiddenMessage + "</p></div>");
            returnString.Append("</div></div></div>");

            if (index % 2 == 0)
            {
                returnString.Append("</div>");

            }
            return returnString.ToString();
        }
    }
}