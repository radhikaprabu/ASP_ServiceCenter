<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEvent.aspx.cs" Inherits="R_Rao_Asp_Proj1.ServiceEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Event Form</title>
</head>
<body>
    <form id="frmServEvent" runat="server">

        <div>
            <asp:DropDownList ID="drpClientID" runat="server" style="z-index: 1; left: 340px; top: 213px; position: absolute" OnSelectedIndexChanged="drpClientID_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 115px; top: 476px; position: absolute; right: 1011px" Text="error"></asp:Label>
            <asp:Label ID="lblServEvent" runat="server" Style="z-index: 1; left: 368px; top: 13px; position: absolute; text-align: center;" Text="Service Event Form" Font-Size="XX-Large"></asp:Label>
            <asp:Label ID="lblClientID" runat="server" Style="z-index: 1; left: 98px; top: 217px; position: absolute; " Text="* Client ID" width="127"></asp:Label>
            <asp:Label ID="lblEvtDate" runat="server" Style="z-index: 1; left: 97px; top: 158px; position: absolute" Text="* Event Date"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" Style="z-index: 1; left: 104px; top: 286px; position: absolute" Text="* Phone"></asp:Label>
            <asp:Label ID="lblContact" runat="server" Style="z-index: 1; left: 105px; top: 356px; position: absolute" Text="* Contact"></asp:Label>
            <asp:Button ID="btnClear" runat="server" Style="z-index: 1; left: 251px; top: 538px; position: absolute" TabIndex="7" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnSubmit" runat="server" Style="z-index: 1; left: 390px; top: 538px; position: absolute" TabIndex="8" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:TextBox ID="txtEvtDate" runat="server" Style="z-index: 1; left: 342px; top: 159px; position: absolute" TabIndex="4" BackColor="White" BorderStyle="None" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" Style="z-index: 1; left: 339px; top: 284px; position: absolute" TabIndex="5"></asp:TextBox>
            <asp:TextBox ID="txtContact" runat="server" Style="z-index: 1; left: 341px; top: 359px; position: absolute" TabIndex="6"></asp:TextBox>
            <asp:Button ID="btnInfo" runat="server" OnClick="btnInfo_Click" Style="z-index: 1; left: 95px; top: 86px; position: absolute" TabIndex="1" Text="Return to the Main Menu" ToolTip="Return to the Main Menu" />
            <asp:Label ID="lblReqMsg" runat="server" Font-Size="Small" ForeColor="#FF3300" style="z-index: 1; left: 104px; top: 420px; position: absolute" Text="* Indicates required field"></asp:Label>
            
        </div>

        

        

    </form>
</body>
</html>
