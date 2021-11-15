<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Content/util.css" rel="stylesheet" />
    <link href="../../../Content/main2.css" rel="stylesheet" />
    <link href="../../../Content/Categories_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="fform">
        <div class="table-title">
            <div>
                <h3>Categories</h3>
            </div>
            <div>
                <asp:HyperLink CssClass="btn btn-success" Font-Bold="true" runat="server" ID="AddCategory" NavigateUrl="~/Pages/Admin/Categories/AddCategory.aspx">Add Category</asp:HyperLink>
            </div>
        </div>
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Category_Id" HeaderText="CategoryId" />
                            <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                            <asp:TemplateField HeaderText="Edits">
                                <ItemTemplate>
                                    <asp:HyperLink ToolTip="Edit" runat="server" NavigateUrl='<%# "~/Pages/Admin/Categories/EditCategory.aspx?id=" + Eval("Category_Id") + "&catName=" + Eval("CategoryName") %>' ImageUrl="~/Images/Icons/icons8-edit-24.png"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Deletes">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/Admin/Categories/DeleteCategory.aspx?id=" + Eval("Category_Id")%>' ImageUrl="~/Images/Icons/icons8-delete-bin-24.png"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    <div runat="server" id="EmptyData" class="Empty-Data">
        <h3>There are no Categories</h3>
        <div>
            <asp:HyperLink CssClass="btn btn-success" Font-Bold="true" runat="server" ID="HyperLink2AddCategory" NavigateUrl="~/Pages/Admin/Categories/AddCategory.aspx">Add Category</asp:HyperLink>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
