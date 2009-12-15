<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Change Address
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Change Address (<%=Model.ClientName %>)</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Client.ChangeAddress.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Fields</legend>
        <%=Html.HiddenFor(model => model.Id) %>
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
            <input type="submit" value="Change Address" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Cancel", MVC.Client.Details.Show(Model.Id)) %>
    </div>
</asp:Content>
