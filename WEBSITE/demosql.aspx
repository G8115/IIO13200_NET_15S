<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demosql.aspx.cs" Inherits="demosql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL DATASOURCE TEST</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
        </div>
    </form>
</body>
</html>
