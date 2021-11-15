<%@ Page Title="Login" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/main.css" rel="stylesheet" />
    <link href="../../Content/util.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-t-85 p-b-20">
                <form runat="server" class="login100-form validate-form">
                    <span class="login100-form-title p-b-70">Welcome
                    </span>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter username">
                        <asp:TextBox runat="server" ID="UserName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Username"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-b-50" data-validate="Enter password">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Password"></span>
                    </div>
                    <div class="container-login100-form-btn">
                        <asp:Button CssClass="login100-form-btn" runat="server" Text="Login" OnClick="Login_Click" />
                    </div>
                    <ul class="login-more p-t-190">
                        <li>
                            <span class="txt1">Don’t have an account?
                            </span>
                            <asp:HyperLink ID="SignUp" runat="server" CssClass="txt2" NavigateUrl="~/Pages/Login/SignUp.aspx">Sign Up</asp:HyperLink>
                        </li>
                    </ul>
                    <br />
                    <div class="Labels">
                        <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
