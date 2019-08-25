<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Articles_Website_Application.Login" Async="true" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form col-md-5">
        <h3>Login</h3>
        <div class="form-group">
            <label for="inputEmail">Email Address</label>
            <input type="email" class="form-control" id="inputEmail" runat="server" />
        </div>
        <div class="form-group">
            <label>Password</label>
            <input type="password" class="form-control" id="inputPassword" runat="server" />

        </div>
        <asp:Button ID="loginButton" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="loginButton_Click" />
    </div>
    <script>
        $(document).ready(function () {
            $('#LoginAnchor').addClass("border-bottom");
        })
    </script>
</asp:Content>
