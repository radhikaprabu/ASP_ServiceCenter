<%@ Page Title="Report" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="R_Rao_Asp_Proj1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="StyleSheets/StyleSheet1.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <p class="title">
            <asp:Label ID="lblTitle" runat="server" Text="Report Selection Form" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </p>
        <br />
        <br />
        <br />
        <asp:Button ID="btnInfo" runat="server" Text="Return to Report Selection Form" OnClick="btnInfo_Click" />
        <asp:GridView ID="gvReport" runat="server" 
            style="z-index: 1; left: 296px; top: 492px; position: absolute; height: 150px; width: 750px" 
             AutoGenerateColumns="True">
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" Text="(error)"></asp:Label>

    </div>
</asp:Content>
