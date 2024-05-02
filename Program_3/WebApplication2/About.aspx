<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="text-align:center;">This is the Weather Data records</h3>
    <div style="padding:2em;">
        <div class="row" style="justify-content:center; text-align:center; display:flex;">
            <div class="col-lg-4">
                <div style="text-align:left; border:1px solid black; padding:1em; display:flex; justify-content:center; flex-direction:column;
                     border-radius:1em;">
                <h4 style="text-align:center;">Insert weather data</h4>
                  
                    <asp:TextBox ID="txtTemperature" runat="server" placeholder="Enter Temperature" />
                    <br />
                    <asp:TextBox ID="txtDate" runat="server" placeholder="Enter Current Date (yyyy-MM-dd)" TextMode="Date" />
                      <br />

                    <asp:DropDownList ID="txtCity" runat="server">
                        <asp:ListItem Text="New York" Value="New York" ></asp:ListItem>
                        <asp:ListItem Text="Pune" Value="Pune" ></asp:ListItem>
                        <asp:ListItem Text="BomBay" Value="BomBay" ></asp:ListItem>
                        <asp:ListItem Text="Delhi" Value="Delhi" ></asp:ListItem>
                        <asp:ListItem Text="Chennai" Value="Chennai" ></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                  

                    <div style="text-align:center;">
                        <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Send Data" OnClick="btnSubmit_Click" />
                    </div>         

                     <div style="padding:1em; text-align:center;">
                         <asp:label ID="Messagelabel" style="text-align:center;" runat="server" Text="" ForeColor="red"></asp:label>
                     </div>
          
                </div>
            </div>
        </div>
    </div>
</asp:Content>
