<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="08MultiRecordDropdownToSingleRecord.aspx.cs" Inherits="WebApp.ExercisePages._08MultiRecordDropdownToSingleRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Multi Record Query Dropdown to Single Record via Page Navigation (EX09,10)</h1>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Select a player "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="ButtonFetch" runat="server" Text="Update/Discontinue/Delete" 
             CausesValidation="false" OnClick="Fetch_Click"/>
        <asp:Button ID="ButtonAdd" runat="server" Text="Add" 
             CausesValidation="false" OnClick="Add_Click"/>
        <br /><br />
        <asp:Label ID="MessageLabel1" runat="server" ></asp:Label>
    </div>
</asp:Content>
