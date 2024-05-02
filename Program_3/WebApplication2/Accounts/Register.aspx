<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication2.Accounts.Register"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br><br>
    <div style="display:flex; width:100%; justify-content:center;">
       
        <div style="padding:0.5em 2em; padding-bottom:1em; border:1px solid black; border-radius:1em; display:flex; width:25em; flex-wrap:wrap; flex-direction:column;
             align-content:center;">
            <div style="padding:1em; text-align:center; font-size:2em; border-bottom:1px solid black;">Register Here</div>

            <label for="username"> Username: </label>
            <input type="text" id="username" runat="server" required />
            <br />

            <label for="password"> Password: </label>
            <input type="password" id="password" runat="server" required />
            <br />

            <label for="confirmPassword">Confirm Password:</label>
            <input type="password" id="confirmPassword" runat="server" required />
            <br />

             <asp:Button CssClass="btn btn-primary" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
             <div style="text-align:center; padding:0.5em;">
                 <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
             </div>
            <br>
        </div>
 
     </div>

</asp:Content>
