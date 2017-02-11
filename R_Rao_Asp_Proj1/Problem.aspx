<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Problem.aspx.cs" Inherits="R_Rao_Asp_Proj1.Problem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:DropDownList ID="drpTechID" runat="server" style="z-index: 1; left: 191px; top: 519px; position: absolute">
        </asp:DropDownList>
        <asp:TextBox ID="txtProblem" runat="server" style="z-index: 1; left: 191px; top: 355px; position: absolute; height: 137px; width: 539px"></asp:TextBox>
        <asp:DropDownList ID="drpProdNo" runat="server" AutoPostBack="True" style="z-index: 1; left: 190px; top: 291px; position: absolute">
        </asp:DropDownList>
        <asp:TextBox ID="txtProblemNo" runat="server" BackColor="Window" style="z-index: 1; left: 197px; top: 238px; position: absolute; width: 90px; height: 31px;" BorderStyle="None" TabIndex="3"></asp:TextBox>
        <asp:TextBox ID="txtTicketNo" runat="server" BackColor="Window" style="z-index: 1; left: 201px; top: 180px; position: absolute; width: 84px; height: 28px;" BorderStyle="None" TabIndex="2"></asp:TextBox>
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 352px; top: 693px; position: absolute" Text="Clear" />
        <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 160px; top: 693px; position: absolute" Text="Submit" width="69px" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblerror" runat="server" Enabled="False" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 40px; top: 630px; position: absolute" Text="error"></asp:Label>
        <asp:Label ID="lblReq" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 36px; top: 586px; position: absolute" Text="* indicates required field"></asp:Label>
        <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 34px; top: 523px; position: absolute" Text="*Technician :"></asp:Label>
        <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 53px; top: 351px; position: absolute" Text="* Problem :"></asp:Label>
        <asp:Label ID="lblProductNo" runat="server" style="z-index: 1; left: 23px; top: 291px; position: absolute" Text="* Product No :"></asp:Label>
        <asp:Label ID="lblProblemNo" runat="server" style="z-index: 1; left: 36px; top: 237px; position: absolute; text-align: right" Text="Problem No :"></asp:Label>
        <asp:Label ID="lblTicketNo" runat="server" style="z-index: 1; left: 56px; top: 188px; position: absolute; text-align: right; bottom: 543px" Text="Ticket No :"></asp:Label>
        <asp:Button ID="btnInfo" runat="server" style="z-index: 1; left: 24px; top: 109px; position: absolute" Text="Return to Service" OnClick="btnInfo_Click" TabIndex="1" />
        <asp:Label ID="lblProblemEntry" runat="server" Font-Bold="False" Font-Size="XX-Large" style="z-index: 1; left: 499px; top: 15px; position: absolute" Text="Problem Entry"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" height="29px" style="z-index: 1; left: 208px; top: 181px; position: absolute; width: 105px; bottom: 554px;" BackColor="Window" BorderStyle="None"></asp:TextBox>

    </div>
        
    </form>
</body>
</html>
