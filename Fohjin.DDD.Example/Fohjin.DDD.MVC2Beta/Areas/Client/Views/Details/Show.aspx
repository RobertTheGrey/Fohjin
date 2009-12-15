<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Client Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Client Details</h2>
        <%=Html.DisplayForModel() %>
    <p>
        <%= Html.ActionLink("Change Name", MVC.Client.ChangeName.Show(Model.Id)) %>
        |
        <%= Html.ActionLink("Change Address", MVC.Client.ChangeAddress.Show(Model.Id)) %>
        |
        <%= Html.ActionLink("Change Phone Number", MVC.Client.ChangePhoneNumber.Show(Model.Id)) %>
        |
        <%=Html.ActionLink("Back to List", MVC.Client.List.Show()) %>
    </p>
</asp:Content>
