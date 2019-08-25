<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Articles_Website_Application.SignUp" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form col-md-5">
        <h3>Sign Up</h3>
        <div class="form-group">
            <label>Email:</label>
            <input id="emailInput" runat="server" type="email" class="form-control" />
        </div>

        <div class="form-group">
            <label>Password</label>
            <input id="passwordInput" runat="server" type="password" class="form-control" />
        </div>

        <div class="form-group">
            <label>First Name</label>
            <input id="firstNameInput" runat="server" type="text" class="form-control" />
        </div>

        <div class="form-group">
            <label>Last Name</label>
            <input id="lastNameInput" runat="server" type="text" class="form-control" />
        </div>

        <asp:Button ID="signUpButton" runat="server" CssClass="btn btn-primary" Text="Sign Up" OnClick="signUpButton_Click" />
    </div>
    <script>
        $(document).ready(function () {
            $('#SignUpAnchor').addClass("border-bottom");
        })
    </script>


</asp:Content>
