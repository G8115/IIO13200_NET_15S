<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levykauppa.aspx.cs" Inherits="Levykauppa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- 1. XML Datasourcen määrittely -->
            <asp:XmlDataSource ID="xmlLevyt" DataFile="~/App_Data/LevykauppaX.xml" XPath="Records/genre[@name='Pop']/record" runat="server"></asp:XmlDataSource>
            <!-- 2. Datakontrolli xml datan esittämistä varten -->
            <!-- puuttuu yhä href:llä arvon seuraavalla sivulle lähettäminen -->
            <asp:Repeater ID="Repeater1" DataSourceID="xmlLevyt" runat="server">
                <ItemTemplate>

                    <table>
                        <img src='<%# "~/Images/"+ Eval("ISBN")+".jpg" %>' alt="Smiley face" runat="server" height="42" width="42" />

                        <tr>
                            <td>
                                <asp:HyperLink
                                    ID='link1'
                                    runat="server"
                                    Text='<%# Eval("ISBN") %>'
                                    NavigateUrl='<%# "./Levykauppa2.aspx?id="+ Eval("ISBN") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td><%# Eval("Artist") %></td>
                        </tr>
                        <tr>
                            <td><%# Eval("Price") %></td>
                        </tr>

                    </table>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
