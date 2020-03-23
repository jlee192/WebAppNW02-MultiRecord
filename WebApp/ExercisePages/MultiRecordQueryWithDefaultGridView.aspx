<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordQueryWithDefaultGridView.aspx.cs" Inherits="WebApp.ExercisePages.MultiRecordQueryWithDefaultGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Multi Record Query with Default GridView</h1>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Select a team: "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" 
             CausesValidation="false" OnClick="Fetch_Click"/>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <asp:GridView ID="List02" runat="server"></asp:GridView>
    </div>
</asp:Content>
