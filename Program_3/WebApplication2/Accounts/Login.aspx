<%@ Page Language="C#"   MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Accounts.Login"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


      <br/> <br/>
      <div style="text-align:center; display:flex; flex-direction: row; justify-content:center;" >
            
         <div style="padding:2em; display:flex; border:1px solid black; width: 22em; justify-content:center;  text-align:left; flex-direction: column;
                     border-radius:2em;" >
            <div style="padding:1em; text-align:center; font-size:2em; border-bottom:1px solid black;">Login</div> <br />

            <label for="username"> Username: </label>
            <input type="text" id="username" runat="server" required />
            <br />

            <label for="password"> Password: </label>
            <input type="password" id="password" runat="server" required />
            <br />

             <asp:Button CssClass="btn btn-success" ID="btnlogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

             <div style="padding:1em; text-align:center;">
                 <asp:label ID="ErrorMessagelabel" style="text-align:center;" runat="server" Text="Your Message will Come here.." ForeColor="red"></asp:label>
             </div>
          
         </div>

      </div>



</asp:Content>
