<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>This is the home page</h1>
        <p class="lead">Welcome to my project!</p>
    </div>

   <%if (Session["LoggedIn"]== null || !(bool)Session["LoggedIn"]) {%>
    <div class="row" style="justify-content:center;">
        <div class="col-l-6" style="padding:1em;">
            <h4 style="text-align:center;">You Have not logged in!</h4>
            <br />

            <div style="padding:1em; text-align:center;">
                <asp:Button CssClass="btn btn-primary" ID="defaultbtn" Text="Login from here!" runat="server" OnClick="btnGoToLogin" />
            </div>
            
        </div>
    </div>

   <% } else { %>

    <div class="row" style="justify-content:center;">
        <div class="col-l-6" style="padding:1em;">
            <h4 style="text-align:center;">Hello, 
                <asp:Label  ID="lblUserName" runat="server"></asp:Label>
            </h4>

        </div>
    </div>

   <% } %>


</asp:Content>
