<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Utilities.aspx.cs" Inherits="Utilities" Title="AlithiaTec.com - Misc. Utilities" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Here are small miscellaneous utilities I created that don’t really belong in their
        own section:
    </h2>
    <h3>
        FolderPortal:</h3>
    <p>
        This little gizmo can help keep a list of commonly accessed folders right at your fingertips.&nbsp;
        Simply drag &amp; drop any folders you wish into the main window and then hide it to the system
        tray.&nbsp; Then, right-click on the application's tray icon (the
        little gear) to see a list of those folders, and click one to open
        it.&nbsp; Double-clicking any folder in the main window opens it as well.</p>
    <p>
        Download it here:
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="downloads/FolderPortal.exe">FolderPortal.exe</asp:HyperLink><br />
        <br />
        <span><span style="color: #ff0000">You need .NET to run it:</span></span>
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.microsoft.com/downloads/info.aspx?na=90&p=&SrcDisplayLang=en&SrcCategoryId=&SrcFamilyId=0856eacb-4362-4b0d-8edd-aab15c5e04f5&u=http%3a%2f%2fdownload.microsoft.com%2fdownload%2f5%2f6%2f7%2f567758a3-759e-473e-bf8f-52154438565a%2fdotnetfx.exe">Download it here from Microsoft.</asp:HyperLink></p>
    <h3>
        TLJExtractor:</h3>
    One day I found I wanted to listen to the ambient music in The Longest Journey (1)
    and couldn’t get the “gap” utility I found on some random website to work. So, I
    wrote this program to extract any stereo music it finds within the game resource
    files (.iss &amp; .xarc). I wrote it based on this wikipedia article: <a href="http://wiki.multimedia.cx/index.php?title=FunCom_ISS">
        http://wiki.multimedia.cx/index.php?title=FunCom_ISS</a> and I used this as
    reference: <a href="http://www.sonicspot.com/guide/wavefiles.html">http://www.sonicspot.com/guide/wavefiles.html</a>.
    Many thanks go out to the authors of those pages.
    <br />
    <br />
    If there’s interest I can easily add sound effect extraction, I was just feeling
    lazy ;)<br />
    <br />
    Download it here:
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="downloads/TLJExtractor.exe">TLJExtractor.exe</asp:HyperLink><br />
    <br />
    <span style="color: #ff0000">You need .NET to run it:</span>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.microsoft.com/downloads/info.aspx?na=90&p=&SrcDisplayLang=en&SrcCategoryId=&SrcFamilyId=0856eacb-4362-4b0d-8edd-aab15c5e04f5&u=http%3a%2f%2fdownload.microsoft.com%2fdownload%2f5%2f6%2f7%2f567758a3-759e-473e-bf8f-52154438565a%2fdotnetfx.exe">Download it here from Microsoft.</asp:HyperLink><br />
    <br />
    <h3>Escape Strings:</h3>
    This is a tool for converting HTML into escaped strings for use in ASP.NET. Enter
    your HTML into the box and press "Go".<br />
    <asp:TextBox ID="TextBox1" runat="server" Height="100px" Width="800px" MaxLength="2000" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click" Text="GO"
        Width="100px" />
</asp:Content>

