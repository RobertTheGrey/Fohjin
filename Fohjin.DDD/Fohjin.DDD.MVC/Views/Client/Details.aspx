<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            ClientName:
            <%= Html.Encode(Model.ClientName) %>
        </p>
        <p>
            Street:
            <%= Html.Encode(Model.Street) %>
        </p>
        <p>
            StreetNumber:
            <%= Html.Encode(Model.StreetNumber) %>
        </p>
        <p>
            PostalCode:
            <%= Html.Encode(Model.PostalCode) %>
        </p>
        <p>
            City:
            <%= Html.Encode(Model.City) %>
        </p>
        <p>
            PhoneNumber:
            <%= Html.Encode(Model.PhoneNumber) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

