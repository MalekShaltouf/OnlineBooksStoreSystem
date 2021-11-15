<%@ Import Namespace="OnlineBooksStoreSystem.Models" %>

<%@ Page Title="Books" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/util.css" rel="stylesheet" />
    <link href="../../Content/main2.css" rel="stylesheet" />
    <link href="../../Content/Books_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="fform" visible="true">
        <div class="table-title">
            <div>
                <asp:HyperLink CssClass="btn btn-success" Font-Bold="true" runat="server" ID="AddBook" NavigateUrl="~/Pages/Admin/Books/AddBook.aspx">Add Book</asp:HyperLink>
            </div>
        </div>
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100">
                    <asp:GridView ID="GridView1" runat="server" OnRowCreated="OnRowCreated" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="BookTitle" HeaderText="Book Title" />
                            <asp:BoundField DataField="Subject" HeaderText="Subject" />
                            <asp:BoundField DataField="Author" HeaderText="Author" />
                            <asp:ImageField DataImageUrlField="CoverImagePath" HeaderText="Image" AlternateText="Book Image" ControlStyle-Width="50px" ControlStyle-Height="50px" ControlStyle-CssClass="imgstyle">
                            </asp:ImageField>
                            <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                            <asp:TemplateField HeaderText="Details">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/Books/BookDetails.aspx?id=" + Eval("BookId")%>'>Details</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edits">
                                <ItemTemplate>
                                    <asp:HyperLink ToolTip="Edit" runat="server" NavigateUrl='<%# "~/Pages/Admin/Books/EditBook.aspx?id=" + Eval("BookId") %>' ImageUrl="~/Images/Icons/icons8-edit-24.png"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Deletes">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/Admin/Books/DeleteBook.aspx?id=" + Eval("BookId")%>' ImageUrl="~/Images/Icons/icons8-delete-bin-24.png"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    <div runat="server" id="EmptyData" class="Empty-Data">
        <h3>There are no Books</h3>
        <div>
            <asp:HyperLink CssClass="btn btn-success" Font-Bold="true" runat="server" ID="HyperLink2AddBook" NavigateUrl="~/Pages/Admin/Books/AddBook.aspx">Add Book</asp:HyperLink>
        </div>
    </div>
</asp:Content>

<%--    
    this page represent  way 1 for display  Books using GridView
    note: in this way we need to bind data with GridView 
         in Page_Load Event 
--%>

