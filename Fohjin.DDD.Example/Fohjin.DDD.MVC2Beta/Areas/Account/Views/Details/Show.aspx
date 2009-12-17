<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.AccountDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Account Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Account Details</h2>
        <%=Html.DisplayForModel() %>
    <p>
        <%= Html.ActionLink("Change Name", MVC.Client.ChangeName.Show(Model.Id)) %>
        |
        <%=Html.ActionLink("Back to Client Details", MVC.Client.Details.Show(Model.ClientReportId))%>
    </p>
</asp:Content>
