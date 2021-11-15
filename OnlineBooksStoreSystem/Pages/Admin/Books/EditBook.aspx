<%@ Page Title="Edit Book" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeFile="EditBook.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Content/main.css" rel="stylesheet" />
    <link href="../../../Content/util.css" rel="stylesheet" />
    <link href="../../../Content/AddCategory_Style.css" rel="stylesheet" />
    <link href="../../../Content/AddBook_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Page-Header">
        <h1>Edit Book</h1>
    </div>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-t-85 p-b-20">
                <form runat="server" class="login100-form validate-form">
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Subject">
                        <asp:TextBox runat="server" ID="Subject" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Subject"></span>
                    </div>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter BookTitle">
                        <asp:TextBox runat="server" ID="BookTitle" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="BookTitle"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Author">
                        <asp:TextBox runat="server" ID="Author" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Author"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter BookQuantity">
                        <asp:TextBox runat="server" ID="BookQuantity" TextMode="Number" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="BookQuantity"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter PublishDate">
                        <asp:TextBox runat="server" TextMode="Date" ID="PublishDate" required CssClass="input100" ></asp:TextBox>
                        <span class="focus-input100" data-placeholder="PublishDate"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter PublishingHouse">
                        <asp:TextBox runat="server" ID="PublishingHouse" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="PublishingHouse"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter BookImage">
                        <asp:FileUpload runat="server" ID="file" CssClass="custom-file-input" />
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Description">
                        <textarea runat="server" id="Description" class="input100 textarea" cols="20" rows="3"></textarea>
                        <span class="focus-input100" data-placeholder="Description"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Price">
                        <asp:TextBox runat="server" ID="Price" TextMode="Number" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Price"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter CategoryName">
                        <asp:DropDownList runat="server" ID="CategoryNameDDList" CssClass="input100 dd">
                        </asp:DropDownList>
                    </div>
                    <div class="container-login100-form-btn">
                        <asp:Button CssClass="login100-form-btn" Font-Bold="true" Font-Names="Arial" runat="server" Text="Edit Book" OnClick="EditBook_Click" />
                    </div><br />
                    <div class="Labels">
                        <asp:HyperLink  runat="server"  CssClass="txt2" NavigateUrl="~/Pages/Books/Books.aspx">Back To List</asp:HyperLink>
                        <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
