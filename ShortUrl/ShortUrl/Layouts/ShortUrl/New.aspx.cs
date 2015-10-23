using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using wp = ShortUrl.RedirectWebPart;
using Microsoft.SharePoint.WebPartPages;

namespace ShortUrl.Layouts.ShortUrl
{
    public partial class New : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblExampleShortUrl.Text = SPContext.Current.Site.Url + "/ShortUrl";
            lblExampleRedirectUrl.Text = SPContext.Current.Site.Url + "/Some/Random/Sub/Page.aspx";
        }


        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            SPWeb web = SPContext.Current.Site.AllWebs.Add(tbShortUrl.Text, tbShortUrl.Text, "", 1033, "STS#1", false, false);
            web.AllProperties[Constants.pbKey] = tbRedirectUrl.Text;
            web.Update();

            using (SPLimitedWebPartManager wpManager = web.GetLimitedWebPartManager("default.aspx", System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared))
            {
                wp.RedirectWebPart webpart = new wp.RedirectWebPart();
                webpart.Title = "Redirect";
                wpManager.AddWebPart(webpart, "Top", 0);
            }

            web.Dispose();

            Response.Redirect(SPContext.Current.Site.Url + "/_layouts/ShortUrl/Manage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(SPContext.Current.Site.Url + "/_layouts/ShortUrl/Manage.aspx");
        }

        private bool IsValid()
        {
            lblError.Text = "";

            if (string.IsNullOrEmpty(tbShortUrl.Text))
                lblError.Text = "Enter a Short Url";
            else if (string.IsNullOrEmpty(tbRedirectUrl.Text))
                lblError.Text = "Enter a Redirect Url";
            else if (tbShortUrl.Text.IndexOfAny(Constants.illegalChars.ToCharArray()) != -1)
                lblError.Text = "Short Url cannot contain any special charactors: " + Constants.illegalChars;
            else if (SPContext.Current.Site.OpenWeb(tbShortUrl.Text).Exists)
                lblError.Text = "The short url is already in use, enter a different short url";

            return lblError.Text == "";
        }
    }
}
