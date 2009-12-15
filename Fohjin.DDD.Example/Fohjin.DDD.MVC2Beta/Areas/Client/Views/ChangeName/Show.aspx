<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Change Name
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Change Name</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Client.ChangeName.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Fields</legend>
        <%=Html.EditorForModel() %>
        <p>
            <input type="submit" value="Change Name" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", MVC.Client.List.Show()) %>
    </div>
</asp:Content>
