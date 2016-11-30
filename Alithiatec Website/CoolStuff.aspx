<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CoolStuff.aspx.cs" Inherits="CoolStuff" Title="AlithiaTec.com - Useful Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Here are some useful tools found on the web:<br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.truecrypt.org/">Open-source disk encryption software for Windows XP/2000/2003 and Linux - http://www.truecrypt.org/</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://free.grisoft.com/">GRISOFT AVG anti-virus and anti-spyware free for personal use - http://free.grisoft.com/</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://sourceforge.net/projects/freemeter/">FreeMeter Bandwidth Monitor For Windows</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://mpesch3.de1.cc/mp3dc.html">Freeware fast mp3 editor - mp3DirectCut - http://mpesch3.de1.cc/mp3dc.html</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://www.doom9.org/">Open-source DVD backup - the definitive resource - http://www.doom9.org/</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="http://pacificcoast.net/~gthompson/">Need a FREE fully-loaded Canadian income tax program that prints CRA approved forms? (sorry, no efile)...Download Taxman</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="http://myepisodes.com/">Keep track of all the tv you've watched at http://myepisodes.com/</asp:HyperLink><br />
    <br />
    Worthwhile reading:<br />
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.einstein-website.de/z_biography/credo.html">Einstein's Credo</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://www.greecefoods.com/">A great guide to the Greek culinary experience!</asp:HyperLink>
<% //<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl=" "></asp:HyperLink> %>
    <br />
    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.ddj.com/dept/architect/189401902">Quick Kill Software Project Management</asp:HyperLink><br />
    <br />
    Funny:<br />
    <br />
    NTU Student survey - Funny course comments<br />
    <% Response.Write("<object width=\"425\" height=\"350\"><param name=\"movie\" value=\"http://www.youtube.com/v/QOqXlbWf9Io\"></param><param name=\"wmode\" value=\"transparent\"></param><embed src=\"http://www.youtube.com/v/QOqXlbWf9Io\" type=\"application/x-shockwave-flash\" wmode=\"transparent\" width=\"425\" height=\"350\"></embed></object>"); %>
    <br />
    Bugatti Veyron reaches 407 km/h<br />
    <% Response.Write("<object width=\"425\" height=\"350\"><param name=\"movie\" value=\"http://www.youtube.com/v/SOAyLGH1sFo\"></param><param name=\"wmode\" value=\"transparent\"></param><embed src=\"http://www.youtube.com/v/SOAyLGH1sFo\" type=\"application/x-shockwave-flash\" wmode=\"transparent\" width=\"425\" height=\"350\"></embed></object>"); %>
    <br />
    Top Gear - Reliant Robin Space Shuttle crash<br />
    <% Response.Write("<object width=\"425\" height=\"350\"><param name=\"movie\" value=\"http://www.youtube.com/v/TN3JjUUdjWU\"></param><param name=\"wmode\" value=\"transparent\"></param><embed src=\"http://www.youtube.com/v/TN3JjUUdjWU\" type=\"application/x-shockwave-flash\" wmode=\"transparent\" width=\"425\" height=\"350\"></embed></object>"); %>
</asp:Content>

