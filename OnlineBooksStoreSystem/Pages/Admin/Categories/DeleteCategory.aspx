<%@ Page Title="Delete Category" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeFile="DeleteCategory.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Content/DeleteCategory_Style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="DC-Child">
            <div>
                <asp:Label runat="server" CssClass="Col-Name">CategoryName: </asp:Label>
                <asp:Label runat="server" CssClass="Col-Value" ID="CategoryName"></asp:Label>
            </div>
            <div>
                <asp:Button runat="server" ID="DeleteBtn" OnClientClick="return ConfirmTheDeletion()" CssClass="btn-danger Delete-Btn" Text="Delete" OnClick="DeleteBtn_Click" /><br />
                <asp:HyperLink runat="server"  CssClass="txt2" NavigateUrl="~/Pages/Admin/Categories/Categories.aspx">Back To List</asp:HyperLink><br />
                <asp:Label ID="Status" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../../../scripts/DeleteCategory_Script.js"></script>
</asp:Content>
