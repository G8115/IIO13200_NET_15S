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
            <asp:XmlDataSource ID="xmlLevyt" DataFile="~/App_Data/LevykauppaX.xml" XPath='<%# xpath %>' runat="server"></asp:XmlDataSource>
            <!-- 2. Datakontrolli xml datan esittämistä varten -->
            <!-- puuttuu yhä href:llä arvon seuraavalla sivulle lähettäminen -->
            <asp:Repeater ID="Repeater1" DataSourceID="xmlLevyt" runat="server">
                <HeaderTemplate>
                        <img src='<%# "~/Images/"+ Request.QueryString["id"]+".jpg" %>' alt="Smiley face" runat="server" height="42" width="42" />
                </HeaderTemplate>
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
