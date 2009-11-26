<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Fohjin.DDD.Reporting.Dto.ClientReport>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Client List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Client List</h2>
    <table>
        <tr>
            <th>
                Name
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.ActionLink("More Details", MVC.Client.Details(item.Id))%>
                |
                <%= Html.ActionLink("Change Name", MVC.Client.ClientChangeName(item.Id)) %>
                |
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Add a new Client", MVC.Client.Create()) %>
    </p>
</asp:Content>
