<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demosql.aspx.cs" Inherits="demosql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL DATASOURCE TEST</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- TÄMÄ ON TOTEUTUS TEHTÄVÄÄN 9b-->
            <!-- 1. Datasourcen määrittely -->
            <asp:SqlDataSource ID="srcMuuvit" ConnectionString="<%$ ConnectionStrings:Muuvit %>" SelectCommand="SELECT title,director,year FROM movies" runat="server"></asp:SqlDataSource>
            <!-- 2. Datakontrolli datan esittämistä varten -->
            <h2>SQLDEMO</h2>
            <asp:GridView ID="gvMuuvit" runat="server" DataSourceID="srcMuuvit"></asp:GridView>

            <!-- 1. XML Datasourcen määrittely -->
            <asp:XmlDataSource ID="xmlMuuvit" DataFile="~/App_Data/Movies.xml" runat="server"></asp:XmlDataSource>
            <!-- 2. Datakontrolli xml datan esittämistä varten -->
            <h2>XMLDEMO</h2>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="xmlMuuvit"></asp:GridView>

            <!-- XML:n esittäminen reapeter kontrollilla -->
            <h2>REAPEATER DEMO</h2>

            <asp:Repeater ID="Repeater1" DataSourceID="xmlMuuvit" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <td>nimi</td>
                            <td>maa</td>
                            <td>ohjaaja</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Country")  %></td>
                        <td><%# Eval("Director")  %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <h2>REAPEATER DEMO 2</h2>
            <asp:Repeater ID="Repeater2" DataSourceID="xmlMuuvit" runat="server">
                <ItemTemplate>
                    <b>
                        <%# Eval("Name") %>
                    </b>
                    <br />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
