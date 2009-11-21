<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>


    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <%= Html.LabelFor(model => model.ClientName) %>
                <%= Html.TextBoxFor(model => model.ClientName) %>
                <%= Html.ValidationMessageFor(model => model.ClientName) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.Street) %>
                <%= Html.TextBoxFor(model => model.Street) %>
                <%= Html.ValidationMessageFor(model => model.Street) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.StreetNumber) %>
                <%= Html.TextBoxFor(model => model.StreetNumber) %>
                <%= Html.ValidationMessageFor(model => model.StreetNumber) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.PostalCode) %>
                <%= Html.TextBoxFor(model => model.PostalCode) %>
                <%= Html.ValidationMessageFor(model => model.PostalCode) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.City) %>
                <%= Html.TextBoxFor(model => model.City) %>
                <%= Html.ValidationMessageFor(model => model.City) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.PhoneNumber) %>
                <%= Html.TextBoxFor(model => model.PhoneNumber) %>
                <%= Html.ValidationMessageFor(model => model.PhoneNumber) %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

