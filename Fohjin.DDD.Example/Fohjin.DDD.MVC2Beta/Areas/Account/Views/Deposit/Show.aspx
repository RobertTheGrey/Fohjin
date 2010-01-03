<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.MVC2Beta.Areas.Account.Models.AccountActivityViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Make a Deposit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Make a Deposit</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Account.Deposit.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Amount</legend>
        <%=Html.EditorForModel() %>
        <p>
            <input type="submit" value="Deposit" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Cancel", MVC.Account.Details.Show(Model.AccountId)) %>
    </div>
</asp:Content>