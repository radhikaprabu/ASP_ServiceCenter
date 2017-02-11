<%@ Page Title="ReportSelection" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportSelection.aspx.cs" Inherits="R_Rao_Asp_Proj1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="StyleSheets/StyleSheet1.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contentdiv">
        <br />
        <br />
        <p class="title">
            <asp:Label ID="lblInfo" runat="server" Text="Report Selection Form" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </p>
        <br />
        <asp:Button ID="btnInfo" runat="server" Text="Return to Main Menu" Height="48px" OnClick="btnInfo_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnTechnician" runat="server" Text="Problems by Technicians" Height="48px" OnClick="btnTechnician_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnClient" runat="server" Text="Problems by Client" Height="48px" OnClick="btnClient_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnInstitution" runat="server" Text="Problems by Institution" Height="48px" OnClick="btnInstitution_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnProduct" runat="server" Text="Problems by Product" Height="48px" OnClick="btnProduct_Click" />
        <br />
        <br />
    </div>
</asp:Content>
