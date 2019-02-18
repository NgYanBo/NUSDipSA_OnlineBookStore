<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browsing.aspx.cs" Inherits="Team10BookShop.Browsing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 214px">
            <br />
            <asp:DropDownList ID="DetailsDL" runat="server">
                <asp:ListItem>Author</asp:ListItem>
                <asp:ListItem>Title</asp:ListItem>
                <asp:ListItem>ISBN</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="CategoryDL" runat="server" OnTextChanged="CategoryDL_TextChanged" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="CategoryDL_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyBooks %>" SelectCommand="SELECT [Name] FROM [Category]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="SearchTxt" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" Text="Search" />
            <%--<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />--%>
            <br />
            <br />
            <asp:Button ID="AllBooksBtn" runat="server" OnClick="AllBooksBtn_Click" Text="All Books" />
            <asp:Panel ID="Panel1" runat="server" Height="481px" Style="padding-top:30px">
                <asp:DataList ID="DataList1" runat="server" DataKeyField="BookID" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" BorderColor="Aqua" BorderWidth="0px" CellPadding="10" CellSpacing="10" GridLines="Both">
                  <ItemTemplate>
                        <image height="120" src="../Images/<%# Eval("ISBN") %>.jpg" width="90" />
                        <br />
                        BookID:
                        <asp:Label ID="BookIDLabel" runat="server" Text='<%# Eval("BookID") %>' />
                        <br />
                        Title:
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                        <br />
                        CategoryID:
                        <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Eval("CategoryID") %>' />
                        <br />
                        ISBN:
                        <asp:Label ID="ISBNLabel" runat="server" Text='<%# Eval("ISBN") %>' />
                        <br />
                        Author:
                        <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                        <br />
                        Stock:
                        <asp:Label ID="StockLabel" runat="server" Text='<%# Eval("Stock") %>' />
                        <br />
                        Price:
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                        <br />
                      <asp:Button ID="DetailButton" runat="server" Text="View Detail"  CommandName="Details" />
                        <br />
                    </ItemTemplate>
                    <SelectedItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                </asp:DataList>
            </asp:Panel>
            <br />
        </div>
</asp:Content>
