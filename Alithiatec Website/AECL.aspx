<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AECL.aspx.cs" Inherits="AECL" Title="AlithiaTec.com - AECL Work" %>
<%@ Register Src="JSPopImage.ascx" TagName="JSPopImage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:JSPopImage runat=server/>
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td align="center">
                All work for Atomic Energy of Canada Ltd. (AECL) has primarily involved Visual Basic
                6. Unfortunately, the majority of the programs are protected for security purposes,
                which means they cannot be provide for download and only screenshots may be shown.
                If you desire a demo, please use the <a href="Contact.aspx">contact </a>form to
                setup some sort of demonstration. Thanks for your interest!
            </td>
            <td align="center" valign="middle">
                Click an image to enlarge it
            </td>
        </tr>
        <tr>
            <td valign="middle" align="center" style="color: #316ac5; background-color: #d3d3d3"
                colspan="2">
                <strong><a name="IPTDIM"></a>IPTDIM - Interface to the Pressure Tube Deuterium Ingress
                    Model</strong></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                In the course of developing IPTDIM a lot of neat stuff was created, here are some
                highlights:<br />
                <span style="font-size: 10pt">auto-filtering DB query control; eye-catching false color
                    charts; reusable utility libraries; compiled Fortran models as DLLs; integrated
                    Excel automation; 1000% improved render speeds over previous versions using data
                    caching and color tables; cubic spline data interpolation; extensive use of the
                    windows API and GDI; .NET-style dynamic window resizing implemented in VB6; OpenGL/DirectX
                    rendering prototype; robust error handling and call stack in VB6; </span>
            </td>
        </tr>
        <tr>
            <td align="center">
                This image shows the application's main window where various data sets can be visualized.
                All the data can be exported, and the core map can be saved as a graphic for inclusion
                in reports.</td>
            <td valign="middle" style="width: 28px" align="center">
                <a href="javascript:popImage('images/portfolio/iptdim/coremap.jpg','IPTDIM Main Window - Reactor Core Map')">
                    <img border="0" src="images/portfolio/iptdim/CoreMap_small.jpg" /></a></td>
        </tr>
        <tr>
            <td valign="middle" align="center">
                After clicking a tube a detail window is displayed with a graph showing data profiles
                along the depth of the reactor and evolution over time. These graphs may also be
                saved as images.</td>
            <td valign="middle" align="center">
                <a href="javascript:popImage('images/portfolio/iptdim/chart.jpg','IPTDIM Details Window - Shows details about a particular tube or a profile')">
                    <img border="0" src="images/portfolio/iptdim/Chart_small.jpg" /></a></td>
        </tr>
        <tr>
            <td valign="middle" align="center">
                The second tab of the detail window displays circumferential data as well as a false-color
                profile along the length of the pressure tube.</td>
            <td valign="middle" align="center">
                <a href="javascript:popImage('images/portfolio/iptdim/circumf.jpg','IPTDIM Details Circumferential Profile')">
                    <img border="0" src="images/portfolio/iptdim/Circumf_small.jpg" /></a></td>
        </tr>
        <tr>
            <td align="center" colspan="2" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; color: #316ac5; background-color: #d3d3d3;" valign="middle"
                align="center" colspan="2">
                <strong><a name="DS"></a>Detector Selector</strong></td>
        </tr>
        <tr>
            <td align="center">
                The application's main window (top-left) controls the front, top, and side view
                sub-windows. In this case we are viewing flux detector data.
            </td>
            <td valign="middle" style="vertical-align: middle; height: 36px;" align="center">
                <a href="javascript:popImage('images/portfolio/ds/detectors.jpg','Detector Selector - Detector Search')">
                    <img border="0" src="images/portfolio/ds/detectors_small.jpg" /></a></td>
        </tr>
        <tr>
            <td align="center">
                Here is the application showing reactor component data such as pressure tubes, LI
                nozzles, and flux detector assemblies.
            </td>
            <td valign="middle" style="vertical-align: middle;" align="center">
                <a href="javascript:popImage('images/portfolio/ds/components.jpg','Detector Selector - Component Search')">
                    <img border="0" src="images/portfolio/ds/components_small.jpg" /></a></td>
        </tr>
    </table>
</asp:Content>
