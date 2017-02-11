<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechInfo.aspx.cs" Inherits="R_Rao_Asp_Proj1.TechInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technician Information Maintaenance</title>
</head>
<body>
    <form id="frmTechInfo" runat="server">
        <div>

            <asp:Label ID="lblTechTitle" runat="server" Font-Size="XX-Large" Style="z-index: 1; left: 345px; top: 17px; position: absolute; text-align: center;" Text="Technician Information"></asp:Label>
            <asp:Label ID="lblEMail" runat="server" Style="z-index: 1; left: 80px; top: 459px; position: absolute" Text="EMail" Width="59"></asp:Label>
            <asp:Label ID="lblDept" runat="server" Style="z-index: 1; left: 80px; top: 520px; position: absolute" Text="Department"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" Style="z-index: 1; left: 80px; top: 580px; position: absolute; text-align: left; width: 101px;" Text="* Phone"></asp:Label>
            <asp:Label ID="lblHRate" runat="server" Style="z-index: 1; left: 80px; position: absolute; height: 28px; top: 639px; width: 140px;" Text="* Hourly Rate"></asp:Label>
            <asp:Button ID="btnInfo" runat="server" Style="z-index: 1; left: 80px; top: 105px; position: absolute" Text="Return to the Main Menu" OnClick="btnInfo_Click" ToolTip="Return to the Main Menu" TabIndex="1" />
            <asp:CheckBox ID="chkAddTech" runat="server" Style="z-index: 1; left: 80px; top: 169px; position: absolute" Text="Add new technician" Font-Bold="True" TabIndex="2" AutoPostBack="true" OnCheckedChanged="chkAddTech_CheckedChanged" />
            <asp:Label ID="lblTechInfo" runat="server" Style="z-index: 1; left: 80px; top: 217px; position: absolute" Text="Technician Information" Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:Label ID="lblTechID" runat="server" Style="z-index: 1; left: 80px; top: 279px; position: absolute; height: 30px; width: 162px;" Text="* Technician ID"></asp:Label>
            <asp:Label ID="lblLName" runat="server" Style="z-index: 1; left: 80px; top: 341px; position: absolute" Text="* Last Name"></asp:Label>
            
            <asp:TextBox ID="txtLName" runat="server" Style="z-index: 1; left: 272px; top: 336px; position: absolute; height: 31px;" MaxLength="100" TabIndex="4"></asp:TextBox>
            <asp:TextBox ID="txtFName" runat="server" Style="z-index: 1; left: 682px; top: 337px; position: absolute" Height="29px" Width="188px" TabIndex="5"></asp:TextBox>
            <asp:TextBox ID="txtMInit" runat="server" Style="z-index: 1; left: 272px; top: 397px; position: absolute" Height="29px" Width="188px" TabIndex="6"></asp:TextBox>
            <asp:Label ID="lblFName" runat="server" Style="z-index: 1; left: 544px; top: 341px; position: absolute" Text="* First Name"></asp:Label>
            <asp:Label ID="lblMInit" runat="server" Style="z-index: 1; left: 80px; top: 401px; position: absolute" Text="Middle Initial"></asp:Label>
            <asp:TextBox ID="txtEMail" runat="server" Style="z-index: 1; left: 272px; top: 453px; position: absolute" Height="29px" Width="188px" TabIndex="7"></asp:TextBox>
            <asp:TextBox ID="txtDept" runat="server" Style="z-index: 1; left: 272px; top: 511px; position: absolute" Height="29px" Width="188px" TabIndex="8"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" Style="z-index: 1; left: 272px; top: 569px; position: absolute" Height="29px" Width="188px" TabIndex="9"></asp:TextBox>
            <asp:TextBox ID="txtHRate" runat="server" Style="z-index: 1; left: 272px; top: 635px; position: absolute; text-align: left;" Height="29px" Width="188px" TabIndex="10"></asp:TextBox>
            <asp:Label ID="lblReqMsg" runat="server" Font-Size="Small" ForeColor="#FF3300" Style="z-index: 1; left: 87px; top: 714px; position: absolute" Text="* Indicates required field"></asp:Label>
            <asp:Button ID="btnClear" runat="server" Height="35px" Style="z-index: 1; left: 392px; top: 800px; position: absolute" Text="Clear" Width="69px" TabIndex="12" OnClick="btnClear_Click" />
            <asp:Button ID="btnUpdate" runat="server" Height="35px" Style="z-index: 1; left: 261px; top: 800px; position: absolute" Text="Update" Width="69px" TabIndex="11" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnSubmit" runat="server" Height="35px" Style="z-index: 1; left: 671px; top: 800px; position: absolute" Text="Submit" Width="69px" TabIndex="14" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" Height="35px" Style="z-index: 1; top: 800px; position: absolute; left: 531px;" Text="Delete" Width="69px" TabIndex="13" OnClick="btnCancel_Click" />
            
        </div>

        

        
        
        

        <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 98px; top: 754px; position: absolute" Text="Error"></asp:Label>

        

        
        
        

        <asp:DropDownList ID="drpTechID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpTechID_SelectedIndexChanged" style="z-index: 1; left: 272px; top: 269px; position: absolute; height: 49px; width: 191px">
        </asp:DropDownList>

        

        
        
        

    </form>
</body>
</html>
