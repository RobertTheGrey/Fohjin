<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.AccountReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Account
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create Account</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Account.Create.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Fields</legend>
        <%=Html.EditorForModel() %>
        <p>
            <input type="submit" value="Create Account" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to Client", MVC.Client.Details.Show(Model.ClientDetailsReportId)) %>
    </div>
</asp:Content>
