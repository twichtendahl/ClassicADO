<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Author List</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="AuthorList" runat="server" OnSelectedIndexChanged="AuthorList_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
    
    </div>
        <asp:GridView ID="BookGrid" runat="server" OnSelectedIndexChanged="BookGrid_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
