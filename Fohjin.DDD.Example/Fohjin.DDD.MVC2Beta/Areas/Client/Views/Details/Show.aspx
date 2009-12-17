<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Client Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Client Details</h2>
        <div id="client-details">
    <%=Html.DisplayForModel() %>
    </div>
        <div id="client-accounts">
    <table>
        <tr>
            <th>
                Accounts
            </th>
        </tr>
        <%foreach (var account in Model.Accounts) {%>
        <tr>
            <td>
                <%=Html.ActionLink(account.AccountNumber, MVC.Account.Details.Show(account.Id) )%> - <%= account.AccountName %>
            </td>
        </tr>
        <%} %>
    </table>
    </div>
        <div id="client-closed-accounts">
    <table>
        <tr>
            <th>
                Closed Accounts
            </th>
        </tr>
        <%foreach (var closedAccount in Model.ClosedAccounts) {%>
        <tr>
            <td>
                <%= closedAccount.AccountNumber %> - <%= closedAccount.AccountName %>
            </td>
        </tr>
        <%} %>
    </table>
    </div>
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
