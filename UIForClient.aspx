<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIForClient.aspx.cs" Inherits="Connections.UIForClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/SetStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="Data"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="U31DUOM.TXT"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="U32DUOM.TXT"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Results"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="U3REZ.TXT"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
        </div>
    </form>
</body>
</html>
