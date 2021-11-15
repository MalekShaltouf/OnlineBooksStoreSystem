<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/main.css" rel="stylesheet" />
    <link href="../../Content/util.css" rel="stylesheet" />
    <link href="../../Content/SignUp_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-t-85 p-b-20">
                <form runat="server" class="login100-form validate-form">
                    <span class="login100-form-title p-b-70">Welcome</span>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter First Name">
                        <asp:TextBox runat="server" ID="FirstName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="First Name"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Last Name">
                        <asp:TextBox runat="server" ID="LastName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Last Name"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter username">
                        <asp:TextBox runat="server" ID="UserName" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Username"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-b-50" data-validate="Enter password">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Password"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter BirthDate">
                        <asp:TextBox runat="server" ID="Birthdate" TextMode="Date" required CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="BirthDate"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Email">
                        <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Email"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter PhoneNumber">
                        <asp:TextBox runat="server" ID="PhoneNumber" TextMode="Number" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Phone Number"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate="Enter Gender">
                        <asp:DropDownList runat="server" ID="Gender" CssClass="input100 dd">
                            <asp:ListItem Value="0">--Select Gender</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="container-login100-form-btn">
                        <asp:Button value="Sign Up" runat="server" CssClass="login100-form-btn" Text="Sign Up" OnClick="SignUp_Click" />
                    </div>
                    <ul class="login-more p-t-190">
                        <li>
                            <span class="txt1">Don’t have an account?
                            </span>
                            <asp:HyperLink ID="SignUp" runat="server" CssClass="txt2" NavigateUrl="~/Pages/Login/SignUp.aspx">Sign Up</asp:HyperLink>
                        </li>
                    </ul><br />
                    <div class="Labels">
                        <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%
        Response.Write("ViewState is " + ViewState["x"]);
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../../scripts/SignUp_Script.js"></script>
</asp:Content>
