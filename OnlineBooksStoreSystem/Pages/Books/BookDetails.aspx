<%@ Page Title="BookDetails" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Content/BookDetails_Style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="BookDetailsForm" runat="server">
        <div class="Page-Header">
            <h1>Details</h1>
        </div>
        <div class="BD-Child">
            <div class="BD-Child-A">
                <asp:Image ID="BookImage" runat="server" AlternateText="Book Image" Width="313px" Height="500px" /><br />
                <asp:Button ID="Button1" runat="server" OnClientClick="return rstx();" Text="Button" />
            </div>
            <div class="BD-Child-B">
                <div>
                    <asp:Label runat="server" Font-Bold="true">Subject: </asp:Label>
                    <asp:Label ID="Subject" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Book Title: </asp:Label>
                    <asp:Label ID="BookTitle" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Author: </asp:Label>
                    <asp:Label ID="Author" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Publish Date: </asp:Label>
                    <asp:Label ID="PublishDate" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Publishing House: </asp:Label>
                    <asp:Label ID="PublishingHouse" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Quantity In Store: </asp:Label>
                    <asp:Label ID="QuantityInStore" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Description: </asp:Label>
                    <asp:Label ID="Description" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Price: </asp:Label>
                    <asp:Label ID="Price" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Font-Bold="true">Category Name: </asp:Label>
                    <asp:Label ID="CategoryName" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="Btn-Buy">
            <a class="btn btn-success" href="../../Pages/Books/Books.aspx">back To List</a>
            <asp:Button ID="BuyBtn" CssClass="btn btn-success" runat="server" Text="Buy" />
            <asp:Button ID="DeleteBtn" OnClientClick="return ConfirmTheDeletion()" CssClass="btn btn-danger" runat="server" Text="Delete Book" OnClick="DeleteBtn_Click" /><br />
            <br />
            <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
        </div>
        <%--<div class="DC-Child">
            <h3>Rate it</h3>
            <div>
                <input type="radio" class="RadioBtn" id="OneStar" name="Rate" value="1" runat="server" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
            </div>
            <div>
                <input type="radio" class="RadioBtn" id="Radio1" name="Rate" value="1" runat="server" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
            </div>
            <div>
                <input type="radio" class="RadioBtn" id="Radio2" name="Rate" value="1" runat="server" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
            </div>
            <div>
                <input type="radio" class="RadioBtn" id="Radio3" name="Rate" value="1" runat="server" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
            </div>
            <div>
                <input type="radio" class="RadioBtn" id="Radio4" name="Rate" value="1" runat="server" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
                <img src="../../Images/Icons/icons8-star-64.png" alt="OneStarIcon" />
            </div>
        </div>--%>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../../../Scripts/DeleteCategory_Script.js"></script>
    <script src="../../../Scripts/BookVote_Script.js"></script>
</asp:Content>
