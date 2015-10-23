<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="ShortUrl.Layouts.ShortUrl.New" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <h2>Create a new Short Url</h2>

    <h3>Short Url:</h3>
    <p>Enter "ShortUrl" for the Short Url to be <asp:Label ID="lblExampleShortUrl" runat="server"></asp:Label>.  Cannot contain slashes or special characters.</p>
    <asp:TextBox ID="tbShortUrl" runat="server" placeholder="ShortUrl"></asp:TextBox>
    
    <h3>Redirect Url:</h3>
    <p>Enter "http://www.google.com" for the Short Url above to redirect to Google or enter "/Some/Random/Sub/Page.aspx" to redirect to  <asp:Label ID="lblExampleRedirectUrl" runat="server"></asp:Label>.</p>
    <asp:TextBox ID="tbRedirectUrl" runat="server" placeholder="http://www.google.com"></asp:TextBox>
    
    <br />
    <div>
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Submit" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </div>
    
    <div><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Short Url - New
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
New Short Url
</asp:Content>
