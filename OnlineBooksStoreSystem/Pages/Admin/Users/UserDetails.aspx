<%@ Page Title="UserDetails" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="OnlineBooksStoreSystem.Pages.Admin.Users.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Content/UserDetails_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="Container-Label">
            <div>
                <asp:Label runat="server" CssClass="Col-Name">FirstName: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="FirstName"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">LastName: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="LastName"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">UserName: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="UserName"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">Password: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="Password"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">Email: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="Email"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">PhoneNumber: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="PhoneNumber"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">BirthDate: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="BirthDate"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">Gender: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="Gender"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" CssClass="Col-Name">UserType: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="UserType"></asp:Label>
            </div>
            <div>
                <asp:HyperLink ID="BackToListLink" runat="server" CssClass="btn btn-success" NavigateUrl="~/Pages/Admin/Users/Users.aspx">Back To List</asp:HyperLink>
                <asp:HyperLink ID="EditUserLink" runat="server" CssClass="btn btn-success" NavigateUrl="~/Pages/Admin/Users/EditUser.aspx">Update</asp:HyperLink>
                <asp:Button ID="DelBtn" Visible="false" CssClass="btn btn-danger" runat="server" Text="Delete User" OnClientClick="return ConfirmTheDeletion()" OnClick="DeleteBtn_Click"/><br /><br />
                <asp:Label ID="Status" ForeColor="Red" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../../../Scripts/DeleteCategory_Script.js"></script>
</asp:Content>
