<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.AccountReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Change Name
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Change Name</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Account.ChangeName.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Account Name</legend>
        <%=Html.EditorForModel() %>
        <p>
            <input type="submit" value="Change Name" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Cancel", MVC.Account.Details.Show(Model.Id)) %>
    </div>
</asp:Content>