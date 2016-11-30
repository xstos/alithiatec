<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeDupify.aspx.cs" Inherits="DeDupify" Title="AlithiaTec.com - DeDupify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="downloads/dedupify.exe">
                    DeDupify
                </a> locates duplicate files on your hard disk. Usage consists of three simple
    steps:<br />
    <br />
    1) Add the folders you wish to search for duplicates.&nbsp; You may also drag them
    into the list from windows explorer.<br />
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/dedupify-tut1.png" /><br />
    <br />
    2)&nbsp; Press scan now and wait until indexing is complete.<br />
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/dedupify-tut2.png" /><br />
    <br />
    3) The duplicates are painted alternating colors for easier visibility. Navigate
    the results and select files by clicking or using the array keys and using the shift/ctrl
    keys. Use the provided buttons to cut/copy/delete files.<br />
    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/dedupify tut3.png" />
</asp:Content>

