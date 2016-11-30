<%@ Control className="ThumbPane" Language="C#" AutoEventWireup="true" CodeFile="ThumbPane.ascx.cs" Inherits="ThumbPane" %>
<%@ Register Src="JSPopImage.ascx" TagName="JSPopImage" TagPrefix="uc2" %>
<%@ Register Src="DirectoryLister.ascx" TagName="DirectoryLister" TagPrefix="uc1" %>
<asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <uc2:JSPopImage ID="JSPopImage1" runat="server" />
</asp:Panel>
