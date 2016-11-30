<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IBMRobot.aspx.cs" Inherits="IBMRobot" Title="AlithiaTec.com - Capstone Design Project" %>

<%@ Register Src="ThumbPane.ascx" TagName="ThumbPane" TagPrefix="uc1" %>

<%@ Register Assembly="Bright.WebControls" Namespace="Bright.WebControls" TagPrefix="bri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Here are images and videos from our Capstone Design Project. The aim of the course
    was to develop a maze-navigating robot that cleared at least one type of blockage.
    Ours cleared both wall barriers made of stretched paper or crumpled pieces of paper
    in an innovative hybrid design (the only robot that could do this). The competition
    was judged by IBM and we tied for first place and each group member was awarded
    125$.<br /><br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://dailynews.mcmaster.ca/story.cfm?id=2868">Here is an article about the competition.</asp:HyperLink>
    <br />
    I'm missing from the ceremony as I was ill the day after we won. This may have had something to do with the fact I didn't sleep for three days straight before the deadline due to last-minute complications.
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="Server" >
        <table>
            <tr>
                <td>
                <% Response.Write("<object width=\"425\" height=\"350\"><param name=\"movie\" value=\"http://www.youtube.com/v/dgdqQvOI9NA\"></param><embed src=\"http://www.youtube.com/v/dgdqQvOI9NA\" type=\"application/x-shockwave-flash\" width=\"425\" height=\"350\"></embed></object>"); %>
                </td>
                <td>
                <% Response.Write("<object width=\"425\" height=\"350\"><param name=\"movie\" value=\"http://www.youtube.com/v/Ec1f8PO4XkE\"></param><embed src=\"http://www.youtube.com/v/Ec1f8PO4XkE\" type=\"application/x-shockwave-flash\" width=\"425\" height=\"350\"></embed></object>"); %>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    Click a thumbnail to see the full-size image (popup).
    <uc1:ThumbPane ID="ThumbPane1" runat="server" Path="~/images/portfolio/ray" />
    
</asp:Content>

