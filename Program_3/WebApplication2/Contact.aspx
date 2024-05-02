<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding:3em;">

        <div style="text-align:center; padding:1em;">
          <asp:Label ID="lblsearch" runat="server" Text="Search box:"></asp:Label>
          <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
          <asp:Button CssClass="btn btn-success" ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
        </div>

        <br /> 
        <div style="text-align:left; display:flex; justify-content:center;">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
            Width="60em" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"
             OnRowCancelingEdit="GridView1_RowCanceling">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Temperature" HeaderText="Temperature" />
                <asp:BoundField DataField="CurrentDate" HeaderText="Date" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>

        <div style="text-align:center; padding:1em; font-size:1.2em;">
            <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        </div>

    </div>
    
</asp:Content>
