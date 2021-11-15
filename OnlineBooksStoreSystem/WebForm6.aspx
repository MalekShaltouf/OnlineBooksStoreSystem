<%@ Import Namespace="OnlineBooksStoreSystem.Models" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Layout2.Master" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="OnlineBooksStoreSystem.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/util.css" rel="stylesheet" />
    <link href="../../Content/main2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-table100">
        <div class="wrap-table100">
            <div class="table100">
                <table>
                    <thead>
                        <tr class="table100-head">
                            <th class="column1">Book Title</th>
                            <th class="column2">Subject</th>
                            <th class="column3">Author</th>
                            <th class="column4">Image</th>
                            <th class="column5">Category</th>
                            <th class="column6">Details</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            foreach (Books book in list)
                            {
                                string row = "<tr><td>" + book.BookTitle + "</td>"
                                             + "<td>" + book.Subject + "</td>"
                                             + "<td>" + book.Author + "</td>"
                                             + "<td>" + "<img src='../../Images/BooksImage/b1.jpg'  Width='50' Height='50'/>" + "</td>"
                                             + "<td>" + book.CategoryName + "</td>"
                                             + "<td>" + "<a href = '#'>Details</a>" + "</td>"
                                             + "</tr>";
                                Response.Write(row);

                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

<%--    
    this page represent Books using normal table and
    will bind data from database to normal table
    without using gridview 
    note: there are code in behind code for this page
--%>
