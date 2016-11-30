<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyMusic.aspx.cs" Inherits="MyMusic" Title="AlithiaTec.com - Music Compositions" %>

<%@ Register Src="DirectoryLister.ascx" TagName="DirectoryLister" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
   Here are various samples of my music both complete and incomplete... enjoy :)</h1>
   
   Some of these songs are in massive need of mastering (filtering, compression, limiting,
    resonance removal, stereo adjustment, etc.). So my apologies if the levels are all over the place and cause thine ears discomfort...<br />
    <h2>Full Songs:</h2>
    <uc1:DirectoryLister ID="DirectoryLister1" runat="server" Path="~/mymusic/full"/>
    <br />
    <h2>Samples:</h2>
    <uc1:DirectoryLister ID="DirectoryLister2" runat="server" Path="~/mymusic/samples"/>
    <br />
    To listen to the songs in your browser get a plugin that supports mp3 playback such
    as <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.apple.com/quicktime/download/win.html">QuickTime</asp:HyperLink> 
    and disable any download managers that interfere with clicking on links. Otherwise,
    you need to save the songs to your computer first.<br />
    <br />
    You know you've got music on the brain when you start humming tunes to the droning noise of household appliances (i.e. microwaves, fridges, vacuums, etc.). If this has happened to you, you may be in need of musical discharge.    
</asp:Content>

