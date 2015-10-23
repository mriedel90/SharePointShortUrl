using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;

namespace ShortUrl.Layouts.ShortUrl
{
    public partial class Manage : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (SPWeb web in SPContext.Current.Site.AllWebs)
                {
                    if (web.AllProperties[Constants.pbKey] != null)
                        tblCurrent.Rows.Add(BuildCurrentItem(web));
                    else
                        blUnavailble.Items.Add(web.Url);
                }

                //show No Short Urls message
                lblNoUrls.Visible = tblCurrent.Rows.Count == 1;
                tblCurrent.Visible = tblCurrent.Rows.Count != 1;
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred - " + ex.Message;
            }
        }

        private TableRow BuildCurrentItem(SPWeb web)
        {
            TableRow row = new TableRow();

            //Short Url
            TableCell cell = new TableCell();
            cell.Controls.Add(new HyperLink() { Text = web.Url, NavigateUrl = web.Url });
            row.Cells.Add(cell);

            //Redirect Url
            cell = new TableCell();
            string redirectUrl = web.AllProperties[Constants.pbKey].ToString();
            cell.Controls.Add(new HyperLink() { Text = redirectUrl, NavigateUrl = redirectUrl });
            row.Cells.Add(cell);

            //Edit
            cell = new TableCell();
            cell.Controls.Add(new HyperLink() { Text = "Edit", NavigateUrl = "/_layouts/ShortUrl/Edit.aspx?ShortUrl=" + web.Url.Replace(web.Site.Url + "/", "") });
            row.Cells.Add(cell);

            //Delete
            cell = new TableCell();
            cell.Controls.Add(new HyperLink() { Text = "Delete", NavigateUrl = web.Url + "/_layouts/deleteweb.aspx" });
            row.Cells.Add(cell);

            return row;
        }

    }
}
