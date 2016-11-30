<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Resume.aspx.cs" Inherits="Resume" Title="AlithiaTec.com - Resume - Chris C" EnableSessionState="True" %>

<%@ Register Src="DirectoryLister.ascx" TagName="DirectoryLister" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        My resume (doc/pdf):</h3>
    <uc1:DirectoryLister ID="DirectoryLister1" runat="server" SearchPatterns="*.pdf/*.doc" Path="~/downloads"/>
</asp:Content>

