using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace ShortUrl.Layouts.ShortUrl
{
    public partial class Edit : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string shortUrl = Request.QueryString["ShortUrl"];

            if (!string.IsNullOrEmpty(shortUrl))
            {
                lblShortUrl.Text = shortUrl;
                using (SPWeb web = SPContext.Current.Site.OpenWeb(shortUrl))
                {
                    if (web.Exists)
                        lblRedirectUrl.Text = web.AllProperties[Constants.pbKey] == null ?
                            "" : web.AllProperties[Constants.pbKey].ToString();
                    else
                        HideForm();
                }
            }
            else
            {
                HideForm();
            }

        }

        private void HideForm()
        {
            tbRedirectUrl.Enabled = false;
            btnSave.Enabled = false;
            lblError.Text = "The site cannot be found";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SPWeb web = SPContext.Current.Site.OpenWeb(lblShortUrl.Text))
            {
                web.AllProperties[Constants.pbKey] = tbRedirectUrl.Text;
                web.Update();
            }

            Response.Redirect(SPContext.Current.Site.Url + "/_layouts/ShortUrl/Manage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(SPContext.Current.Site.Url + "/_layouts/ShortUrl/Manage.aspx");
        }
    }
}
