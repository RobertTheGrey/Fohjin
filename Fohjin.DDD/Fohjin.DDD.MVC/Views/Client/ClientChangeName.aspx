<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Change Name
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Change Name</h2>


    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
                <%= Html.HiddenFor(model => model.Id) %>
            <p>
                <%= Html.LabelFor(model => model.Name) %>
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </p>
            <p>
                <input type="submit" value="Change Name" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

