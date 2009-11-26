<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Change Client Phone Number
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Change Client Phone Number (<%=Model.ClientName %>)</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <%=Html.HiddenFor(model => model.Id) %>
            <p>
                <%= Html.LabelFor(model => model.PhoneNumber) %>
                <%= Html.TextBoxFor(model => model.PhoneNumber) %>
                <%= Html.ValidationMessageFor(model => model.PhoneNumber) %>
            </p>
            <p>
                <input type="submit" value="Change Phone Number" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Cancel", MVC.Client.Details(Model.Id)) %>
    </div>

</asp:Content>

