<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="alithiatools.aspx.cs" Inherits="alithiatools" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="uploadButton" runat="server" OnClick="uploadButton_Click" Text="Upload" />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" BackColor="WhiteSmoke" BorderColor="Red" BorderStyle="Solid" CellPadding="0" EnableSortingAndPagingCallbacks="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="600px">
    </asp:GridView>
</asp:Content>

