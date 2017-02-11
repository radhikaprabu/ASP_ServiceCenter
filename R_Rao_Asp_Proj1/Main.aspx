<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="R_Rao_Asp_Proj1.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Selection Form</title>
</head>
<body>
    <form id="frmMain" runat="server">
             
    <div>
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="XX-Large" style="z-index: 1; left: 344px; top: 34px; position: absolute; width: 432px" Text="Main Selection Form"></asp:Label>
        <asp:Button ID="btnService" runat="server" style="z-index: 1; left: 383px; top: 147px; position: absolute; width: 354px;" Text="Service Event" Font-Size="Large" height="48px" OnClick="btnService_Click" />
        <asp:Button ID="btnProblem" runat="server" Font-Size="Large" height="48px" style="z-index: 1; left: 383px; top: 271px; position: absolute" Text="Problem Resolution" width="354px" OnClick="btnProblem_Click" />
        <asp:Button ID="btnReports" runat="server" Font-Size="Large" height="48px" style="z-index: 1; left: 383px; top: 392px; position: absolute; width: 354px" Text="Reports" OnClick="btnReports_Click" />
        <asp:Button ID="btnManageTechs" runat="server" Font-Size="Large" height="48px" style="z-index: 1; left: 383px; top: 512px; position: absolute; width: 354px" Text="Manage Technicians" OnClick="btnManageTechs_Click" />
    </div>
        
    </form>
</body>
</html>
