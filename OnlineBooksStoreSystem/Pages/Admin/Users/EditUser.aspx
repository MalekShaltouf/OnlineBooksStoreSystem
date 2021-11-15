<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="OnlineBooksStoreSystem.Pages.Admin.Users.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Content/main.css" rel="stylesheet" />
    <link href="../../../Content/util.css" rel="stylesheet" />
    <link href="../../../Content/AddCategory_Style.css" rel="stylesheet" />
    <link href="../../../Content/AddUser_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Page-Header">
        <h1>Edit User</h1>
    </div>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-t-85 p-b-20">
                <form runat="server" class="login100-form validate-form">
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter FirstName">
                        <asp:TextBox runat="server" ID="FirstName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="First Name"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter LastName">
                        <asp:TextBox runat="server" ID="LastName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Last Name"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter UserName">
                        <asp:TextBox runat="server" ID="UserName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="UserName"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Password">
                        <asp:TextBox runat="server" TextMode="Password" ID="Password" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Password"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Email">
                        <asp:TextBox runat="server" TextMode="Email" ID="Email" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Email"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter PhoneNumber">
                        <asp:TextBox runat="server" ID="PhoneNumber" TextMode="Number" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Phone Number"></span>
                    </div>
                   <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter BirthDate">
                        <asp:TextBox runat="server" ID="BirthDate" required TextMode="Date" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="BirthDate"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Gender">
                        <asp:DropDownList CssClass="input100 dd" ID="GenderDDList" runat="server"></asp:DropDownList>
                    </div>
                    <div class="container-login100-form-btn">
                        <asp:Button CssClass="login100-form-btn" Font-Bold="true" Font-Names="Arial" runat="server" Text="Edit User" OnClick="EditUser_Click"/>
                    </div><br />
                    <div class="Labels">
                        <asp:HyperLink runat="server" CssClass="txt2" NavigateUrl="~/Pages/Admin/Users/Users.aspx">Back To List</asp:HyperLink>
                        <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
