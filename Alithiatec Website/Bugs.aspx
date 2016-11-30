<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bugs.aspx.cs" Inherits="Bugs" Title="AlithiaTec.com - Submit a bug report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td style="width: 120px">
                <span style="font-size: 16pt; color: #316ac5">Bug Report</span></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Clear Form" OnClick="Button1_Click1" /></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Your Name</td>
            <td>
                <asp:TextBox ID="name" runat="server" MaxLength="255" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Your Email</td>
            <td>
                <asp:TextBox ID="senderEmail" runat="server" MaxLength="230" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Product</td>
            <td>
                <asp:ListBox 
                ID="product" 
                runat="server" 
                Rows="1" 
                AutoPostBack="True" 
                DataMember="item"
                DataValueField="name"
                DataTextField="name"
                DataSourceID="XmlDataSource1"
                OnSelectedIndexChanged="product_SelectedIndexChanged" OnInit="product_Init" OnPreRender="product_PreRender">
                </asp:ListBox>
                
                <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/products.xml" XPath="Data/Applications[@type='desktop']/item">
                </asp:XmlDataSource>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Version</td>
            <td>
                <asp:ListBox 
                ID="productVersion" 
                runat="server"
                DataSourceID="XmlDataSource2"
                Rows="1" OnLoad="productVersion_Load">
                </asp:ListBox>
                <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/products.xml"></asp:XmlDataSource>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Bug Description /<br />
                Steps to Reproduce</td>
            <td>
                <asp:TextBox ID="bug" runat="server" MaxLength="20000" Rows="10" TextMode="MultiLine"
                    Width="640px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
            </td>
            <td>
                <asp:Button ID="sendReport" runat="server" OnClick="Button1_Click" Text="Submit Bug Report" /></td>
        </tr>
        <tr>
            <td style="text-align: right">
            </td>
            <td>
                <asp:Label ID="status" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

