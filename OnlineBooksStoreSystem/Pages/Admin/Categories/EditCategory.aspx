<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Content/main.css" rel="stylesheet" />
    <link href="../../../Content/util.css" rel="stylesheet" />
    <link href="../../../Content/AddCategory_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Page-Header">
        <h1>Edit Category</h1>
    </div>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-t-85 p-b-20">
                <form runat="server" class="login100-form validate-form">
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter CategoryName">
                        <asp:TextBox runat="server" ID="CategoryName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Category Name"></span>
                    </div>
                    <div class="container-login100-form-btn">
                        <asp:Button CssClass="login100-form-btn" Font-Bold="true" Font-Names="Arial" runat="server" Text="Edit Category" OnClick="AddCategory_Click" />
                    </div><br />
                    <div class="Labels">
                        <asp:HyperLink  runat="server"  CssClass="txt2" NavigateUrl="~/Pages/Admin/Categories/Categories.aspx">Back To List</asp:HyperLink>
                        <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
