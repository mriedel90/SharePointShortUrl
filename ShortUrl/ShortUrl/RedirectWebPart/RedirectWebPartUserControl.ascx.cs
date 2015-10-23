using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace ShortUrl.RedirectWebPart
{
    public partial class RedirectWebPartUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var redirectUrl = SPContext.Current.Web.AllProperties[Constants.pbKey];
            if (redirectUrl == null)
                return;
            Page.Response.Redirect(redirectUrl.ToString());
        }
    }
}
