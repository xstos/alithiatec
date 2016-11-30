<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="AlithiaTec.com - Welcome!" %>

<%@ Register Src="AdSense.ascx" TagName="AdSense" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span style="color: #316AC5; font-size: 16pt;"><strong><span style="color: #696969">
        Introducing:<br />
        <br />
    </span></strong></span><span style="text-decoration: underline"></span>
    <table id="TABLE1" style="width: 100%;" cellpadding="3">
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <span style="font-size: 16pt"><strong><span style="color: #316ac5">RapidFetch</span></strong><span
                    style="color: #316ac5">
                    <br />
                    <br />
                </span></span>Tired of the regular windows search, the windows start menu, or navigating
                folders the <span style="text-decoration: underline">slow way</span> to find your
                documents, music, pictures, and <span style="text-decoration: underline">any</span>
                other miscellaneous files? This remarkably fast desktop search utility and file
                launcher lets you locate and open files on-demand, and returns results <span style="text-decoration: underline">
                    as you type!</span></td>
            <td style="text-align: left; vertical-align: top;">
                <span style="font-size: 16pt"><strong><span style="color: #316ac5">DeDupify</span></strong><span
                    style="color: #316ac5">
                    <br />
                    <br />
                </span></span>Personal computers are notorious for amassing clutter. File backups
                and moving files from one computer to another can leave your hard disk sprinkled
                with redundant files. DeDupify provides a fast and easy way to find those duplicates
                and consolidate them. Search results can also be saved and revisited at a later
                date.</td>
        </tr>
        <tr>
            <td style="text-align: center; vertical-align: top;">
                <a href="downloads/rapidfetch.exe">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/download_button.png" /><br />
                </a>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RapidFetch.aspx">Learn More</asp:HyperLink><br />
            </td>
            <td style="text-align: center; vertical-align: top;">
                <a href="downloads/dedupify.exe">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/download_button2.png" /><br />
                </a>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/DeDupify.aspx">Learn More</asp:HyperLink><br />
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/downloads/eula.txt">EULA</asp:HyperLink><br />
                <br />
                NOTE: DeDupify doesn't do anything to your files unless explicitly instructed to!</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <br />
                No install required. Both apps require the .NET 2.0 framework to run,<br />
                <br />
                <span style="color: #ff0000">so if you get an error like this:
                    <br />
                    "To run this application, you first must install one of the following versions of
                    the .Net Framework: V2.0.50727" </span>&nbsp;<br />
                <br />
                download .NET
                from Microsoft
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.microsoft.com/downloads/info.aspx?na=90&p=&SrcDisplayLang=en&SrcCategoryId=&SrcFamilyId=0856eacb-4362-4b0d-8edd-aab15c5e04f5&u=http%3a%2f%2fdownload.microsoft.com%2fdownload%2f5%2f6%2f7%2f567758a3-759e-473e-bf8f-52154438565a%2fdotnetfx.exe">here</asp:HyperLink>.</td>
        </tr>
    </table>
    <br />
    Alternate RapidFetch Download Link: <a href="http://www.download.com/RapidFetch/3000-2344-10659966.html?part=dl-RapidFet&subj=uo&tag=button"><img src="http://www.download.com/i/dl/button/anim_button.gif" alt="Get it from CNET Download.com!" height="60" width="150" align="middle" border="0"></a>
    <br />
    <br />
    Why another search utility? RapidFetch was built to address the following needs:<br />
    <br />
    <table style="font-size: smaller">
        <tr>
            <td style="color: #316ac5; background-color: #d3d3d3; text-align: center">
                <strong>Problem</strong></td>
            <td style="color: #316ac5; background-color: #d3d3d3; text-align: center">
                <strong>RapidFetch Solution</strong></td>
        </tr>
        <tr>
            <td>
                Windows explorer makes it tedious to search multiple folders at the same time.</td>
            <td>
                Provides labelled folder groups to search multiple areas of your computer simultaneously.</td>
        </tr>
        <tr>
            <td>
                The built-in search in windows explorer is slow and doesn't facilitate multiple
                searches in quick succession.</td>
            <td>
                Pre-searches folder groups on the fly and returns instantaneous results as you type
                to help guide and refine your search.</td>
        </tr>
        <tr>
            <td>
                Frequently-accessed areas of your computer such as the windows start menu, my documents,
                my music, favorites, internet history, etc, can involve repetitive, tedious, and
                time-consuming clicking and then browsing files to find and open what you're looking
                for.</td>
            <td>
                User-created or built-in folder groups double as instant "start menus" by simply
                clicking the relevant group, typing a part of the keyword until your result appears,
                and pressing enter or double clicking to open it.</td>
        </tr>
        <tr>
            <td>
                Other desktop search engines don't allow partial searches, meaning if you can't
                remember the exact keyword you're looking for, the correct results won't show up.</td>
            <td>
                Partial searches are supported. As soon as the first letter is typed in, results
                containing that letter appear immediately.</td>
        </tr>
        <tr>
            <td>
                There's no built-in way to get a file and folder listing.</td>
            <td>
                The search results can be saved to a spreadsheet.</td>
        </tr>
        <tr>
            <td>
                No easy-to-reach search exists on the Windows taskbar.</td>
            <td>
                When idle, RapidFetch can be conveniently hidden to the system tray, ready to be
                activated with a mouse-click.</td>
        </tr>
    </table>
    <br />
    Best of all, it's free, and continuously being improved through user
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Feedback.aspx">input</asp:HyperLink>!<br />
    <br />
</asp:Content>
