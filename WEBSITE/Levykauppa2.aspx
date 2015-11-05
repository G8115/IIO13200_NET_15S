<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levykauppa2.aspx.cs" Inherits="Levykauppa2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- 1. XML Datasourcen määrittely -->
            <asp:XmlDataSource ID="xmlLevyt" DataFile="~/App_Data/LevykauppaX.xml" runat="server"></asp:XmlDataSource>
            <asp:XmlDataSource ID="xmlLevyt2" DataFile="~/App_Data/LevykauppaX.xml" runat="server"></asp:XmlDataSource>

            <!-- 2. Datakontrolli xml datan esittämistä varten -->
            <asp:Repeater ID="Repeater2" DataSourceID="xmlLevyt2" runat="server">
                <ItemTemplate>
                   <img src='<%# "~/Images/"+ Eval("ISBN")+".jpg" %>' alt="Smiley face" runat="server" height="42" width="42" /></br>
                   Artisti: <%# Eval("Artist") %></br>
                   Hinta: <%# Eval("Price") %></br>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Repeater1" DataSourceID="xmlLevyt" runat="server">
                <ItemTemplate>
                   <%#"Song number: "+Eval("num")+". Song name: "+ Eval("name") %> </br>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
