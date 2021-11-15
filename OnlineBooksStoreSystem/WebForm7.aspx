<%@ Page Title="" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/util.css" rel="stylesheet" />
    <link href="../../Content/main2.css" rel="stylesheet" />
    <style>
        .imgstyle {
            margin: 10px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
            <div class="container-table100">
                <div class="wrap-table100">
                    <div class="table100">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BookId,Category_Id" DataSourceID="SqlDataSource2" >
                            <Columns >
                                <asp:BoundField DataField="BookTitle" HeaderText="Book Title" SortExpression="BookTitle" />
                                <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
                                <asp:ImageField HeaderText="Image" DataImageUrlField="CoverImagePath" AlternateText="Book Image" ControlStyle-Width="50px" ControlStyle-Height="50px"  ControlStyle-CssClass="imgstyle"></asp:ImageField>
                                <asp:HyperLinkField NavigateUrl="~/Pages/Books/BookDetails.aspx?id=1" HeaderText="Details" Text="Details"/>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:conStr %>" SelectCommand="SELECT * FROM [Books] inner join categories on Books.CategoryId = categories.Category_Id"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </form>
</asp:Content>
<%--    
    this page represent way 2 for display  Books using GridView
    note: in this way we bind the data with GridView using SqlDataSource so
         we not need to write any code in Page_Load() Event
--%>