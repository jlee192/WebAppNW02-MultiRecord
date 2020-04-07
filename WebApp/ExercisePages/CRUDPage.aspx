<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="WebApp.ExercisePages.CRUDPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Player Page</h1>
    <asp:DataList ID="Message" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <%--**************** Player ID ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="Label1" runat="server" Text="ID"
                     AssociatedControlID="ID">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="ID" runat="server" ReadOnly="true">
                </asp:TextBox>
        </div>
    </div>
    <%--**************** Player First Name ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label2" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>
    <%--**************** Player Last Name ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label5" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <%--**************** Player's Guardian ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="Label6" runat="server" Text="Guardian"
                     AssociatedControlID="GuardianList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="GuardianList" runat="server" Width="300px">
                </asp:DropDownList> 
        </div>
    </div>
    <%--**************** Player's Team ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="Label7" runat="server" Text="Team"
                     AssociatedControlID="TeamList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="TeamList" runat="server" Width="300px" >
                </asp:DropDownList> 
        </div>
    </div>
    <%--**************** Player's Age ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label3" runat="server" Text="Age"
                     AssociatedControlID="Age"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="Age" runat="server"></asp:TextBox>
        </div>
    </div>
    <%--**************** Player's Gender ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label4" runat="server" Text="Gender"
                     AssociatedControlID="Gender">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="Gender" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <%--**************** Player's Alberta Health Care Number ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label8" runat="server" Text="Alberta Health Care Number"
                     AssociatedControlID="AlbertaHealthCareNumber">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="AlbertaHealthCareNumber" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <%--**************** Player's Medical Alert Details ****************--%>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label9" runat="server" Text="Medical Alert Details"
                     AssociatedControlID="MedicalAlertDetails">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="MedicalAlertDetails" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <%--<div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label11" runat="server" Text="Discontinued"
                     AssociatedControlID="Discontinued">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:CheckBox ID="Discontinued" runat="server">
                </asp:CheckBox> 
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-6 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />&nbsp;&nbsp;
            <asp:Button ID="ClearButton" runat="server" OnClick="Clear_Click" Text="Clear" CausesValidation="false"/>&nbsp;&nbsp;
            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add"/>&nbsp;&nbsp;
            <asp:Button ID="UpdateButton" runat="server" OnClick="Update_Click" Text="Update"/>&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" OnClick="Delete_Click" Text="Delete"
              OnClientClick="return CallFunction();"/>
        </div>
    </div>
    <script type="text/javascript">
        function CallFunction() {
            return confirm("Are you sure you wish to delete this player?");
       }
   </script>
</asp:Content>
