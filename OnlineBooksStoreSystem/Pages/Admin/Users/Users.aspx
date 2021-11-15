<%@ Page Title="Users" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="OnlineBooksStoreSystem.Pages.Admin.Users.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Content/util.css" rel="stylesheet" />
    <link href="../../../Content/main2.css" rel="stylesheet" />
    <link href="../../../Content/Books_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="fform" visible="true">
        <div class="table-title">
            <div>
                <asp:HyperLink CssClass="btn btn-success" Font-Bold="true" runat="server" ID="AddUser" NavigateUrl="~/Pages/Admin/Users/AddUser.aspx">Add User</asp:HyperLink>
            </div>
        </div>
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="TypeDesc" HeaderText="UserType" />
                            <asp:TemplateField HeaderText="Details">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/Admin/Users/UserDetails.aspx?id=" + Eval("UserId")%>'>Details</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edits">
                                <ItemTemplate>
                                    <asp:HyperLink ToolTip="Edit" runat="server" NavigateUrl='<%# "~/Pages/Admin/Users/EditUser.aspx?id=" + Eval("UserId") %>' ImageUrl="~/Images/Icons/icons8-edit-24.png"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Deletes">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/Admin/Users/DeleteUser.aspx?id=" + Eval("UserId")%>' ImageUrl="~/Images/Icons/icons8-delete-bin-24.png"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    <div runat="server" id="EmptyData" class="Empty-Data">
        <h3>There are no Users</h3>
        <div>
            <asp:HyperLink CssClass="btn btn-success" Font-Bold="true" runat="server" ID="HyperLink2AddUser" NavigateUrl="~/Pages/Admin/Users/AddUser.aspx">Add User</asp:HyperLink>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
