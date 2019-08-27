<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisteredUser.aspx.cs" Inherits="Articles_Website_Application.RegisteredUser" EnableEventValidation="false" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div >
        <asp:GridView ID="GV1" runat="server" CssClass="table table-hover table-striped">
            <HeaderStyle Width="100px" />
        </asp:GridView>
    </div>

    <style>
        table {
            border: hidden;
        }
    </style>
</asp:Content>


