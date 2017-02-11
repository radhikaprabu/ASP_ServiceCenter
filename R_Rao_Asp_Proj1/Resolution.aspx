<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resolution.aspx.cs" Inherits="R_Rao_Asp_Proj1.Resolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Resolution</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:CheckBox ID="chkIntNoCharge" runat="server" OnCheckedChanged="chkIntNoCharge_CheckedChanged" style="z-index: 1; left: 426px; top: 547px; position: absolute" Text="No Charge" />
    
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 510px; top: 681px; position: absolute" Text="Clear" OnClick="btnClear_Click" />
        <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 257px; top: 681px; position: absolute" Text="Submit" OnClick="btnSubmit_Click" />
    
        <asp:TextBox ID="txtDtOnsite" runat="server" style="z-index: 1; left: 850px; top: 540px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtMisc" runat="server" style="z-index: 1; left: 539px; top: 494px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtMileage" runat="server" style="z-index: 1; left: 542px; top: 435px; position: absolute; width: 101px; right: 539px;"></asp:TextBox>
        <asp:Label ID="lblDateOnsite" runat="server" style="z-index: 1; left: 693px; top: 544px; position: absolute; right: 347px;" Text="Date Onsite :"></asp:Label>
        <asp:Label ID="lblMisc" runat="server" style="z-index: 1; left: 428px; top: 496px; position: absolute" Text="Misc"></asp:Label>
        <asp:Label ID="lblCostMiles" runat="server" style="z-index: 1; left: 704px; top: 437px; position: absolute" Text="Cost Miles :"></asp:Label>
        <asp:Label ID="lblMileage" runat="server" style="z-index: 1; left: 428px; top: 437px; position: absolute" Text="Mileage :"></asp:Label>
        <asp:TextBox ID="txtDtFixed" runat="server" style="z-index: 1; left: 181px; top: 542px; position: absolute; width: 126px; right: 829px;"></asp:TextBox>
        <asp:TextBox ID="txtSupplies" runat="server" style="z-index: 1; left: 181px; top: 494px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtHours" runat="server" style="z-index: 1; left: 181px; top: 435px; position: absolute; width: 91px"></asp:TextBox>
        <asp:DropDownList ID="drpTechnician" runat="server" style="z-index: 1; left: 181px; top: 398px; position: absolute">
        </asp:DropDownList>
        <asp:TextBox ID="txtResol" runat="server" style="z-index: 1; left: 181px; top: 258px; position: absolute; height: 124px; width: 711px"></asp:TextBox>
        <asp:TextBox ID="txtResolNo" runat="server" style="z-index: 1; left: 181px; top: 205px; position: absolute; width: 41px" BackColor="Window" BorderStyle="None"></asp:TextBox>
        <asp:TextBox ID="txtProblemNo" runat="server" style="z-index: 1; left: 181px; top: 154px; position: absolute; width: 41px" BackColor="Window" BorderStyle="None"></asp:TextBox>
        <asp:TextBox ID="txtTicketNo" runat="server" style="z-index: 1; left: 181px; top: 111px; position: absolute; width: 41px" BackColor="Window" BorderStyle="None"></asp:TextBox>
    
        <asp:Label ID="lblSupplies" runat="server" style="z-index: 1; left: 66px; top: 496px; position: absolute" Text="Supplies :"></asp:Label>
        <asp:Label ID="lblResol" runat="server" style="z-index: 1; left: 39px; top: 251px; position: absolute" Text="* Resolution"></asp:Label>
        <asp:Label ID="lblResolNo" runat="server" style="z-index: 1; left: 11px; top: 204px; position: absolute" Text="Resolution No :"></asp:Label>
        <asp:Label ID="lblProblemNo" runat="server" style="z-index: 1; left: 32px; top: 157px; position: absolute" Text="Problem No :"></asp:Label>
        <asp:Button ID="btnInfo" runat="server" style="z-index: 1; left: 46px; top: 62px; position: absolute" Text="Return to Open Problems" OnClick="btnInfo_Click" />
        <asp:Label ID="lblResolEntry" runat="server" Font-Size="XX-Large" style="z-index: 1; left: 400px; top: 12px; position: absolute" Text="Resolution Entry"></asp:Label>
        <asp:Label ID="lblTicketNo" runat="server" style="z-index: 1; left: 52px; top: 115px; position: absolute" Text="Ticket No :"></asp:Label>
        <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 24px; top: 400px; position: absolute" Text="* Technician :"></asp:Label>
        <asp:Label ID="lblHrs" runat="server" style="z-index: 1; left: 72px; top: 437px; position: absolute" Text="* Hours :"></asp:Label>
        <asp:Label ID="lblDateFix" runat="server" style="z-index: 1; left: 46px; top: 544px; position: absolute" Text="Date Fixed :"></asp:Label>
        <asp:Label ID="lblInfo" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 29px; top: 595px; position: absolute" Text="* indicates required information"></asp:Label>
        <asp:TextBox ID="txtCOstMil" runat="server" style="z-index: 1; left: 856px; top: 436px; position: absolute; width: 73px"></asp:TextBox>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 36px; top: 630px; position: absolute" Text="error" Font-Size="Small" ForeColor="Red"></asp:Label>
    </div>
        
        
        
    </form>
</body>
</html>
