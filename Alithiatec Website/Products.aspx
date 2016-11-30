<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Products.aspx.cs" Inherits="Default2" Title="AlithiaTec.com - Products" %>

<%@ Register Src="AdSense.ascx" TagName="AdSense" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <span style="font-size: 24pt; color: #316ac5"><strong>AlithiaTec Products:<br />
    </strong></span><span style="color: #696969"><strong>Sparing you from tedious tasks,
        to tackle the important stuff.<br />
        <br />
    </strong></span>
    <table style="" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%; text-align: center">
                <span style="color: #191970"><strong><span style="font-size: 14pt">
                    <br />
                    Our <span style="color: #1e90ff">FREE</span> Flagship Utility</span></strong> </span><br />
                <a href="downloads/rapidfetch.exe">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/rapidfetch.jpg" /></a><br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RapidFetch.aspx">Learn More</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <br />
                <strong><span style="color: #191970"><span style="font-size: 14pt">Another useful free
                    utility: </span></span></strong>
                <br />
                <br />
                <a href="downloads/dedupify.exe">DeDupify</a> - Finds and deals with duplicate files
                on your computer.&nbsp; Great for managing all that accumulated clutter!<br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/DeDupify.aspx">Learn More</asp:HyperLink></td>
        </tr>
    </table>
    <br />
</asp:Content>
