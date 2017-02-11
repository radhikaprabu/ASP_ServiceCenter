<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Open Problems.aspx.cs" Inherits="R_Rao_Asp_Proj1.Open_Problems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Open Problems</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 123px; top: 516px; position: absolute" Text="error"></asp:Label>
        <asp:Label ID="lblOpenProb" runat="server" Font-Size="XX-Large" style="z-index: 1; left: 421px; top: 14px; position: absolute" Text="Open Problems"></asp:Label>
        <asp:Button ID="btnInfo" runat="server" style="z-index: 1; left: 26px; top: 94px; position: absolute" Text="Return to Main Menu" OnClick="btnInfo_Click" />
        <asp:GridView ID="gvProblems" runat="server" style="z-index: 1; left: 36px; top: 252px; position: absolute; height: 201px; width: 984px" OnRowCommand="gvProblems_RowCommand" OnSelectedIndexChanged="gvProblems_SelectedIndexChanged" AutoGenerateColumns="False">
        
            <Columns>
                <asp:ButtonField CommandName="Select" Text="SELECT" 
                    CausesValidation ="false"/>
                <asp:BoundField DataField="TicketID" HeaderText="TicketID" SortExpression="TicketID" />
                <asp:BoundField DataField="IncidentNo" HeaderText="IncidentNo" SortExpression="IncidentNo" />
                <asp:BoundField DataField="ProblemDesc" HeaderText="ProblemDesc" SortExpression="ProblemDesc" />
                <asp:BoundField DataField="EventDate" HeaderText="EventDate" SortExpression="EventDate" />
                <asp:BoundField DataField="Institution" HeaderText="Institution" SortExpression="Institution" />
                <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
            </Columns>
        
        </asp:GridView>
    </div>
    </form>
</body>
</html>
