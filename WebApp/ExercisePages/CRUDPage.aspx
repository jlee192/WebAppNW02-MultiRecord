<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="WebApp.ExercisePages.CRUDPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>CRUD Page</h1>
    <asp:Label ID="MessageLabel" runat="server"></asp:Label><br />
    <asp:Button ID="Back" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />

    <%--<div class="row">
        <div class="col-md-12 alert alert-info">
            This demo will show basic web form construction, validation, data collection and display.
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-12 text-left">

            <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server"
                ErrorMessage="First name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="FirstName"> </asp:RequiredFieldValidator>

            <asp:RequiredFieldValidator ID="RequiredLastName" runat="server"
                ErrorMessage="Last name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="LastName"> </asp:RequiredFieldValidator>

            <%--<asp:CompareValidator ID="CompareUnitPrice" runat="server"
                ErrorMessage="Unit Price must be 0.00 or greater" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="UnitPrice" Operator="GreaterThanEqual" ValueToCompare="0.00" Type="Double"> </asp:CompareValidator>--%>

            <asp:RangeValidator ID="RequiredAge" runat="server"
                ErrorMessage="Age must be between 6 - 14" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Age" MaximumValue="14" MinimumValue="6" Type="Integer"> </asp:RangeValidator>

            <asp:RequiredFieldValidator ID="RequiredAlbertaHealthCareNumber" runat="server"
                ErrorMessage="10 digits; first digit must start with 1 - 9" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="AlbertaHealthCareNumber"> </asp:RequiredFieldValidator>

<%--            <asp:RangeValidator ID="RangeUnitsOnOrder" runat="server"
                ErrorMessage="Units on order must be between 0 and 32767" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="UnitsOnOrder" MaximumValue="32767" MinimumValue="0" Type="Integer"> </asp:RangeValidator>

            <asp:RangeValidator ID="RangeReorderLevel" runat="server"
                ErrorMessage="Reorder levlel must be between 0 and 32767" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="ReorderLevel" MaximumValue="32767" MinimumValue="0" Type="Integer"> </asp:RangeValidator>--%>

            <%-- validation summary control--%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Address the following concerns with your entered data." />

        </div>
    </div>

    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label1" runat="server" Text="Player ID"
                AssociatedControlID="PlayerID">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="PlayerID" runat="server">
            </asp:TextBox>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label2" runat="server" Text="FirstName"
                AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label3" runat="server" Text="LastName"
                AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label4" runat="server" Text="Age"
                AssociatedControlID="Age"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="Age" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label5" runat="server" Text="Alberta Health Care Number"
                AssociatedControlID="AlbertaHealthCareNumber"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="AlbertaHealthCareNumber" runat="server"></asp:TextBox>
        </div>
    </div>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label4" runat="server" Text="Supplier"
                AssociatedControlID="SupplierList">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="SupplierList" runat="server" Width="350px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label5" runat="server" Text="Category"
                AssociatedControlID="CategoryList">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="CategoryList" runat="server" Width="350px">
            </asp:DropDownList>
        </div>
    </div>--%>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label3" runat="server" Text="Quantity/Unit"
                AssociatedControlID="QuantityPerUnit"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="QuantityPerUnit" runat="server"></asp:TextBox>
        </div>
    </div>--%>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label4" runat="server" Text="Unit Price"
                AssociatedControlID="UnitPrice">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="UnitPrice" runat="server"> 
            </asp:TextBox>
        </div>
    </div>--%>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label8" runat="server" Text="Units In Stock"
                AssociatedControlID="UnitsInStock">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="UnitsInStock" runat="server"> 
            </asp:TextBox>
        </div>
    </div>--%>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label9" runat="server" Text="Units On Order"
                AssociatedControlID="UnitsOnOrder">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="UnitsOnOrder" runat="server"> 
            </asp:TextBox>
        </div>
    </div>--%>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label10" runat="server" Text="Reorder Level"
                AssociatedControlID="ReorderLevel">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="ReorderLevel" runat="server"> 
            </asp:TextBox>
        </div>
    </div>--%>
    <%--<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label11" runat="server" Text="Discontinued"
                AssociatedControlID="Discontinued">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:CheckBox ID="Discontinued" runat="server" Text="Discontinued"></asp:CheckBox>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4 text-left">
            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add" />&nbsp;&nbsp;
            <asp:Button ID="ClearButton" runat="server" OnClick="Clear_Click" Text="Clear" CausesValidation="false" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="PeopleGridView" runat="server"></asp:GridView>
        </div>
    </div>
    <%--<script src="Scripts/bootwrap-freecode.js"></script>--%>
</asp:Content>
