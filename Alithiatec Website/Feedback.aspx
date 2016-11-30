<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Bugs" Title="AlithiaTec.com - Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td style="width: 120px; text-align: center;">
                <span style="font-size: 16pt; color: dodgerblue">Contact Us</span></td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Clear Form" /></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                Your Name</td>
            <td>
                <asp:TextBox ID="_name" runat="server" MaxLength="255" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                Your Email</td>
            <td>
                <asp:TextBox ID="_senderEmail" runat="server" MaxLength="230" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                Subject</td>
            <td>
                <asp:TextBox ID="_subject" runat="server" Width="400px" MaxLength="255"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                Message Body</td>
            <td>
                <asp:TextBox ID="_message" runat="server" MaxLength="20000" Rows="10" TextMode="MultiLine"
                    Width="800px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
            </td>
            <td>
                <asp:Button ID="sendReport" runat="server" OnClick="Button1_Click" Text="Send Message" /></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
            </td>
            <td>
                <asp:Label ID="status" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

