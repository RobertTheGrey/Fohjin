<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Client Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Client Details</h2>
        <%=Html.DisplayForModel() %>
    <p>
        <%= Html.ActionLink("Change Name", MVC.Client.ClientChangeName(Model.Id)) %>
        |
        <%= Html.ActionLink("Change Address", MVC.Client.ClientHasMoved(Model.Id)) %>
        |
        <%= Html.ActionLink("Change Phone Number", MVC.Client.ClientChangedPhoneNumber(Model.Id)) %>
        |
        <%=Html.ActionLink("Back to List", MVC.Client.Index()) %>
    </p>
</asp:Content>
