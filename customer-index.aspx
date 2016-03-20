<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="customer-index.aspx.cs" Inherits="WebUI.customer_index" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="BusinessLogic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tbl-customer" class="table table-condensed">
        <tr>
            <th>CustomerID</th>
            <th>Firstname</th>
            <th>Middlename</th>
            <th>Lastname</th>
            <th>Birthdate</th>
            <th>Gender</th>
            <th>DateCreated</th>
        </tr>

        <%
            Customer objCustomer = new Customer();
            objCustomer.CustomerID = null;
            objCustomer.Firstname = null;
            objCustomer.Middlename = null;
            objCustomer.Lastname = null;
            objCustomer.BirthDate = null;
            objCustomer.Gender = null;

            CustomerBL objCustomerBL = new CustomerBL();

            List<Customer> objCustomerList = new List<Customer>();
            objCustomerList = objCustomerBL.GetCustomerList(objCustomer);

            foreach (Customer drCustomer in objCustomerList)
            {%>
        <tr>
            <td>
                <button type="button" class="btn btn-xs customerID" data-toggle="modal" data-id='<%=drCustomer.CustomerID%>'><%=drCustomer.CustomerID%></button>
            </td>
            <td><%=drCustomer.Firstname%></td>
            <td><%=drCustomer.Middlename%></td>
            <td><%=drCustomer.Lastname%></td>
            <td><%=drCustomer.BirthDate%></td>
            <td><%=drCustomer.Gender%></td>
            <td><%=drCustomer.DateCreated%></td>
        </tr>
        <%}
        %>
    </table>
</asp:Content>
