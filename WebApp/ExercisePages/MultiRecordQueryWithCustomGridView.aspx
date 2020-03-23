<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordQueryWithCustomGridView.aspx.cs" Inherits="WebApp.ExercisePages.MultiRecordQueryWithCustomGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1> Multi Record Query with Custom GridView</h1>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Select an Item: "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" 
             CausesValidation="false" OnClick="Fetch_Click"/>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <asp:GridView ID="List02" runat="server" 
            AutoGenerateColumns="False"
             CssClass="table table-striped" GridLines="Horizontal"
             BorderStyle="None" AllowPaging="True" OnPageIndexChanging="List02_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="List02_SelectedIndexChanged">

            <Columns>
                <%--<asp:CommandField SelectText="View" ShowSelectButton="True" 
                    ButtonType="Button" CausesValidation="false"></asp:CommandField>--%>

                <%--Player Name--%>
                <asp:TemplateField HeaderText="Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%-- this is where your reference to the data on your
                              record is placed--%>
                        <asp:Label ID="PlayerName" runat="server" 
                            Text='<%# Eval("PlayerName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Player Age--%>
                <asp:TemplateField HeaderText="Age">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%-- this is where your reference to the data on your
                              record is placed--%>
                        <asp:Label ID="Age" runat="server" 
                            Text='<%# Eval("Age") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Player Gender--%>
                <asp:TemplateField HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%-- this is where your reference to the data on your
                              record is placed--%>
                        <asp:Label ID="Gender" runat="server" 
                            Text='<%# Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Player medical details--%>
                <asp:TemplateField HeaderText="Med Alert">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%-- this is where your reference to the data on your
                              record is placed--%>
                        <asp:Label ID="MedicalAlertDetails" runat="server" 
                            Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Qty/Per">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="QuantityPerUnit" runat="server" 
                            Text='<%# Eval("QuantityPerUnit") == null ? "each" : Eval("QuantityPerUnit") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>--%>
               <%-- <asp:TemplateField HeaderText="Price ($)">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="UnitPrice" runat="server" 
                            Text='<%# string.Format("{0:0.00}",Eval("UnitPrice"))%>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="Disc">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                         <asp:CheckBox ID="Discontinued" runat="server" 
                              Checked='<%# Eval("Discontinued") %>'/>category
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataTemplate>
                No data available at this time
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>
</asp:Content>
